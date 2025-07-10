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

    public IActionResult GuardarIngresoo(string nombre, string contraseña)
    {
        // Validar que los parámetros no sean nulos o vacíos
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña))
        {
            ViewBag.Error = "Por favor, complete todos los campos.";
            ViewBag.no = false;
            return View();
        }

        // Crear una instancia temporal para verificar login
        Integrantes integranteTemp = new Integrantes();
        Integrantes integranteOG = integranteTemp.VerificarIntegrantes(nombre, contraseña);

        // Si no se encuentra el usuario
        if (integranteOG == null)
        {
            ViewBag.Error = "Nombre de usuario o contraseña incorrectos.";
            ViewBag.no = false;
            return View();
        }
        
        // Login exitoso - guardar en sesión y redirigir al perfil
        HttpContext.Session.SetString("UsuarioLogueado", Objeto.ObjectToString(integranteAutenticado));
        
        // Pasar el usuario autenticado a la vista perfil
        return View("perfil", integranteOG);
    }

    // Método para mostrar el perfil
    public IActionResult Perfil()
    {
        string usuarioSession = HttpContext.Session.GetString("UsuarioLogueado");
        
        if (string.IsNullOrEmpty(usuarioSession))
        {
            // Si no hay usuario en sesión, redirigir al login
            return RedirectToAction("Index");
        }

        Integrantes usuario = Objeto.StringToObject<Integrantes>(usuarioSession);
        return View(usuario);
    }

    // Método para cerrar sesión
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
