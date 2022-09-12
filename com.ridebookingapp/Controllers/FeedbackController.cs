using com.ridebookingapp.Models;
using com.ridebookingapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace com.ridebookingapp.Controllers;

[ApiController]
[Route("api")]
public class FeedbackController : ControllerBase
{
    private readonly FeedbackService _feedbackService;

    public FeedbackController(FeedbackService feedbackService) =>
        _feedbackService = feedbackService;

    [HttpGet]
    [Route("/api/v1.0/rideapp/feedback/all")]
    public async Task<List<Feedback>> Get() =>
        await _feedbackService.GetAsync();


    [HttpPost("{name}")]
    [Route("/api/v1.0/rideapp/{name}/feedback/")]
    public async Task<IActionResult> Post(Feedback newFeedback)
    {
     
     
        await _feedbackService.CreateAsync(newFeedback);

        return CreatedAtAction(nameof(Get), new { id = newFeedback.Id }, newFeedback);
    }

    [HttpPut("{id}")]
    [Route("/api/v1.0/rideapp/{name}/updateFeedback/{id}")]
    public async Task<IActionResult> Update(string id, string feed)
    {
        var Feedback = await _feedbackService.GetAsync(id);

        if (Feedback is null)
        {
            return NotFound();
        }

         Feedback.Feed=feed;

        await _feedbackService.UpdateAsync(id, Feedback);

        return Ok(Feedback);
    }

    [HttpDelete("{id}")]
    [Route("/api/v1.0/rideapp/{name}/deleteFeedback/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Feedback = await _feedbackService.GetAsync(id);

        if (Feedback is null)
        {
            return NotFound();
        }

        await _feedbackService.RemoveAsync(id);

        return NoContent();
    }
}