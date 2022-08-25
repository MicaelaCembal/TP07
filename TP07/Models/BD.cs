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
        @"Server=MICAELA-CEMBAL\SQLEXPRESS;
        DataBase=Qatar2022;Trusted_Connection=True;";
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
         string conector = "WHERE";
        if(dificultad>0){
         sql = sql + conector + "IdDificultad=dificultad";
         conector = "AND";
        }
        if(categoria>0){
        sql = sql + conector + "IdCategoria=categoria";
        }
        using(SqlConnection db = new SqlConnection(_connectionString)){
            lista = db.Query<Equipo>(sql).ToList();
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                lista.AddRange(connection.Query<Respuesta>("SELECT * FROM Respuestas WHERE IdPregunta = " + pregunta.IdPregunta).AsList());
            }
        }
       
}
}

