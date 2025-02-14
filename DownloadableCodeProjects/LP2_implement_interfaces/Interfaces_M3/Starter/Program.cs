// This is the entry point of the application.
// It creates an instance of the Application class and runs it.
// After refactoring, the Application class will accept dependencies via its constructor.
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create and run the application.
        // Note: After refactoring, the Application class will require ILogger and IDataAccess
        // instances to be passed into its constructor.
        var app = new Application();
        app.Run();
    }
}