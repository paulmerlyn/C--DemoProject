﻿using System;
using System.Collections.Generic;

namespace GradeBook {

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Paul's Grade Book");

            Console.WriteLine("Welcome to the Grade Book! Enter grades. Type 'q' to quit or end your sequence of grades.");

            while (true) {
                Console.WriteLine("Enter grade (or q): ");
                var input = Console.ReadLine();
                if (input == "q") {
                    break;
                }
                
                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                } catch(ArgumentException ex) {
                    Console.WriteLine(ex.Message);
                } catch(FormatException ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            //book.AddGrade(20);
            //book.AddGrade(71);
            //book.AddGrade(90);
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
