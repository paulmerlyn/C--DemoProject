using System;
using System.Collections.Generic;

namespace GradeBook
{
    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject, IBook {
        protected Book(string name) : base(name)
        {
        }

        // Abstract methods are implicitly virtual, so no need to use the virtual keyword here
        public abstract void AddGrade(double grade);

        // The keyword virtual signifies that a derived class (e.g. InMemoryBook) may try to override this method
        public virtual Statistics GetStatistics() {
            throw new NotImplementedException();
        }

        public virtual event GradeAddedDelegate GradeAdded;
    }
    public class NamedObject : Object {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name {
            get;
            set;
        }
    }

    public class InMemoryBook : Book {
        private List<double> grades = new List<double>();
        
        private List<char> letterGrades = new List<char>();

        //private string name;

        public InMemoryBook(string name) : base(name) {
            //this.Name = name;
        }

        public InMemoryBook(string name, string category) : base(name) {
            //this.Name = name;
            this.category = category;
        }

        public override void AddGrade(double grade) {
            if (grade >= 0 && grade <= 100) {
                grades.Add(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

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

        public override Statistics GetStatistics() {
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

        /*public void SetName(string name) {
            this.name = name;
        }

        public string GetName() {
            return this.name;
        }*/

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

        
        /* When designated as readonly, a field may be changed from its default value in the constructor only*/
        readonly string category = "Science";

        /* Constants don't need to be in capitalized. They are accessed at class-level (cf. object-level). */
        public const string SERVICELEVEL = "Professional";
    }
}