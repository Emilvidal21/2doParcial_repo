using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialL4G
{
    class FactData
    {
        public void Insertar(Order order, Order_Detail detail,string resp)
        {
                      

            using (NorthwindEntities n = new NorthwindEntities())
            { 
                Console.WriteLine("Digite el ID de cliente:");
                order.CustomerID = Console.ReadLine();
                order.OrderDate = DateTime.Now;
                n.Orders.Add(order);

                try
                {                    
                    n.Orders.Add(order);
                    n.SaveChanges();                   
                }
                    catch (Exception)
                {
                    Console.WriteLine("No se pudo ejecutar la accion");                  
                }

                InsertarD(order, detail, resp);
            }

     





        }

        public void InsertarD(Order order,Order_Detail detail, string resp)
        {
            do 
            {
                using (NorthwindEntities no = new NorthwindEntities())
                {

                    detail.OrderID = order.OrderID;
                    Console.WriteLine("Digite el ID del producto:");
                    detail.ProductID = Convert.ToInt32(Console.ReadLine());
                    var product = no.Products.Where(a => a.ProductID == detail.ProductID).Select(x => x).FirstOrDefault();
                    detail.UnitPrice = Convert.ToDecimal(product.UnitPrice);
                    Console.WriteLine("Digite el la cantidad del producto:");
                    detail.Quantity = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("¿Hay descuento?:");
                    if (Console.ReadLine() == "si")
                    {
                        do
                        {
                            try
                            {
                                Console.WriteLine("¿Cuanto es el descuento?");
                                detail.Discount = Convert.ToInt64(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Valor Invalido");
                            }
                        } while (detail.Discount == 0);
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
        }
    }
}
