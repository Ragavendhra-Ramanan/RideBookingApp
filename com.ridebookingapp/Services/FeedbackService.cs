using com.ridebookingapp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace com.ridebookingapp.Services;

public class FeedbackService
{
    private readonly IMongoCollection<Feedback> _feedbackCollection;

    public FeedbackService(
        IOptions<FeedbackDatabaseSettings> feedbackDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            feedbackDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            feedbackDatabaseSettings.Value.DatabaseName);

        _feedbackCollection = mongoDatabase.GetCollection<Feedback>(
            feedbackDatabaseSettings.Value.FeedsCollectionName);
    }

    public async Task<List<Feedback>> GetAsync() =>
        await _feedbackCollection.Find(_ => true).ToListAsync();

    public async Task<Feedback?> GetAsync(string id) =>
        await _feedbackCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Feedback newfeedback) =>
        await _feedbackCollection.InsertOneAsync(newfeedback);

    public async Task UpdateAsync(string id, Feedback updatedfeedback) =>
        await _feedbackCollection.ReplaceOneAsync(x => x.Id == id, updatedfeedback);

    public async Task RemoveAsync(string id) =>
        await _feedbackCollection.DeleteOneAsync(x => x.Id == id);
}