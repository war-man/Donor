using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Donor;
using Donor.Entity;
using System.Web.Helpers;
using Donor.Models;

namespace Donor.Controllers
{
    public class IamDonorController : Controller
    {
        private readonly DonorContext _context;

        public IamDonorController(DonorContext context)
        {
            _context = context;
        }

        // GET: DonorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donors.ToListAsync());
        }
        [HttpGet]
        public JsonResult Search(string bloodGroup,string location,string type)
        {
            var data = _context.Donors.Where(a=>a.BoodGroup==bloodGroup && a.DonateType==type && (a.District.Contains(location)||a.Thana.Contains(location))).Take(10).ToList();
            return Json(data);
        }

        // GET: DonorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorModel = await _context.Donors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donorModel == null)
            {
                return NotFound();
            }

            return View(donorModel);
        }

        // GET: DonorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,District,Thana,Address,DonateType,PreviewesHealthProblem,BoodGroup,RecentDrag,Others,Approved,Id,CreatedDate")] DonorModel donorModel)
        {
            if (ModelState.IsValid)
            {
                var alreadyExists = _context.Donors.Where(a => a.Phone == donorModel.Phone).FirstOrDefault();
                if (alreadyExists!=null)
                {
                    ViewBag.Msg = "You already a Donor. Thanks to be a Donor!";
                    return View();
                }
                _context.Add(donorModel);
                await _context.SaveChangesAsync();
                //  return RedirectToAction(nameof(Index));
                ViewBag.Msg = "Congratulation!! and Thanks to be a Donor!";
            }
            return View();
        }

        // GET: DonorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorModel = await _context.Donors.FindAsync(id);
            if (donorModel == null)
            {
                return NotFound();
            }
            return View(donorModel);
        }

        // POST: DonorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,District,Thana,Address,DonateType,PreviewesHealthProblem,BoodGroup,RecentDrag,Others,Approved,Id,CreatedDate")] DonorModel donorModel)
        {
            if (id != donorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorModelExists(donorModel.Id))
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
            return View(donorModel);
        }

        // GET: DonorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donorModel = await _context.Donors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donorModel == null)
            {
                return NotFound();
            }

            return View(donorModel);
        }
        public IActionResult Remove()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveByPhone(RemoveRequest removeRequest)
        {
            if (string.IsNullOrEmpty(removeRequest.PhoneNumber))
            {
                return NotFound();
            }
            var donorModel = await _context.Donors
    .FirstOrDefaultAsync(m => m.Phone == removeRequest.PhoneNumber);
            if (donorModel == null)
            {
                return NotFound();
            }
            if (removeRequest.HidePhone)
            {
                donorModel.Address = removeRequest.Address;
                _context.Donors.Update(donorModel);
                _context.SaveChanges();
            }
            ViewBag.Msg = "Thanks, Your request sucessfully executed!";
            return View("Remove");
        }

        // POST: DonorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donorModel = await _context.Donors.FindAsync(id);
            _context.Donors.Remove(donorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorModelExists(int id)
        {
            return _context.Donors.Any(e => e.Id == id);
        }
    }
}
