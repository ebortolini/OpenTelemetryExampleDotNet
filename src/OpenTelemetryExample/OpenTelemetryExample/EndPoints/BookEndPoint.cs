using Microsoft.AspNetCore.Http.HttpResults;
using OpenTelemetryExample.Models;

namespace OpenTelemetryExample.EndPoints
{
    public class BookEndPoint : EndPointBase
    {

        public static List<Book> _books = new List<Book>
        {
            new Book() { Id = 1, Description = "Math", Title = "Math" },
            new Book() { Id = 2, Description = "Learn C#", Title = "C#" },
        };

        public override string GetGroup()
        {
            return "books";
        }

        public override RouteGroupBuilder MapGroup(RouteGroupBuilder builder)
        {
            builder.MapGet("/", GetAll);
            builder.MapGet("/{id}", Get);
            return builder;
        }

        public IResult GetAll(ILogger<BookEndPoint> log) 
        {
            log.LogInformation("Getting all books: {bookCount}", _books.Count);
            return Results.Ok(_books);
        }

        public IResult Get(int id, ILogger<BookEndPoint> log) 
        {
            var book =  _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                log.LogWarning("Book with id: {id} not found", id);
                return Results.NotFound();
            }

            log.LogInformation("Book with {id} of title: {title} was found.", id, book.Title);

            return Results.Ok(book);
        }
    }
}
