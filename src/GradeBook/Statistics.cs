namespace GradeBook {
    public class Statistics {
        private double average;
        private double min;
        private double max;
        private char letter;

        public Statistics(double average, double min, double max, char letter) {
            this.average = average;
            this.min = min;
            this.max = max;
            this.letter = letter;
        }

        public double GetAverage() {
            return this.average;
        }

        public double GetLow() {
            return this.min;
        }

        public double GetHigh() {
            return this.max;
        }

        public char GetLetterGrade() {
            return this.letter;
        }

    }
}

