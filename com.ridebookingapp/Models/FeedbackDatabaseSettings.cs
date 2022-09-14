namespace com.ridebookingapp.Models;

public class FeedbackDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string FeedsCollectionName { get; set; } = null!;
}