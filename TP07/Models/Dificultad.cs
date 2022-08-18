using System;
using System.Collections.Generic;
namespace TP07.Models{

public class Dificultad
{
    private int _idDificultad;
    private string _nombre;
   
    public Dificultades(int idDificultad,string nombre)
        {
           _idDificultad=idDificultad;
           _nombre=nombre;
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
  
}
}