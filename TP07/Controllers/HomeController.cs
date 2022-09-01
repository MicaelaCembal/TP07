using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace TP07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger)
    {
        Environment=environment;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ConfigurarJuego()
    {
        /*Debe llamar al método InicializarJuego() de la clase
        Juego y retornar la View ConfigurarJuego. Por ViewBag deben viajar las categorías y
        dificultades!*/
        Juego.InicializarJuego();
        ViewBag.Categorias = Juego.ObtenerCategorias();
        ViewBag.Dificultades = Juego.ObtenerDificultades();
         return View("ConfigurarJuego");
         //redirect to action
         
    }

   public IActionResult Jugar(){
        /*Carga en ViewBag todo lo necesario para mostrar la pregunta
            actual con sus respectivas respuestas (que proviene del método ObtenerProximaPregunta.
            Si ya no hay más preguntas disponibles, retorna la view Fin. Si el método retorna una
            pregunta, invoca a ObtenerProximasRespuestas de la clase Juego guardando estos datos
            en ViewBag y retorna la view Juego.*/

            ViewBag.UnaPregunta= Juego.ObtenerProximaPregunta();
            if(Juego.ObtenerProximaPregunta() == null){
            return View("Fin");
            }
            else{
                ViewBag.RespuestasPreg= Juego.ObtenerProximasRespuestas(ViewBag.UnaPregunta.idPregunta);
                return View("Juego");
            }

    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
         /*IActionResult Comenzar(string username, int dificultad, int categoria): Recibe el
            username, dificultad y categoría elegidas por el usuario, invoca al método CargarPartida de
            la clase Juego y redirige el sitio al ActionResult Jugar.
            */
        Juego.CargarPartida(username, dificultad, categoria); 
        return RedirectToAction("Jugar");
    }

        /*[HttpPost] IActionResult VerificarRespuesta(int idPregunta, int idRespuesta):
    Recibe el id de la respuesta elegida, invoca al método VerificarRespuesta de la clase Juego
    y retorna la view Respuesta, enviando por ViewBag si fue correcta o no. (Como opcional,
    podés enviar también cuál era la respuesta correcta).*/
    [HttpPost]
   public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {    
          ViewBag.RespuestaCorrecta =  Juego.VerificarRespuesta(idPregunta, idRespuesta);
          return View("Respuesta");
       
    }   
    
}
