using Project_09_Mid_Term_.Models;
using Project_09_Mid_Term_.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Entity;

namespace Project_09_Mid_Term_.Controllers
{

    public class CrystalReportController : Controller
    {
        ComputerDbContext db = new ComputerDbContext();
        // GET: CrystalReport
        public ActionResult Index()
        {
            return View(db.Computers.ToList());
        }
        public ActionResult ComputerPDF()
        {
            var data = db.Computers.AsEnumerable().Select(x => new ComputerViewModel
            {
                ComputerId = x.ComputerId,
                ComputerName = x.ComputerName,
                Price = x.Price,
                MGFDate = x.MGFDate,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Computers.pdf");

        }
        public ActionResult ComputerExcel()
        {
            var data = db.Computers.AsEnumerable().Select(x => new ComputerViewModel
            {
                ComputerId = x.ComputerId,
                ComputerName = x.ComputerName,
                Price = x.Price,
                MGFDate = x.MGFDate,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Computers.xls");

        }
        public ActionResult CustomerReport()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult CustomerPDF()
        {
            var data = db.Customers.AsEnumerable().Select(x => new CustomerReportModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                phone = x.phone,
                Address = x.Address,
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Customers.pdf");

        }
        public ActionResult CustomerExcel()
        {
            var data = db.Customers.AsEnumerable().Select(x => new CustomerReportModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                phone = x.phone,
                Address = x.Address,
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Customers.xls");

        }
        public ActionResult OrderReport()
        {
            var data = db.Orders.Include(x => x.Customer).Select(x => new OrderReportModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                DelivaryDate = x.DelivaryDate,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.CustomerName
            }).ToList();
            return View(data);
        }
        public ActionResult OrderPDF()
        {
            var data = db.Orders.Include(x => x.Customer).Select(x => new OrderReportModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                DelivaryDate = x.DelivaryDate,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.CustomerName
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport4.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Orders.pdf");

        }
        public ActionResult OrderExcel()
        {
            var data = db.Orders.Include(x => x.Customer).Select(x => new OrderReportModel
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                DelivaryDate = x.DelivaryDate,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.CustomerName
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport4.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Orders.xls");

        }
        public ActionResult OrderItemReport()
        {
            var data = db.OrdersItem.Include(x => x.Computer).Include(x => x.Order).Select(x => new OrderItemReport
            {
                OrderItemId = x.OrderItemId,
                Quantity = x.Quantity,
                ComputerId = x.ComputerId,
                ComputerName = x.Computer.ComputerName,
                OrderId = x.OrderId,
                OrderDate = x.Order.OrderDate
            }).ToList();
            return View(data);
        }
        public ActionResult OrderItemPDF()
        {
            var data = db.OrdersItem.Include(x => x.Computer).Include(x => x.Order).Select(x => new OrderItemReport
            {
                OrderItemId = x.OrderItemId,
                Quantity = x.Quantity,
                ComputerId = x.ComputerId,
                ComputerName = x.Computer.ComputerName,
                OrderId = x.OrderId,
                OrderDate = x.Order.OrderDate
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport5.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "OrdersItem.pdf");

        }
        public ActionResult OrderItemExcel()
        {
            var data = db.OrdersItem.Include(x => x.Computer).Include(x => x.Order).Select(x => new OrderItemReport
            {
                OrderItemId = x.OrderItemId,
                Quantity = x.Quantity,
                ComputerId = x.ComputerId,
                ComputerName = x.Computer.ComputerName,
                OrderId = x.OrderId,
                OrderDate = x.Order.OrderDate
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport5.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "OrdersItem.xls");

        }
    }
}