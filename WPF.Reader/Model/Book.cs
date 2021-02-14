using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Reader.Model
{
    class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public String Title { get; set; }
        public String Author { get; set; }
        public String Content { get; set; }
        public String Category { get; set; }




    }
    //add an observable class for data binding
    class BooksCollection : ObservableCollection<Book>
    {
        public void CopyFrom(IEnumerable<Book> books)
        {
            this.Items.Clear();
            foreach (var p in books)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
