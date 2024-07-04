using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Controllers
{
    public class RequisitionsController : Controller
    {
        private readonly StoreManagementSystemContext _context;

        public RequisitionsController(StoreManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Requisitions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requisitions.ToListAsync());
        }

        // GET: Requisitions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                        .Include( r => r.RequisitionItems)
                            .ThenInclude( ri => ri.Item)
                                .ThenInclude(i => i.Unit)

                        .FirstOrDefaultAsync(m => m.Id == id);

            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // GET: Requisitions/Create
        public async Task<IActionResult> Create()
        {

            var items = await _context.Items.ToListAsync();

            ViewData["items"] = items;

            return View();
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Status,RefNumber,CreatedOn,RequisitionItems")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {

                requisition.CreatedOn = DateTime.UtcNow;
                requisition.UpdatedOn = DateTime.UtcNow;

                string uniqueNumber = DateTime.UtcNow.ToString("yyMdHms");

                requisition.Number = uniqueNumber;

                _context.Add(requisition);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(requisition);
        }

        // GET: Requisitions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.ToListAsync();

            var requisition = await _context.Requisitions.Include(r => r.RequisitionItems).SingleOrDefaultAsync(r => r.Id == id);

            if (requisition == null)
            {
                return NotFound();
            }

            ViewData["items"] = items;

            return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Number,Status,RefNumber,Id,RequisitionItems")] Requisition requisition)
        {
            if (id != requisition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var oldRequisition = await _context.Requisitions.AsNoTracking().SingleOrDefaultAsync(r => r.Id == requisition.Id);

                    requisition.CreatedOn = oldRequisition.CreatedOn;
                    requisition.Number = oldRequisition.Number;
                    requisition.Status = oldRequisition.Status;
                    requisition.UpdatedOn = DateTime.UtcNow;

                    _context.Update(requisition);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitionExists(requisition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisitions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var requisition = await _context.Requisitions.FindAsync(id);
            if (requisition != null)
            {
                _context.Requisitions.Remove(requisition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitionExists(long id)
        {
            return _context.Requisitions.Any(e => e.Id == id);
        }
    }
}
