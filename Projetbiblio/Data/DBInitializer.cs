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



            var books = new Book[]

            {

                new Book { Content ="Lorem Ipsum", Name = "Test", Price=10.2f}

            };

            bookDbContext.Books.AddRange(books);

            bookDbContext.SaveChanges();



          
        }

       
    }

}