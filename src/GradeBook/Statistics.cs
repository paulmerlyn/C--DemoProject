namespace GradeBook {
    public class Statistics {
        private double average;
        private double min;
        private double max;

        public Statistics(double average, double min, double max) {
            this.average = average;
            this.min = min;
            this.max = max;
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

    }
}

