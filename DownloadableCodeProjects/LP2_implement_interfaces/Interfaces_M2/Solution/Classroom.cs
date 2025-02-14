public class Classroom : IEnumerable
{
    private List students = new List();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void SortStudentsByAge()
    {
        students.Sort(); // Uses the IComparable implementation in Student
    }

    public IEnumerator GetEnumerator()
    {
        return students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}