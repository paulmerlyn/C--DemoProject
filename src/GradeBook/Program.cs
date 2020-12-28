using System;
using System.Collections.Generic;

namespace GradeBook {

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Paul's Grade Book");
            book.AddGrade(2);
            book.AddGrade(5);
            book.AddGrade(9);

            //double gradeTotal = 0;
            //double gradeAverage = 0;
            //var grades = new List<double>() {5, 7, 13, 6, 2};
            if (args.Length > 0) {
                Console.WriteLine($"Hello, {args[0]} {args[1]}");
            } else {
                Console.WriteLine("Hello Mr No Name!");
            }

            System.Console.WriteLine($"Welcome to {book.GetName()}");
            //Console.WriteLine($"Grade average is: {book.AverageGrade()}");
            //Console.WriteLine($"Lowest grade is: {book.LowestGrade():N2}");
            //System.Console.WriteLine($"Highest grade is: {book.HighestGrade():N2}");
            Console.WriteLine(book.ShowStatistics());
        }
    }
}

