using System.Data.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Data;
using SubmiSoonApi.Dtos;
using SubmiSoonApi.Models;

[ApiController]
[Route("api/attemptlist")]
[Authorize]
public class AttemptListController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _db = db;

    [HttpGet("incomplete")]
    public async Task<IActionResult> GetIncompleteAttempts()
    {
        var studentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var attempts = await _db.Attempts
        .Include(a => a.Assessment)
        .Where(a => a.StudentId == studentId &&
                (a.Status == AttemptStatus.NotStarted ||
                a.Status == AttemptStatus.Draft))
        .ToListAsync();

        var result = attempts.Select(a => new IncompleteAttemptDto
        {
            AttemptId = a.AttemptId,
            AssessmentId = a.AssessmentId,
            Title = a.Assessment.Title,
            Description = a.Assessment.Description,
            StartDate = a.Assessment.StartDate,
            EndDate = a.Assessment.EndDate,
            Status = a.Status.ToString()
        }).ToList();

        return Ok(result);
    }

    [HttpGet("complete")]

    public async Task<IActionResult> GetCompleteAttempts()
    {
        var studentId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var attempts = await _db.Attempts
        .Include(a => a.Assessment)
        .Where(a => a.Status == AttemptStatus.OnReview ||
                a.Status == AttemptStatus.Complete)
        .ToListAsync();

        var result = attempts.Select(a => new CompleteAttemptDto
        {
            AttemptId = a.AttemptId,
            AssessmentId = a.AssessmentId,
            Title = a.Assessment.Title,
            Description = a.Assessment.Description,
            SubmittedAt = a.SubmittedAt,
            Status = a.Status.ToString(),
            Score = a.Score

        }).ToList();

        return Ok(result);
    }
}