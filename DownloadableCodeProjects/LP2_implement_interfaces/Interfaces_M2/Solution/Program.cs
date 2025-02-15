class Program
{
    static void Main(string[] args)
    {
        // Create a teacher and students
        IPerson teacher = new Teacher { Name = "Helen Karu", Age = 35 };
        IPerson student1 = new Student { Name = "Eba Lencho", Age = 20 };
        IPerson student2 = new Student { Name = "Frederiek Eppink", Age = 22 };

        // Use the utility class to print details
        PersonUtilities.PrintPersonDetails(teacher);
        PersonUtilities.PrintPersonDetails(student1);

        // Create a classroom and add students
        Classroom classroom = new Classroom();
        classroom.AddStudent((Student)student1);
        classroom.AddStudent((Student)student2);

        // Sort students by age
        classroom.SortStudentsByAge();

        Console.WriteLine("\nSorted Students by Age:");
        foreach (var student in classroom)
        {
            student.DisplayInfo();
        }
    }
}