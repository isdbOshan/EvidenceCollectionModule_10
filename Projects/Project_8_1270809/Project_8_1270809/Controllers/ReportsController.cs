using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Project_8_1270809.Models;
using Project_8_1270809.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.Shared;

namespace Project_8_1270809.Controllers
{
    public class ReportsController : Controller
    {
        TraineesDbContext db = new TraineesDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            return View(db.Trainees.ToList());
        }
        public ActionResult TraineeReport()
        {
            var data = db.Trainees.Include(x => x.Modules).Select(x => new TraineeViewModel
            {
                TraineeName = x.TraineeName,
                TraineeId = x.TraineeId,
                DateOfBirth = x.DateOfBirth,
                AdmitionFee = x.AdmitionFee,
                OnAddmited = x.OnAddmited,
            }).ToList();
            return View(data);
        }
        public ActionResult TraineePDF()
        {
            var data = db.Trainees.AsEnumerable().Select(x => new TraineeViewModel
            {
                TraineeId=x.TraineeId,TraineeName=x.TraineeName, AdmitionFee=x.AdmitionFee, DateOfBirth=x.DateOfBirth, OnAddmited=x.OnAddmited, Picture=x.Picture,
                Image= System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"),x.Picture))
            }).ToList();
            ReportDocument rd=new ReportDocument();
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

            return File(stream, "application/pdf", "Trainee.pdf");
        }
        public ActionResult Traineexls()
        {
            var data = db.Trainees.AsEnumerable().Select(x => new TraineeViewModel
            {
                TraineeId = x.TraineeId,
                TraineeName = x.TraineeName,
                AdmitionFee = x.AdmitionFee,
                DateOfBirth = x.DateOfBirth,
                OnAddmited = x.OnAddmited,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Uploads"), x.Picture))
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

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "neNtsaRegistrationForm.xls");
        }
        public ActionResult ModuleReports()
        {
            var data = db.Modules.Include(x => x.Exams).Select(x => new ModuleView
            {
                ModuleName = x.ModuleName,
                ModuleId         = x.ModuleId,
                TimeDuration = x.TimeDuration,
            }).ToList();
            return View(data);
        }
        public ActionResult ModulePDF()
        {
            var data = db.Modules.AsEnumerable().Select(x => new ModuleView
            {
                ModuleName = x.ModuleName,
                ModuleId = x.ModuleId,
                TimeDuration = x.TimeDuration,
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

            return File(stream, "application/pdf", "Module.pdf");
        }
        public ActionResult Moduleexcel()
        {
            var data = db.Modules.AsEnumerable().Select(x => new ModuleView
            {
                ModuleName = x.ModuleName,
                ModuleId = x.ModuleId,
                TimeDuration = x.TimeDuration,
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

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "eNtsaRegistrationForm.xls");
        }
    }
}