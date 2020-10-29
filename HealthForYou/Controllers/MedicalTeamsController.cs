using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HealthForYou.Areas.Identity.Data;
using HealthForYou.Data;
using HealthForYou.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HealthForYou.Controllers
{
    public class MedicalTeamsController : Controller
    {
        private readonly HealthForYouContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<HealthForYouUser> _userManager;
        private readonly SignInManager<HealthForYouUser> _signInManager;



        public MedicalTeamsController(HealthForYouContext context, Microsoft.AspNetCore.Identity.UserManager<HealthForYouUser> userManager,
            SignInManager<HealthForYouUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;


        }
        public async Task<IActionResult> IndexAsync(string searchString,int yearsOfExp,string Expertise)
        {
            var Doctors = from m in _context.MedicTeam
                           select m;
            if(!String.IsNullOrEmpty(searchString))
            {
                Doctors = Doctors.Where(S => S.FullName.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(Expertise))
            {
                Doctors = Doctors.Where(S => S.Expertise.Contains(Expertise));
            }


          if(yearsOfExp!=0)
            {
                Doctors = Doctors.Where(S => S.YearsOfexp >= yearsOfExp);
            }



            return View(await Doctors.ToListAsync());
        }
        public async Task<IActionResult> FamilyDoctors( string Expertise)
        {
            var Doctors = from m in _context.MedicTeam
                          select m;
           

            if (!String.IsNullOrEmpty(Expertise))
            {
                Doctors = Doctors.Where(S => S.Expertise.Contains(Expertise));
            }

            return View(await Doctors.ToListAsync());
        }

        public async Task<IActionResult> PlasticDoctors(string Expertise)
        {
            var Doctors = from m in _context.MedicTeam
                          select m;


            if (!String.IsNullOrEmpty(Expertise))
            {
                Doctors = Doctors.Where(S => S.Expertise.Contains(Expertise));
            }

            return View(await Doctors.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,FullName,Gender,Location,Expertise,YearsOfexp")] MedicalTeam doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.MedicTeam
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.MedicTeam.FindAsync(id);
            _context.MedicTeam.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RegisterAsync(int?id,string username)
        {
            var doctors = from m in _context.MedicTeam
                         select m;
            var Users = from m in _context.Users
                       select m;
            var userid = Users.Where(u => u.UserName.Equals(username)).First().Id;
            var time = DateTime.Now;
            var Appointment = new Appointment { Time = time, UserId = userid, Doctorid = (int)id };
            _context.Appointments.Add(Appointment);
            _context.SaveChanges();
            var doctor = await _context.MedicTeam
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            return View(doctor);

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.MedicTeam
               .Include(s => s.Appointments).ThenInclude(e => e.User).AsNoTracking().FirstOrDefaultAsync(m => m.DoctorId == id);
            return View(doctor);
        }

        public async Task<IActionResult> NewAppoitment(string searchString, int yearsOfExp, string Expertise)
        {
            var Doctors = from m in _context.MedicTeam
                          select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                Doctors = Doctors.Where(S => S.FullName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(Expertise))
            {
                Doctors = Doctors.Where(S => S.Expertise.Contains(Expertise));
            }


            if (yearsOfExp != 0)
            {
                Doctors = Doctors.Where(S => S.YearsOfexp >= yearsOfExp);
            }



            return View(await Doctors.ToListAsync());
        }
    }
}
