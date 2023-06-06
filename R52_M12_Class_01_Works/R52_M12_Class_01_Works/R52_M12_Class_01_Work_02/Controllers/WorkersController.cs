using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R52_M12_Class_01_Work_02.Models;
using R52_M12_Class_01_Work_02.ViewModels;

namespace R52_M12_Class_01_Work_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly WorkerDbContext _context;

        public WorkersController(WorkerDbContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
          if (_context.Workers == null)
          {
              return NotFound();
          }
            return await _context.Workers.ToListAsync();
        }
        [HttpGet("VM")]
        public async Task<ActionResult<IEnumerable<WorkerViewModel>>> GetWorkerViewModels()
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var data = await _context.Workers.ToListAsync();
            return data.Select(w =>
            
                new WorkerViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    PayRate = w.PayRate,
                    StartDate = w.StartDate,
                    EndDate = w.EndDate,
                    DaysWorked = w.EndDate.HasValue ? (w.EndDate.Value - w.StartDate).Days + 1 : null,
                    TotalEarning = w.EndDate.HasValue ? ((w.EndDate.Value - w.StartDate).Days + 1)*w.PayRate : null

                }
            ).ToList();
                
        }
        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
          if (_context.Workers == null)
          {
              return NotFound();
          }
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return worker;
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, Worker worker)
        {
            if (id != worker.Id)
            {
                return BadRequest();
            }

            _context.Entry(worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
          if (_context.Workers == null)
          {
              return Problem("Entity set 'WorkerDbContext.Workers'  is null.");
          }
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkerExists(int id)
        {
            return (_context.Workers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
