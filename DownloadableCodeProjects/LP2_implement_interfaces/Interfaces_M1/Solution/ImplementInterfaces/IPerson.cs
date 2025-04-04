namespace ImplementInterfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void DisplayInfo();
    }

    public class Student : IPerson
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;

        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name}, Age: {Age}");
        }
    }
}