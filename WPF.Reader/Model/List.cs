using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Reader.Model
{
    public class Books : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String Name { get; set; }
        public int Ammount { get; set; }
    }
    public class ListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Books> Books { get; set; } = new() { 
            new Books() { Name = "Book1", Ammount = 1 },
            new Books() { Name = "Book2", Ammount = 2 },
            new Books() { Name = "Book3", Ammount = 3 } };
    }
}
