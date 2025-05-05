using System.Reflection;

namespace OpenTelemetryExample.Helpers
{
    public static class ReflectionHelper
    {
        public static List<Type> GetAllImplementations<T>(Assembly assembly)
        {
            var type = typeof(T);

            return  assembly.GetTypes().Where(t => t.IsAssignableTo(type) && !t.IsAbstract && !t.IsInterface).ToList();
        }
    }
}
