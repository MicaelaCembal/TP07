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

namespace TP06.Models;
    public class BD {

 private static string _connectionString = 
        @"Server=MICAELA-CEMBAL\SQLEXPRESS;
        DataBase=Qatar2022;Trusted_Connection=True;";


    }
