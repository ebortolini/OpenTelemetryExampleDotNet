using OpenTelemetryExample.Models;

namespace OpenTelemetryExample.EndPoints
{
    public class BookEndPoint : EndPointBase
    {
        public override string GetGroup()
        {
            return "books";
        }

        public override RouteGroupBuilder MapGroup(RouteGroupBuilder builder)
        {
            builder.MapGet("/", GetAll);

            return builder;
        }

        public List<Book> GetAll() 
        { 
            return new List<Book> { new Book() { Description = "Test", Title = "Test" } };
        }
    }
}
