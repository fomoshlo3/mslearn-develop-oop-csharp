public class Student : IPerson, IComparable
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;

    public string Role => "Student";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student Name: {Name}, Age: {Age}");
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return this.Age.CompareTo(other.Age);
    }
}