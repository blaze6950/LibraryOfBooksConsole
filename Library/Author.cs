using System;

namespace Library
{
    class Author : ICloneable
    {
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;
        private int _numOfBooks;
        private Book[] _books;
        public Author()
        {
            _name = "default";
            _surname = "default";
            _dateOfBirth = DateTime.Now;
            _books = null;
        }
        public object Clone()
        {
            Author nauth = new Author();
            nauth.Name = Name;
            nauth.SurName = SurName;
            nauth.Date = Date;
            return nauth;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string SurName
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public DateTime Date
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public Book[] Books
            {
                get { return _books; }
                set { _books = value; }
            }
        public int NumOfBooks
        {
            get { return _numOfBooks; }
            set { _numOfBooks = value; }
        }
        public int FindB(string name)
        {
            for (int i = 0; i < _numOfBooks; i++)
            {
                if (_books[i].Name.Contains(name))
                {
                    return i;
                }
            }
            return -1;
        }
        public void AddB(Book nbook)
        {
            Book[] nbooks = new Book[_numOfBooks + 1];
            for (int i = 0; i < _numOfBooks; i++)
            {
                nbooks[i] = new Book();
                nbooks[i].Name = _books[i].Name;
                nbooks[i].Num = _books[i].Num;
                nbooks[i].Year = _books[i].Year;
            }
            nbooks[_numOfBooks] = (Book)nbook.Clone();
            _books = nbooks;
            _numOfBooks++;
            Sort();
        }
        private void Sort()
        {
            if (_numOfBooks > 1)
            {
                Array.Sort(_books, CmpBooks);
            }
        }
        static int CmpBooks(Book x, Book y)
        {
            return String.CompareOrdinal(x.Name, y.Name);
        }
        public void DeleteB(int index)
        {
            Book[] nbooks = new Book[_numOfBooks - 1];
            for (int i = 0, space = 0; i < _numOfBooks; i++, space++)
            {
                if (i == index && i < _numOfBooks)
                {
                    i++;
                }
                if (i < _numOfBooks)
                {
                    nbooks[space] = new Book();
                    nbooks[space].Name = _books[i].Name;
                    nbooks[space].Num = _books[i].Num;
                    nbooks[space].Year = _books[i].Year;
                }
            }
            _books = nbooks;
            _numOfBooks--;
            Sort();
        }
        public void Print()
        {
            Console.WriteLine(_name + " " + _surname + " (" + _dateOfBirth.ToLongDateString() + ") " + "Books : " + _numOfBooks);
            for (int i = 0; i < _numOfBooks; i++)
            {
                Console.Write("  -");
                _books[i].Print();
            }
        }
    }
}
