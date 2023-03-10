using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace AM.Web.Controllers
{
    public class FlightController : Controller
    {
        
        IServiceFlight isf;

        IServicePlane isp;
        //ci dessous une injection par conctructeur
        public FlightController(IServiceFlight isf, IServicePlane isp)
        {
            this.isf = isf;
            this.isp = isp;
        }

        // GET: FlightController
        public ActionResult Index() //attends tjrs un retour de type iterable
        {
            return View(isf.GetAll()); //cette methode permet de retourner la liste des vols, getAll a été heritée depuis le service generique service.cs, via l'instance isf dans program.cs
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            //recuperation de la liste des plane, nous avons injecte l'interface Sce plane en haut pour pouvoir appeler la methode getall plane
            ViewBag.PlaneList = new SelectList(isp.GetAll(), "PlaneId","Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight f)
        {
            try
            {
                isf.Add(f);
                isf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
