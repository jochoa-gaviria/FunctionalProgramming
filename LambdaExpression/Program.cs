using System;
using System.Text.RegularExpressions;

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


        }
    }
}
