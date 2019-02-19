using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging.Core;
using NuGet.Versioning;

namespace YAMLParser
{
    public static class RosMessageBasePackageExtensions
    {
        private const string MESSAGE_BASE_PACKAGE_ID = "Uml.Robotics.Ros.MessageBase";
        private const string MESSAGE_BASE_PACKAGE_VERSION = "1.0.3";

        public static PackageIdentity MessageBasePackage { get; } = new PackageIdentity(MESSAGE_BASE_PACKAGE_ID, NuGetVersion.Parse(MESSAGE_BASE_PACKAGE_VERSION));

        public static bool HasRosMessageBasePackage(this IEnumerable<PackageIdentity> packages)
        {
            if (packages == null) throw new ArgumentNullException(nameof(packages));

            return packages.Any(p => p.IsRosMessageBasePackage());
        }
        
        public static IList<PackageIdentity> AddRosMessageBasePackage(this IList<PackageIdentity> packages)
        {
            if (packages == null) throw new ArgumentNullException(nameof(packages));
            
            packages.Insert(0, MessageBasePackage);
            return packages;
        }

        public static bool IsRosMessageBasePackage(this PackageIdentity package)
        {
            if (package == null) throw new ArgumentNullException(nameof(package));
            
            return string.Equals(package.Id, MESSAGE_BASE_PACKAGE_ID, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}