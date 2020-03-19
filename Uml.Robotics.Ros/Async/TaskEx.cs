using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Xamla.Robotics.Ros.Async
{
    public static class TaskEx
    {
        public static Task<T> Throw<T>(Exception exception)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.TrySetException(exception);
            return tcs.Task;
        }

        public static Task<T> Throw<T>(IEnumerable<Exception> exceptions)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.TrySetException(exceptions);
            return tcs.Task;
        }

        public static Task Throw(Exception exception)
        {
            return Throw<object>(exception);
        }

        public static Task Throw(IEnumerable<Exception> exceptions)
        {
            return Throw<object>(exceptions);
        }

        public static Task WhenCompleted(this Task task, TaskContinuationOptions continuationOptions = TaskContinuationOptions.ExecuteSynchronously)
        {
            return task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var e = t.Exception;
                }
            }, continuationOptions);
        }

        public static Task Finally(this Task task, Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.ExecuteSynchronously)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var e = t.Exception;
                }
                action();
            }, continuationOptions);
            return task;
        }

        public static Task<T> Finally<T>(this Task<T> task, Action action, TaskContinuationOptions continuationOptions = TaskContinuationOptions.ExecuteSynchronously)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var e = t.Exception;
                }
                action();
            }, continuationOptions);
            return task;
        }

        public static Task TimeoutAfter(this Task task, TimeSpan? timeout)
        {
            return timeout.HasValue ? TimeoutAfter(task, timeout.Value) : task;
        }

        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            if (task.IsCompleted)
                await task.ConfigureAwait(false);

            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token)).ConfigureAwait(false);
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    await task.ConfigureAwait(false);
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
            }
        }

        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            if (task.IsCompleted)
                await task.ConfigureAwait(false);

            using (var timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token)).ConfigureAwait(false);
                if (completedTask == task)
                {
                    timeoutCancellationTokenSource.Cancel();
                    return await task.ConfigureAwait(false);
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
            }
        }

        public static Task<T> Publish<T>(this Task<T> task, TaskCompletionSource<T> tcs, TaskContinuationOptions continuationOptions = TaskContinuationOptions.PreferFairness)
        {
            task.ContinueWith(
                (t, o) =>
                {
                    var s = (TaskCompletionSource<T>)o;
                    switch (t.Status)
                    {
                        case TaskStatus.Canceled:
                            s.TrySetCanceled();
                            break;
                        case TaskStatus.RanToCompletion:
                            s.TrySetResult(t.Result);
                            break;
                        case TaskStatus.Faulted:
                            s.TrySetException(t.Exception.InnerExceptions);
                            break;
                    }
                },
                tcs,
                continuationOptions
            );

            return tcs.Task;
        }

        public static Task Publish(this Task task, TaskCompletionSource<object> tcs, TaskContinuationOptions continuationOptions = TaskContinuationOptions.PreferFairness)
        {
            task.ContinueWith(
                (t, o) =>
                {
                    var s = (TaskCompletionSource<object>)o;
                    switch (t.Status)
                    {
                        case TaskStatus.Canceled:
                            s.TrySetCanceled();
                            break;
                        case TaskStatus.RanToCompletion:
                            s.TrySetResult(null);
                            break;
                        case TaskStatus.Faulted:
                            s.TrySetException(t.Exception.InnerExceptions);
                            break;
                    }
                },
                tcs,
                continuationOptions
            );

            return tcs.Task;
        }

        public static Task<TBase> Cast<TDerived, TBase>(this Task<TDerived> task)
            where TBase : TDerived
        {
            var tcs = new TaskCompletionSource<TBase>();
            task.ContinueWith(
                (t, o) =>
                {
                    var s = (TaskCompletionSource<TBase>)o;
                    switch (t.Status)
                    {
                        case TaskStatus.Canceled:
                            s.TrySetCanceled();
                            break;
                        case TaskStatus.RanToCompletion:
                            s.TrySetResult((TBase)t.Result);
                            break;
                        case TaskStatus.Faulted:
                            s.TrySetException(t.Exception.InnerExceptions);
                            break;
                    }
                },
                tcs
            );
            return tcs.Task;
        }

        public static Task<object> ResultAsObject<T>(this Task<T> task)
        {
            var tcs = new TaskCompletionSource<object>();
            task.ContinueWith(
                (t, o) =>
                {
                    var s = (TaskCompletionSource<object>)o;
                    switch (t.Status)
                    {
                        case TaskStatus.Canceled:
                            s.TrySetCanceled();
                            break;
                        case TaskStatus.RanToCompletion:
                            s.TrySetResult(t.Result);
                            break;
                        case TaskStatus.Faulted:
                            s.TrySetException(t.Exception.InnerExceptions);
                            break;
                    }
                },
                tcs
            );
            return tcs.Task;
        }

        /// <summary>
        /// Allows to capture the AggregateException when multiple exceptions had been raised while awaiting a task.
        /// See http://msmvps.com/blogs/jon_skeet/archive/2011/06/22/eduasync-part-11-more-sophisticated-but-lossy-exception-handling.aspx
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static Task WithAllExceptions(this Task task)
        {
            var tcs = new TaskCompletionSource<object>();

            task.ContinueWith(ignored =>
            {
                switch (task.Status)
                {
                    case TaskStatus.Canceled:
                        tcs.SetCanceled();
                        break;
                    case TaskStatus.RanToCompletion:
                        tcs.SetResult(null);
                        break;
                    case TaskStatus.Faulted:
                        // SetException will automatically wrap the original AggregateException
                        // in another one. The new wrapper will be removed in TaskAwaiter, leaving
                        // the original intact.
                        tcs.SetException(task.Exception);
                        break;
                }
            });

            return tcs.Task;
        }

        public static Task<T> WithAllExceptions<T>(this Task<T> task)
        {
            var tcs = new TaskCompletionSource<T>();

            task.ContinueWith(ignored =>
            {
                switch (task.Status)
                {
                    case TaskStatus.Canceled:
                        tcs.SetCanceled();
                        break;
                    case TaskStatus.RanToCompletion:
                        tcs.SetResult(task.Result);
                        break;
                    case TaskStatus.Faulted:
                        // SetException will automatically wrap the original AggregateException
                        // in another one. The new wrapper will be removed in TaskAwaiter, leaving
                        // the original intact.
                        tcs.SetException(task.Exception);
                        break;
                }
            });

            return tcs.Task;
        }

        public static IAsyncResult ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            if (task.AsyncState == state)
            {
                if (callback != null)
                {
                    task.ContinueWith(new Action<Task<TResult>>(callback), CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                }
                return task;
            }

            var tcs = new TaskCompletionSource<TResult>(state);

            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(task.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(task.Result);

                if (callback != null)
                    callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

            return tcs.Task;
        }

        public static IAsyncResult ToApm(this Task task, AsyncCallback callback, object state)
        {
            if (task.AsyncState == state)
            {
                if (callback != null)
                {
                    task.ContinueWith(new Action<Task>(callback), CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                }

                return task;
            }

            var tcs = new TaskCompletionSource<object>(state);

            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(null);

                if (callback != null)
                    callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

            return tcs.Task;
        }

        /// <summary>
        /// Returns a <see cref="Task"/> that is canceled when this <see cref="CancellationToken"/> is canceled.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor.</param>
        /// <returns>A <see cref="Task"/> that is canceled when this <see cref="CancellationToken"/> is canceled.</returns>
        public static Task AsTask(this CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
                return TaskConstants.Never;

            if (cancellationToken.IsCancellationRequested)
                return TaskConstants.Canceled;

            var tcs = new TaskCompletionSource<object>();
            cancellationToken.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false);
            return tcs.Task;
        }

        /// <summary>
        /// Schedules an action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task Then(this Task task, Action completed, bool continueOnCapturedContext = false)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            completed();
        }

        /// <summary>
        /// Schedules an action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T">The type of the result of the source task.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task Then<T>(this Task<T> task, Action<T> completed, bool continueOnCapturedContext = false)
        {
            completed(await task.ConfigureAwait(continueOnCapturedContext));
        }

        /// <summary>
        /// Schedules an action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T">The type of the result of the completed delegate.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task<T> Then<T>(this Task task, Func<T> completed, bool continueOnCapturedContext = false)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            return completed();
        }

        /// <summary>
        /// Schedules an action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T1">The type of the result of the source task.</typeparam>
        /// <typeparam name="T2">The type of the result of the completed delegate.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task<T2> Then<T1, T2>(this Task<T1> task, Func<T1, T2> completed, bool continueOnCapturedContext = false)
        {
            return completed(await task.ConfigureAwait(continueOnCapturedContext));
        }

        /// <summary>
        /// Schedules an asynchronous action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task Then(this Task task, Func<Task> completed, bool continueOnCapturedContext = false)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            await completed();
        }

        /// <summary>
        /// Schedules an asynchronous action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T">The type of the result of the source task.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task Then<T>(this Task<T> task, Func<T, Task> completed, bool continueOnCapturedContext = false)
        {
            await completed(await task.ConfigureAwait(continueOnCapturedContext));
        }

        /// <summary>
        /// Schedules an asynchronous action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T">The type of the result of the completed delegate.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task<T> Then<T>(this Task task, Func<Task<T>> completed, bool continueOnCapturedContext = false)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            return await completed();
        }

        /// <summary>
        /// Schedules an asynchronous action to execute when the task completes successfully. If the source task completes with an error or cancellation, that result is propagated and the completed delegate is not run.
        /// </summary>
        /// <typeparam name="T1">The type of the result of the source task.</typeparam>
        /// <typeparam name="T2">The type of the result of the completed delegate.</typeparam>
        /// <param name="task">The source task.</param>
        /// <param name="completed">The completed delegate.</param>
        public static async Task<T2> Then<T1, T2>(this Task<T1> task, Func<T1, Task<T2>> completed, bool continueOnCapturedContext = false)
        {
            return await completed(await task.ConfigureAwait(continueOnCapturedContext));
        }

        public static void Rethrow(this AggregateException exception)
        {
            exception = exception.Flatten();
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
        }

        public static bool HasCompletedSuccessfully(this Task t)
        {
            return t.Status == TaskStatus.RanToCompletion;
        }
    }
}
