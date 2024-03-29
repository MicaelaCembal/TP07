﻿using System.Diagnostics;
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

            Pregunta pregunta= Juego.ObtenerProximaPregunta();
            ViewBag.username=Juego.UserNameView(); 
            ViewBag.Puntajeok=Juego.PuntajeView();
            if(pregunta== null){
              return View("Fin");
              
            }
            else{
                ViewBag.Respuestas= Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
                ViewBag.Pregunta = pregunta; 
               /* List<Respuesta> RespuestasPreg = new List<Respuesta>();*/
                
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
       /* List<Respuesta> resp = Juego.ObtenerProximasRespuestas(idPregunta);

         if(Juego.VerificarRespuesta(idPregunta, idRespuesta)== true){
            ViewBag.RespCorrecta=idRespuesta;
            ViewBag.RespIncorrecta=-1; 
         }
         else{
            ViewBag.RespIncorrecta=idRespuesta; 
            foreach(Respuesta respu in resp)
            {
                if(respu.Correcta)
                {
                     ViewBag.RespCorrecta=respu.IdRespuesta; 
                }
            }
         }

        
         
         ViewBag.FueRespondida= true;*/
       /* ViewBag.pregunta = Juego.ObtenerPregunta(idPregunta);
        ViewBag.respuestas = Juego.ObtenerProximasRespuestas(idPregunta);
*/
       /* erificrs respyeat devuelve u boolenaon 
        si es true--> cartelito de genial continuar
        sino--> volver y en la view misma continuar*/
        
        ViewBag.IdRespuesta=idRespuesta;
         
        if (Juego.VerificarRespuesta(idPregunta,idRespuesta))
        {
            ViewBag.Mensaje = "¡Muy bien! Correctoooo";
            ViewBag.Correcta=true;
            
            
            
        }
        else
        {
            ViewBag.Correcta=false;
             ViewBag.Mensaje = "¡Naa! ¿Sos de Iona? Incorrecto";
        }
        ViewBag.UnaPregunta= BD.ObtenerUnaPregunta(idPregunta);
        ViewBag.Respuestas= Juego.ObtenerProximasRespuestas(idPregunta);
        return View("Respuesta");

       
       
    }   

    public IActionResult AgregarPregunta(int IdPregunta){
       
        ViewBag.IdPregunta = IdPregunta;
        
        return View("AgregarPregunta");
    }

    public IActionResult AgregarRespuesta(int IdPregunta){
       
        ViewBag.IdPregunta = IdPregunta;
        
        return View("AgregarRespuesta");
    }

    [HttpPost]
   public IActionResult GuardarRespuesta(int idRespuesta,int idPregunta, int opcion, string contenido, bool correcta, string foto)
    {    
       Respuesta respuesta = new Respuesta(idRespuesta,idPregunta,opcion,contenido,correcta,foto);
        BD.AgregarRespuesta(respuesta);
         ViewBag.ListaPregunta = BD.ListarPregunta();
         return View ("VerPreguntas");
    }
    
    public IActionResult VerPreguntas(){
       
        ViewBag.ListaPregunta = BD.ListarPregunta();
        
        return View("VerPreguntas");
    }
   
   public IActionResult EliminarPregunta(int IdPregunta)
   {
        BD.EliminarPregunta(IdPregunta);
        return View ("ConfigurarJuego");
    }

  [HttpPost]
   public IActionResult GuardarPregunta(int idPregunta,int idCategoria, int idDificultad, string enunciado, string foto)
    {    
       Pregunta pregunta = new Pregunta(idPregunta,idCategoria, idDificultad,enunciado,foto);
        BD.AgregarPregunta(pregunta);
         return View ("ConfigurarJuego");
    }
    

    
}
