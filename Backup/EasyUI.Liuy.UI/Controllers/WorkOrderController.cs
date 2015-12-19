using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.Domain.Abstract.IService;
using EasyUI.Liuy.UI.ViewModels;

namespace EasyUI.Liuy.UI.Controllers
{

    public class WorkOrderController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();
        UploadInfoViewModel uploadInfo = new UploadInfoViewModel();

        private IWorkOrderService iWorkOrderService;
        private IReplyMessageService iReplyMessageService;
        // GET: /WorkOrder/
        public WorkOrderController(IWorkOrderService iService, IReplyMessageService iMessageService)
        {
            iWorkOrderService = iService;
            iReplyMessageService = iMessageService;
        }
        public ActionResult Index()
        {
            var workorders = db.WorkOrders.Include(w => w.Product);
            return View(workorders.ToList());
        }

        public JsonResult DataGrid(FormCollection form)
        {
            var user = Response.Cookies[".ASPXAUTH"].Value;
            var query = from s in iWorkOrderService.Search(c => true)
                        where
                       (string.IsNullOrEmpty(form["Id"]) ? true : s.Id == form["Id"]) &&
                     (string.IsNullOrEmpty(form["State"]) ? true : s.State.Contains(form["State"])) &&
                    (string.IsNullOrEmpty(form["Type"]) ? true : s.Type.Contains(form["Type"])) &&
                  (string.IsNullOrEmpty(form["Phone"]) ? true : s.Phone.Contains(form["Phone"])) &&
                  (string.IsNullOrEmpty(form["Service"]) ? true : s.Service.Contains(form["Service"])) &&
                        (string.IsNullOrEmpty(form["ProcessingMode"]) ? true : s.ProcessingMode.Contains(form["ProcessingMode"])) &&
                        (string.IsNullOrEmpty(form["ProductId"]) ? true : s.ProductId == int.Parse(form["ProductId"])) &&
                      (string.IsNullOrEmpty(form["Cstart"]) && string.IsNullOrEmpty(form["Cend"]) ? true : DateTime.Parse(s.CreateTime) >= DateTime.Parse(form["Cstart"]) && DateTime.Parse(s.CreateTime) <= DateTime.Parse(form["Cend"])) &&
                    (string.IsNullOrEmpty(form["Astart"]) && string.IsNullOrEmpty(form["Aend"]) ? true : DateTime.Parse(s.ProcessingTime) >= DateTime.Parse(form["Astart"]) && DateTime.Parse(s.ProcessingTime) <= DateTime.Parse(form["Aend"]))

                        select new
                        {
                            s.Id,
                            s.Type,
                            s.SIM,
                            s.Product.Name,
                            s.Terminal,
                            s.Service,
                            s.Quantity,
                            s.Company,
                            s.Contact,
                            s.Sex,
                            s.Phone,
                            s.ProblemDescription,
                            s.Attachment,
                            s.ProcessingMode,
                            s.SI,
                            s.Suggestion,
                            s.State
                        };

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /WorkOrder/Details/5
        /// <summary>
        /// 待处理工单详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string id, string type)
        {
            var query = iWorkOrderService.PendingById(id);
            var List = query.ReplyMessages.ToList();
            ViewBag.model = List;
            ViewBag.type = type == "1" ? "OK" : "";
            return View(query);
        }

        /// <summary>
        /// 受理工单阶梯性回复
        /// </summary>
        /// <returns></returns>
        public ActionResult Acceptance(HttpPostedFileBase Attachment)
        {
            //回复信息
            ReplyMessage replyMessage = new ReplyMessage();
            AccountInfo account = Session["account"] as AccountInfo;
            replyMessage.WorkOrderId = Request["Id"];
            replyMessage.Attachment = Request["hid-Attachment"];
            replyMessage.Suggestion = Request["Suggestion"];
            replyMessage.ProcessingMode = Request["ProcessingMode"];
            replyMessage.SI = Request["SI"];
            replyMessage.AcceptanceDep = account.Department;
            replyMessage.AcceptancePer = account.MyName;
            replyMessage.AcceptancePhone = account.TEL;
            replyMessage.CreateTime = Request["CreateTime"];
            replyMessage.ProcessingTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (Request["ProcessingMode"] == "直接归档")
            {
                //工单处理完成改变状态
                var model = iWorkOrderService.FindById(Request["Id"]);
                model.State = "完成";
                iWorkOrderService.Update(model);
                iReplyMessageService.AddAcceptance(replyMessage);
            }
            else
            {
                var model = iWorkOrderService.FindById(Request["Id"]);
                model.State = "待处理";
                model.ProcessingMode = "转相关SI";
                iWorkOrderService.Update(model);
                iReplyMessageService.AddAcceptance(replyMessage);
            }

            //上传文件
            uploadInfo.IsReady = false;


            if (!string.IsNullOrEmpty(Request["hid-Attachment"]))
            {

                string path = this.Server.MapPath(@"../Uploads");
                string fileName = Path.GetFileName(Attachment.FileName);

                uploadInfo.ContentLength = Attachment.ContentLength;
                uploadInfo.FileName = fileName;
                uploadInfo.UploadedLength = 0;

                uploadInfo.IsReady = true;

                int bufferSize = 1;
                byte[] buffer = new byte[bufferSize];



                using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    while (uploadInfo.UploadedLength < uploadInfo.ContentLength)
                    {
                        int bytes = Attachment.InputStream.Read(buffer, 0, bufferSize);
                        fs.Write(buffer, 0, bytes);
                        uploadInfo.UploadedLength += bytes;
                    }
                }
            }
            return Content("OK");

        }

