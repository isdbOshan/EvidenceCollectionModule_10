using CarPartsDetailsInformations.Models;
using CarPartsDetailsInformations.ViewModel;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CarPartsDetailsInformations.Controllers
{
    public class ReportsController : Controller
    {
        VehicleInformationDbContext db = new VehicleInformationDbContext();
        //GET: Reports
        public ActionResult Index()
        {

            return View(db.Vehicles.ToList()); ;
        }
        public ActionResult VehicleReport()
        {
            var data = db.Vehicles.Include(x =>x.Customer).Select(x => new VehicleInputModel
            {
                VehicleId = x.VehicleId,
                VehicleName = x.VehicleName,
                Price = x.Price,
                IsStock = x.IsStock,
                MakeYear = x.MakeYear,
            }).ToList();
            return View(data);
        }
        public ActionResult VehiclePDF()
        {
            var data = db.Vehicles.AsEnumerable().Select(x => new VehicleInputModel
            {
                VehicleId = x.VehicleId,
                VehicleName = x.VehicleName,
                Price = x.Price,
                IsStock = x.IsStock,
                MakeYear = x.MakeYear,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            }).ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation =
                CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Vehicle.pdf");
        }
        public ActionResult CustomerReports()
        {
            var data = db.Customers.Include(x => x.Orders).Select(x => new CustomerReportView
            {
                CustomerName = x.CustomerName,
                CustomerId = x.CustomerId,
                Address = x.Address,
                Email= x.Email,
                Phone= x.Phone,
            }).ToList();
            return View(data);
        }
        public ActionResult CustomerPDF()
        {
            var data = db.Customers.AsEnumerable().Select(x => new CustomerReportView
            {
                CustomerName = x.CustomerName,
                CustomerId = x.CustomerId,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
            }).ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation =
                CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Customer.pdf");
        }
    }
}