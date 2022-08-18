using System;
using System.Collections.Generic;
namespace TP07.Models{

public class Respuesta
{
    private int _idRespuesta;
    private int _idPregunta;
    private int _opcion;
    private string contenido;
    private string _correcta;
    private string _foto;
   
    public Respuestas(int idRespuesta,int idPregunta, int opcion, string contenido, string correcta, string foto)
        {
            _idRespuesta=idRespuesta;
           _idPregunta= idPregunta;
           _idCategoria=idCategoria;
           _idDificultad=idDificultad;
           _enunciado=enunciado;
           _foto=foto;

        }
    public int IdPregunta
    {
        get
        {
            return _idPregunta;
        }
        set{
            _idPregunta = value;
        }

    }
    public int IdCategoria
    {
        get
        {
            return _idCategoria;
        }
        set{
            _idCategoria = value;
        }

    }

    public string Nombre
    {
        get
        {
            return _nombre;
        }
        set{
            _nombre = value;
        }
    }

     public string Foto
    {
        get
        {
            return _foto;
        }
        set{
            _foto = value;
        }
    }
  
}
}