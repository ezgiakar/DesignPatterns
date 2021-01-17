using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Author = "Umberto Eco",
                Title = "Gülün Adı",
                Isbn = "123456"

            };

            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "654321";
            book.Title = "GÜLÜN TADI";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        string _title;
        string _author;
        string _isbn;
        DateTime _lastEdited;
        public string Title 
        {
            get { return _title; }
            set 
            { 
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set 
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set 
            { 
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_title, _isbn,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _lastEdited = memento.LastEdited;
            _isbn = memento.Isbn;
            _author = memento.Author;
            _title = memento.Title;

        }

        public void ShowBook()
        {
            Console.WriteLine("{0}, {1}, {2} edited : {3}", Isbn, Title, Author, _lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
