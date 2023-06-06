using Project_8_1270809.Models;
using Project_8_1270809.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Project_8_1270809.Controllers
{
    public class MasterDetailsController : Controller
    {
        TraineesDbContext db = new TraineesDbContext();
        // GET: MasterDetails
        public ActionResult Index()
        {
            return View(db.Trainees.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TraineeInputModel data)
        {
           if(ModelState.IsValid)
            {
                Trainee t = new Trainee
                {
                    TraineeName = data.TraineeName,
                    DateOfBirth = data.DateOfBirth,
                    AdmitionFee = data.AdmitionFee,
                    OnAddmited = data.OnAddmited,
                    Picture = data.Picture
                };
                foreach(var p in data.Modules)
                {
                    t.Modules.Add(p);
                }
                db.Trainees.Add(t);
                db.SaveChanges();
                return Json(new {id=t.TraineeId});
            }
            return Json(null);
        }
        public PartialViewResult AddModuleToForm(TraineeInputModel t=null, int? index = null)
        {
            if (t == null) new TraineeInputModel();
            if (index.HasValue)
            {
                if (index < t.Modules.Count)
                {
                    t.Modules.RemoveAt(index.Value);
                }
            }
            else
            {
                t.Modules.Add(new Module());
            }
            return PartialView("_PartialModule",t);
        }
        public ActionResult UploadImage(int id, ImageUpload pic)
        {
            if (ModelState.IsValid)
            {
                if(pic.Picture!= null)
                {
                    Trainee t = db.Trainees.First(x=>x.TraineeId==id);
                    string ext = Path.GetExtension(pic.Picture.FileName);
                    string fineName=Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+ext;
                    string savePath = Path.Combine(Server.MapPath("~/Uploads"), fineName);
                    pic.Picture.SaveAs(savePath);
                    t.Picture = fineName;
                    db.SaveChanges();
                    return Json(fineName);
                }
            }
            return Json(null);
        }
            public ActionResult Edit(int id)
        {
            var trainee = db.Trainees.Include(x => x.Modules).First(x => x.TraineeId == id);
            return View(new TraineeEditModel
            {
                TraineeId = trainee.TraineeId,
                TraineeName = trainee.TraineeName,
                DateOfBirth = trainee.DateOfBirth,
                AdmitionFee = trainee.AdmitionFee,
                OnAddmited = trainee.OnAddmited,
                Picture = trainee.Picture,
                Modules = trainee.Modules.ToList(),

            });
        }
        [HttpPost]
        public ActionResult Edit(TraineeEditModel model)
        {
            var existing = db.Trainees.First(x => x.TraineeId == model.TraineeId);
            if(ModelState.IsValid)
            {
                existing.TraineeName= model.TraineeName;
                existing.DateOfBirth= model.DateOfBirth;
                existing.AdmitionFee= model.AdmitionFee;
                existing.OnAddmited= model.OnAddmited;
                db.Modules.RemoveRange(existing.Modules.ToList());
                foreach(var p in model.Modules)
                {
                    p.TraineeId= existing.TraineeId;
                    db.Modules.Add(p);
                }
                db.SaveChanges();
                return Json(existing.TraineeId);
            }
            return Json(null);
        }
        public PartialViewResult AddModuleEditForm(TraineeEditModel d ,int? index = null)
        {
            if (index.HasValue)
            {
                if(index < d.Modules.Count)
                {
                    d.Modules.RemoveAt(index.Value);
                }
            }
            return PartialView("_PartialModulesEdit", d);
        }

        public PartialViewResult AddMore(TraineeEditModel d,int? index = null)
        {
            if(d==null) d= new TraineeEditModel();
            if(index.HasValue)
            {
                if(index<d.Modules.Count)
                {
                    d.Modules.RemoveAt(index.Value);
                }
            }
            else
            {
                d.Modules.Add(new Module());
            }
            return PartialView("_PartialModulesEdit", d);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var existing = db.Trainees.FirstOrDefault(x => x.TraineeId == id);
            if (existing != null)
            {
                db.Trainees.Remove(existing);
                db.SaveChanges();
                return Json(existing.TraineeId);
            }
            return Json(null);
        }
    }
}