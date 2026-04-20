using System;
using System.Globalization;

namespace TareaDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culturaEspanola = new CultureInfo("es-ES");

            Console.Write("Introduce tu nombre completo: ");
            string nombreCompleto = Console.ReadLine();

            string primerNombre = "";
            int indiceEspacio = nombreCompleto.Trim().IndexOf(' ');
            if (indiceEspacio != -1)
            {
                primerNombre = nombreCompleto.Substring(0, indiceEspacio);
            }
            else
            {
                primerNombre = nombreCompleto;
            }

            DateTime fechaNacimiento;
            DateTime hoy = DateTime.Today;

            while (true)
            {
                Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
                string entradaFecha = Console.ReadLine();

                if (DateTime.TryParse(entradaFecha, culturaEspanola, DateTimeStyles.None, out fechaNacimiento))
                {
                    if (fechaNacimiento > hoy)
                    {
                        Console.WriteLine("Error: La fecha no puede estar en el futuro.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Formato no válido. Inténtalo de nuevo.");
                }
            }

            int edad = hoy.Year - fechaNacimiento.Year;
            if (hoy < fechaNacimiento.AddYears(edad)) 
            {
                edad--;
            }

            DateTime proximoCumple = new DateTime(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);
            if (proximoCumple < hoy)
            {
                proximoCumple = proximoCumple.AddYears(1);
            }

            int diasRestantes = (proximoCumple - hoy).Days;
            string signo = ObtenerSignoZodiaco(fechaNacimiento.Day, fechaNacimiento.Month);

            Console.WriteLine("\n-----------------------------------------");
            Console.WriteLine($"Hola, {primerNombre}!");
            Console.WriteLine($"Tienes {edad} años.");
            Console.WriteLine($"Tu cumpleaños es el {fechaNacimiento.ToString("dddd, d 'de' MMMM 'de' yyyy", culturaEspanola)}.");
            Console.WriteLine($"Tu signo del zodiaco es {signo}.");

            if (diasRestantes == 0)
            {
                Console.WriteLine("¡Felicidades! ¡Hoy es tu cumpleaños!");
            }
            else
            {
                Console.WriteLine($"Faltan {diasRestantes} días para tu próximo cumpleaños.");
            }
            Console.WriteLine("-----------------------------------------");
        }

        static string ObtenerSignoZodiaco(int dia, int mes)
        {
            if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19)) return "Aries";
            if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20)) return "Tauro";
            if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 20)) return "Géminis";
            if ((mes == 6 && dia >= 21) || (mes == 7 && dia <= 22)) return "Cáncer";
            if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22)) return "Leo";
            if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22)) return "Virgo";
            if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22)) return "Libra";
            if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21)) return "Escorpio";
            if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21)) return "Sagitario";
            if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 19)) return "Capricornio";
            if ((mes == 1 && dia >= 20) || (mes == 2 && dia <= 18)) return "Acuario";
            return "Piscis";
        }
    }
}