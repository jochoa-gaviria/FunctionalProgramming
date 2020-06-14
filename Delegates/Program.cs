using System;

namespace Delegates
{
    class Program
    {
        /// <summary>
        /// Ejemplo cajero electronico u operaciones financieras
        /// Los delegados son muy parecidos al patron de diseño Builder
        /// </summary>

        #region Delegate

        public delegate float DelegateOperation(float val1, float val2);

        #endregion

        #region funciones
        public static float Deposito(float valor, float saldo)
        {
            return saldo + valor;
        }

        public static float Retiro(float valor, float saldo)
        {
            if (valor>saldo)
            {
                Console.WriteLine("Saldo insuficiente");
                return 0.0f;
            }
            return saldo - valor;
        }

        public static float ExecuteOperation(DelegateOperation operation, float valor, float saldo)
        {
            return operation(valor, saldo);
        }
        #endregion

        #region main

        static void Main(string[] args)
        {
            DelegateOperation retiro = Retiro;
            DelegateOperation deposito = Deposito;

            Console.WriteLine($"Ejecutamos retiro {ExecuteOperation(retiro, 10, 500)}");
            Console.WriteLine($"Ejecutamos deposito {ExecuteOperation(deposito, 40, 500)}");

            # region Delegate y Lambda Expession

            DelegateOperation depositoInteres = (valor, saldo) =>
            valor > 100 ? deposito((valor + valor * 0.02f), saldo) : deposito(valor, saldo);

            //{
            //    if (valor >= 100)
            //    {
            //        return deposito((valor + valor * 0.02f), saldo);
            //    }
            //    return deposito(valor, saldo);
            //};

            Console.WriteLine($"Ejecutamos deposito con interes {ExecuteOperation(depositoInteres, 150, 10000)}");


            #endregion
        }

        #endregion
    }
}
