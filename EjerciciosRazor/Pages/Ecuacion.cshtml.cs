using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Reflection.Emit;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

namespace EjerciciosRazor.Pages
{
    public class EcuacionModel : PageModel
    {
        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public double N { get; set; }

        public double resExpr = 0.0;

        public Dictionary<(double, double), double> resultados = new Dictionary<(double, double), double>();

        public void OnPost(string accion)
        {
            resExpr = CalcularExpresion();
            CalcularSuma();
            Console.WriteLine(resultados);
        }

        public double CalcularExpresion()
        {
            return Math.Pow((A * X) + (B * Y), N);
        }

        public double CalcularFactorial(double fac)
        {
            double factorial = 1.0;

            for (double i = fac; i >= 1; i--)
            {
                factorial *= i;
            }

            return factorial;
        }

        public double CalcularKN(double k, double n)
        {          
            return CalcularFactorial(n) / (CalcularFactorial(k) * CalcularFactorial(n - k));
        }

        public double CalcularMul(double k)
        {
            return Math.Pow((A * X),(N-k)) * Math.Pow((B * Y), k);

        }

        public void CalcularSuma()
        {
            for (double k = 0.0; k <= N; k++)
            {              
                double resultado = CalcularKN(k, N) * CalcularMul(k);
                resultados[(k, N)] = resultado;                
            }
        }
    }
}