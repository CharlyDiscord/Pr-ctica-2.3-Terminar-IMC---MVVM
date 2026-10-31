using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCMVVM_CALC.Models
{
    public class Persona
    {
        //datos numericos necesarios para el calculo
        //variables
        public double Peso { get; set; }
        public double Estatura { get; set; }
        //metodo que devuelve el IMC utilizando los datos de persona
        public double CalcularIMC()
        {
            return Peso / (Estatura * Estatura);
        }

    }
}