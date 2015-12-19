using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyUI.Liuy.Domain.Models;

namespace EasyUI.Liuy.UI.Controllers
{
    public class SysDepartmentController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();

        //
        // GET: /SysDepartment/

        public ActionResult Index()
        {
            return View(db.SysDepartments.ToList());
        }

        public JsonResult DataGrid()
        {
            var model = from s in db.SysDepartments
                        select new
                        {
                            s.Id,
                            s.Name,
                            Parent = s.SysDepartment2.Name,
                            s.Sort,
                            s.State
                        };
            return Json(model);
        }
        //
        // GET: /SysDepartment/Details/5

        public ActionResult Details(int id = 0)
        {
            SysDepartment sysdepartment = db.SysDepartments.Find(id);
            if (sysdepartment == null)
            {
                return HttpNotFound();
            }
            return View(sysdepartment);
        }

        //
        // GET: /SysDepartment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SysDepartment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SysDepartment sysdepartment)
        {
            if (ModelState.IsValid)
            {
                db.SysDepartments.Add(sysdepartment);
                db.SaveChanges();
                return Content("OK");
            }

            return View(sysdepartment);
        }

        //
        // GET: /SysDepartment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SysDepartment sysdepartment = db.SysDepartments.Find(id);
            if (sysdepartment == null)
            {
                return HttpNotFound();
            }
            return View(sysdepartment);
        }

        //
        // POST: /SysDepartment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SysDepartment sysdepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysdepartment).State = EntityState.Modified;
                db.SaveChanges();
                return Content("OK");
            }
            return View(sysdepartment);
        }

        //
        // GET: /SysDepartment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SysDepartment sysdepartment = db.SysDepartments.Find(id);
            if (sysdepartment == null)
            {
                return HttpNotFound();
            }
            return View(sysdepartment);
        }

        //
        // POST: /SysDepartment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysDepartment sysdepartment = db.SysDepartments.Find(id);
            db.SysDepartments.Remove(sysdepartment);
            db.SaveChanges();
            return Content("OK");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}