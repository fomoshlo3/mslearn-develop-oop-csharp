// Interface for data access operations.
public interface IDataAccess
{
    // Connects to the data source.
    void Connect();

    // Retrieves data from the data source.
    string GetData();
}