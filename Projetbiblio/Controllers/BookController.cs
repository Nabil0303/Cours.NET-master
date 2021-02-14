using Projetbiblio.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetbiblio.Data;
using Projetbiblio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetbiblio.Controllers
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        //public IActionResult Index()
        //{

        //    var listeBooks = libraryDbContext.Books;
        //    ViewBag.listeBooks = listeBooks;
        //    return View();
        //}



        [HttpGet("/api/[controller]/GetInfosLivres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/api/[controller]/infoLivres/{nb}")]
        public ActionResult<List<Book>> GetInfosLivres(String genre)
        {
            //return new List<Book>() { new Book() { Name = "Test", Content = "Lorem ipsum", Price = 9.99f } };
            ///
            Genre g = libraryDbContext.Genre.Where(x => x.Name == genre).First();
            List<Book> books = libraryDbContext.Books.Include(b => b.Genres).Where(x => x.Genres.Contains(g)).Skip(20).Take(10).ToList<Book>();

            return books;
        }


        [HttpGet("/api/[controller]/GetInfosGenres")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("/api/[controller]/infoGenres/{nb}")]
        public ActionResult<List<Genre>> GetInfosGenres(int nb)
        {
            List<Genre> genres = libraryDbContext.Genre.ToList<Genre>();
            return genres;
        }


        [Route("/api/[controller]/call")]
        public ActionResult<int> Call()
        {
            return Ok(libraryDbContext.Books.Count());
        }
        public async Task<ActionResult<Book>> AsyncCall()
        {
            return await libraryDbContext.Books.Include(b => b.Genres).Where(x => x.Price > 0).FirstAsync();
        }


        public async Task<ActionResult<Book>> Search(String name)
        {
            return await libraryDbContext.Books.FirstAsync(x => x.Name == name);
        }


    }
}

