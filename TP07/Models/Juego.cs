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

public class Pregunta
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List<Pregunta> _preguntas;
    private static List<Respuesta> _respuestas;
   
    public Preguntas(string username,int puntajeActual,int cantidadPreguntasCorrectas,List<Pregunta> preguntas, List<Respuesta> respuestas)
        {
           _username= username;
           _puntajeActual=puntajeActual;
           _cantidadPreguntasCorrectas=cantidadPreguntasCorrectas;
           _preguntas=preguntas;
           _respuestas=respuestas;
           /*primero categoria y dificultad */
        }
    public int UserName
    {
        get
        {
            return _username;
        }
        
    }
    public int PuntajeActual
    {
        get
        {
            return _puntajeActual;
        }
        

    }

    public string CantidadPreguntasCorrectas
    {
        get
        {
            return _cantidadPreguntasCorrectas;
        }
        
    }

     public List<Pregunta> Preguntas
    {
        get
        {
            return _preguntas;
        }
       
    }
   public List<Pregunta> Respuestas
    {
        get
        {
            return _respuestas;
        }
       
    }
    public void InicializarJuego()
    {
          _username= "";
           _puntajeActual=0;
           _cantidadPreguntasCorrectas=0;
           _preguntas="";
           _respuestas="";
    }

    public List<CategoriaJuego> ObtenerCategorias(){

/*crear nueva lista y BD.ListarCategorias() = a la nueva lista*/
     //Retorna la lista de categorías.}*/
     List<CategoriaJuego> lista = new List<CategoriaJuego>();
     lista= BD.ObtenerCategorias();
     return lista;
     }
      public List<DificultadJuego> ObtenerDificultades(){

/*crear nueva lista y BD.ListarCategorias() = a la nueva lista*/
     //Retorna la lista de categorías.}*/
    List<DificultadJuego> lista = new List<Dificultad>();
     lista= BD.ObtenerDificultades();
     return lista;
     }
    public void CargarPartida(string username, int dificultad, int categoria)
     {
            /*Recibe la
            dificultad y categoría elegidas, invoca a los métodos ObtenerPreguntas y
            ObtenerRespuestas (en ese orden) y guarda los resultados en los atributos
            _preguntas y _respuestas.
            */
            _preguntas= BD.ObtenerPreguntas() 
            
            _respuestas= BD.ObtenerRespuestas()

     }

     /*ObtenerProximaPregunta(): Retorna, de ser posible, una pregunta al azar de la
lista de preguntas.
*/
public string ObtenerProximaPregunta(){
var random = new Random();
         var list = ObtenerPreguntas(dificultad, categoria)
         int pos = random.Next(list.Count);
         string pregProx= (list[pos]);
         return pregProx;
}
public List<RespuestasUnaPregunta> ObtenerProximasRespuestas(int idPregunta){
    /*Retorna una lista con todas las
respuestas relacionadas a la pregunta enviada por parámetro*/
    List<RespuestasUnaPregunta> lista = new List<RespuestasUnaPregunta>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                lista.connection.Query<RespuestasUnaPregunta>("SELECT * FROM Respuestas WHERE IdPregunta = " + idPregunta);
            }
    return lista;
}
    public bool VerificarRespuesta(int idPregunta, int idRespuesta){
         /*Recibe un id de
    pregunta y un id de respuesta, y retorna un booleano indicando si la respuesta fue
    correcta o incorrecta. Previo a devolver el booleano realiza dos acciones:
    1. Si la respuesta del usuario fue correcta, suma una cantidad específica de
    puntos a _puntajeActual (la definen ustedes) y suma 1 respuesta correcta
    en _cantidadPreguntasCorrectas.
    2. Elimina la pregunta enviada por parámetro de la lista de preguntas*/
        bool respuesta=true; 
        if(idPregunta=idRespuesta)
        {
            _puntajeActual=_puntajeActual+10; 
            _cantidadPreguntasCorrectas++; 
             return respuesta; 
        }
        else
        {
            respuesta=false;
            return respuesta; 
        }
        _preguntas.RemoveAt(idPregunta);
        
    }
}








