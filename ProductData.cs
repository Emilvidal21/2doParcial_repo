
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialL4G
{
    class ProductData
    {
        public ProductData()
        {
            LProducto = new List<Product>();
        }



        public List<Product> LProducto { get; set; }

        public List<Product> ObtenerProductos(Product product)
        {
            using (NorthwindEntities n = new NorthwindEntities())
            {
                return LProducto = n.Products.ToList();
            }
        }

        public bool Insertar(Product product)
        {
            Category c = new Category();


            Console.WriteLine("Digite el nombre:");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Digite la categoria:");
            try
            {
                product.CategoryID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }

            Console.WriteLine("Digite la cantidad por unidad del producto:");
            try
            {
                product.QuantityPerUnit = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }

            Console.WriteLine("Digite el precio:");
            try
            {
                product.UnitPrice = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }

            product.Discontinued = false;

            try
            {
                using (NorthwindEntities n = new NorthwindEntities())
                {
                    n.Products.Add(product);
                    n.SaveChanges();
                    
                    Console.WriteLine("El producto ha sido agregado");
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
        
        public bool Actualizar(Product product)
        {

            Console.WriteLine("Digite el ID:");
            
            try
            {
                product.ProductID = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadLine();
                return false;
            }

            NorthwindEntities n = new NorthwindEntities();
            var resultado = n.Products.Where(a => a.ProductID == product.ProductID).Select(x => x).FirstOrDefault();
            product.Discontinued = resultado.Discontinued;

            if (product.Discontinued == false)
            {
                Console.WriteLine("¿Desea descontinuar el producto?");
                if (Console.ReadLine() == "si")
                {
                    product.Discontinued = true;
                }

            }
            else
            {
                Console.WriteLine("¿Desea reactivarar el producto?");
                if (Console.ReadLine() == "si")
                {
                    product.Discontinued = false;
                }
            }

            if (product.Discontinued == false)
            {
                Console.WriteLine("Digite el nuevo nombre:");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Digite la nueva categoria:");
                try
                {
                    product.CategoryID = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }

                Console.WriteLine("Digite la nueva cantidad por unidad del producto:");
                try
                {
                    product.QuantityPerUnit = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }

                Console.WriteLine("Digite el nuevo precio:");
                try
                {
                    product.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }

            }
            try
            {
                using (n)
                {
                    if (product.Discontinued == false)
                    {
                        resultado.ProductName = product.ProductName;
                        resultado.CategoryID = product.CategoryID;
                        resultado.QuantityPerUnit = product.QuantityPerUnit;
                        resultado.UnitPrice = product.UnitPrice;
                    }
                    resultado.Discontinued = product.Discontinued;
                    n.SaveChanges();
                    Console.WriteLine("El producto ha sido actualizado");

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

        public bool Eliminar(Product product)
        {

            Console.WriteLine("Digite el ID:");
            try
            {
                product.ProductID = Convert.ToInt32(Console.ReadLine());
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
                    var resultado = n.Products.Where(a => a.ProductID == product.ProductID).Select(x => x).FirstOrDefault();
                    n.Products.Remove(resultado);
                    n.SaveChanges();
                    Console.WriteLine("El producto ha sido eliminado");
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
