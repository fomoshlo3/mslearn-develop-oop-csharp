namespace ImplementInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IPerson student = new Student { Name = "John Doe", Age = 20 };
            IPerson teacher = new Teacher { Name = "Jane Smith", Age = 35 };

            student.DisplayInfo();
            teacher.DisplayInfo();
        }
    }
}