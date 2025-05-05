using System.Reflection;
using OpenTelemetryExample.Helpers;

namespace OpenTelemetryExample.EndPoints
{
    public abstract class EndPointBase
    {
        public abstract string GetGroup();

        public abstract RouteGroupBuilder MapGroup(RouteGroupBuilder builder);
    }

    public static class EndPointExtensions
    {
        public static WebApplication MapEndPoints(this WebApplication app)
        {
            var endPointTypes = ReflectionHelper.GetAllImplementations<EndPointBase>(Assembly.GetExecutingAssembly());

            foreach (var endPointType in endPointTypes)
            {
                var endPoint = (EndPointBase)Activator.CreateInstance(endPointType);

                var group = app.MapGroup(endPoint.GetGroup());
                endPoint.MapGroup(group);
            }

            return app;
        }
    }
}
