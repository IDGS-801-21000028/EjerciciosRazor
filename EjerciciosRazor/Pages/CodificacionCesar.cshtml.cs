using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace EjerciciosRazor.Pages
{
    public class CodificacionCesarModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; } = "";
        [BindProperty]
        public int Desplazamiento { get; set; }
        public string Resultado { get; set; } = "";

        public void OnPost(string accion)
        {
            if (accion == "codificar")
            {
                Resultado = Codificar(Mensaje, Desplazamiento);
            }
            else if (accion == "decodificar")
            {
                Resultado = Decodificar(Mensaje, Desplazamiento);
            }
        }

        private string Codificar(string mensaje, int desplazamiento)
        {
            return Transformar(mensaje, desplazamiento);
        }

        private string Decodificar(string mensaje, int desplazamiento)
        {
            return Transformar(mensaje, -desplazamiento);
        }

        private string Transformar(string mensaje, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in mensaje.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    resultado.Append(TransformarLetra(c, desplazamiento));
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }

        private char TransformarLetra(char letra, int desplazamiento)
        {
            int indiceOriginal = letra - 'A';
            int nuevoIndice = (indiceOriginal + desplazamiento + 26) % 26; // Agregar 26 para manejar valores negativos
            char letraTransformada = 'A';

            switch (nuevoIndice)
            {
                case 0: letraTransformada = 'A'; break;
                case 1: letraTransformada = 'B'; break;
                case 2: letraTransformada = 'C'; break;
                case 3: letraTransformada = 'D'; break;
                case 4: letraTransformada = 'E'; break;
                case 5: letraTransformada = 'F'; break;
                case 6: letraTransformada = 'G'; break;
                case 7: letraTransformada = 'H'; break;
                case 8: letraTransformada = 'I'; break;
                case 9: letraTransformada = 'J'; break;
                case 10: letraTransformada = 'K'; break;
                case 11: letraTransformada = 'L'; break;
                case 12: letraTransformada = 'M'; break;
                case 13: letraTransformada = 'N'; break;
                case 14: letraTransformada = 'O'; break;
                case 15: letraTransformada = 'P'; break;
                case 16: letraTransformada = 'Q'; break;
                case 17: letraTransformada = 'R'; break;
                case 18: letraTransformada = 'S'; break;
                case 19: letraTransformada = 'T'; break;
                case 20: letraTransformada = 'U'; break;
                case 21: letraTransformada = 'V'; break;
                case 22: letraTransformada = 'W'; break;
                case 23: letraTransformada = 'X'; break;
                case 24: letraTransformada = 'Y'; break;
                case 25: letraTransformada = 'Z'; break;
            }

            return letraTransformada;
        }
    }
}
