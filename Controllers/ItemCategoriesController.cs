using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data;
using StoreManagementSystem.Models;

namespace StoreManagementSystem.Controllers
{
    public class ItemCategoriesController : Controller
    {
        private readonly StoreManagementSystemContext _context;

        public ItemCategoriesController(StoreManagementSystemContext context)
        {
            _context = context;
        }

        // GET: ItemCategories
        public async Task<IActionResult> Index()
        {
            var itemCategoryQuery = _context.ItemCategories.Include(i => i.ParentCategory);

            return View(await itemCategoryQuery.ToListAsync());
        }


        // GET: ItemCategories/Create
        public async Task<IActionResult> Create()
        {
           
            ViewData["ParentCategoryId"] = await GetSelectList();

            return View();
        }

        // POST: ItemCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentCategoryId,Name,Description,GroupCode")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {

                itemCategory.IsActive = true;
                itemCategory.CreatedOn = DateTime.UtcNow;
                itemCategory.UpdatedOn = DateTime.UtcNow;

                _context.Add(itemCategory);

                await _context.SaveChangesAsync();

                var parentCategory = await _context.ItemCategories.FindAsync(itemCategory.ParentCategoryId);

                itemCategory.GroupCode = "00000" + itemCategory.Id.ToString() + parentCategory?.GroupCode;

                _context.Update(itemCategory);

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            ViewData["ParentCategoryId"] = await GetSelectList();
            
            return View(itemCategory);
        }

        // GET: ItemCategories/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            ViewData["ParentCategoryId"] = await GetSelectList();
            
            return View(itemCategory);
        }

        // POST: ItemCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ParentCategoryId,Name,Description,Id,GroupCode,IsActive")] ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var oldCategory = await _context.ItemCategories.AsNoTracking().SingleOrDefaultAsync( ic => ic.Id == itemCategory.Id);

                    var parentCategory = await _context.ItemCategories.FindAsync(itemCategory.ParentCategoryId);
                    itemCategory.GroupCode = "00000" + itemCategory.Id.ToString() + parentCategory?.GroupCode;
                    itemCategory.UpdatedOn = DateTime.UtcNow;

                    itemCategory.CreatedOn = oldCategory.CreatedOn;

                    _context.Update(itemCategory);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemCategory.Id))
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
            
            ViewData["ParentCategoryId"] = await GetSelectList();

            return View(itemCategory);
        }

        // GET: ItemCategories/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .Include(i => i.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // POST: ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory != null)
            {
                _context.ItemCategories.Remove(itemCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryExists(long id)
        {
            return _context.ItemCategories.Any(e => e.Id == id);
        }


        public async Task<List<SelectListItem>> GetSelectList()
        {
            var categories = await _context.ItemCategories.ToListAsync();

            var categorySelectList = new SelectList(categories, "Id", "Name");

            // Create a list of SelectListItem with a default option
            var categorySelectListWithDefault = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select an option",
                    Value = string.Empty,
                    Selected = true
                }
            };

           categorySelectListWithDefault.AddRange(categorySelectList);

           return categorySelectListWithDefault;
        }
    }
}
