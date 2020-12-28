using System.Collections.Generic;

namespace GradeBook
{
    public class Book {
        private List<double> grades = new List<double>();
        private string name;
        public Book(string name) {
            this.name = name;
        }
        public void AddGrade(double grade) {
            grades.Add(grade);
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
            return $"Calling ShoweStatistics reveals the following\nHighest grade is: {this.HighestGrade():N2}\nLowest grade is: {this.LowestGrade():N2}\nAverage grade is: {this.AverageGrade():N1}";
        }

        public Statistics GetStatistics() {
            return new Statistics(this.AverageGrade(), this.LowestGrade(), this.HighestGrade());
        }

        public void SetName(string name) {
            this.name = name;
        }

        public string GetName() {
            return this.name;
        } 
    }
}