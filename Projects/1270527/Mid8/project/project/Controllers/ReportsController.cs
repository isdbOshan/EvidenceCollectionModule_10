using CrystalDecisions.CrystalReports.Engine;
using project.Models;
using project.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class ReportsController : Controller
    {
        TutorDbContext db = new TutorDbContext();
        // GET: Reports
        public ActionResult Index()
        {

            return View(db.Teachers.ToList()); ;
        }
        public ActionResult QualificationReport()
        {
            var data = db.TeacherQualifications.Include(x=> x.Teachers).Select(x => new QualificationReportModel
            {
                TeacherName = x.Teachers.TeacherName,
                TeacherId = x.TeacherId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            return View(data);
        }
        public ActionResult TeacherPDF()
        {
            var data = db.Teachers.AsEnumerable().Select(x => new TeacherViewModel
            {
                TeacherId = x.TeacherId,
                TeacherName = x.TeacherName,
                IsAvailable = x.IsAvailable,
                Teacherdob = x.Teacherdob,
                TeacherEmail = x.TeacherEmail,
                TeacherPhone = x.TeacherPhone,
                ExpectedAmount = x.ExpectedAmount,
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


            return File(stream, "application/pdf", "Teachers.pdf");

        }
        public ActionResult TeacherXls()
        {
            var data = db.Teachers.AsEnumerable().Select(x => new TeacherViewModel
            {
                TeacherId = x.TeacherId,
                TeacherName = x.TeacherName,
                IsAvailable = x.IsAvailable,
                Teacherdob = x.Teacherdob,
                TeacherEmail = x.TeacherEmail,
                TeacherPhone = x.TeacherPhone,
                ExpectedAmount = x.ExpectedAmount,
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

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Teachers.xls");


            

        }
        public ActionResult QualificationPDF()
        {
            var data = db.TeacherQualifications.Include(x => x.Teachers).Select(x => new QualificationReportModel
            {
                TeacherName = x.Teachers.TeacherName,
                TeacherId = x.TeacherId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport3.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "Qualifaction.pdf");
        }

        public ActionResult QualificationXsl()
        {
            var data = db.TeacherQualifications.Include(x => x.Teachers).Select(x => new QualificationReportModel
            {
                TeacherName = x.Teachers.TeacherName,
                TeacherId = x.TeacherId,
                Degree = x.Degree,
                PassingYear = x.PassingYear,
                Result = x.Result,
                Institute = x.Institute
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport3.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Stream stream1 = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/vnd.ms-excel", "Qualifaction.xls");
        }
    }
}