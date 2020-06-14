using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace FuntionalLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Where and Count
            var calificaciones = new List<int>() { 10, 8, 4, 3, 5,  9, 6 , 10, 6, 7, 3 , 2, 1, 8};

            //Obtener cantidad de calificaciones mayores a 8

            //Imperativo
            Console.WriteLine("\nImperativo.");
            int contador = 0;
            foreach (var calificacion in calificaciones)
            {
                if (calificacion >= 8) contador++;
            }
            Console.WriteLine(contador);

            //Declarativo
            Console.WriteLine("\nDeclarativo.");
            var result = calificaciones.Where(c => c >= 8).Count();
            Console.WriteLine(result);

            #endregion

            #region modificar elemento.
            var numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            //Obtener cuadrados de cada numero

            //Imperativo
            Console.WriteLine("\nImperativo.");
            foreach (var numero in numeros) Console.WriteLine(numero * numero);

            //Declarativo
            Console.WriteLine("\nDeclarativo.");
            var result1=numeros.Select(n => n * n);
            foreach (var numero in result1) Console.WriteLine(numero);

            #endregion

            #region Reduccion de elemento

            //Obtener la suma de los elementos

            //Imperativo
            Console.WriteLine("\nImperativo.");
            var sum = 0;
            foreach (var numero in numeros) sum+=numero;
            Console.WriteLine(sum);

            //Declarativo
            Console.WriteLine("\nDeclarativo.");
            int result2 = numeros.Aggregate((acumulador, n)=> n+acumulador);
            Console.WriteLine(result2);

            #endregion

            #region Ordenamiento e interaciones funcionales

            //Obtener la lista ordenada asc o desc
            //Iterar funcionalmente

            //Declarativo
            Console.WriteLine("\nDeclarativo.");
            calificaciones.OrderByDescending(n => n).ToList().ForEach(n => Console.WriteLine(n));

            #endregion

            #region Encontrar elemento

            //Buscar si el numero 7 se encuentra en la collecion

            //Declarativo
            Console.WriteLine("\nDeclarativo.");

            //Contains
            bool existe = calificaciones.Contains(71);
            Console.WriteLine(existe);


            //Any
            existe=calificaciones.Any(n => n==10);
            Console.WriteLine(existe);


            //Find retorna el elemento si existe, sino retorna un valor por default.
            result = calificaciones.Find(n => n == 5);
            Console.WriteLine(result);

            //Single retorna el elemento si existe, sino genera una excepcion
            result = calificaciones.Single(n => n == 7);
            Console.WriteLine(result);
            #endregion

            #region Join query
            Console.WriteLine("\n///Join");
            var users = User.Users();
            var taks = Task.Tasks();
            (from user in users
             join task in taks on user.Id equals task.UserId
             select new
             {
                 Task = task.Name,
                 User = user.UserName
             }
            ).ToList().ForEach(ut =>
            Console.WriteLine($"User name: {ut.User}, Taks: {ut.Task}"));

            #endregion

            #region Join Distinct query 
            Console.WriteLine("\n///Distinct");
            (from user in users
             join task in taks on user.Id equals task.UserId
             select user.UserName
            ).Distinct() ///Se usa para no obtener registro duplicados.
            .ToList().ForEach(u =>
            Console.WriteLine($"User name: {u}"));

            #endregion

            #region Group by and order by 
            //Obtener la cantidad por usuario y ordenar por cantidad de tareas de manera desendente.
            Console.WriteLine("\n///group");
            (from user in users
             join task in taks on user.Id equals task.UserId
             group user by user.UserName into groupUser
             orderby groupUser.Count() descending
             select  new
             {
                 Message = $"UserName: {groupUser.Key} , Cantidad de tareas: {groupUser.Count()}"
             }
            ).ToList().ForEach(m =>
            Console.WriteLine(m));

            #endregion

            #region Left join 
            //Obtener username de usuario que no tengan tareas. 

            Console.WriteLine("\n///Left join");
            (from user in users
             join task in taks on user.Id equals task.UserId into relacion
             from a in relacion.DefaultIfEmpty()
             where a==null
             select user.UserName
            ).ToList().ForEach(u =>
            Console.WriteLine(u));

            #endregion
        }
    }
}
