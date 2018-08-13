using System;

namespace Library
{
    class Book : ICloneable
    {
        private String _name = "default";
        private Int32 _numberOfPages;
        private Int32 _year = 2017;

        public Object Clone() //реализация метода Clone из интерфейса ICloneable
        {
            Book nbook = new Book();
            nbook.Name = Name;
            nbook.Num = Num;
            nbook.Year = Year;
            return nbook;
        }
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Num
        {
            get { return _numberOfPages; }
            set {
                if (value > 0)
                {
                    _numberOfPages = value;
                }
                else
                {
                    //throw exception
                }
            }
        }
        public int Year
        {
            get { return _year; }
            set {
                if (value > 0)
                {
                    _year = value;
                }
                else
                {
                    //throw exception
                }
            }
        }
        public void Print()
        {
            Console.WriteLine(_name + " (" + _year + ") " + _numberOfPages + " pages");
        }
    }
}
