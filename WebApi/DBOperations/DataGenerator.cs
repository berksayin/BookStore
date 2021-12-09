using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Name = "Kürk Mantolu Madonna",
                        Author = "Sabahattin Ali",
                        GenreId = 1, //Novel
                        PageCount = 160,
                        PublishDate = new DateTime(1943, 01, 01)
                    },
                    new Book
                    {
                        //Id = 2,
                        Name = "Book 2",
                        Author = "John Doe",
                        GenreId = 2, //Unnamed
                        PageCount = 200,
                        PublishDate = new DateTime(1943, 08, 21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}