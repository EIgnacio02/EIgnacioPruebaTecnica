using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Add();
            Delete();
            
        }

        public static void Add()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingresa los datos");

            Console.WriteLine("Ingresa el nombre");
            libro.Nombre=Console.ReadLine();

            Console.WriteLine("Ingresa el Numero de Paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la Fecha de Publicacion");
            libro.FechaPublicacion = Console.ReadLine();
            
            Console.WriteLine("Ingresa la edicion");
            libro.Edicion = Console.ReadLine();
            
            libro.Autor = new ML.Autor();
            Console.WriteLine("Ingresa el autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Ingresa la editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new ML.Genero();
            Console.WriteLine("Ingresa el Genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }


        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingresa los datos");

            Console.WriteLine("Ingresa el IdLibro para que se eliminado");
            libro.IdLibro = int.Parse(Console.ReadLine());


            ML.Result result = BL.Libro.Delete(libro.IdLibro);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }


    }
}
