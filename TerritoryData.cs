using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialL4G
{
    class TerritoryData
    {
            public TerritoryData()
            {
                LTerritorio = new List<Territory>();
            }

            public List<Territory> LTerritorio { get; set; }

            public List<Territory> ObtenerTerritorios(Territory territory)
            {

                using (NorthwindEntities n = new NorthwindEntities())
                {
                    return LTerritorio = n.Territories.ToList();
                }
            }

            public bool Insertar(Territory territory)
            {
                Console.WriteLine("Digite el ID:");
                territory.TerritoryID = Console.ReadLine();
                Console.WriteLine("Digite la descripcion:");
                territory.TerritoryDescription = Console.ReadLine();
                Console.WriteLine("Digite el ID de region:");
                try
                {
                    territory.RegionID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }

                try
                {
                    using (NorthwindEntities n = new NorthwindEntities())
                    {
                        n.Territories.Add(territory);
                        n.SaveChanges();
                        Console.WriteLine("El territorio ha sido agregado");
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

            public bool Actualizar(Territory territory)
            {

                Console.WriteLine("Digite el ID:");
                territory.TerritoryID = Console.ReadLine();
                Console.WriteLine("Digite la nueva descripcion:");
                territory.TerritoryDescription = Console.ReadLine();
                Console.WriteLine("Digite el nuevo ID de region:");
                try
                {
                    territory.RegionID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }

                try
                {
                    using (NorthwindEntities n = new NorthwindEntities())
                    {
                        var resultado = n.Territories.Where(a => a.TerritoryID == territory.TerritoryID).Select(x => x).FirstOrDefault();
                        resultado.TerritoryDescription = territory.TerritoryDescription;
                        resultado.RegionID = territory.RegionID;
                        n.SaveChanges();
                        Console.WriteLine("El territorio ha sido actualizado");
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

            public bool Eliminar(Territory territory)
            {

                Console.WriteLine("Digite el ID:");
                territory.TerritoryID = Console.ReadLine();

                try
                {
                    using (NorthwindEntities n = new NorthwindEntities())
                    {
                        var resultado = n.Territories.Where(a => a.TerritoryID == territory.TerritoryID).Select(x => x).FirstOrDefault();
                        n.Territories.Remove(resultado);
                        n.SaveChanges();
                        Console.WriteLine("El territorio ha sido eliminado");
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

