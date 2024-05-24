using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using address_bk.Models;
using Microsoft.AspNetCore.Authorization;

namespace address_bk
{
    public class BookContactsController : Controller
    {
        private readonly BookDBContext _context;

        public BookContactsController(BookDBContext context)
        {
            _context = context;
        }


        // GET: BookContacts
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: BookContacts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookContacts = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookContacts == null)
            {
                return NotFound();
            }

            return View(bookContacts);
        }

        // GET: BookContacts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookContacts/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,FatherName,MotherName,EmailAddr,AddrLine1,AddrLine2,MobileNumber,CityName")] BookContacts bookContacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookContacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookContacts);
        }

        // GET: BookContacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookContacts = await _context.Contacts.FindAsync(id);
            if (bookContacts == null)
            {
                return NotFound();
            }
            return View(bookContacts);
        }

        // POST: BookContacts/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,FatherName,MotherName,EmailAddr,AddrLine1,AddrLine2,MobileNumber,CityName")] BookContacts bookContacts)
        {
            if (id != bookContacts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookContacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookContactsExists(bookContacts.Id))
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
            return View(bookContacts);
        }

        // GET: BookContacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookContacts = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookContacts == null)
            {
                return NotFound();
            }

            return View(bookContacts);
        }

        // POST: BookContacts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var bookContacts = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(bookContacts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookContactsExists(int? id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
