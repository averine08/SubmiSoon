using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubmiSoonApi.Data;
using SubmiSoonApi.Dtos;
using SubmiSoonApi.Models;

namespace SubmiSoonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentStatController (AppDbContext db) : ControllerBase 
    {
        private readonly AppDbContext _db = db;

        [HttpGet("dashboard")]
        // [Authorize]
        public async Task<IActionResult> GetLeaderboard()
        {
            // var result = await _db.Attempts
            // .Where(a => a.Status == AttemptStatus.Complete)
            // .GroupBy(a => a.StudentId)
            // .Select(g => new
            // {
            //     StudentId = g.Key,
            //     CompletedCount = g.Count()
            // })
            // .OrderByDescending(x => x.CompletedCount)
            // .Take(5)
            // .ToListAsync();

            // var studentIds = result.Select(x => x.StudentId).ToList();
            // var students = await _db.Students
            // .Where(s => studentIds.Contains(s.StudentId))
            // .ToDictionaryAsync(s => s.StudentId, s => s.Name);

            // var leaderboard = result
            // .Select((item, index) => new LeaderboardItemDto
            // {
            //     Rank = index +1,
            //     StudentId = item.StudentId,
            //     Name = students[item.StudentId],
            //     CompletedCount = item.CompletedCount
                
            // })
            // .ToList();


            // var leaderboard = await _db.StudentStats
            // .OrderByDescending(s => s.CompletedCount)
            // .Take(5)
            // .Join(_db.Students,
            //     stats => stats.StudentId,
            //     stu => stu.StudentId,
            //     (stats, stu) => new {
            //         stu.Name,
            //         stats.CompletedCount
            //     })
            // .ToListAsync();
            // return Ok(leaderboard);


            var top = await _db.StudentStats
            .OrderByDescending(s => s.TotalCompleted)
            .Take(5)
            .Select(s => new {s.StudentId, s.TotalCompleted})
            .ToListAsync();

            if(top.Count == 0)
                return Ok(Array.Empty<object>());
            
            var ids = top.Select(t => t.StudentId).ToList();
            var students = await _db.Students
            .Where(s => ids.Contains(s.StudentId))
            .ToDictionaryAsync(s => s.StudentId);        

            var TotalAssigneds = await _db.Attempts
            .Where(s => ids.Contains(s.StudentId))
            .GroupBy( s => s.StudentId)
            .Select( g => new
            {
                StudentId = g.Key,
                Count = g.Count()
            })
            .ToDictionaryAsync( x => x.StudentId, x => x.Count );

            var res = top.Select((t, idx) => new LeaderboardItemDto
            {
                Rank = idx +1,
                StudentId = t.StudentId,
                Name = students[t.StudentId].Name,
                TotalCompleted = t.TotalCompleted,
                TotalAssigned = TotalAssigneds.ContainsKey(t.StudentId) ? TotalAssigneds[t.StudentId] : 0
            }).ToList();

            return Ok(res);
        }  
    }

}