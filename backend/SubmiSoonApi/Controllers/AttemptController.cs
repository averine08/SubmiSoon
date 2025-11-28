using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Data;
using SubmiSoonApi.Dtos;
using SubmiSoonApi.Models;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class AttemptController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _db = db;

    [HttpGet("{attemptId}")]
    public async Task<IActionResult> GetAttemptDetail(int attemptId)
    {
        var studentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var attempt = await _db.Attempts
        .Include(a => a.Assessment)
            .ThenInclude(ass => ass.Questions)
                .ThenInclude(q => q.Choices)
        .Include(a => a.Answers)
        .FirstOrDefaultAsync(a => a.StudentId == studentId &&
                (a.AssessmentId == attemptId));
        
        if(attempt == null) return NotFound();

        var res  = new AttemptDetailDto
        {
            AttemptId = attempt.AttemptId,
            AssesmentId = attempt.AssessmentId,
            Status = attempt.Status,
            AsgTitle = attempt.Assessment.Title,
            StartDate = attempt.Assessment.StartDate,
            EndDate = attempt.Assessment.EndDate,
            Questions = attempt.Assessment.Questions
                        .Select(q => new QuestionDto
                        {
                            QuestionId = q.QuestionId,
                            QuestionText = q.QuestionText,
                            QuestionType = q.QuestionType,
                            Choices = q.Choices
                                .Select(x => new ChoiceDto
                                {
                                    ChoiceId = x.ChoiceId,
                                    Text = x.Text
                                }).ToList()
                        }).ToList(),
            Answers = attempt.Answers
                        .Select( a => new AnswerDto
                        {
                            AnswerId = a.AnswerId,
                            QuestionId = a.QuestionId,
                            EssayAnswer = a.EssayAnswer,
                            ChoosenId = a.ChosenAnswerId,
                            FilePath = a.FilePath,
                            LastUpdated = a.LastUpdated,
                            Type = a.Question.QuestionType.ToString().ToLower(),
                        }).ToList()
                    
        };
        return Ok(res);
    }

    [HttpGet("{attemptId}/submit")]
    public async Task<IActionResult> SubmitAttempt(int attemptId)
    {
        var attempt = await _db.Attempts
        .Include( a => a.Answers)
        .FirstOrDefaultAsync(a => a.AttemptId == attemptId);

        if(attempt == null) return NotFound("Attempt Not Found");

        // foreach(var ans in dto.Answers)
        // {
        //     var existing = attempt.Answers
        //     .FirstOrDefault(a => a.QuestionId == ans.QuestionId);

        //     // if(existing != null)
        //     // {
        //         existing!.EssayAnswer = ans.EssayAnswer;
        //         existing.ChosenAnswerId = ans.ChooosenId;
        //         existing.FilePath = ans.FilePath;
        //         existing.LastUpdated = ans.LastUpdated;
        //     // }
        // }

        attempt.SubmittedAt = DateTime.UtcNow;
        attempt.Score = 100;
        attempt.Status = AttemptStatus.Complete;

        await _db.SaveChangesAsync();
            return Ok(new 
            {
                code    = 200,
                attemptId = attempt.AttemptId,
                score     = attempt.Score,
                submittedAt = attempt.SubmittedAt
            });
    }

    [HttpGet("{attemptId}/answer")]
    public async Task<IActionResult> SubmitSingleAnswer(int attemptId, [FromBody] AnswerDto dto)
    {
        var attempt = await _db.Attempts
        .Include(a => a.Answers)
        .FirstOrDefaultAsync(a => a.AttemptId == attemptId);

        if (attempt == null) return NotFound("Attempt not found");
        
        var existing = attempt.Answers
            .FirstOrDefault(a => a.QuestionId == dto.QuestionId);
        Answer ans;
        if (existing != null)
        {
            // Update existing
            existing.EssayAnswer = dto.EssayAnswer;
            existing.ChosenAnswerId = dto.ChoosenId;
            existing.FilePath = dto.FilePath;
            existing.LastUpdated = DateTime.UtcNow;

            ans = existing;
        }
        else
        {
            // Create new answer
            var newAnswer = new Answer
            {
                AttemptId = attempt.AttemptId,
                QuestionId = dto.QuestionId,
                EssayAnswer = dto.EssayAnswer,
                ChosenAnswerId = dto.ChoosenId,
                FilePath = dto.FilePath,
                LastUpdated = DateTime.UtcNow
            };

            attempt.Answers.Add(newAnswer);
            ans = newAnswer;
        }

        await _db.SaveChangesAsync();

        return Ok( new AnswerDto
            {
                AnswerId = ans.AnswerId,  
                QuestionId = dto.QuestionId,
                Type = ans.Question.QuestionType.ToString().ToLower(),
                EssayAnswer = ans.EssayAnswer,
                ChoosenId = ans.ChosenAnswerId,
                FilePath = ans.FilePath,
                LastUpdated = ans.LastUpdated             
            }
        );

    }
}