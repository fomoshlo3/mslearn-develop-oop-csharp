class Program
{
    static void Main(string[] args)
    {
        // Create instances of ConsoleLogger and DatabaseAccess.
        var logger = new ConsoleLogger();
        var dataAccess = new DatabaseAccess();

        // Inject the dependencies into the Application class.
        var app = new Application(logger, dataAccess);
        app.Run();
    }
}