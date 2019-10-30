using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialL4G
{
    class FactData
    {
        public bool Insertar(Order order, string resp)
        {
                      

            using (NorthwindEntities n = new NorthwindEntities())
            { 
                Console.WriteLine("Digite el ID de cliente:");
                try
                {
                    order.CustomerID = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Valor invalido");
                    Console.ReadLine();
                    return false;
                }
                
                order.OrderDate = DateTime.Now;
                

                try
                {                    
                    n.Orders.Add(order);
                    n.SaveChanges();
                    InsertarD(order, resp);
                    
                }
                    catch (Exception)
                {
                    Console.WriteLine("No se pudo ejecutar la accion");
                    return false;
                }
               
                return true;

            }

     





        }

        public bool InsertarD(Order order, string resp)
        {
            Order_Detail detail = new Order_Detail();
            do
            {
                using (NorthwindEntities no = new NorthwindEntities())
                {
                    
                    detail.OrderID = order.OrderID;
                    Console.WriteLine("Digite el ID del producto:");
                    detail.ProductID = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        detail.ProductID = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Valor invalido");
                        Console.ReadLine();
                        return false;
                    }
                    detail.Product = no.Products.Where(a => a.ProductID == detail.ProductID).Select(x => x).FirstOrDefault();
                    detail.UnitPrice = Convert.ToDecimal(detail.Product.UnitPrice);
                    
                    do
                    {
                        try
                        {
                            resp = "1";
                            Console.WriteLine("Digite el la cantidad del producto:");
                            detail.Quantity = Convert.ToInt16(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Valor Invalido");
                            resp = "0";
                        }                      

                    } while (resp == "0");

                    Console.WriteLine("¿Hay descuento?:");
                    if (Console.ReadLine() == "si")
                    {
                        do
                        {
                            try
                            {
                                resp = "1";
                                Console.WriteLine("¿Cuanto es el descuento?");
                                detail.Discount = float.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Valor Invalido");
                                resp = "0";
                            }

                            if (detail.Discount >= 1)
                            {
                                Console.WriteLine("Valor Invalido");
                                resp = "0";
                            }

                        } while (resp == "0");
                    }
                    else
                    {
                        detail.Discount = 0;
                    }


                    try
                    {

                        no.Order_Details.Add(detail);
                        no.SaveChanges();
                        Console.WriteLine("Se ha agregado el producto a la lista");

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo ejecutar la accion");
                    }

                    do
                    {
                        Console.WriteLine("¿Desea agregar otro producto?");
                        resp = Console.ReadLine();
                        if (resp != "si" && resp != "no")
                        {
                            Console.WriteLine("La opcion no es valida");
                        }
                    } while (resp != "si" && resp != "no");

                }

            } while (resp != "no");
            return true;
        }
    }
}
