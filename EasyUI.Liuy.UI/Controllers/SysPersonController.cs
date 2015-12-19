using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.UI.Filters;

namespace EasyUI.Liuy.UI.Controllers
{
    public class SysPersonController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();
        private ISysPersonService iSysPersonService;
        //
        // GET: /SysPerson/
        public SysPersonController(ISysPersonService iService)
        {
            iSysPersonService = iService;
        }
        [VaildateLogin]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SysPerson/Details/5

        public ActionResult Details(int id = 2)
        {
            var model = from s in iSysPersonService.Search(c => c.Id == id)
                        select new
                        {
                            s.Id,
                            s.Name,
                            s.MyName,
                            s.Password,
                            s.Sex,
                            s.State,
                            RoleName = s.SysRole.Name,
                            DepName = s.SysDepartment.Name,
                            Phone = s.PhoneNumber,
                            s.City,
                            s.Type,
                            s.Village
                        };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /SysPerson/Create

        public ActionResult Create()
        {
            ViewBag.SysDepartmentId = new SelectList(db.SysDepartments, "Id", "Name");
            ViewBag.SysRoleId = new SelectList(db.SysRoles, "Id", "Name");
            return View();
        }

        //
        // POST: /SysPerson/Create

        [HttpPost]

        public ActionResult Create(SysPerson sysperson)
        {

            iSysPersonService.Add(sysperson);

            //   ViewBag.SysDepartmentId = new SelectList(db.SysDepartments, "Id", "Name", sysperson.SysDepartmentId);
            //    ViewBag.SysRoleId = new SelectList(db.SysRoles, "Id", "Name", sysperson.SysRoleId);
            return Content("OK");
        }

        //
        // GET: /SysPerson/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SysPerson sysperson = db.SysPersons.Find(id);
            if (sysperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.SysDepartmentId = new SelectList(db.SysDepartments, "Id", "Name", sysperson.SysDepartmentId);
            ViewBag.SysRoleId = new SelectList(db.SysRoles, "Id", "Name", sysperson.SysRoleId);
            return View(sysperson);
        }

        //
        // POST: /SysPerson/Edit/5

        [HttpPost]

        public ActionResult Edit(SysPerson sysperson)
        {
          
            iSysPersonService.Update(sysperson);
            return Content("OK");
        }

        //
        // GET: /SysPerson/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SysPerson sysperson = db.SysPersons.Find(id);
            if (sysperson == null)
            {
                return HttpNotFound();
            }
            return View(sysperson);
        }

        //
        // POST: /SysPerson/Delete/5

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {

            var model = iSysPersonService.Search(c => c.Id == id).First();
            iSysPersonService.Delete(model);
            return Content("OK");
        }
        public JsonResult DataGrid()
        {
            var model = from s in db.SysPersons
                        select new
                        {
                            s.Id,
                            s.Name,
                            s.MyName,
                            s.Sex,
                            RoleName = s.SysRole.Name,
                            DepartmentName = s.SysDepartment.Name,
                           s.PhoneNumber,
                            s.Password,
                            s.City,
                            s.Village,
                            s.State,
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