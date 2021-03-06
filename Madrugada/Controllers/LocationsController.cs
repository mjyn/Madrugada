﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Madrugada.Data;
using Madrugada.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Madrugada.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LocationsController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Locations.Include(l => l.Work);

            var rqf = Request.HttpContext.Features.Get<Microsoft.AspNetCore.Localization.IRequestCultureFeature>();
            // Culture contains the information of the requested culture
            var culture = rqf.RequestCulture.Culture;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var location = await _context.Locations
                .Include(l => l.Work)
                .Include(l => l.Images).ThenInclude(i => i.CompareImage)
                .Include(l => l.Messages).ThenInclude(i => i.ReplyMessage)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(new ViewModels.LocationDetail()
            {
                Location = location,
                Message = new Message()
            });
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewData["WorkId"] = new SelectList(_context.Works, "WorkId", "Name");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (location.StreetViewHeading == null)
                location.StreetViewHeading = 0;
            if (location.StreetViewPitch == null)
                location.StreetViewPitch = 0;
            ViewData["WorkId"] = new SelectList(_context.Works, "WorkId", "Name", location.WorkId);
            return View(location);
        }

        // GET: Locations/Edit/5
        [Authorize(Roles = "Admin, Author")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["WorkId"] = new SelectList(_context.Works, "WorkId", "Name", location.WorkId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Author")]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,Name,WorkId,Text,Address,Latitude,Longitude,HasStreetView,StreetViewLatitude,StreetViewLongitude,StreetViewHeading,StreetViewPitch,IsPublished")] Location location)
        {
            if (id != location.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationId))
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
            ViewData["WorkId"] = new SelectList(_context.Works, "WorkId", "Name", location.WorkId);
            return View(location);
        }

        // GET: Locations/Delete/5
        [Authorize(Roles = "Admin, Author")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .Include(l => l.Work)
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Author")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
