using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book {
        private List<double> grades = new List<double>();
        
        private List<char> letterGrades = new List<char>();

        private string name;

        /*public string Name {
            get {
                return name;
            }

            set {
                if(!String.IsNullOrEmpty(value)) {
                    name = value;
                }
            }
        }*/

        public Book(string name) {
            this.name = name;
        }
        public void AddGrade(double grade) {
            if (grade >= 0 && grade <= 100) {
                grades.Add(grade);
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        private double HighestGrade() {
            double highGrade = double.MinValue;
            foreach(var grade in this.grades) {
                if (grade > highGrade) {
                    highGrade = grade;
                }
            }
            return highGrade;
        }

        private double LowestGrade() {
            double lowGrade = double.MaxValue;
            foreach(var grade in grades) {
                lowGrade = (grade < lowGrade ? grade : lowGrade);
            }
            return lowGrade;
        }

        private double AverageGrade() {
            double sum = 0;
            foreach(var grade in grades) {
                sum += grade;
            }
            return sum/grades.Count;
        }

        public string ShowStatistics() {
            return $"Calling ShoweStatistics reveals the following\nHighest grade is: {this.HighestGrade():N2}\nLowest grade is: {this.LowestGrade():N2}\nAverage grade is: {this.AverageGrade():N1}\nLetter grade is: {this.LetterGrade():N1}";
        }

        public Statistics GetStatistics() {
            return new Statistics(this.AverageGrade(), this.LowestGrade(), this.HighestGrade(), this.LetterGrade());
        }

        private char LetterGrade()
        {
            char letter = 'X';
            switch(this.AverageGrade()) {
                case var d when d > 90.0:
                    letter = 'A';
                    break;
                case var d when d > 80.0:
                    letter = 'B';
                    break;
                case var d when d > 70.0:
                    letter = 'C';
                    break;
                case var d when d > 60.0:
                    letter = 'D';
                    break;
                case var d when d > 50.0:
                    letter = 'E';
                    break;
                default:
                    letter = 'F';
                    break;
            }
            return letter;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public string GetName() {
            return this.name;
        }

        public void AddLetterGrade(char letter) {
            letterGrades.Add(letter);
            switch(letter) {
                case 'A': 
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
    }
}