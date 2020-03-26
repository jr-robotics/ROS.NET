using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Uml.Robotics.Ros
{
    public class TypeRegistryBase
    {
        public Dictionary<string, Type> TypeRegistry { get; } = new Dictionary<string, Type>();
        public List<string> PackageNames { get; } = new List<string>();
        protected ILogger Logger { get; set; }

        protected TypeRegistryBase(ILogger logger)
        {
            this.Logger = logger;
        }

        public IEnumerable<string> GetTypeNames()
        {
            return TypeRegistry.Keys;
        }

        protected T Create<T>(string rosType) where T : class, new()
        {
            T result = null;
            bool typeExist = TypeRegistry.TryGetValue(rosType, out Type type);
            if (typeExist)
            {
                result = Activator.CreateInstance(type) as T;
            }

            return result;
        }

        [Obsolete("This method has different behavior in .Net Cora and .Net Framework. It was moved to Uml.Robotics.Ros", true)]
        public static IEnumerable<Assembly> GetCandidateAssemblies(params string[] tagAssemblies)
        {
            throw new InvalidOperationException("This method is obsolete and was moved to Uml.Robotics.Ros");
        }
    }
}
