// See https://aka.ms/new-console-template for more information

namespace Ejercicio3___Hospital
{
    internal class Program
    {
        public delegate Dictionary<string, string> CalcularPresupuestoDelegate(decimal presupuestoTotal);

        public delegate bool PredicateDelegate(string area);

        public static void Main(string[] args)
        {
            // Crear una instancia del delegate para calcular el presupuesto
            CalcularPresupuestoDelegate calcularPresupuesto = CalcularPresupuesto;
            var presupuesto = calcularPresupuesto(500250m);

            Console.WriteLine("Presupuesto total por área:");
            foreach (var item in presupuesto)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Definición del predicate para filtrar áreas con presupuesto mayor a 200000
            PredicateDelegate filtro = area => decimal.Parse(presupuesto[area]) > 200000m;

            Console.WriteLine("\nÁreas con presupuesto mayor a 200000:");
            foreach (var item in presupuesto)
            {
                // Aplicación del predicate
                if (filtro(item.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        public static Dictionary<string, string> CalcularPresupuesto(decimal presupuestoTotal)
        {
            var presupuesto = new Dictionary<string, string>();

            decimal odontologia = presupuestoTotal * 0.4m;
            decimal traumatologia = presupuestoTotal * 0.25m;
            decimal pediatria = presupuestoTotal * 0.35m;

            presupuesto.Add("ODONTOLOGÍA", odontologia.ToString("N2"));
            presupuesto.Add("TRAUMATOLOGÍA", traumatologia.ToString("N2"));
            presupuesto.Add("PEDIATRÍA", pediatria.ToString("N2"));

            return presupuesto;
        }
    }
}