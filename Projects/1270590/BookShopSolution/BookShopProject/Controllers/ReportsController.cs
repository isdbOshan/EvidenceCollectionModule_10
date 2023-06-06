using BookShopProject.Models;
using BookShopProject.ViewModels;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopProject.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Reports
        BookDbContext db = new BookDbContext();
        public ActionResult Publisher()
        {
            return View(db.Publishers.ToList());
        }
        public ActionResult PublisherPDF()
        {
           var data = db.Publishers.ToList();
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

            return File(stream, "application/pdf", "Publisher.pdf");
        }
        public ActionResult Authors()
        {
            return View(db.Authors.ToList());
        }
        public ActionResult AuthorReport()
        {
            var data = db.Authors.AsEnumerable().Select(x => new AuthorViewModel
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                Age = x.Age,
                Gender = x.Gender,
                Phone = x.Phone,
                Email = x.Email,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"), x.Picture))
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Author.pdf");
        }


        public ActionResult AuthorExcel()
        {
            var data = db.Authors.AsEnumerable().Select(x => new AuthorViewModel
            {
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                Age = x.Age,
                Gender = x.Gender,
                Phone = x.Phone,
                Email = x.Email,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"), x.Picture))
            }).ToList();

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Author.xls");
        }

        public ActionResult AllTable()
        {
            var data = db.orders.Include(x => x.Book).Include(x => x.Book.Author).Include(x => x.Book.Author.Publisher).ToList();
            return View(data);
        }
        public ActionResult AllTablePDF()
        {
            var data = db.orders.Include(x => x.Book).Include(x => x.Book.Author).Include(x => x.Book.Author.Publisher).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport3.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "AllTableData.xls");
        }

        public ActionResult Books()
        {
            var data = db.orders.Include(x => x.Book).Select(x => new Order
            {
                
                Quantity = x.Quantity,
                Price = x.Price,
                OrderDate = x.OrderDate,
                BookId = x.BookId
            }).ToList();
            return View(data);
        }
 
        public ActionResult BookPDF()
        {
            var data = db.orders.Include(x => x.Book).Select(x => new OrderViewModel
            {
                Quantity = x.Quantity,
                Price = x.Price,
                OrderDate = x.OrderDate,
                BookId = x.BookId
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

            return File(stream, "application/pdf", "Book.pdf");
        }

    }
}