        /// <summary>
        /// 工单查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Query()
        {
            var model = iWorkOrderService.Search(c => c.State == "待处理");
            return View(model);
        }

        //
        // GET: /WorkOrder/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.Id = DateTime.Now.ToString("yyMMddHHmms");
            return View();
        }

        //
        // POST: /WorkOrder/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase Attachment)
        {
            WorkOrder workOrder = new WorkOrder();


            workOrder.Id = Request["Id"];
            workOrder.Type = Request["Type"];
            workOrder.SIM = Request["SIM"];
            workOrder.ProductId = int.Parse(Request["ProductId"]);
            workOrder.Terminal = Request["Terminal"];
            workOrder.Service = Request["Service"];
            workOrder.Quantity = int.Parse(Request["Quantity"]);
            workOrder.Company = Request["Company"];
            workOrder.Contact = Request["Contact"];
            workOrder.Sex = Request["Sex"];
            workOrder.Phone = Request["Phone"];
            workOrder.ProblemDescription = Request["ProblemDescription"];
            workOrder.Attachment = Request["hid-Attachment"];
            workOrder.ProcessingMode = Request["ProcessingMode"];
            workOrder.SI = Request["SI"];
            workOrder.Suggestion = Request["Suggestion"];
            workOrder.State = Request["State"];

            workOrder.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            iWorkOrderService.Add(workOrder);


            #region MyRegion
            //if (Filedata == null ||
            //        string.IsNullOrEmpty(Filedata.FileName) ||
            //        Filedata.ContentLength == 0)
            //{
            //    return this.HttpNotFound();
            //}

            //// 保存到 ~/photos 文件夹中，名称不变
            //string filename = System.IO.Path.GetFileName(Filedata.FileName);
            //string virtualPath =
            //    string.Format("UploadFile/{0}", filename);
            //// 文件系统不能使用虚拟路径
            //string path = this.Server.MapPath(virtualPath);

            //Filedata.SaveAs(path); 
            #endregion


            uploadInfo.IsReady = false;


            #region MyRegion
            if (!string.IsNullOrEmpty(Request["hid-Attachment"]))
            {

                string path = this.Server.MapPath(@"../Uploads");
                string fileName = Path.GetFileName(Attachment.FileName);

                uploadInfo.ContentLength = Attachment.ContentLength;
                uploadInfo.FileName = fileName;
                uploadInfo.UploadedLength = 0;

                uploadInfo.IsReady = true;

                int bufferSize = 1;
                byte[] buffer = new byte[bufferSize];



                using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    while (uploadInfo.UploadedLength < uploadInfo.ContentLength)
                    {
                        int bytes = Attachment.InputStream.Read(buffer, 0, bufferSize);
                        fs.Write(buffer, 0, bytes);
                        uploadInfo.UploadedLength += bytes;
                    }
                }
            }
            #endregion;


            return Content(workOrder.Id);

        }

        //
        // GET: /WorkOrder/Edit/5

        public ActionResult Edit(string id = null)
        {
            WorkOrder workorder = db.WorkOrders.Find(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", workorder.ProductId);
            return View(workorder);
        }

        //
        // POST: /WorkOrder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkOrder workorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", workorder.ProductId);
            return View(workorder);
        }

        //
        // GET: /WorkOrder/Delete/5

        public ActionResult Delete(string id = null)
        {
            WorkOrder workorder = db.WorkOrders.Find(id);
            if (workorder == null)
            {
                return HttpNotFound();
            }
            return View(workorder);
        }

        //
        // POST: /WorkOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            WorkOrder workorder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 待处理工单
        /// </summary>
        /// <returns></returns>
        public JsonResult PendingList(FormCollection form)
        {
            int pageSize = 10;
            int pageIndex = 1;
            int.TryParse(form["page"], out pageIndex);
            int.TryParse(form["rows"], out pageSize);
            pageSize = pageSize <= 0 ? 10 : pageSize;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var model = iWorkOrderService.PendingList(pageIndex, pageSize, form["type"]);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pending(string type)
        {
            ViewBag.type = type;
            return View();
        }

        /// <summary>
        /// 工单回复信息列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ReplyMessageList(string id)
        {
            var model = iReplyMessageService.GetReplyMessageList(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportExcel(FormCollection form)
        {


            //var sbHtml = new StringBuilder();
            //sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            //sbHtml.Append("<tr>");
            //var lstTitle = new List<string> { "编号", "姓名", "年龄", "创建时间" };
            //foreach (var item in lstTitle)
            //{
            //    sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
            //}
            //sbHtml.Append("</tr>");

            //for (int i = 0; i < 1000; i++)
            //{
            //    sbHtml.Append("<tr>");
            //    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", i);
            //    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>屌丝{0}号</td>", i);
            //    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", new Random().Next(20, 30) + i);
            //    sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", DateTime.Now);
            //    sbHtml.Append("</tr>");
            //}
            //sbHtml.Append("</table>");
            //byte[] fileContents = Encoding.UTF8.GetBytes(sbHtml.ToString());
            //var fileStream = new MemoryStream(fileContents);
            //return File(fileStream, "application/ms-excel", "fileStream.xls");

            //获取查询后条件的数据
            var query = from s in iWorkOrderService.Search(c => true)
                        where
                       (string.IsNullOrEmpty(form["hid"]) ? true : s.Id == form["hid"]) &&
                     (string.IsNullOrEmpty(form["hState"]) ? true : s.State.Contains(form["hState"])) &&
                    (string.IsNullOrEmpty(form["hType"]) ? true : s.Type.Contains(form["hType"])) &&
                  (string.IsNullOrEmpty(form["hPhone"]) ? true : s.Phone.Contains(form["hPhone"])) &&
                  (string.IsNullOrEmpty(form["hService"]) ? true : s.Service.Contains(form["hService"])) &&
                        (string.IsNullOrEmpty(form["hProcessingMode"]) ? true : s.ProcessingMode.Contains(form["hProcessingMode"])) &&
                        (string.IsNullOrEmpty(form["hProductId"]) ? true : s.ProductId == int.Parse(form["hProductId"])) &&
                      (string.IsNullOrEmpty(form["hCstart"]) && string.IsNullOrEmpty(form["hCend"]) ? true : DateTime.Parse(s.CreateTime) >= DateTime.Parse(form["hCstart"]) && DateTime.Parse(s.CreateTime) <= DateTime.Parse(form["hCend"])) &&
                    (string.IsNullOrEmpty(form["hAstart"]) && string.IsNullOrEmpty(form["hAend"]) ? true : DateTime.Parse(s.ProcessingTime) >= DateTime.Parse(form["hAstart"]) && DateTime.Parse(s.ProcessingTime) <= DateTime.Parse(form["hAend"]))

                        select new
                        {
                            s.Id,
                            s.Type,
                            s.SIM,
                            s.Product.Name,
                            s.Terminal,
                            s.Service,
                            s.Quantity,
                            s.Company,
                            s.Contact,
                            s.Sex,
                            s.Phone,
                            s.ProblemDescription,
                            s.Attachment,
                            s.ProcessingMode,
                            s.SI,
                            s.Suggestion,
                            s.State
                        };



            #region MyRegion
            System.Web.UI.WebControls.DataGrid dgExport = null;

            // 当前对话  

            System.Web.HttpContext curContext = System.Web.HttpContext.Current;

            // IO用于导出并返回excel文件  

            System.IO.StringWriter strWriter = null;

            System.Web.UI.HtmlTextWriter htmlWriter = null;

            string filename = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_"

            + DateTime.Now.Hour + "_" + DateTime.Now.Minute;

            byte[] str = null;



            // 设置编码和附件格式

            curContext.Response.Charset = "GB2312";

            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");

            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文

            curContext.Response.ContentType = "application/vnd.ms-excel";

            //System.Text.Encoding.UTF8;

            // 导出excel文件  

            strWriter = new System.IO.StringWriter();

            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);



            // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid  

            dgExport = new System.Web.UI.WebControls.DataGrid();

            dgExport.DataSource = query;// db.WorkOrders.ToList();

            dgExport.AllowPaging = false;

            dgExport.DataBind();

            dgExport.RenderControl(htmlWriter);

            // 返回客户端  

            str = System.Text.Encoding.UTF8.GetBytes(strWriter.ToString());


            return File(str, "attachment;filename=" + filename + ".xls");
            #endregion

        }


        public ActionResult Recover()
        {
            return View();
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}