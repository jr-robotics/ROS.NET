using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace YAMLParser
{
    public class AssemblyResolver : IDisposable
    {
        private readonly IEnumerable<Assembly> assemblies;
        private readonly AppDomain appDomain;

        public AssemblyResolver(IEnumerable<Assembly> assemblies, AppDomain appDomain)
        {
            this.assemblies = assemblies ?? throw new ArgumentNullException(nameof(assemblies));
            this.appDomain = appDomain ?? throw new ArgumentNullException(nameof(appDomain));

            this.appDomain.AssemblyResolve += OnAssemblyResolve;
        }
        
        public void Dispose()
        {
            this.appDomain.AssemblyResolve -= OnAssemblyResolve;
        }
        
        private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assembly = assemblies.FirstOrDefault(x => x.FullName == args.Name);
            return assembly;
        }
    }
}