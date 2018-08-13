using System;

namespace Library
{
    class Program
    {
        static void Main()
        {
            Library lib = new Library();
            ConsoleKey choose;
            while (true)
            {
                Console.Clear();
                Text();
                choose = Console.ReadKey().Key;
                switch (choose)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        AddBook(lib);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        AddAuthor(lib);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        DeleteBook(lib);
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        DeleteAuthor(lib);
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Print(lib);
                        break;
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
        static void Text()
        {
            Console.WriteLine("1. Добавить книгу(1)");
            Console.WriteLine("2. Добавить автора(2)");
            Console.WriteLine("3. Удалить книгу(3)");
            Console.WriteLine("4. Удалить автора(4)");
            Console.WriteLine("5. Вывести список библиотеки(5)");
        }
        static void AddBook(Library lib)
        {
            String name, numOfPages, year, nameA, surnameA, yearA, monthA, dayA;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите название книги :");
                    name = Console.ReadLine();
                    if (name != null && name.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите количество страниц в книге :");
                    numOfPages = Console.ReadLine();
                    // ReSharper disable once BuiltInTypeReferenceStyle
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(numOfPages);                    
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите год издания книги :");
                    year = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(year);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите имя автора книги :");
                    nameA = Console.ReadLine();
                    if (nameA != null && nameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите фамилию автора книги :");
                    surnameA = Console.ReadLine();
                    if (surnameA != null && surnameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите год рождения автора :");
                    yearA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(yearA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите месяц рождения автора :");
                    monthA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(monthA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите день рождения автора :");
                    dayA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(dayA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            DateTime date = new DateTime(Int32.Parse(yearA), Int32.Parse(monthA), Int32.Parse(dayA));
            lib.AddBook(name, Int32.Parse(numOfPages), Int32.Parse(year), nameA, surnameA, date);
        }
        static void Print(Library lib)
        {
            lib.Print();
            Console.WriteLine("==============================================");
            Console.WriteLine("Чтобы выйти нажмите любую клавишу :");
            Console.ReadKey();
        }
        static void AddAuthor(Library lib)
        {
            String nameA, surnameA, yearA, monthA, dayA;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите имя автора книги :");
                    nameA = Console.ReadLine();
                    if (nameA != null && nameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите фамилию автора книги :");
                    surnameA = Console.ReadLine();
                    if (surnameA != null && surnameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите год рождения автора :");
                    yearA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(yearA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите месяц рождения автора :");
                    monthA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(monthA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите день рождения автора :");
                    dayA = Console.ReadLine();
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Int32.Parse(dayA);
                    break;
                }
                catch (FormatException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
                catch (OverflowException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            DateTime date = new DateTime(Int32.Parse(yearA), Int32.Parse(monthA), Int32.Parse(dayA));
            lib.AddAuthor(nameA, surnameA, date);
        }
        static void DeleteBook(Library lib)
        {
            String name;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите название книги, которую хотите удалить :");
                    name = Console.ReadLine();
                    if (name != null && name.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            lib.DeleteB(name);
        }
        static void DeleteAuthor(Library lib)
        {
            String nameA, surnameA;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите имя автора книги, чтобы его удалить(вместе с ним удалятся и книги, которые он написал) :");
                    nameA = Console.ReadLine();
                    if (nameA != null && nameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите фамилию автора книги :");
                    surnameA = Console.ReadLine();
                    if (surnameA != null && surnameA.Length < 2)
                    {
                        throw new ArgumentException("Неккоректное название!");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (ArgumentException s)
                {
                    Console.WriteLine("Error! : " + s.Message);
                }
            }
            lib.DeleteA(nameA, surnameA);
        }
    }
}
