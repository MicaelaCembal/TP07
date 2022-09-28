/*Crear y definir la clase BD con los siguientes métodos estáticos y públicos
a. ObtenerCategorias(): Devuelve una lista con todas las categorías
b. ObtenerDificultades(): Devuelve una lista con todas las dificultades
c. ObtenerPreguntas(int dificultad, int categoria): Recibe un id de dificultad y
un id de categoría. Devuelve una lista con las preguntas que se van a utilizar en el
juego.
Aclaración:
Si dificultad = -1, trae las preguntas de todas las dificultades.
Si categoria = -1, trae las preguntas de todas las categorías.
d. ObtenerRespuestas(List<Pregunta> preguntas): Recibe la lista de preguntas
que se va a usar en el juego, y devuelve una lista con todas las respuestas para
dichas preguntas.
Ayuda 1 : Para conseguir las respuestas, hay que ir recorriendo la lista de
preguntas!!
Ayuda 2 : El método AddRange de cualquier lista, permite agregar varios objetos
a una lista en una sola operación. Podría servirte para agregar todas las respuestas
que vienen de cada pregunta a la lista general de respuestas…
(Crear además todos los atributos y métodos privados que se requieran vistos en clase,
para poder conectar el proyecto con la base de datos)*/

using System;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

namespace TP07.Models;
    public class BD {

 private static string _connectionString = 
        @"Server=A-PHZ2-CIDI-031;
        DataBase=TP07;Trusted_Connection=True;";
//a. ObtenerCategorias(): Devuelve una lista con todas las categorías
    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> lista = new List<Categoria>();
        string sql = "SELECT * FROM  Categorias";
        using(SqlConnection db = new SqlConnection(_connectionString)){
                lista = db.Query<Categoria>(sql).ToList();
            }
        return lista;
    }
//b. ObtenerDificultades(): Devuelve una lista con todas las dificultades
    public static List<Dificultad> ObtenerDificultades(){
    List<Dificultad> lista = new List<Dificultad>();
    string sql = "SELECT * FROM Dificultades";
    using(SqlConnection db = new SqlConnection(_connectionString)){
            lista = db.Query<Dificultad>(sql).ToList();
        }
        return lista;
}
/*
ObtenerPreguntas(int dificultad, int categoria): Recibe un id de dificultad y
un id de categoría. Devuelve una lista con las preguntas que se van a utilizar en el
juego.
Aclaración:
Si dificultad = -1, trae las preguntas de todas las dificultades.
Si categoria = -1, trae las preguntas de todas las categorías.

*/
public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria){
        List<Pregunta> lista = new List<Pregunta>();
         string sql = "SELECT * FROM Preguntas";
         string conector = " WHERE ";
        if(dificultad>0){
         sql = sql + conector + " IdDificultad = @pdificultad ";
         conector = " AND ";
        }
        if(categoria>0){
        sql = sql + conector + " IdCategoria = @pcategoria ";
        }
        using(SqlConnection db = new SqlConnection(_connectionString)){
            lista = db.Query<Pregunta>(sql, new{pdificultad = dificultad, pcategoria = categoria}).ToList();
        }
        return lista;
    }
/*ObtenerRespuestas(List<Pregunta> preguntas): Recibe la lista de preguntas
que se va a usar en el juego, y devuelve una lista con todas las respuestas para
dichas preguntas.
Ayuda 1 : Para conseguir las respuestas, hay que ir recorriendo la lista de
preguntas!!
Ayuda 2 : El método AddRange de cualquier lista, permite agregar varios objetos
a una lista en una sola operación. Podría servirte para agregar todas las respuestas
que vienen de cada pregunta a la lista general de respuestas…
(Crear además todos los atributos y métodos privados que se requieran vistos en clase,
para poder conectar el proyecto con la base de datos*/
public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas){
        List<Respuesta> lista = new List<Respuesta>();
        foreach(Pregunta pregunta in preguntas)
        {   
            string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                lista.AddRange(connection.Query<Respuesta>(sql, new {pIdPregunta = pregunta.IdPregunta}));
            }
        }
       return  lista;
}

public static Pregunta ObtenerUnaPregunta(int idPregunta)
{
        Pregunta UnaPregunta= null; 
         
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Preguntas WHERE IdPregunta = @pIdPregunta";
                UnaPregunta=db.QueryFirstOrDefault<Pregunta>(sql, new {pIdPregunta=idPregunta}); 
            }
            return UnaPregunta;
}

public static void AgregarPregunta(Pregunta Preg){
        string sql = "INSERT INTO Preguntas(IdCategoria, IdDificultad,Enunciado,Foto) VALUES (@pIdCategoria, @pIdDificultad,@pEnunciado,@pFoto)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdCategoria= Preg.IdCategoria, pIdDificultad=Preg.IdDificultad, pEnunciado=Preg.Enunciado, pFoto=Preg.Foto });
        }
    }



     public static void EliminarPregunta(int id){
        string sql = "DELETE FROM Preguntas WHERE IdPregunta = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new { pId = id });
        }
        
    }

     public static List<Pregunta> ListarPregunta(){
        List<Pregunta> lista = new List<Pregunta>();
        string sql = "SELECT * FROM Preguntas";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            lista = db.Query<Pregunta>(sql).ToList();
        }
        return lista;
    }
  public static void AgregarRespuesta(Respuesta Resp){
        string sql = "INSERT INTO Respuestas  (IdPregunta,  Opcion,  Contenido,  Correcta,  Foto) VALUES (@pIdPregunta,  @pOpcion,  @pContenido,  @pCorrecta,  @pFoto)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdPregunta=Resp.IdPregunta, pOpcion= Resp.Opcion, pContenido=Resp.Contenido, pCorrecta=Resp.Correcta, pFoto=Resp.Foto });
        }
    
       
}
}




