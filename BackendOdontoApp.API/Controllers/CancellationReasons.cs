using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Controllers
{
    [Authorize(Roles = "Odontologo")]
    public class CancellationReasons : Controller
    {
        private readonly DataContext _context;

        public CancellationReasons(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CancellationReasons.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CancellationReason cancellationReason)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(cancellationReason);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este motivo de cancelación");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);

                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(cancellationReason);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CancellationReason cancellationReason = await _context.CancellationReasons.FindAsync(id);
            if (cancellationReason == null)
            {
                return NotFound();
            }
            return View(cancellationReason);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CancellationReason cancellationReason)
        {
            if (id != cancellationReason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancellationReason);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este motivo de cancelación");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);

                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(cancellationReason);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CancellationReason cancellationReason = await _context.CancellationReasons.FirstOrDefaultAsync(m => m.Id == id);

            if (cancellationReason == null)
            {
                return NotFound();
            }

            _context.CancellationReasons.Remove(cancellationReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
