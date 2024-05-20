using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq; 


namespace EjerciciosRazor.Pages
{
    public class NumeroAleatoriosModel : PageModel
    {
        public int[] Numeros { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }
        public int[] NumerosOrdenados { get; set; }
        
        public void OnPost()
    {
        GenerarNumerosAleatorios();
        CalcularSuma();
        CalcularPromedio();
        CalcularModa();
        CalcularMediana();
        OrdenarNumeros();
    }

    private void GenerarNumerosAleatorios()
    {
        Random random = new Random();
        Numeros = new int[20];
        for (int i = 0; i < Numeros.Length; i++)
        {
            Numeros[i] = random.Next(0, 100);(
        }
    }

    private void CalcularSuma()
    {
        Suma = 0;
        foreach (int num in Numeros)
        {
            Suma += num;
        }
    }

    private void CalcularPromedio()
    {
        Promedio = (double)Suma / Numeros.Length;
    }

    private void CalcularModa()
    {
        Dictionary<int, int> frecuencia = new Dictionary<int, int>();
        foreach (int num in Numeros)
        {
            if (frecuencia.ContainsKey(num))
            {
                frecuencia[num]++;
            }
            else
            {
                frecuencia[num] = 1;
            }
        }

        int maxFrecuencia = frecuencia.Values.Max();
        Moda = frecuencia.Where(x => x.Value == maxFrecuencia).Select(x => x.Key).ToList();
    }

    private void CalcularMediana()
    {
        NumerosOrdenados = (int[])Numeros.Clone();
        Array.Sort(NumerosOrdenados);
        
        int medio = NumerosOrdenados.Length / 2;
        if (NumerosOrdenados.Length % 2 == 0)
        {
            Mediana = (NumerosOrdenados[medio - 1] + NumerosOrdenados[medio]) / 2.0;
        }
        else
        {
            Mediana = NumerosOrdenados[medio];
        }
    }

    private void OrdenarNumeros()
    {
        Array.Sort(NumerosOrdenados);
    }


    }
}