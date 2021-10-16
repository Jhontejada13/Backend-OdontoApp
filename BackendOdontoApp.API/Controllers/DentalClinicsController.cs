using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Controllers
{
    public class DentalClinicsController : Controller
    {
        private readonly DataContext _context;

        public DentalClinicsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DentalClinics.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DentalClinic dentalClinic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(dentalClinic);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta clínica");
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

            return View(dentalClinic);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DentalClinic dentalClinic = await _context.DentalClinics.FindAsync(id);
            if (dentalClinic == null)
            {
                return NotFound();
            }
            return View(dentalClinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DentalClinic dentalClinic)
        {
            if (id != dentalClinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dentalClinic);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta clínica");
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
            return View(dentalClinic);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DentalClinic dentalClinic = await _context.DentalClinics.FirstOrDefaultAsync(m => m.Id == id);

            if (dentalClinic == null)
            {
                return NotFound();
            }

            _context.DentalClinics.Remove(dentalClinic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
