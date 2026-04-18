using System;
using System.IO;

namespace tallerIUJO01
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*** Taller 01 ***");
            
            string registroUsuario = "ID_77; juanperez; EVALUACION; 95";
            
            Console.WriteLine("registroUsuario:");
            string registroLimpio = registroUsuario.Trim();
            Console.WriteLine(registroLimpio);
            
            string[] partes = registroLimpio.Split(';');
            string id = partes[0].Trim();
            string nombre = partes[1].Trim();
            string tareas = partes[2].Trim();
            string nota = partes[3].Trim();
            
            Console.WriteLine(string.Format("El id es: {0} del usuario {1} con la nota {2}", id, nombre, nota));
            
            string rutaraiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos IUJO");
            
            if (!Directory.Exists(rutaraiz))
            {
                Directory.CreateDirectory(Path.Combine(rutaraiz, "Reportes"));
                Console.WriteLine("Creando directorio correctamente");
            }
            
            string archivotexto = Path.Combine(rutaraiz, "Reportes", "notas.txt");
            
            using (StreamWriter sw = new StreamWriter(archivotexto, true))
            {
                sw.WriteLine(string.Format("ID: {0} nota {1} ({2})", id, nota, DateTime.Now.ToString("yyyy-MM-dd HH:mm")));
            }
            
            Console.WriteLine("\n--- Verificación de Archivo ---");
            Console.WriteLine("Archivo guardado en: " + archivotexto);
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(File.ReadAllText(archivotexto));
            
            Console.WriteLine("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
