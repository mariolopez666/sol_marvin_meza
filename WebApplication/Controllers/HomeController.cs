using Business.Entity.Layer;
using Data.Access.Layer;
using System;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly MatriculaRepository matriculaRepository;

        public HomeController()
        {
            this.matriculaRepository = new MatriculaRepository();
        }
        public ActionResult Index()
        {
            var matriculas = matriculaRepository.ListarMatriculas();
            return View(matriculas);
        }

        public ActionResult Details(int id)
        {
            var persona = matriculaRepository.GetMatriculaById(id);
            return View(persona);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Matricula matricula)
        {
            try
            {
                matriculaRepository.InsertMatricula(matricula);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            var persona = matriculaRepository.GetMatriculaById(id);
            return View(persona);
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Matricula matricula)
        {
            try
            {
                matriculaRepository.UpdateMatricula(matricula);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            var matricula = matriculaRepository.GetMatriculaById(id);
            return View(matricula);
        }

        // POST: Demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Matricula matricula)
        {
            try
            {
                matriculaRepository.DeleteMatricula(matricula);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}