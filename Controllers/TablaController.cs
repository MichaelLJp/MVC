using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPrueba1.Models;
using WebPrueba1.Models.ViewModels;

namespace WebPrueba1.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using(PRUEBAWEBEntities db = new PRUEBAWEBEntities())
            {
                 lst = (from d in db.clients
                           select new ListTablaViewModel
                           {
                               id = d.id,
                               nameClient = d.nameClient,
                               documentType = d.documentType,
                               documentNumber = d.documentNumber,
                               addressPlace = d.addressPlace,
                               phone = d.phone,
                               email = d.email,
                               dateCreate = d.dateCreate,
                           }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            
                if (ModelState.IsValid)
                {
                    using (PRUEBAWEBEntities db = new PRUEBAWEBEntities())
                    {
                        db.SP_clientCreate(model.nameClient, model.documentType, model.documentNumber, model.addressPlace, model.phone, model.email, DateTime.Now.ToString());
                   // var otabla = new clients();
                   // otabla.nameClient = model.nameClient;
                   // otabla.documentType = model.nameClient;
                   //otabla.documentNumber = model.documentNumber;
                   // otabla.addressPlace = model.addressPlace;
                   // otabla.phone = model.phone;
                   //otabla.email = model.email;
                   // otabla.dateCreate = DateTime.Now.ToString();
                   // db.clients.Add(otabla);
                    db.SaveChanges();
                   
                }
                    return Redirect("~/Tabla/");

                }
                else
                {
                return View(model);

                }

        }



        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (PRUEBAWEBEntities db = new PRUEBAWEBEntities()) {
                var oTabla = db.clients.Find(id);
                model.nameClient = oTabla.nameClient;
                model.documentType = oTabla.documentType;
                model.documentNumber = oTabla.documentNumber;
                model.addressPlace = oTabla.addressPlace;
                model.phone = oTabla.phone;
                model.email = oTabla.email;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {

            if (ModelState.IsValid)
            {
                using (PRUEBAWEBEntities db = new PRUEBAWEBEntities())
                {
                    db.SP_clientUpdate(model.id.ToString(), model.nameClient, model.documentType, model.documentNumber, model.addressPlace, model.phone, model.email);

                 //   var otabla = db.clients.Find(model.id);
                 //   otabla.nameClient = model.nameClient;
                  //  otabla.documentType = model.documentType;
                  //  otabla.documentNumber = model.documentNumber;
                  //  otabla.addressPlace = model.addressPlace;
                  //  otabla.phone = model.phone;
                  //  otabla.email = model.email;
                    //otabla.dateCreate = model.dateCreate;
                   // db.Entry(otabla).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("~/Tabla/");

            }
            else
            {
                return View(model);

            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (PRUEBAWEBEntities db = new PRUEBAWEBEntities())
            {
                db.SP_clientDelete(id);
                db.SaveChanges();
                 
            }
            return Redirect("~/Tabla/");
        }


    }
}
