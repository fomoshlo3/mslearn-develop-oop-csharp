// This class represents the main application logic.
// It is currently tightly coupled to the ConsoleLogger and DatabaseAccess classes.
// Your task is to refactor this class to use interfaces (ILogger and IDataAccess)
// instead of directly depending on concrete implementations.
public class Application
{
    private readonly ConsoleLogger _logger;
    private readonly DatabaseAccess _dataAccess;

    // The constructor directly instantiates the ConsoleLogger and DatabaseAccess classes,
    // creating tight coupling. This will be refactored in the exercise.
    public Application()
    {
        _logger = new ConsoleLogger();
        _dataAccess = new DatabaseAccess();
    }

    // Runs the application logic.
    public void Run()
    {
        // Log the start of the application.
        _logger.Log("Application started.");

        // Connect to the database and retrieve data.
        _dataAccess.Connect();
        var data = _dataAccess.GetData();

        // Log the retrieved data.
        _logger.Log($"Data retrieved: {data}");

        // Log the end of the application.
        _logger.Log("Application finished.");
    }
}