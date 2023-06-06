
using CrystalDecisions.CrystalReports.Engine;
using EquipmentPart_Mid_Month_Project.Models;
using EquipmentPart_Mid_Month_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentPart_Mid_Month_Project.Controllers
{
    public class CrystalController : Controller
    {
        EquipmentDbContext db = new EquipmentDbContext();
        public ActionResult Index()
        {

            return View(db.Equipments.ToList());
        }
        public ActionResult PartReport()
        {
            var data = db.Parts.Include(x => x.Equipment).Select(x => new PartReportModel
            {
                EquipmentName = x.Equipment.EquipmentName,
                EquipmentId = x.EquipmentId,
                PartId = x.PartId,
                PartName = x.PartName,
                Quantity = x.Quantity
            }).ToList();
            return View(data);
        }
        public ActionResult EquipmentPDF()
        {
            var data = db.Equipments.AsEnumerable().Select(x => new EquipmentViewModel
            {
                EquipmentId = x.EquipmentId,
                EquipmentName = x.EquipmentName,
                DeliveryDate = x.DeliveryDate,
                Price = x.Price,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
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

            return File(stream, "application/pdf", "Equipments.pdf");

        }
        public ActionResult PartPDF()
        {
            var data = db.Parts.Include(x => x.Equipment).Select(x => new PartReportModel
            {
                EquipmentName = x.Equipment.EquipmentName,
                EquipmentId = x.EquipmentId,
                PartId = x.PartId,
                PartName = x.PartName,
                Quantity = x.Quantity
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            //Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //stream.Seek(0, SeekOrigin.Begin);
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "eNtsaRegistrationForm.xls");

            //return File(stream, "application/pdf", "Part.pdf");
        }
    }
}