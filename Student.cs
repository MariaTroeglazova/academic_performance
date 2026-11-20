namespace academic_performance
{
    internal class Student
    {
        public string Name { get; }
        public static int GradesNum = 3;
        byte[] _grades = new byte[GradesNum];
        byte[] Grades
        {
            get
            {
                return (byte[])_grades.Clone();
            }
        }
        public double Avg { get; }
        public string AcademicPerformance { get; }

        public Student(string Name, byte[] grades)
        {
            this.Name = Name;
            for (int i = 0; i < grades.Length; i++)
            {
                this._grades[i] = grades[i];
            }
            this.Avg = this.СalculateAverageGrade();
            this.AcademicPerformance = this.СalculatePerformance();
        }

        double СalculateAverageGrade()
        {
            byte sum = 0;
            foreach (byte grade in this._grades) sum += grade;
            double Avg = (double)sum / (double)GradesNum;
            return Avg;
        }

        string СalculatePerformance()
        {
            if (this.Avg >= 4.5 && this.Avg <= 5.0) return "Отлично";
            else if (this.Avg >= 3.5 && this.Avg < 4.5) return "Хорошо";
            else if (this.Avg >= 2.5 && this.Avg < 3.5) return "Удовлетворительно";
            else if (this.Avg < 2.5) return "Неудовлетворительно";
            else throw new Exception("Ошибка в растёте успеваемости! Приложение завершит работу.");
        }

        public void PrintStudent()
        {
            Console.Write($"\nСтудент {Name}.\nОценки: ");
            foreach (byte grade in this._grades) { Console.Write($"{grade} "); }
            Console.Write($"\nСредний балл: {this.Avg:F2}");
            Console.WriteLine($"\nУспеваемость: {this.AcademicPerformance}\n");
        }
    }
}
