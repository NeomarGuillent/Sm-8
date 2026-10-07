using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres=new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Sistemas de notas");
            Console.WriteLine("*****************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a  la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre= Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota: ");
                nota=double.Parse(Console.ReadLine());
                if(nota>=0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error: La nota debe ser [0-20]:");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void mostrar()
        {
            Console.WriteLine("*******Listado de Estudiantes*********");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for(int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + "-Nota:" + notas[i]);
            }
        }
        static public void buscar_estudiante()
        {
            Console.WriteLine("**********BUSCAR ESTUDIANTE**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                {
                    Console.WriteLine(nombres[i] + "NOTA:" + notas[i]);
                    encontrado = true;
                    break;
                }
                if (!encontrado)
                {
                    Console.WriteLine("No se encontró el estudiante");
                }
            }
        }
        static public void modificar_estudiante()
        {
            Console.WriteLine("**********MODIFICAR ESTUDIANTE**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                {
                    Console.WriteLine(nombres[i] + "NOTA:" + notas[i]);
                    encontrado = true;
                    double nota;
                    while (true)
                    {
                        Console.Write("Ingresar nueva nota: ");
                        nota = double.Parse(Console.ReadLine());
                        if (nota >= 0 && nota <= 20)
                        {
                            Console.Write("Ingresar nueva nota: ");
                            nota = double.Parse(Console.ReadLine());
                            if (nota >= 0 && nota <= 20)
                            {
                                notas[i] = nota;
                                Console.WriteLine("Nota modificada correctamente");
                                break;
                            }
                            Console.WriteLine("Error: La nota debe ser [0-20]:");
                        }
                    }
                }
                Console.WriteLine("No se encontró el estudiante");
            }
        }
        static public void burbuja()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_notas = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_notas;
                        temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombres;

                    }
                }
            }
        }
        static public void seleccion()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0; i < contador - 1; i++)
            {
                int mayor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[mayor])
                    {
                        mayor = j;
                    }
                }
                temp_notas = notas[i];
                notas[i] = notas[mayor];
                notas[mayor] = temp_notas;
                temp_nombres = nombres[i];
                nombres[i] = nombres[mayor];
                nombres[mayor] = temp_nombres;
            }
            Console.WriteLine("***** REPORTE ORDENADO DESCENDENTEMENTE *****");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".- " + nombres[i] + " - Nota: " + notas[i]);
            }
        }
        static public void promedio_maxima()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }

            double suma = 0;
            double maxima = notas[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];

                if (notas[i] > maxima)
                {
                    maxima = notas[i];
                }
            }
            double promedio = suma / contador;
            Console.WriteLine("***** PROMEDIO Y NOTA MÁXIMA *****");
            Console.WriteLine("Promedio: " + promedio);
            Console.WriteLine("Nota máxima: " + maxima);
        }
        static void Pausar()
        {
            Console.WriteLine("\nPresiona una tecla para volver al menú...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            
            int opc = 0;
            while (opc!=8)
            {
                Console.Clear();
                Titulo();
                Console.WriteLine("*****MENU PRINCIPAL********");
                Console.WriteLine("[1]Registrar estudiante");
                Console.WriteLine("[2]Buscar estudiantes");
                Console.WriteLine("[3]Modificar nota");
                Console.WriteLine("[4]Mostrar lista sin ordenar");
                Console.WriteLine("[5]Mostrar reporte ordenado por burbuja");
                Console.WriteLine("[6]Mostrar reporte ordenado descendentemente");
                Console.WriteLine("[7]Mostrar reporte de promedio y nota maxima"); 
                Console.WriteLine("[8]Salir");
                Console.Write("Ingresar opcion: ");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, debe ingresar un valor numerico");
                    continue;
                }
                if (opc<1 || opc > 8)
                {
                    Console.WriteLine("Error, opcion fuera de rango[1-8]:");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        Console.WriteLine("\n Estudiante registrado correctamente.");
                        Pausar();
                        break;
                    case 2:
                        buscar_estudiante();
                        Pausar();
                        break;
                    case 3:
                        modificar_estudiante();
                        Pausar();
                        break;
                    case 4:
                        mostrar();
                        Pausar();
                        break;
                    case 5:
                        burbuja();
                        Console.WriteLine("\n Lista ordenada por burbuja correctamente.");
                        mostrar();
                        break;
                    case 6:               
                        seleccion();
                        Pausar();
                        break;
                    case 7:
                        promedio_maxima();
                        Pausar();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta..!!");
                        break;

                }

            }

        }
    }
}
