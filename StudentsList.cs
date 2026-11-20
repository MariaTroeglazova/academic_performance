namespace academic_performance
{
    internal class StudentsList
    {
        Student[] _students {  get; set; }
        Student[] Students
        {
            get
            {
                return (Student[])_students.Clone();
            }
        }
        double Avg { get; }

        public StudentsList() {
            Console.WriteLine("Введите число студентов в группе: ");
            byte studNum;
            while (true)
            {
                try
                {
                    studNum = Convert.ToByte(Console.ReadLine());
                    if (studNum == 0) throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильный ввод. Укажите целое число студентов не менее одного.");
                    continue;
                }
            }

            this._students = new Student[studNum];

            for (int i = 0; i < this._students.Length; i++)
            {
                Console.WriteLine($"Введите имя {i + 1}-го студента: ");
                string? Name = Console.ReadLine();
                if (Name == "" || Name == null)
                {
                    Console.WriteLine("Имя не должно быть пустым!");
                    i--;
                    continue;
                }
                byte[] grades = new byte[Student.GradesNum];
                for (int j = 0; j < Student.GradesNum; j++)
                {
                    Console.WriteLine($"Введите {j + 1}-ую оценку судента {Name}: ");
                    byte grade;
                    while (true)
                    {
                        try
                        {
                            grade = Convert.ToByte(Console.ReadLine());
                            if (grade is 2 or 3 or 4 or 5)
                            {
                                grades[j] = grade;
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break; ;
                        }
                        catch
                        {
                            Console.WriteLine("Неправильный ввод. Укажите оценку 2, 3, 4 или 5.");
                            continue;
                        }
                    }
                }
                this._students[i] = new Student(Name, grades);
            }
            this.Avg = this.СalculateAverageGrade();
        }

        double СalculateAverageGrade()
        {
            double sum = 0;
            foreach (Student student in this._students) sum += student.Avg;
            double avg = sum / this.Students.Length;
            return avg;
        }

        public Student GetStudentWithMaxAvgGrade()
        {
            Student maxAvgStudent = this.Students[0];
            foreach (Student student in this.Students)
            {
                if (student.Avg > maxAvgStudent.Avg) maxAvgStudent = student;
            }
            return maxAvgStudent;
        }

        public void PrintStudentsList()
        {
            foreach (Student student in this._students) student.PrintStudent();
            Console.WriteLine($"\nСредняя оценка группы: {this.Avg:F2}");
        }
    }
}
