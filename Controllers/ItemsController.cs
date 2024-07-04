using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        private readonly StoreManagementSystemContext _context;

        public ItemsController(StoreManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var itemQuery = _context.Items.Include(i => i.Category).Include(i => i.Unit);

            return View(await itemQuery.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {

            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Symbol");

            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,UnitId,Description,Ref,GroupCode")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.CreatedOn = DateTime.UtcNow;
                item.UpdatedOn = DateTime.UtcNow;

                _context.Add(item);

                await _context.SaveChangesAsync();


                var category = await _context.ItemCategories.FindAsync(item.CategoryId);

                item.GroupCode = "00000" + item.Id.ToString() + category.GroupCode;

                _context.Update(item);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.CategoryId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Symbol", item.UnitId);

            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.CategoryId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Symbol", item.UnitId);

            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CategoryId,UnitId,Description,GroupCode,Ref,Id")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldItem = await _context.Items.AsNoTracking().FirstOrDefaultAsync( i => i.Id == item.Id);

                    var category = await _context.ItemCategories.FindAsync(item.CategoryId);

                    item.GroupCode = "00000" + item.Id.ToString() + category.GroupCode;

                    item.UpdatedOn = DateTime.UtcNow;
                    item.CreatedOn = oldItem.CreatedOn;

                    _context.Update(item);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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

            ViewData["CategoryId"] = new SelectList(_context.ItemCategories, "Id", "Name", item.CategoryId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Symbol", item.UnitId);

            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(long id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
