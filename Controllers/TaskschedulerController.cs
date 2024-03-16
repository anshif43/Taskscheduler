using Microsoft.AspNetCore.Mvc;
using Taskscheduler.Data;
using Taskscheduler.Models;

namespace Taskscheduler.Controllers
{
    public class TaskschedulerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskschedulerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index( int pg=1)
        {
            List<Taskschedule> taskschedules = _context.Taskschedules.ToList();
            const int pagesize = 5;
            if(pg<1)
                pg = 1;
            int count = taskschedules.Count();
            var pager = new Pager(count, pg, pagesize);
            int skip = (pg-1) * pagesize;
            var data = taskschedules.Skip(skip).Take(pager.Pagesize).ToList();
            this.ViewBag.Pager = pager;
            
           
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Taskschedule obj)
        {
            if (ModelState.IsValid)
            {
                _context.Taskschedules.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Taskschedule task = _context.Taskschedules.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(Taskschedule obj)
        {
            if (ModelState.IsValid)
            {
                _context.Taskschedules.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Taskschedule task = _context.Taskschedules.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Taskschedule task = _context.Taskschedules.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Taskschedule task = _context.Taskschedules.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
    }
}
