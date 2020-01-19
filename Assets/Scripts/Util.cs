// Various random stuff used everywhere

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Util {
    private const double TOLERANCE = 0.001;

    public static bool EqualsFloat(this float n1, float n2) {
        return Math.Abs(n1 - n2) < TOLERANCE;
    }

    public static bool EqualsZero(this float n1) {
        return Math.Abs(n1) < TOLERANCE;
    }

    public static Type FindType(string fullName) {
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetSafeTypes())
            .FirstOrDefault(t => t.FullName != null && t.FullName.Equals(fullName));
    }

    public static Type FindType(string fullName, string assemblyName) {
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetSafeTypes()).FirstOrDefault(t =>
            t.FullName != null && t.FullName.Equals(fullName) && t.Assembly.GetName().Name.Equals(assemblyName));
    }

    public static IEnumerable<Type> GetSafeTypes(this Assembly assembly) {
        try {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e) {
            return e.Types.Where(x => x != null);
        }
        catch (Exception) {
            return new List<Type>();
        }
    }
}