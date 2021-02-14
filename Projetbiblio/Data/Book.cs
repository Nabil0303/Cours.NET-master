using Projetbiblio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;


namespace Projetbiblio.Model
{ 
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public String Name { get; set; }
        public String Content { get; set; }
        // public List<Genre> Genre { get; set; }
        // public int Edition { get; set; } "   Edition: " + Edition + ,int Edition
        public float Price { get; set; }
        public List<Genre> Genres { get; internal set; }

        public override string ToString()
    {
        return "Name: " + Name +"   Content: " + Content + "   Price: " + Price;
    }
        public Book(string name, string content, float price)
        {
            this.Name = name;
            this.Content = content;
            this.Price = price;
           // this.Edition = Edition;
        }

        public Book()
        {
        }

        ~Book()
        {

        }
    }
    /**
    class Genre
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public List<Book> Book { get; set; }
        public override string ToString()
        {
            return " ID: " + ID + "Name: " + Name + "Book :" + Book;
        }
    }
  /**  interface IAjoutBook {​ 
    void AjoutBook();
      }​
    class ImplementationClass : IAjoutBook
    {
        void IAjoutBook.AjoutBook()
        { }
        public String Name { get; set; }
        public String Content { get; set; }
        public List<Genre> Genre { get; set; }
        public int Edition { get; set; }
        public float Price { get; set; }

       

    }**/
    }

/** public class Example
 {
     public static void Main()
     {
         // Create a list of parts.
         List<Book> Books = new List<Book>();

         // Add parts to the list.
         Books.Add(new Book() { Name = "crank arm", Content = "12324",Genre=[1,"n","c"] });
         Books.Add(new Book() { Name = "cra arm", Content = "12834", Genre =[12, "n", "c"] });
         Books.Add(new Book() { Name = "crnk arm", Content = "19234", Genre =[13, "n", "c"] });
         Books.Add(new Book() { Name = "crank", Content = "12234", Genre =[14, "n", "c"] });
         Books.Add(new Book() { Name = "cank arm", Content = "125434", Genre =[15, "n", "c"] });
         Books.Add(new Book() { Name = "rank arm", Content = "12434", Genre =[16, "n", "c"] });

         // Write out the parts in the list. This will call the overridden ToString method
         // in the Part class.
         Console.WriteLine();
         foreach (Book aBook in Books)
         {
             Console.WriteLine(aBook);
         }

         // Check the list for part #1734. This calls the IEquatable.Equals method
         // of the Part class, which checks the PartId for equality.
         Console.WriteLine("\nContains(\"1734\"): {0}",
         Books.Contains(new Book { Name = "crank arm", Content = "12324", Genre =[1, "n", "c"] }));

         // Insert a new item at position 2.
         Console.WriteLine("\nInsert(2, \"1834\")");
         Books.Insert(2, new Book() { Name = "Nabil", Content = "123d24", Genre =[1, "n", "c"] });

         //Console.WriteLine();
         foreach (Book aPart in Books)
         {
             Console.WriteLine(aPart);
         }


         Console.WriteLine("\nRemove(\"1534\")");

         // This will remove part 1534 even though the PartName is different,
         // because the Equals method only checks PartId for equality.
         Books.Remove(new Book() { Name = "crank arm", Content = "12324", Genre =[1, "n", "c"] });

         
         Console.WriteLine("\nRemoveAt()");
         // This will remove the part at index 3.
         Books.RemoveAt(3);

        **/

