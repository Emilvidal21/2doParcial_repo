using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialL4G
{
    class CategoriaData
    {
        public CategoriaData()
        {
            LCategoria = new List<Category>();
        }

        public List<Category> LCategoria { get; set; }

        public List<Category> ObtenerCategorias(Category categoria)
        {
            using (NorthwindEntities n = new NorthwindEntities())
            {
                return LCategoria = n.Categories.ToList();
            }
        }

        public bool Insertar(Category categoria)
        {

            Console.WriteLine("Digite el nombre:");
            categoria.CategoryName = Console.ReadLine();
            Console.WriteLine("Digite la descripcion:");
            categoria.Description = Console.ReadLine();

            try
            {
                using (NorthwindEntities n = new NorthwindEntities())
                {
                    n.Categories.Add(categoria);
                    n.SaveChanges();
                    Console.WriteLine("La categoria ha sido agregada");
                    Console.ReadLine();

                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo ejecutar la accion");
                Console.ReadLine();
                return false;
            }
        }

        public bool Actualizar(Category categoria)
        {

            Console.WriteLine("Digite el ID:");
            try
            {
                categoria.CategoryID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }
            Console.WriteLine("Digite el nuevo nombre:");
            categoria.CategoryName = Console.ReadLine();
            Console.WriteLine("Digite la nueva descripcion:");
            categoria.Description = Console.ReadLine();

            try
            {
                using (NorthwindEntities n = new NorthwindEntities())
                {
                    var resultado = n.Categories.Where(a => a.CategoryID == categoria.CategoryID).Select(x => x).FirstOrDefault();
                    resultado.CategoryName = categoria.CategoryName;
                    resultado.Description = categoria.Description;
                    n.SaveChanges();
                    Console.WriteLine("La categoria ha sido actualizada");
                    Console.ReadLine();

                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo ejecutar la accion");
                Console.ReadLine();
                return false;
            }

        }

        public bool Eliminar(Category categoria)
        {

            Console.WriteLine("Digite el ID:");
            try
            {
                categoria.CategoryID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }

            try
            {
                using (NorthwindEntities n = new NorthwindEntities())
                {
                    var resultado = n.Categories.Where(a => a.CategoryID == categoria.CategoryID).Select(x => x).FirstOrDefault();
                    n.Categories.Remove(resultado);
                    n.SaveChanges();
                    Console.WriteLine("La categoria ha sido eliminada");
                    Console.ReadLine();

                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo ejecutar la accion");
                Console.ReadLine();
                return false;
            }

        }

       
    }
}
