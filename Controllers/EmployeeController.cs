using ASP_NET_HW_12.Data;
using ASP_NET_HW_12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_HW_12.Controllers {
    public class EmployeeController : Controller {
        private readonly DataContext _context;

        private const int PageSize = 5;

        public EmployeeController(DataContext context) {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string? filter, int page = 1, SortState sortOrder = SortState.NameAsc) {
            ViewData["CurrentFilter"] = filter;
            if (string.IsNullOrWhiteSpace(filter)) filter = "";
            
            IQueryable<Employee> employees = _context.Employees!.Where(e => e.FullName!.Contains(filter))
                .Include(e => e.Company)
                .Include(e => e.Insurances);

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["SalarySort"] = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;
            ViewData["CompanySort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;
            ViewData["CurrentSort"] = sortOrder;

            employees = sortOrder switch {
                SortState.NameDesc => employees.OrderByDescending(e => e.FullName),
                SortState.CompanyAsc => employees.OrderBy(e => e.Company!.Name),
                SortState.CompanyDesc => employees.OrderByDescending(e => e.Company!.Name),
                SortState.SalaryAsc => employees.OrderBy(e => e.Salary),
                SortState.SalaryDesc => employees.OrderByDescending(e => e.Salary),
                _ => employees.OrderBy(e => e.FullName)
            };

            var count = await employees.CountAsync();
            var items = await employees.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();

            var pageViewModel = new PageViewModel(count, page, PageSize);
            var viewModel = new IndexViewModel {
                PageViewModel = pageViewModel,
                Objects = items
            };

            return View(viewModel);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || _context.Employees == null) {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create() {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,CompanyId,Position,Salary")] Employee employee) {
            if (ModelState.IsValid) {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null || _context.Employees == null) {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) {
                return NotFound();
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,FullName,CompanyId,Position,Salary")]
            Employee employee) {
            if (id != employee.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!EmployeeExists(employee.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Employees == null) {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Employees == null) {
                return Problem("Entity set 'DataContext.Employees'  is null.");
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee != null) {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id) {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}