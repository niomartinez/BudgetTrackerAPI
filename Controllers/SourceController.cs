using BudgetTracker.API.DataAccess;
using BudgetTracker.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourceController : Controller
    {
        private readonly BudgetTrackerDbContext _budgetTrackerDbContext;
        public SourceController(BudgetTrackerDbContext budgetTrackerDbContext)
        {
            _budgetTrackerDbContext = budgetTrackerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSources()
        {
            var sources = await _budgetTrackerDbContext.Sources.ToListAsync();
            return Ok(sources);
        }

        [HttpPost]
        public async Task<IActionResult> AddSource([FromBody]Source sourceRequest)
        {
            sourceRequest.Id = Guid.NewGuid();
            await _budgetTrackerDbContext.Sources.AddAsync(sourceRequest);
            await _budgetTrackerDbContext.SaveChangesAsync();

            return Ok(sourceRequest);
        }
    }
}
