using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Projetbiblio.Model;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Security.Claims;

using System.Threading.Tasks;



namespace Projetbiblio.Data

{

    public class DbInitializer

    {

        public static void Initialize(LibraryDbContext bookDbContext)

        {

            if (bookDbContext.Books.Any())

                return;

            var genres = new Genre[]
           {
                new Genre{Name = "genre 1", Book = new List<Book>(){ } },
                new Genre{Name = "genre 2" },
                new Genre{Name = "genre 3"}
           };

            var books = new Book[]

            {

                new Book { Content ="Lorem Ipsum", Name = "book1", Price=10.2f},
                new Book { Content ="xvx", Name = "book", Price=15.2f}
            };
            bookDbContext.Genre.AddRange(genres);
            bookDbContext.Books.AddRange(books);

            bookDbContext.SaveChanges();



          
        }

       
    }

}