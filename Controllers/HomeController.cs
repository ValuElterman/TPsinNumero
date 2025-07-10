using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPsinNumero.Models;
using Newtonsoft.Json;

namespace TPsinNumero.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Comenzar(int IdIntegrante, string nombre, string password, string apellido, int telefono, string barrio, bool mascota, string hobbie)
    {
        Integrantes integrante = new Integrantes(IdIntegrante, nombre, password, apellido, telefono, barrio, mascota, hobbie);
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(integrante));
        return View();
    }

    [HttpPost]
    public IActionResult GuardarIngreso(string nombre, string contraseña)
    {
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña))
        {
            ViewBag.Error = "Por favor, complete todos los campos.";
            return View();
        }
        // Crear una instancia temporal para verificar login
        Integrantes integranteTemporal = new Integrantes();
        Integrantes integranteOG = integranteTemporal.VerificarIntegrantes(nombre, contraseña);

        if (integranteOG == null)
        {
            ViewBag.Error = "Nombre de usuario o contraseña incorrectos.";
            return View();
        }
        
        ViewBag.info = integranteOG;
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(integranteOG));
        return View("perfil");
    }
}
