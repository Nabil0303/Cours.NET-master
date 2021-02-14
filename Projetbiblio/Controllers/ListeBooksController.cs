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

    public class ListeBooksController: Controller
    {
        private readonly LibraryDbContext libraryDbContext;
        public ListeBooksController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }
        public IActionResult Index()
        {
            var listebooks = libraryDbContext.Books.Include(b => b.Genres);
            ViewBag.listeBooks = listebooks;
            return View();
        }
        public IActionResult ListeGenres()
        {
            var listeGenres = libraryDbContext.Genre.Include(b => b.Book);
            ViewBag.listeGenres = listeGenres;
            return View();
        }
        public IActionResult DeleteBook(String name)
        {
            if (name != null)
            {
                var book = libraryDbContext.Books.Where(book => book.Name == name).Single();
                libraryDbContext.Books.Remove(book);
                libraryDbContext.SaveChanges();
            }
            var listebooks = libraryDbContext.Books.Include(b => b.Genres);
            ViewBag.listeBooks = listebooks;
            return View("Index");
        }
        public IActionResult DeleteGenre(String name)
        {
            if (name != null)
            {
                var genre = libraryDbContext.Genre.Where(genre => genre.Name == name).Single();
                libraryDbContext.Genre.Remove(genre);
                libraryDbContext.SaveChanges();
            }
            var listeGenres = libraryDbContext.Genre.Include(b => b.Book);
            ViewBag.listeGenres = listeGenres;
            return View("ListeGenres");
        }
        public IActionResult CreateBook()
        {
            var listeGenres = libraryDbContext.Genre.Include(b => b.Book);
            ViewBag.listeGenres = listeGenres;
            return View();
        }
        public IActionResult Create(String bookname, String price, String genreName, String content)
        {
            var genre = libraryDbContext.Genre.Where(genre => genre.Name == genreName).Single();
            Book book = new Book { Content = content, Name = bookname, Price = float.Parse(price), Genres = new List<Genre>() { genre } };
            libraryDbContext.Books.Add(book);
            libraryDbContext.SaveChanges();
            var listebooks = libraryDbContext.Books.Include(b => b.Genres);
            ViewBag.listeBooks = listebooks;
            return View("Index");
        }
    }
}

