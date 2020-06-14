using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //Las expresiones Lambda son expresiones anonimas que se almacenan en variables, no requieren uso de la palabra reservada 'return'

            #region First LambdaExpression

            Func<int, bool> par = numero => (numero % 2 == 0);
            int num=255;
            Console.WriteLine($"El numero {num} es par: {par(num)}");

            #endregion

            #region Expresiones con multiples parametros.
            int numero1 = 2;
            int numero2 = 5;
            Func<int, int, int> sum = (num1, num2) => num1 + num2;
            Console.WriteLine($"La suma de {numero1} y {numero2} es: {sum(numero1, numero2)}");
            #endregion

            #region Expresiones con multiples sentencias. Uso de expresiones regulares para validar el email.

            string expression;
            expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            Func<string, string, bool> validador = (correo,  regularExp)=>
            {
                if (Regex.IsMatch(correo, regularExp))
                {
                    if (Regex.Replace(correo, regularExp, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(">El correo es invalido");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(">El correo es invalido");
                    return false;
                }
            };
            Console.WriteLine($"El correo es valido: {validador("jochoa@visionamos.com", expression)}");
            #endregion

            #region Expresiones sin retorno.

            Action<string, int> saludar = (message, numero) => Console.WriteLine($"{message} , {numero}");

            saludar("Hello World!! this is an action from lambda expresion", 16);

            #endregion

            #region Exercises
            Exercises();

            CalDelegate suma = Sum;
            CalDelegate resta = Res;
            CalDelegate multiplicacion = Mul;
            CalDelegate division = Div;

            Console.WriteLine($"Ejecutamos suma {ExecuteOperation(suma, 40, 500)}");
            Console.WriteLine($"Ejecutamos resta {ExecuteOperation(resta, 500, 100)}");
            Console.WriteLine($"Ejecutamos multiplicacion {ExecuteOperation(multiplicacion, 10, 5)}");
            Console.WriteLine($"Ejecutamos division {ExecuteOperation(division, 10, 5)}");


            #endregion


        }

        public static void Exercises()
        {

            #region Numero primo
           Func<int, bool> primo = numero =>
           {
               int divisor = 2;
               while (divisor < numero)
               {
                   if (numero % divisor == 0) return false;
                   divisor++;
               }
               return true;
           };
            #endregion

            #region Factorial
            Func<int, long> factorial = numero =>
            {
                long result=1;
                for (int i = 2; i <= numero; i++)
                {
                    result = result * i;
                }
                return result;
            };
            #endregion

            #region Promedio numeros enteros
            Func<List<int>, float> promedio = numeros  => 
            {
                float result = 0;
                foreach (int number in numeros)
                {
                    result +=  number;
                }
                return result / numeros.Count;
            };
            #endregion

            #region Buscar el numero 79
            Func<List<int>, bool> search79 = numeros =>
            {
                foreach (int number in numeros)
                {
                    if (number == 79) return true;
                }
                return false;
            };
            #endregion

            #region 3 enteros ¿Son primos?
            Func<int, int, int, bool> primos = (num1, num2, num3) =>
            {
                if (primo(num1) && primo(num2) && primo(num3)) return true;
                return false;
            };
            #endregion

            #region Palabra palindroma
            Func<string, bool> palindroma = cadena =>
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] != cadena[cadena.Length - i - 1])
                        return false;
                }
                return true;
            };
            #endregion

            #region Lista palabras palindromas
            Func<List<string>, bool> palindromas = cadenas =>
            {
                foreach (string palabra in cadenas)
                {
                    if (!palindroma(palabra)) return false;
                }
                return true;
            };
            #endregion

            #region EjecucionExercises
            //1
            Console.WriteLine($"El numero 10 es primo: {primo(10)}");
            //2
            Console.WriteLine($"El factorial del numero 4 es: {factorial(4)}");
            //3
            List<int> numeros = new List<int>()
            {
                3,
                5,
                8,
                16, 
                58, 
                79
            };
            Console.WriteLine($"El promedio de los numeros es: {promedio(numeros)}");
            //4
            Console.WriteLine($"Esta el 79 en la lista: {search79(numeros)}");
            //5
            int numero1 = 5;
            int numero2 = 11;
            int numero3 = 3;
            Console.WriteLine($"Los numeros {numero1}, {numero2}, {numero3} son primos: {primos(numero1, numero2, numero3)}");
            //6
            Console.WriteLine($"La palabra Radar es palindroma: {palindroma("radar")}");
            //7
            List<string> palabras = new List<string>()
            {
                "radar",
                "orejero",
                "rotomotor",
                "solos"
            };

            Console.WriteLine($"Las palabra son palindromas: {palindromas(palabras)}");
            #endregion
        }

        #region Delegate Calculadora

        public delegate float CalDelegate(int val1, int val2);

        public static float Sum(int val1, int val2)
        {
            return val1 + val2;
        }
        public static float Res(int val1, int val2)
        {
            return val1 - val2;
        }

        public static float Mul(int val1, int val2)
        {
            return val1 * val2;
        }
        public static float Div(int val1, int val2)
        {
           Func<int, int, float> division = (val1,val2)=>
            val2 == 0 ? 0.0f : (val1 / val2);

            return division(val1, val2);
        }

        public static float ExecuteOperation(CalDelegate operation, int valor1, int valor2)
        {
            return operation(valor1, valor2);
        }
        #endregion

    }
}
