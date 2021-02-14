using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetbiblio.Model
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public String Name { get; set; }
        public List<Book> Book { get; set; }
        public override string ToString()
        {
            return "Name: " + Name + "Book :" + Book;
        }
    }

}

