using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    class DetailsBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ItemSelectedCommand { get; set; }

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() { 
            new Book() { Content = "Read this book"}
          
        };

        
    }
}
