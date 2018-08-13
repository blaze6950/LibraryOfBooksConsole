using System;
using System.Collections;

namespace Library
{
    class Library : IEnumerable
    {
        private String _name = "default";
        private String _addres = "default";
        private Int32 _numOfAuthors;
        private Author[] _authors;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public String Addres
        {
            get { return _addres; }
            set { _addres = value; }
        }
        public void AddBook(String nameOfBook, Int32 numberOfPages, Int32 yearOfBook, String nameAuthor, String surnameAuthor, DateTime dateOfBirth)
        {
            Book nbook = new Book();
            nbook.Name = nameOfBook.Trim();
            nbook.Num = numberOfPages;
            nbook.Year = yearOfBook;
            Author nauth = new Author();
            nauth.Name = nameAuthor.Trim();
            nauth.SurName = surnameAuthor.Trim();
            nauth.Date = dateOfBirth;
            Int32 index = FindA(nameAuthor, surnameAuthor);
            if (index >= 0)
            {
                if (_authors[index].FindB(nameOfBook) < 0)
                {
                    _authors[index].AddB(nbook);
                }
                else
                {
                    // кидаем исключение, такая книга уже есть у автора
                }
            }
            else
            {
                AddAuthor(nauth);
                index = FindA(nameAuthor, surnameAuthor);
                _authors[index].AddB(nbook);
            }
            Sort();
        }
        public void AddAuthor(Author nauthor)
        {
            Author[] nauth = new Author[_numOfAuthors + 1];
            for (int i = 0; i < _numOfAuthors; i++)
            {
                nauth[i] = new Author();
                nauth[i].Name = _authors[i].Name;
                nauth[i].SurName = _authors[i].SurName;
                nauth[i].Date = _authors[i].Date;
                nauth[i].NumOfBooks = _authors[i].NumOfBooks;
                if (_authors[i].Books != null)
                {
                    nauth[i].Books = (Book[])_authors[i].Books.Clone();
                }
            }
            nauth[_numOfAuthors] = (Author)nauthor.Clone();
            _authors = nauth;
            _numOfAuthors++;
            Sort();
        }
        public void AddAuthor(String name, String surname, DateTime dateOfBirth)
        {
            Author[] nauth = new Author[_numOfAuthors + 1];
            for (int i = 0; i < _numOfAuthors; i++)
            {
                nauth[i] = new Author();
                nauth[i].Name = _authors[i].Name;
                nauth[i].SurName = _authors[i].SurName;
                nauth[i].Date = _authors[i].Date;
                nauth[i].NumOfBooks = _authors[i].NumOfBooks;
                if (_authors[i].Books != null)
                {
                    nauth[i].Books = (Book[])_authors[i].Books.Clone();
                }
            }
            nauth[_numOfAuthors] = new Author();
            nauth[_numOfAuthors].Name = name.Trim();
            nauth[_numOfAuthors].SurName = surname.Trim();
            nauth[_numOfAuthors].Date = dateOfBirth;
            _authors = nauth;
            _numOfAuthors++;
            Sort();
        }
        public int FindA(String name, String surname) // поиск автора по имени и фамилии
        {
            for (int i = 0; i < _numOfAuthors; i++)
            {
                if (_authors[i].Name.Contains(name) && _authors[i].SurName.Contains(surname))
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindB(String name, ref Int32 index) // поиск книги по имени
        {
            for (int i = 0; i < _numOfAuthors; i++)
            {
                if (_authors[i].FindB(name) >= 0)
                {
                    index = _authors[i].FindB(name);
                    return i;
                }
            }
            return -1;
        }
        public void DeleteB(String name) // удаление книги по названию
        {
            int iBook = 0;
            int iAuth = FindB(name, ref iBook);
            if (iAuth >= 0)
            {
                _authors[iAuth].DeleteB(iBook);
            }
        }
        public void DeleteA(String name, String surname) // удаление автора по имени и фамилии
        {
            int iAuth = FindA(name, surname);
            if (iAuth >= 0)
            {
                Author[] nauth = new Author[_numOfAuthors - 1];
                for (int i = 0; i < _numOfAuthors; i++)
                {
                    if (i == iAuth && i < _numOfAuthors)
                    {
                        i++;
                    }
                    if (i < _numOfAuthors)
                    {
                        nauth[i] = new Author();
                        nauth[i].Name = _authors[i].Name;
                        nauth[i].SurName = _authors[i].SurName;
                        nauth[i].Date = _authors[i].Date;
                        nauth[i].NumOfBooks = _authors[i].NumOfBooks;
                        if (_authors[i].Books != null)
                        {
                            nauth[i].Books = (Book[])_authors[i].Books.Clone();
                        }
                    }
                }
                _authors = nauth;
                _numOfAuthors--;
                Sort();
            }
            else
            {
                // кидаем исключение, так как такого автора нет
            }
        }
        public void Print()
        {
            int allBooks = 0;
            for (int i = 0; i < _numOfAuthors; i++)
            {
                allBooks += _authors[i].NumOfBooks;
            }
            Console.WriteLine("Library : " + _name + " " + _addres + ", books : " + allBooks);
            for (int i = 0; i < _numOfAuthors; i++)
            {
                Console.Write(" ");
                _authors[i].Print();
            }
        }
        private void Sort()
        {
            if (_numOfAuthors > 1)
            {
                Array.Sort(_authors, CmpAuthors);
            }
        }
        static int CmpAuthors(Author x, Author y)
        {

            return String.CompareOrdinal(x.Name, y.Name);
        }

        public class Enumerator : IEnumerator
        {
            Library lib;
            int _i = -1;

            public Enumerator(Library p)
            {
                lib = p;
            }

            public object Current
            {
                get { return lib._authors[_i]; }
            }

            public bool MoveNext()
            {
                _i++;
                return _i >= lib._numOfAuthors ? false : true;
            }

            public void Reset()
            {
                _i = -1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
