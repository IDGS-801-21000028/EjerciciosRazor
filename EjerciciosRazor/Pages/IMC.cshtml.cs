using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; } = 0;

        [BindProperty]
        public double Altura { get; set; } = 0;
        public double IMC { get; set; } = 0;
        public string Clasificacion { get; set; } = "";
        public string ImgReco { get; set; } = "";

        public void OnPost()
        {
            Altura = Altura / 100;
            IMC = Math.Round((Peso / Altura / Altura), 2);
            Clasificacion = ClasificacionIMC(IMC);
            ImgReco = ObtenerImg(IMC);
        }

        public string ClasificacionIMC(double imc)
        {
            if (imc < 18) return "Peso Bajo";
            if (imc >= 18 && imc < 25) return "Peso Normal";
            if (imc >= 25 && imc < 27) return "Sobrepeso";
            if (imc >= 27 && imc < 30) return "Obesidad grado I";
            if (imc >= 30 && imc < 40) return "Obesidad grado II";
            return "Obesidad grado III";
        }

        public string ObtenerImg(double imc)
        {
            if (imc < 18) return "~/img/pesoBajo.jpeg";
            if (imc >= 18 && imc < 25) return "~/img/pesoNormal.png";
            if (imc >= 25 && imc < 27) return "~/img/sobrepeso.jpeg";
            if (imc >= 27 && imc < 30) return "~/img/obesidad_grado_I.jpg";
            if (imc >= 30 && imc < 40) return "~/img/obesidad_grado_II.jpeg";
            return "~/img/obesidad_grado_III.jpeg";
        }
    }
}
