
using Microsoft.EntityFrameworkCore;
using Projetbiblio.Model;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;



namespace Projetbiblio.Data

{

    public class LibraryDbContext : DbContext

    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)

        {

        }



        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; internal set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Genre>().ToTable("Genre");

        }

    }





}