using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SegundoParcialL4G
{
    class Program
    {
        static void Main(string[] args)
        {
            string resp;

            do
            {
                Console.Clear();
                Console.WriteLine("Escoja una opcion:");
                Console.WriteLine("1-Mantenimiento de Productos");
                Console.WriteLine("2-Mantenimiento de Territorios");
                Console.WriteLine("3-Mantenimiento de Categorias");
                Console.WriteLine("4-Creacion de Factura");
                Console.WriteLine("5-Cargar informacion de cliente");
                Console.WriteLine("6-Exportar Factura");
                Console.WriteLine("7-Salir");


                resp = Console.ReadLine();

                
                switch (resp)
                {
                    case "1":
                        Console.Clear();

                        Product product = new Product();
                        ProductData pd = new ProductData();

                        do
                        {
                            
                            Console.WriteLine("Escoja una opcion para el mantenimiento de producto:");
                            Console.WriteLine("1-Enlistar");
                            Console.WriteLine("2-Agregar");
                            Console.WriteLine("3-Actualizar");
                            Console.WriteLine("4-Eliminar");
                            Console.WriteLine("5-Salir");

                            resp = Console.ReadLine();


                            switch (resp)
                            {
                                case "1":

                                    Console.Write("ID".PadRight(3));
                                    Console.Write("Nombre".PadRight(40));
                                    Console.Write("Categoria".PadRight(16));
                                    Console.Write("Cantidad por Unidad".PadRight(21));
                                    Console.Write("Precio por Unidad".PadRight(18));
                                    Console.WriteLine("¿Descontinuado?".PadRight(15));
                                    NorthwindEntities np = new NorthwindEntities();

                                    pd.ObtenerProductos(product);
                                    foreach (Product p in pd.LProducto)
                                    {
                                        var category = np.Categories.Where(a => a.CategoryID == p.CategoryID).Select(x => x).FirstOrDefault();
                                        Console.Write(Convert.ToString(p.ProductID).PadRight(3));
                                        Console.Write(p.ProductName.PadRight(40));
                                        Console.Write(category.CategoryName.PadRight(16));
                                        Console.Write(Convert.ToString(p.QuantityPerUnit).PadRight(21));
                                        Console.Write(Convert.ToString(p.UnitPrice).PadRight(18));
                                        Console.WriteLine(Convert.ToString(p.Discontinued).PadRight(15));
                                    }

                                    break;

                                case "2":

                                    pd.Insertar(product);
                                    break;

                                case "3":

                                    pd.Actualizar(product);
                                    break;

                                case "4":

                                    pd.Eliminar(product);
                                    break;

                                case "5":


                                    break;
                                default:
                                    Console.WriteLine("La opcion no es valida");
                                    Console.ReadLine();
                                    break;
                            }

                        } while (resp != "5");

                        break;
                    case "2":

                        Console.Clear();

                        Territory territory = new Territory();
                        TerritoryData td = new TerritoryData();
                        

                        do
                        {
                            Console.WriteLine("Escoja una opcion para el mantenimiento de territorio:");
                            Console.WriteLine("1-Enlistar");
                            Console.WriteLine("2-Agregar");
                            Console.WriteLine("3-Actualizar");
                            Console.WriteLine("4-Eliminar");
                            Console.WriteLine("5-Salir");

                            resp = Console.ReadLine();


                            switch (resp)
                            {
                                case "1":

                                    Console.Write("ID".PadRight(6));
                                    Console.Write("Descripcion".PadRight(50));
                                    Console.WriteLine("Region".PadRight(11));
                                    td.ObtenerTerritorios(territory);
                                    NorthwindEntities nr = new NorthwindEntities();
                                    
                                    foreach (Territory t in td.LTerritorio)
                                    {
                                        var region = nr.Regions.Where(a => a.RegionID == t.RegionID).Select(x => x).FirstOrDefault();
                                        Console.Write(Convert.ToString(t.TerritoryID).PadRight(6));
                                        Console.Write(t.TerritoryDescription.PadRight(50));
                                        Console.WriteLine(region.RegionDescription.PadRight(11));                             
                                    }

                                    break;

                                case "2":

                                    td.Insertar(territory);
                                    break;

                                case "3":

                                    td.Actualizar(territory);
                                    break;

                                case "4":

                                    td.Eliminar(territory);
                                    break;

                                case "5":


                                    break;
                                default:
                                    Console.WriteLine("La opcion no es valida");
                                    break;
                            }

                        } while (resp != "5");

                        break;

                    case "3":

                        Console.Clear();

                        Category categoria = new Category();
                        CategoriaData cd = new CategoriaData();

                        do
                        {
                            Console.WriteLine("Escoja una opcion para el mantenimiento de categorias:");
                            Console.WriteLine("1-Enlistar");
                            Console.WriteLine("2-Agregar");
                            Console.WriteLine("3-Actualizar");
                            Console.WriteLine("4-Eliminar");
                            Console.WriteLine("5-Salir");

                            resp = Console.ReadLine();


                            switch (resp)
                            {
                                case "1":

                                    Console.Write("ID".PadRight(3));
                                    Console.Write("Nombre".PadRight(16));
                                    Console.WriteLine("Descripcion".PadRight(60));
                                    cd.ObtenerCategorias(categoria);
                                    foreach (Category c in cd.LCategoria)
                                    {
                                        Console.Write(Convert.ToString(c.CategoryID).PadRight(3));
                                        Console.Write(c.CategoryName.PadRight(16));
                                        Console.WriteLine(c.Description.PadRight(60));
                                    }

                                    break;

                                case "2":

                                    cd.Insertar(categoria);
                                    break;

                                case "3":

                                    cd.Actualizar(categoria);
                                    break;

                                case "4":

                                    cd.Eliminar(categoria);
                                    break;

                                case "5":


                                    break;
                                default:
                                    Console.WriteLine("La opcion no es valida");
                                    break;
                            }

                        } while (resp != "5");

                        break;

                    case "4":

                        Order order = new Order();
                        Order_Detail detail = new Order_Detail();
                        FactData fd = new FactData();

                        fd.Insertar(order, detail, resp);
                        
                        break;

                    case "5":

                        List<Customer> LCustomer = new List<Customer>();
                        NorthwindEntities n = new NorthwindEntities();
                        LCustomer = n.Customers.ToList();

                        string ruta = Properties.Settings.Default.RutaArchivo;
                        StreamReader reader = new StreamReader(ruta);
                        string contenido = null;
                        string[] contenidoTemp = null;

                        contenido = reader.ReadLine();

                        try
                        {
                            while (contenido != null)
                            {
                                bool comp = false;
                                contenidoTemp = contenido.Split(',');

                                foreach (Customer c in LCustomer)
                                {
                                   
                                    if (c.CustomerID == contenidoTemp[0])
                                    {
                                        var resultado = n.Customers.Where(a => a.CustomerID == c.CustomerID).Select(x => x).FirstOrDefault();
                                        resultado.CompanyName = contenidoTemp[1];
                                        comp = true;
                                    }
                                    
                                }
                                if (comp == false)
                                {
                                    n.Customers.Add(new Customer { CustomerID = contenidoTemp[0], CompanyName = contenidoTemp[1] });
                                }
                                n.SaveChanges();

                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Los clientes no pudieron ser agregados");
                            Console.ReadLine();
                        }                        
                        reader.Close();


                        break;

                    case "7":

                        break;

                    default:
                        Console.WriteLine("La opcion no es valida");
                        Console.ReadLine();
                        break;
                }

            } while (resp != "7");

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
