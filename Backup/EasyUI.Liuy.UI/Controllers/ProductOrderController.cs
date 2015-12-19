using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyUI.Liuy.Domain.Models;
using EasyUI.Liuy.UI.ViewModels;

namespace EasyUI.Liuy.UI.Controllers
{
    public class ProductOrderController : Controller
    {
        //
        // GET: /Order/
        private WorkOrderContext db = new WorkOrderContext();
        private UploadInfoViewModel uploadInfo = new UploadInfoViewModel();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ImportExcel(HttpPostedFileBase Attachment)
        {
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
                string file = Path.Combine(path, fileName);
                string result = string.Empty;
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + file + "; " + "Extended Properties=Excel 8.0;";
                OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
                DataSet myDataSet = new DataSet();
                myCommand.Fill(myDataSet, "ProductOrder");
                System.Data.DataTable tab = myDataSet.Tables["ProductOrder"].DefaultView.ToTable();
                // ...用foreach把tab中数据添加到数据库 省略了如果是多表插入,可以调用存储过程.呵呵
                foreach (DataRow dr in tab.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["商品号"].ToString()))
                    {
                        ProductOrder model = new ProductOrder()
                                      {
                                          CreateTime = dr["日期"].ToString(),
                                          CustomerServices = dr["接待客服"].ToString(),
                                          Customer = dr["顾客姓名"].ToString(),
                                          Address = dr["联系地址"].ToString(),
                                          TEL = dr["联系电话"].ToString(),
                                          ProductName = dr["所购商品"].ToString(),
                                          Quantity = dr["数量"].ToString(),
                                          Price = dr["单价"].ToString(),
                                          Unit = dr["单位"].ToString(),
                                          TotalPrice = dr["总价"].ToString(),
                                          PayoutStatus = dr["支付情况"].ToString(),
                                          OrderId = dr["商品号"].ToString(),
                                          Sim = dr["sim卡号"].ToString(),
                                          SimStatus = dr["sim卡开通情况"].ToString(),
                                          LogisticsId = dr["物流单号"].ToString(),
                                          ReceivingStatus = dr["收货情况"].ToString(),
                                          CollectionStatus = dr["收款情况"].ToString(),
                                      };
                        db.ProductOrders.Add(model);
                        db.SaveChanges(); 
                    }
                    else
                    {
                          break;
                    }
                  
                }
                #region MyRegion
                //using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy("Data Source=.;Initial Catalog=WorkOrder;Integrated Security=True;MultipleActiveResultSets=True"))
                //{
                //    bcp.ColumnMappings.Add("日期", "CreateTime");
                //    bcp.ColumnMappings.Add("接待客服", "CustomerServices");
                //    bcp.ColumnMappings.Add("顾客姓名", "Customer");
                //    bcp.ColumnMappings.Add("联系地址", "Address");
                //    bcp.ColumnMappings.Add("数量", "Quantity");
                //    bcp.ColumnMappings.Add("所购商品", "ProductName");
                //    bcp.ColumnMappings.Add("联系电话", "TEL");
                //    bcp.ColumnMappings.Add("支付情况", "PayoutStatus");
                //    bcp.ColumnMappings.Add("商品号", "OrderId");
                //    bcp.ColumnMappings.Add("sim卡号", "Sim");
                //    bcp.ColumnMappings.Add("sim卡开通情况", "SimStatus");
                //    bcp.ColumnMappings.Add("物流单号", "LogisticsId");
                //    bcp.ColumnMappings.Add("收货情况", "ReceivingStatus");
                //    bcp.ColumnMappings.Add("收款情况", "CollectionStatus");
                //    bcp.BatchSize = 100;//每次传输的行数
                //    bcp.NotifyAfter = 100;//进度提示的行数
                //    bcp.DestinationTableName = "ProductOrder";//目标表
                //    bcp.WriteToServer(tab);
                //} 
                #endregion
                #region MyRegion
                //using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=WorkOrder;Integrated Security=True;MultipleActiveResultSets=True"))
                //{
                //    try
                //    {
                //        connection.Open();
                //        //给表名加上前后导符
                //        using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, null)
                //            {
                //                DestinationTableName = "ProductOrder",
                //                BatchSize = 10000
                //            })
                //        {
                //            //循环所有列，为bulk添加映射
                //            //dataTable.EachColumn(c => bulk.ColumnMappings.Add(c.ColumnName, c.ColumnName), c => !c.AutoIncrement);
                //            foreach (DataColumn dc in tab.Columns)
                //            {
                //                bulk.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                //            }
                //            bulk.WriteToServer(tab);
                //            bulk.Close();
                //        }
                //        return View();
                //    }
                //    catch (Exception exp)
                //    {
                //        return View();
                //    }
                //} 
                #endregion

                return RedirectToAction("List");
                result = "导入成功！";
                JsonResult json = new JsonResult();
                json.Data = result;
                return json;
            }

            return View();
        }

        public ActionResult ProductOrdersList()
         {
             var model= db.ProductOrders.ToList();
             return Json(model, JsonRequestBehavior.AllowGet);
         }
         public ActionResult List()
         {
             return View();
         }
    }
}
