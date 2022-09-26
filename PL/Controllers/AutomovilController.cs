using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AutomovilController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Automovil auto = new ML.Automovil();
            auto.Placa = new ML.Placa();
            auto.Marca = new ML.Marca();
           
            ML.Result result = BL.Automovil.GetAll();
            if (result.Correct)
            {
                auto.Automoviles = result.Objects;
            }
            else
            {
                result.Correct = false;
            }
            return View(auto);
        }
        [HttpGet]
        public ActionResult Form(int? IdAutomovil)
        {
            ML.Automovil auto = new ML.Automovil();
            auto.Placa = new ML.Placa();
            auto.Marca = new ML.Marca();
            ML.Result resultPlacas = BL.Placas.GetAll();
            ML.Result resultMarca = BL.Marca.GetAll();

            if (resultPlacas.Correct && resultMarca.Correct)
            {
                if (auto.IdAutomovil == null)
                {
                    return View(auto);
                }
                else
                {
                    ML.Result result = BL.Automovil.GetById(IdAutomovil.Value);
                    if (result.Correct)
                    {
                        auto = (ML.Automovil)result.Object;
                    }
                    else
                    {
                        ViewBag.Mensaje = "Registro no encontrado";
                        return View("Modal");
                    }
                }
            }
            return View(auto);
        }
        [HttpPost]
        public ActionResult Form(ML.Automovil auto)
        {
            if(auto.IdAutomovil == 0)
            {
                ML.Result result = BL.Automovil.Add(auto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registrado exitósamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al registrar";
                }
                return View("Modal");
            }
            else
            {
                ML.Result result = BL.Automovil.Update(auto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizado exitósamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar";
                }
                return View("Modal");
            }
        }
        [HttpGet]
        public ActionResult Delete(int IdAutomovil)
        {
            ML.Result result = BL.Automovil.Delete(IdAutomovil);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Borrado exitósamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al borrar";
            }
            return View("Modal");
        }
    }
}
