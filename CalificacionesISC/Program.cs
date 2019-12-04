using System;
using System.Collections.Generic;
using System.IO;

namespace CalificacionesISC
{
    class Program
    {
        public static void Main()
        {
            int Respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine("\t¿Que decea hacer?");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1.- Agregar nombres de alumnos");
                Console.WriteLine("2.- Agregar Calificacones a alumnos");
                Console.WriteLine("3.- Generar calificaciones finales a alumnos");
                Console.WriteLine("4.- Salir");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Respuesa: ");
                Respuesta = int.Parse(Console.ReadLine());

                switch (Respuesta)
                {
                    case 1:
                        AgregarAlumnos();
                        break;
                    case 2:
                        AgregarCalificaciones();
                        break;
                    case 3:
                        GenerarCalificacionesFinales();
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("\n-----------------------------------------------------------------");
                        Console.WriteLine("\t\tGracias por su preferencia");
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Esa no es una opcion correcta\nIntenta de nuevo");
                        break;
                }

                if (Respuesta == 4)
                    break;

            } while (Respuesta != 4);


        }

        private static void GenerarCalificacionesFinales()
        {
            Console.Clear();
            try
            {
                FileStream LeerAlumnos = File.OpenRead("NomAlumnos.txt");
                FileStream LeerCalUni1 = File.OpenRead("CalUni1.txt");
                FileStream LeerCalUni2 = File.OpenRead("CalUni2.txt");
                FileStream LeerCalUni3 = File.OpenRead("CalUni3.txt");
                FileStream LeerCalUni4 = File.OpenRead("CalUni4.txt");

                if (LeerAlumnos.CanRead && LeerAlumnos.Length >= 0 && LeerCalUni1.CanRead && LeerCalUni1.Length >= 0 && LeerCalUni2.CanRead && LeerCalUni2.Length >= 0 && LeerCalUni3.CanRead && LeerCalUni3.Length >= 0 && LeerCalUni4.CanRead && LeerCalUni4.Length >= 0)
                {
                    StreamWriter ArchivoCalificacionesFinalesISC = File.CreateText("CalificacionesFinalesISC.txt");

                    ArchivoCalificacionesFinalesISC.WriteLine("Nombre del alumno\t|\tCalificación U1\t|\tCalificación U2\t\t|\tCalificación U3\t\t|\tCalificación U4\t\t|\tPromedio\t|");

                    StreamReader LeerArchivoAlumnos = new StreamReader("NomAlumnos.txt");
                    StreamReader LeerArchivoCalUni1 = new StreamReader("CalUni1.txt");
                    StreamReader LeerArchivoCalUni2 = new StreamReader("CalUni2.txt");
                    StreamReader LeerArchivoCalUni3 = new StreamReader("CalUni3.txt");
                    StreamReader LeerArchivoCalUni4 = new StreamReader("CalUni4.txt");
                    string lineaAlumnos = LeerArchivoAlumnos.ReadLine();
                    string lineaCalUni1 = LeerArchivoCalUni1.ReadLine();
                    string lineaCalUni2 = LeerArchivoCalUni2.ReadLine();
                    string lineaCalUni3 = LeerArchivoCalUni3.ReadLine();
                    string lineaCalUni4 = LeerArchivoCalUni4.ReadLine();
                    while (lineaAlumnos != null && lineaCalUni1 != null && lineaCalUni2 != null && lineaCalUni3 != null && lineaCalUni4 != null)
                    {
                        int SumaCalificacionFinal=0;

                        SumaCalificacionFinal += int.Parse(lineaCalUni1) + int.Parse(lineaCalUni2) + int.Parse(lineaCalUni3) + int.Parse(lineaCalUni4);
                        float promedio = 0;
                        promedio = SumaCalificacionFinal / 4;

                        ArchivoCalificacionesFinalesISC.WriteLine(lineaAlumnos+ "\t|\t" +lineaCalUni1+ "\t\t|\t" + lineaCalUni2 + "\t\t|\t" + lineaCalUni3 + "\t\t|\t" + lineaCalUni4 + "\t\t|\t" + promedio.ToString()+"\t|");
                        
                        lineaAlumnos = LeerArchivoAlumnos.ReadLine();
                        lineaCalUni1 = LeerArchivoCalUni1.ReadLine();
                        lineaCalUni2 = LeerArchivoCalUni2.ReadLine();
                        lineaCalUni3 = LeerArchivoCalUni3.ReadLine();
                        lineaCalUni4 = LeerArchivoCalUni4.ReadLine();
                    }
                    LeerArchivoAlumnos.Close();
                    LeerArchivoCalUni1.Close();
                    LeerArchivoCalUni2.Close();
                    LeerArchivoCalUni3.Close();
                    LeerArchivoCalUni4.Close();
                    ArchivoCalificacionesFinalesISC.Close();

                    StreamReader LeerArchivoCalificacionFinal = new StreamReader("CalificacionesFinalesISC.txt");
                    string lineaCalificacionesFinales = LeerArchivoCalificacionFinal.ReadLine();

                    while (lineaCalificacionesFinales!=null)
                    {
                        Console.WriteLine(lineaCalificacionesFinales);
                        lineaCalificacionesFinales = LeerArchivoCalificacionFinal.ReadLine();
                    }
                    LeerArchivoCalificacionFinal.Close();
                }
                else if (!LeerAlumnos.CanRead && !LeerCalUni1.CanRead && !LeerCalUni2.CanRead && !LeerCalUni3.CanRead && !LeerCalUni4.CanRead)
                {
                    Console.WriteLine("No se puede leer alguno de los archivos");
                }
                else
                {
                    Console.WriteLine("Aun no has generado algun archivo");
                    Console.WriteLine("Primero agrega un alumnos");
                }

                LeerAlumnos.Close();
                LeerCalUni1.Close();
                LeerCalUni2.Close();
                LeerCalUni3.Close();
                LeerCalUni4.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
                Console.ReadKey();
            
        }

        private static void AgregarCalificaciones()
        {
            int Opcion;
            bool HayAlumnos = true;
            do
            {
                Console.Clear();
                Console.WriteLine("¿Que desa hacer?");
                Console.WriteLine("1.- Agregar Calificaciones de Unidad 1");
                Console.WriteLine("2.- Agregar Calificaciones de Unidad 2");
                Console.WriteLine("3.- Agregar Calificaciones de Unidad 3");
                Console.WriteLine("4.- Agregar Calificaciones de Unidad 4");
                Console.WriteLine("5.- Regresar al menu principal?");
                Console.Write("Opcion: ");
                Opcion = int.Parse(Console.ReadLine());

                if (Opcion >= 1 && Opcion <= 4)
                {
                    try
                    {
                        FileStream LEerAlumnos = File.OpenRead("NomAlumnos.txt");

                        if (LEerAlumnos.CanRead && LEerAlumnos.Length >= 0)
                        {
                            HayAlumnos = true;
                        }
                        else if (!LEerAlumnos.CanRead)
                        {
                            Console.WriteLine("No se puede leer el archivo ''NomAlumnos.txt''");
                            HayAlumnos = false;
                        }
                        else
                        {
                            Console.WriteLine("Aun no cuentas con ningun alumno agregado");
                            Console.WriteLine("Primero agrega un alumnos");
                            HayAlumnos = false;
                        }

                        LEerAlumnos.Close();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    
                }

                if (Opcion == 1 && HayAlumnos)
                {
                    StreamReader LeerAlumnos = new StreamReader("NomAlumnos.txt");
                    string linea=LeerAlumnos.ReadLine();
                    StreamWriter CrearArchivoCalificacionesUnidad1= File.CreateText("CalUni1.txt");
                    while (linea != null)
                    {
                        Console.Clear();
                        int Calificacion;

                        do
                        {
                            Console.WriteLine("Ingresa la Calificacion de " + linea + " sobre la unidad 1:");
                            Calificacion = int.Parse(Console.ReadLine());
                            if (!(Calificacion >= 0 && Calificacion <= 100))
                            {
                                Console.WriteLine("Ingresa Una calificacion correcta\n");
                            }

                        } while (!(Calificacion >= 0 && Calificacion <= 100));

                        CrearArchivoCalificacionesUnidad1.WriteLine(Calificacion.ToString());
                        linea = LeerAlumnos.ReadLine();
                    }
                    CrearArchivoCalificacionesUnidad1.Close();
                    LeerAlumnos.Close();
                }
                else if (Opcion == 2 && HayAlumnos)
                {
                    StreamReader LeerAlumnos = new StreamReader("NomAlumnos.txt");
                    string linea = LeerAlumnos.ReadLine();
                    StreamWriter CrearArchivoCalificacionesUnidad2 = File.CreateText("CalUni2.txt");
                    while (linea != null)
                    {
                        Console.Clear();
                        int Calificacion;

                        do
                        {
                            Console.WriteLine("Ingresa la Calificacion de " + linea + " sobre la unidad 2:");
                            Calificacion = int.Parse(Console.ReadLine());
                            if (!(Calificacion >= 0 && Calificacion <= 100))
                            {
                                Console.WriteLine("Ingresa Una calificacion correcta\n");
                            }

                        } while (!(Calificacion >= 0 && Calificacion <= 100));

                        CrearArchivoCalificacionesUnidad2.WriteLine(Calificacion.ToString());
                        linea = LeerAlumnos.ReadLine();
                    }
                    CrearArchivoCalificacionesUnidad2.Close();
                    LeerAlumnos.Close();
                }
                else if (Opcion == 3 && HayAlumnos)
                {
                    StreamReader LeerAlumnos = new StreamReader("NomAlumnos.txt");
                    string linea = LeerAlumnos.ReadLine();
                    StreamWriter CrearArchivoCalificacionesUnidad3 = File.CreateText("CalUni3.txt");
                    while (linea != null)
                    {
                        Console.Clear();
                        int Calificacion;

                        do
                        {
                            Console.WriteLine("Ingresa la Calificacion de " + linea + " sobre la unidad 3:");
                            Calificacion = int.Parse(Console.ReadLine());
                            if (!(Calificacion >= 0 && Calificacion <= 100))
                            {
                                Console.WriteLine("Ingresa Una calificacion correcta\n");
                            }

                        } while (!(Calificacion >= 0 && Calificacion <= 100));

                        CrearArchivoCalificacionesUnidad3.WriteLine(Calificacion.ToString());
                        linea = LeerAlumnos.ReadLine();
                    }
                    CrearArchivoCalificacionesUnidad3.Close();
                    LeerAlumnos.Close();
                }
                else if (Opcion == 4 && HayAlumnos)
                {
                    StreamReader LeerAlumnos = new StreamReader("NomAlumnos.txt");
                    string linea = LeerAlumnos.ReadLine();
                    StreamWriter CrearArchivoCalificacionesUnidad4 = File.CreateText("CalUni4.txt");
                    while (linea != null)
                    {
                        Console.Clear();
                        int Calificacion;

                        do
                        {
                            Console.WriteLine("Ingresa la Calificacion de " + linea + " sobre la unidad 4:");
                            Calificacion = int.Parse(Console.ReadLine());
                            if (!(Calificacion >= 0 && Calificacion <= 100))
                            {
                                Console.WriteLine("Ingresa Una calificacion correcta\n");
                            }

                        } while (!(Calificacion >= 0 && Calificacion <= 100));

                        CrearArchivoCalificacionesUnidad4.WriteLine(Calificacion.ToString());
                        linea = LeerAlumnos.ReadLine();
                    }
                    CrearArchivoCalificacionesUnidad4.Close();
                    LeerAlumnos.Close();
                }
                else if (Opcion == 5)
                {

                    Console.WriteLine("Usted regresara al menu principal");
                    Console.ReadKey();
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Ha elejido una respuesta incorrecta \nPor favor elija correctamente su respuesta");
                        Console.Write("Opcion: ");
                        Opcion = int.Parse(Console.ReadLine());

                    } while (Opcion != 1 && Opcion != 2 && Opcion != 3 && Opcion != 4 && Opcion != 5);
                }

            } while (Opcion != 5);

            Main();
        }
    

        private static void AgregarAlumnos()
        {
            int Opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("¿Que desa hacer?");
                Console.WriteLine("1.- Agregar alumnos");
                Console.WriteLine("2.- Regresar al menu principal");
                Console.Write("Opcion: ");
                Opcion = int.Parse(Console.ReadLine());

                if (Opcion == 1)
                {

                    StreamWriter EscribirArchivoAlumnos = File.CreateText("NomAlumnos.txt");
                    int R = 0;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("¿Cual es el nombre del alumno?");
                        EscribirArchivoAlumnos.WriteLine(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("¿Deceas ingresar otro alumno 1/si o 2/no?");
                            R = int.Parse(Console.ReadLine());

                        } while (R != 1 && R != 2);

                    } while (R != 2);

                    EscribirArchivoAlumnos.Close();
                }
                else if (Opcion == 2)
                {
                    Console.WriteLine("Usted regresara al menu principal");
                    Console.ReadKey();
                }
                else
                {
                    do
                    {

                        Console.WriteLine("Ha elejido una respuesta incorrecta \nPor favor elija correctamente su respuesta");
                        Console.Write("Opcion: ");
                        Opcion = int.Parse(Console.ReadLine());

                    } while (Opcion != 1 && Opcion != 2);
                }
            } while (Opcion!=2);

            Main();
        }
    }
}
