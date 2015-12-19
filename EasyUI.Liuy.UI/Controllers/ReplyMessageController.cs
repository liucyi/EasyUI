using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Abstract.IService;
namespace EasyUI.Liuy.UI.Controllers
{
    public class ReplyMessageController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();
        //
        // GET: /ReplyMessage/

        public ActionResult Index()
        {
            var replymessages = db.ReplyMessages.Include(r => r.WorkOrder);
            return View(replymessages.ToList());
        }
         
        // GET: /ReplyMessage/Details/5

        public ActionResult Details(int id = 0)
        {
            ReplyMessage replymessage = db.ReplyMessages.Find(id);
            if (replymessage == null)
            {
                return HttpNotFound();
            }
            return View(replymessage);
        }

        //
        // GET: /ReplyMessage/Create

        public ActionResult Create()
        {
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "Id", "Type");
            return View();
        }

        //
        // POST: /ReplyMessage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyMessage replymessage)
        {
            if (ModelState.IsValid)
            {
                db.ReplyMessages.Add(replymessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "Id", "Type", replymessage.WorkOrderId);
            return View(replymessage);
        }

        //
        // GET: /ReplyMessage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReplyMessage replymessage = db.ReplyMessages.Find(id);
            if (replymessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "Id", "Type", replymessage.WorkOrderId);
            return View(replymessage);
        }

        //
        // POST: /ReplyMessage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReplyMessage replymessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(replymessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "Id", "Type", replymessage.WorkOrderId);
            return View(replymessage);
        }

        //
        // GET: /ReplyMessage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReplyMessage replymessage = db.ReplyMessages.Find(id);
            if (replymessage == null)
            {
                return HttpNotFound();
            }
            return View(replymessage);
        }

        //
        // POST: /ReplyMessage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReplyMessage replymessage = db.ReplyMessages.Find(id);
            db.ReplyMessages.Remove(replymessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}