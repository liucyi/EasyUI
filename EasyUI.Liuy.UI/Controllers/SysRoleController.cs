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
    public class SysRoleController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();

        //
        // GET: /SysRole/

        public ActionResult Index()
        {
            return View(db.SysRoles.ToList());
             
        }

        //
        // GET: /SysRole/Details/5

        public ActionResult Details(int id = 0)
        {
            SysRole sysrole = db.SysRoles.Find(id);
            if (sysrole == null)
            {
                return HttpNotFound();
            }
            return View(sysrole);
        }

        //
        // GET: /SysRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SysRole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SysRole sysrole)
        {
            if (ModelState.IsValid)
            {
                db.SysRoles.Add(sysrole);
                db.SaveChanges();
                return Content("OK");
            }

            return View(sysrole);
        }

        //
        // GET: /SysRole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SysRole sysrole = db.SysRoles.Find(id);
            if (sysrole == null)
            {
                return HttpNotFound();
            }
            return View(sysrole);
        }

        //
        // POST: /SysRole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SysRole sysrole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysrole).State = EntityState.Modified;
                db.SaveChanges();
                return Content("OK");
            }
            return View(sysrole);
        }

        //
        // GET: /SysRole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SysRole sysrole = db.SysRoles.Find(id);
            if (sysrole == null)
            {
                return HttpNotFound();
            }
            return View(sysrole);
        }

        //
        // POST: /SysRole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysRole sysrole = db.SysRoles.Find(id);
            db.SysRoles.Remove(sysrole);
            db.SaveChanges();
            return Content("OK");
        }

        public JsonResult GetRoleList()
        {
            var model = from s in
                            db.SysRoles.ToList()
                        select new
                            {
                                s.Id,
                                s.Name,
                                s.Description,
                                s.Type
                            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}