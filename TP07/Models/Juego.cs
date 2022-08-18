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
    /*CREAR LISTAS*/

    private string _username;
    private int _puntajeActual;
    private int _cantidadPreguntasCorrectas;
    private List<Pregunta> _preguntas;
    private List<Respuesta> _respuestas;
   
    public Preguntas(string username,int puntajeActual,int cantidadPreguntasCorrectas,List<Pregunta> preguntas, List<Respuesta> respuestas)
        {
           _username= username;
           _puntajeActual=puntajeActual;
           _cantidadPreguntasCorrectas=cantidadPreguntasCorrectas;
           _preguntas=preguntas;
           _respuestas=respuestas;
        }
    public int UserName
    {
        get
        {
            return _username;
        }
        set{
            _username = value;
        }

    }
    public int PuntajeActual
    {
        get
        {
            return _puntajeActual;
        }
        set{
            _puntajeActual = value;
        }

    }

    public string CantidadPreguntasCorrectas
    {
        get
        {
            return _cantidadPreguntasCorrectas;
        }
        set{
            _cantidadPreguntasCorrectas = value;
        }
    }

     public List<Pregunta> Preguntas
    {
        get
        {
            return _preguntas;
        }
        set{
            _preguntas = value;
        }
    }
   public List<Pregunta> Respuestas
    {
        get
        {
            return _respuestas;
        }
        set{
            _respuestas = value;
        }
    }
}
}