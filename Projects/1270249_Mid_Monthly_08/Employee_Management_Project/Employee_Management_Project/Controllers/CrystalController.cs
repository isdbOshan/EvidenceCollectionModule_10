using CrystalDecisions.CrystalReports.Engine;
using Employee_Management_Project.Models;
using Employee_Management_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_Project.Controllers
{
    [Authorize]
    public class CrystalController : Controller
    {
        
        // GET: Reports
        EmployeeExperienceDbContext db = new EmployeeExperienceDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult EmployeePDF()
        {
            var data = db.Employees.AsEnumerable().Select(x => new EmployeeReportViewModel
            {
                EmployeeID = x.EmployeeID,
                EmployeeName = x.EmployeeName,
                BranchName = x.BranchName,
                JoiningDate = x.JoiningDate,
                ActivityStatus = x.ActivityStatus,
                Salary= x.Salary,
                Phone= x.Phone,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeReport.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Employees.pdf");
        }
        public ActionResult EmployeeExcel()
        {
            var data = db.Employees.AsEnumerable().Select(x => new EmployeeReportViewModel
            {
                EmployeeID = x.EmployeeID,
                EmployeeName = x.EmployeeName,
                BranchName = x.BranchName,
                JoiningDate = x.JoiningDate,
                ActivityStatus = x.ActivityStatus,
                Salary = x.Salary,
                Phone = x.Phone,
                Picture = x.Picture,
                Image = System.IO.File.ReadAllBytes(System.IO.Path.Combine(Server.MapPath("~/Pictures"), x.Picture))
            })
                .ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeReport.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "EmployeeExcelSheet.xls");
        }
        public ActionResult EmployeeExperienceReport()
        {
            var data = db.Experiences.Include(x => x.Employee).Select(x => new EmployeeExperienceReportModel
            {
                EmployeeName = x.Employee.EmployeeName,
                EmployeeID = x.EmployeeID,
                Designation = x.Designation,
                CompanyName = x.CompanyName,
                ExperienceYear= x.ExperienceYear,
            }).ToList();
            return View(data);
        }
        public ActionResult EmployeeExperiencePDF()
        {
            var data = db.Experiences.Include(x => x.Employee).Select(x => new EmployeeExperienceReportModel
            {
                EmployeeName = x.Employee.EmployeeName,
                Designation = x.Designation,
                CompanyName = x.CompanyName,
                ExperienceYear = x.ExperienceYear
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeExperienceReport.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeeExperienceReport.pdf");
        }
        public ActionResult EmployeeExperienceExcel()
        {
            var data = db.Experiences.Include(x => x.Employee).Select(x => new EmployeeExperienceReportModel
            {
                EmployeeName = x.Employee.EmployeeName,
                Designation = x.Designation,
                CompanyName = x.CompanyName,
                ExperienceYear = x.ExperienceYear
            }).ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeExperienceReport.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "EmployeeExperienceExcelSheet.xls");
        }
        public ActionResult TeamReport()
        {
            var data = db.Teams.Include(x => x.Employee).Select(x => new TeamReportViewModel
            {
                EmployeeName = x.Employee.EmployeeName,
                EmployeeID = x.EmployeeID,
                Department = x.Department,
                TeamName = x.TeamName,
                TeamLeader = x.TeamLeader
            }).ToList();
            return View(data);
        }
        public ActionResult TeamsPDF()
        {
            var data = db.Teams.Include(x=>x.Employee).Select(x => new TeamReportViewModel
            {
                EmployeeName= x.Employee.EmployeeName,
                TeamID = x.TeamID,
                Department = x.Department,
                TeamName = x.TeamName,
                TeamLeader = x.TeamLeader
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeTeam.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EmployeesTeam.pdf");

        }
        public ActionResult TeamsExcel()
        {
            var data = db.Teams.Include(x => x.Employee).Select(x => new TeamReportViewModel
            {
                EmployeeName = x.Employee.EmployeeName,
                TeamID = x.TeamID,
                Department = x.Department,
                TeamName = x.TeamName,
                TeamLeader = x.TeamLeader
            })
                .ToList();
            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeTeam.rpt"));
            rd.SetDataSource(data);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", "EmployeeTeam.xls");

        }
    }
}