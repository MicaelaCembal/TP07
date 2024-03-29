/*Crear y definir la clase Juego con los siguientes elementos estáticos:
Atributos:
a. string _username
b. int _puntajeActual
c. int _cantidadPreguntasCorrectas
d. List<Pregunta> _preguntas
e. List<Respuesta> _respuestas
Crear todas las propiedades de lectura!
Métodos:
a. InicializarJuego(): Debe limpiar todos los atributos privados de la clase.
b. ObtenerCategorias(): Retorna la lista de categorías.
c. ObtenerDificultades(): Retorna la lista de dificultades.
d. CargarPartida(string username, int dificultad, int categoria): Recibe la
dificultad y categoría elegidas, invoca a los métodos ObtenerPreguntas y
ObtenerRespuestas (en ese orden) y guarda los resultados en los atributos
_preguntas y _respuestas.
e. ObtenerProximaPregunta(): Retorna, de ser posible, una pregunta al azar de la
lista de preguntas.
f. ObtenerProximasRespuestas(int idPregunta): Retorna una lista con todas las
respuestas relacionadas a la pregunta enviada por parámetro
g. VerificarRespuesta(int idPregunta, int idRespuesta): Recibe un id de
pregunta y un id de respuesta, y retorna un booleano indicando si la respuesta fue
correcta o incorrecta. Previo a devolver el booleano realiza dos acciones:
1. Si la respuesta del usuario fue correcta, suma una cantidad específica de
puntos a _puntajeActual (la definen ustedes) y suma 1 respuesta correcta
en _cantidadPreguntasCorrectas.
2. Elimina la pregunta enviada por parámetro de la lista de preguntas*/

using System.Collections.Generic;
namespace TP07.Models{

public class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List<Pregunta> _preguntas;
    private static List<Respuesta> _respuestas;
   /*
    public Juego(string username,int puntajeActual,int cantidadPreguntasCorrectas,List<Pregunta> preguntas, List<Respuesta> respuestas)
        {
           _username= username;
           _puntajeActual=puntajeActual;
           _cantidadPreguntasCorrectas=cantidadPreguntasCorrectas;
           _preguntas=preguntas;
           _respuestas=respuestas;
           /*primero categoria y dificultad 
        }
        */
    public static string UserName
    {
        get
        {
            return _username;
        }
        
    }
    public static int PuntajeActual
    {
        get
        {
            return _puntajeActual;
        }
        

    }

    public static int CantidadPreguntasCorrectas
    {
        get
        {
            return _cantidadPreguntasCorrectas;
        }
        
    }

     public static List<Pregunta> Preguntas
    {
        get
        {
            return _preguntas;
        }
       
    }
   public static List<Respuesta> Respuestas
    {
        get
        {
            return _respuestas;
        }
       
    }
    public static void InicializarJuego()
    {
          _username= "";
           _puntajeActual=0;
           _cantidadPreguntasCorrectas=0;
           _preguntas=null;
           _respuestas=null;
    }

    public static List<Categoria> ObtenerCategorias(){

/*crear nueva lista y BD.ListarCategorias() = a la nueva lista*/
     //Retorna la lista de categorías.}*/
     List<Categoria> lista = new List<Categoria>();
     lista= BD.ObtenerCategorias();
     return lista;
     }
      public static List<Dificultad> ObtenerDificultades(){

/*crear nueva lista y BD.ListarCategorias() = a la nueva lista*/
     //Retorna la lista de categorías.}*/
    List<Dificultad> lista = new List<Dificultad>();
     lista= BD.ObtenerDificultades();
     return lista;
     }
    public static void CargarPartida(string username, int dificultad, int categoria)
     {
            /*Recibe la
            dificultad y categoría elegidas, invoca a los métodos ObtenerPreguntas y
            ObtenerRespuestas (en ese orden) y guarda los resultados en los atributos
            _preguntas y _respuestas.
            */
            _preguntas= BD.ObtenerPreguntas( dificultad, categoria);
            
            _respuestas= BD.ObtenerRespuestas(_preguntas);
            _username=username;

     }

     /*ObtenerProximaPregunta(): Retorna, de ser posible, una pregunta al azar de la
lista de preguntas.
*/
    public static Pregunta ObtenerProximaPregunta(){
        if(_preguntas.Count()==0)return null;
        var random = new Random();
        int pos = random.Next(_preguntas.Count);          
        return _preguntas[pos];
    }

public static List<Respuesta> ObtenerProximasRespuestas(int idPreguntaok){
    /*Retorna una lista con todas las
respuestas relacionadas a la pregunta enviada por parámetro*/
List<Respuesta> lista = new List<Respuesta>();
     foreach(Respuesta respuesta in _respuestas)
        {
            if(respuesta.IdPregunta == idPreguntaok)
            {
                lista.Add(respuesta);

            }
        }
    return lista;
}
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
         /*Recibe un id de
    pregunta y un id de respuesta, y retorna un booleano indicando si la respuesta fue
    correcta o incorrecta. Previo a devolver el booleano realiza dos acciones:
    1. Si la respuesta del usuario fue correcta, suma una cantidad específica de
    puntos a _puntajeActual (la definen ustedes) y suma 1 respuesta correcta
    en _cantidadPreguntasCorrectas.
    2. Elimina la pregunta enviada por parámetro de la lista de preguntas*/
        for(int i =0; i<_preguntas.Count(); i++) {
            if(_preguntas[i].IdPregunta ==idPregunta){
                _preguntas.RemoveAt(i);
            }
        }
        foreach(Respuesta resp in _respuestas)
        {
           

                if (resp.IdPregunta==idPregunta)
                {
                  
                    if (resp.IdRespuesta==idRespuesta && resp.Correcta==true)
                    {
                        _puntajeActual=_puntajeActual+10; 
                        _cantidadPreguntasCorrectas++; 
                        return true; 
                    }
                }
        }
          //_preguntas.RemoveAt(idPregunta);
        

        return false;
        
    }

    public static string UserNameView(){

        return _username; 
    }
    public static int PuntajeView(){

        return _puntajeActual; 
    } 
}
}








