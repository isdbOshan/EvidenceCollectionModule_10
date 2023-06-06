using Employee_Management_Project.Models;
using Employee_Management_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Management_Project.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
        EmployeeExperienceDbContext db = new EmployeeExperienceDbContext();
        // GET: Teams
        public ActionResult Index()
        {
            return View(db.Teams.Include(e => e.Employee).ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Departments = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Departments",Value="", Selected=true},
                new SelectListItem{Text="Sales and Marketing Department", Value="Sales and Marketing Department"},
                new SelectListItem{Text="Admin Department", Value="Admin Department"},
                new SelectListItem{Text="Operations Department", Value="Operations Department"},
                new SelectListItem{Text="Quality Assurance Department", Value="Quality Assurance Department"},
                new SelectListItem{Text="Accounts and Finance Department", Value="Accounts and Finance Department"},
                new SelectListItem{Text="Research and Development Department", Value="Research and Development Department"},
                new SelectListItem{Text="Human Resources Team", Value="Human Resources Team"},
                new SelectListItem{Text="Customer Support Department", Value="Customer Support Department"},
                new SelectListItem{Text="Security Department", Value="Security Department"}
            };
            ViewBag.TeamNames = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Names",Value="", Selected=true},
                new SelectListItem{Text="Kickin’ Crew", Value="Kickin’ Crew"},
                new SelectListItem{Text="Filthy Fresh Brainiacs", Value="Filthy Fresh Brainiacs"},
                new SelectListItem{Text="Noice Set", Value="Noice Set"},
                new SelectListItem{Text="Fierce Matrix", Value="Fierce Matrix"},
                new SelectListItem{Text="Savage Squad", Value="Savage Squad"},
                new SelectListItem{Text="Iconic Force", Value="Iconic Force"},
                new SelectListItem{Text="Legendary Set", Value="Legendary Set"},
                new SelectListItem{Text="Beastly Syndicate", Value="Beastly Syndicate"},
                new SelectListItem{Text="Spifftacular Troop", Value="Spifftacular Troop"},
                new SelectListItem{Text="50Smooth Posse00", Value="Smooth Posse"},
                new SelectListItem{Text="Notorious Squad", Value="Notorious Squad"}
            };
            ViewBag.TeamLeaders = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Leaders",Value="", Selected=true},
                new SelectListItem{Text="Samantha Hyde", Value="Samantha Hyde"},
                new SelectListItem{Text="Katie Hamlyn", Value="Katie Hamlyn"},
                new SelectListItem{Text="Gloria Fernandes", Value="Gloria Fernandes"},
                new SelectListItem{Text="Felicity Ruff", Value="Felicity Ruff"},
                new SelectListItem{Text="Shaun Foley", Value="Shaun Foley"},
                new SelectListItem{Text="Sandra Gonzalez", Value="Sandra Gonzalez"},
                new SelectListItem{Text="Michael Campion", Value="Michael Campion"},
                new SelectListItem{Text="Justin Goodwin", Value="Justin Goodwin"},
                new SelectListItem{Text="Matthew Wood", Value="Matthew Wood"},
                new SelectListItem{Text="Stephen Richter", Value="Stephen Richter"},
                new SelectListItem{Text="Neil Thompsony", Value="Neil Thompson"}
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(Team t)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Departments = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Departments",Value="", Selected=true},
                new SelectListItem{Text="Sales and Marketing Department", Value="Sales and Marketing Department"},
                new SelectListItem{Text="Admin Department", Value="Admin Department"},
                new SelectListItem{Text="Operations Department", Value="Operations Department"},
                new SelectListItem{Text="Quality Assurance Department", Value="Quality Assurance Department"},
                new SelectListItem{Text="Accounts and Finance Department", Value="Accounts and Finance Department"},
                new SelectListItem{Text="Research and Development Department", Value="Research and Development Department"},
                new SelectListItem{Text="Human Resources Team", Value="Human Resources Team"},
                new SelectListItem{Text="Customer Support Department", Value="Customer Support Department"},
                new SelectListItem{Text="Security Department", Value="Security Department"}
            };
            ViewBag.TeamNames = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Names",Value="", Selected=true},
                new SelectListItem{Text="Kickin’ Crew", Value="Kickin’ Crew"},
                new SelectListItem{Text="Filthy Fresh Brainiacs", Value="Filthy Fresh Brainiacs"},
                new SelectListItem{Text="Noice Set", Value="Noice Set"},
                new SelectListItem{Text="Fierce Matrix", Value="Fierce Matrix"},
                new SelectListItem{Text="Savage Squad", Value="Savage Squad"},
                new SelectListItem{Text="Iconic Force", Value="Iconic Force"},
                new SelectListItem{Text="Legendary Set", Value="Legendary Set"},
                new SelectListItem{Text="Beastly Syndicate", Value="Beastly Syndicate"},
                new SelectListItem{Text="Spifftacular Troop", Value="Spifftacular Troop"},
                new SelectListItem{Text="50Smooth Posse00", Value="Smooth Posse"},
                new SelectListItem{Text="Notorious Squad", Value="Notorious Squad"}
            };
            ViewBag.TeamLeaders = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Leaders",Value="", Selected=true},
                new SelectListItem{Text="Samantha Hyde", Value="Samantha Hyde"},
                new SelectListItem{Text="Katie Hamlyn", Value="Katie Hamlyn"},
                new SelectListItem{Text="Gloria Fernandes", Value="Gloria Fernandes"},
                new SelectListItem{Text="Felicity Ruff", Value="Felicity Ruff"},
                new SelectListItem{Text="Shaun Foley", Value="Shaun Foley"},
                new SelectListItem{Text="Sandra Gonzalez", Value="Sandra Gonzalez"},
                new SelectListItem{Text="Michael Campion", Value="Michael Campion"},
                new SelectListItem{Text="Justin Goodwin", Value="Justin Goodwin"},
                new SelectListItem{Text="Matthew Wood", Value="Matthew Wood"},
                new SelectListItem{Text="Stephen Richter", Value="Stephen Richter"},
                new SelectListItem{Text="Neil Thompsony", Value="Neil Thompson"}
            };
            var team = db.Teams.FirstOrDefault(t => t.TeamID == id);
            return View(new TeamEditModel
            {
                TeamID= team.TeamID,
                Department=team.Department,
                TeamName=team.TeamName,
                TeamLeader=team.TeamLeader,
                EmployeeID=team.EmployeeID
            });
        }
        [HttpPost]
        public ActionResult Edit(TeamEditModel t)
        {
            Team team = db.Teams.First(x=>x.TeamID==t.TeamID);
            if(ModelState.IsValid)
            {
                team.Department= t.Department;
                team.TeamName= t.TeamName;
                team.TeamLeader= t.TeamLeader;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employees = db.Employees.ToList();
            ViewBag.Departments = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Departments",Value="", Selected=true},
                new SelectListItem{Text="Sales and Marketing Department", Value="Sales and Marketing Department"},
                new SelectListItem{Text="Admin Department", Value="Admin Department"},
                new SelectListItem{Text="Operations Department", Value="Operations Department"},
                new SelectListItem{Text="Quality Assurance Department", Value="Quality Assurance Department"},
                new SelectListItem{Text="Accounts and Finance Department", Value="Accounts and Finance Department"},
                new SelectListItem{Text="Research and Development Department", Value="Research and Development Department"},
                new SelectListItem{Text="Human Resources Team", Value="Human Resources Team"},
                new SelectListItem{Text="Customer Support Department", Value="Customer Support Department"},
                new SelectListItem{Text="Security Department", Value="Security Department"}
            };
            ViewBag.TeamNames = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Names",Value="", Selected=true},
                new SelectListItem{Text="Kickin’ Crew", Value="Kickin’ Crew"},
                new SelectListItem{Text="Filthy Fresh Brainiacs", Value="Filthy Fresh Brainiacs"},
                new SelectListItem{Text="Noice Set", Value="Noice Set"},
                new SelectListItem{Text="Fierce Matrix", Value="Fierce Matrix"},
                new SelectListItem{Text="Savage Squad", Value="Savage Squad"},
                new SelectListItem{Text="Iconic Force", Value="Iconic Force"},
                new SelectListItem{Text="Legendary Set", Value="Legendary Set"},
                new SelectListItem{Text="Beastly Syndicate", Value="Beastly Syndicate"},
                new SelectListItem{Text="Spifftacular Troop", Value="Spifftacular Troop"},
                new SelectListItem{Text="50Smooth Posse00", Value="Smooth Posse"},
                new SelectListItem{Text="Notorious Squad", Value="Notorious Squad"}
            };
            ViewBag.TeamLeaders = new List<SelectListItem>
            {
                new SelectListItem{Text="Select Team Leaders",Value="", Selected=true},
                new SelectListItem{Text="Samantha Hyde", Value="Samantha Hyde"},
                new SelectListItem{Text="Katie Hamlyn", Value="Katie Hamlyn"},
                new SelectListItem{Text="Gloria Fernandes", Value="Gloria Fernandes"},
                new SelectListItem{Text="Felicity Ruff", Value="Felicity Ruff"},
                new SelectListItem{Text="Shaun Foley", Value="Shaun Foley"},
                new SelectListItem{Text="Sandra Gonzalez", Value="Sandra Gonzalez"},
                new SelectListItem{Text="Michael Campion", Value="Michael Campion"},
                new SelectListItem{Text="Justin Goodwin", Value="Justin Goodwin"},
                new SelectListItem{Text="Matthew Wood", Value="Matthew Wood"},
                new SelectListItem{Text="Stephen Richter", Value="Stephen Richter"},
                new SelectListItem{Text="Neil Thompsony", Value="Neil Thompson"}
            };
            return View(t);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Teams.FirstOrDefault(p => p.TeamID == id);
            if (existing != null)
            {
                db.Teams.Remove(existing);
                db.SaveChanges();
                return Json(existing.TeamID);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}