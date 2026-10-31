using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IMCMVVM_CALC.Models;
using Microsoft.Extensions.Options;

namespace IMCMVVM_CALC.ViewModels
{
    public class IMCViewMoel : INotifyPropertyChanged
    {
        // Los Entry capturan texto, incluso cuando representan números.
        public string PesoT { get; set; } = "";
        public string EstaturaT { get; set; } = "";

        private string resultado = "Ingresa tus datos";
        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Resultado)));
            }
        }

        private string clasificacion = "";
        public string Clasificacion
        {
            get { return clasificacion; }
            set
            {
                clasificacion = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Clasificacion)));
            }
        }

        public ICommand CalcularCommand { get; }

        public IMCViewMoel()
        {
            CalcularCommand = new Command(Calcular);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Calcular()
        {
            // Validar el peso.
            bool pesoValidado = double.TryParse(PesoT, out double peso);

            if (!pesoValidado || !double.IsFinite(peso) || peso <= 0)
            {
                Resultado = "Escribe un peso válido mayor que cero.";
                Clasificacion = "";
                return;
            }

            // Validar la estatura.
            bool estaturaValidada = double.TryParse(EstaturaT, out double estatura);

            if (!estaturaValidada || !double.IsFinite(estatura) || estatura <= 0)
            {
                Resultado = "Escribe una estatura válida mayor que cero.";
                Clasificacion = "";
                return;
            }

            Persona persona = new Persona
            {
                Peso = peso,
                Estatura = estatura
            };

            double imc = persona.CalcularIMC();

            if (!double.IsFinite(imc))
            {
                Resultado = "Revisa el peso y la estatura.";
                Clasificacion = "";
                return;
            }

            if (imc < 18.5)
            {
                Clasificacion = "Peso bajo";
            }
            else if (imc < 25)
            {
                Clasificacion = "Peso normal";
            }
            else if (imc < 30)
            {
                Clasificacion = "Sobrepeso";
            }
            else
            {
                Clasificacion = "Obesidad";
            }

            Resultado = $"Tu IMC es: {imc:F2}";
        }
    }
}
