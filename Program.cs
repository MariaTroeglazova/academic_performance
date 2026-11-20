using academic_performance;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            StudentsList studentList = new();
            studentList.PrintStudentsList();

            Student maxAvgStudent = studentList.GetStudentWithMaxAvgGrade();
            Console.WriteLine($"Студент с самым высоким средним баллом: {maxAvgStudent.Name}");

            Console.WriteLine("Хотите проанализировать успеваемость ещё одной группы? (Д/н)");
            while (true)
            {
                string? answer = Console.ReadLine();
                if (answer == "н" || answer == "Н") return;
                else if (answer == "д" || answer == "Д") break;
                else Console.WriteLine("Неправильный ввод. Только Д/н");
            }
        }
    }
}