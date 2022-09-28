using System;
using System.Collections.Generic;
namespace TP07.Models{

public class Pregunta
{
    private int _idPregunta;
    private int _idCategoria;
    private int _idDificultad;
    private string _enunciado;
    private string _foto;
   
    public Pregunta(int idPregunta,int idCategoria, int idDificultad, string enunciado, string foto)
        {
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
     public int IdDificultad
    {
        get
        {
            return _idDificultad;
        }
        set{
            _idDificultad = value;
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

     public string Enunciado
    {
        get
        {
            return _enunciado;
        }
        set{
            _enunciado = value;
        }
    }
  
}
}