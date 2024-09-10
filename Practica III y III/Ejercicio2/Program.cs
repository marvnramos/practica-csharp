using System;
using Newtonsoft.Json.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        string jsonString = "{\"nombre\":\"Juan\",\"Edad\":35,\"direccion\":\"Soyapango\"}";

        // Convertir de JSON string a JObject
        JObject jsonObject = JObject.Parse(jsonString);

        // Accediendo a los valores para los objetos JObject
        string nombre = (string)jsonObject["nombre"]!;
        int? edad = (int)jsonObject["Edad"]!;
        string? direccion = (string)jsonObject["direccion"]!;

        // Output
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("Direccion: " + direccion);
    }
}

/*
 *  Análisis General
 * 1. Para poder hacer uso de Newtonsoft.Json debe instalarse la dependencia desde el administrador de paquetes de nugets
 * 2. El código tenía una llave ( } ) extra por lo que presentaba un error de sintaxis
 * 3. Al momento de obtener el valor de una propiedad del objeto, debe hacerse referencia a esta tal y como está definida
 * dentro del objeto, ya que es case sensitive, lo que quiere decir que "nombre" no es lo mismo que "Nombre"
 *
 * Análisis de Respuesta
 * Al obtener correctamente los valores de las propiedades de un objeto logramos visualizarlas sin errores, en nuestra consola:
 * Nombre: Juan
 * Edad: 35
 * Dirección: Soyapango
 *
 * Lo que estamos imprimiendo solo es el valor de las propiedades de un objeto que fueron reasignadas a una variable especifica
 * según corresponda el nombre, no estamos imprimiendo el objeto como tal, sino, la respuesta se vería tal que:
 *
 *  {
 *    "nombre": "Juan",
 *    "Edad": 35,
 *    "direccion": "Soyapango"
 *  }
 *
 */