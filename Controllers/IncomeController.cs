using BudgetTracker.API.DataAccess;
using BudgetTracker.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : Controller
    {
        private readonly BudgetTrackerDbContext _budgetTrackerDbContext;
        public IncomeController(BudgetTrackerDbContext budgetTrackerDbContext)
        {
            _budgetTrackerDbContext = budgetTrackerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncome()
        {
            var incomes = await _budgetTrackerDbContext.Incomes
                .Include(i => i.Source)
                .ToListAsync();

            return Ok(incomes);
        }


        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody]Income incomeRequest)
        {
            incomeRequest.Id= Guid.NewGuid();
            await _budgetTrackerDbContext.Incomes.AddAsync(incomeRequest);
            await _budgetTrackerDbContext.SaveChangesAsync();

            return Ok(incomeRequest);
        }
    }
}
