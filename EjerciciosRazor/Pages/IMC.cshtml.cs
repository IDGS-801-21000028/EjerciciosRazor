using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public float Peso { get; set; } = 0;

        [BindProperty]
        public float Altura { get; set; } = 0;
        public float IMC { get; set; } = 0;
        public string Clasificacion { get; set; } = "";
        public string ImgReco { get; set; } = "";

        public void OnPost()
        {
            IMC = Peso / (Altura * Altura);
            Clasificacion = ClasificacionIMC(IMC);
            ImgReco = ObtenerImg(IMC);
        }

        public string ClasificacionIMC(float imc)
        {
            if (imc < 18) return "Peso Bajo";
            if (imc >= 18 && imc < 25) return "Peso Normal";
            if (imc >= 25 && imc < 27) return "Sobrepeso";
            if (imc >= 27 && imc < 30) return "Obesidad grado I";
            if (imc >= 30 && imc < 40) return "Obesidad grado II";
            return "Obesidad grado III";
        }

        public string ObtenerImg(float imc)
        {
            if (imc < 18) return "/img/";
            if (imc >= 18 && imc < 25) return "/img/";
            if (imc >= 25 && imc < 27) return "/img/";
            if (imc >= 27 && imc < 30) return "/img/";
            if (imc >= 30 && imc < 40) return "/img/";
            return "/img/";
        }

    }
}
