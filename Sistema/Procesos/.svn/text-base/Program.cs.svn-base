using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Collections;  

namespace Procesos
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                    Console.WriteLine(args[0]);
                else
                    Console.WriteLine("No hay parametros...");

                Notificaciones alert = new Notificaciones();
                int opciones;
                if (!int.TryParse(args[0], out opciones))
                {
                    return;
                }
                if (((Opciones)opciones & Opciones.NotificarClientesSinCi) == Opciones.NotificarClientesSinCi)
                {
                    Console.WriteLine("Clientes sin CI");
                    alert.EnviarNotificacionSinCi();
                    return;
                }

                if (((Opciones)opciones & Opciones.NotificarYEliminarClientesSinPagos) == Opciones.NotificarYEliminarClientesSinPagos)
                {
                    Console.WriteLine("Eliminar clientes sin pagos");
                    alert.EliminarClientesSinPagos();
                    return;
                }

                if (((Opciones)opciones & Opciones.NotificarYDeshabilitarClientesMorosos) == Opciones.NotificarYDeshabilitarClientesMorosos)
                {
                    Console.WriteLine("Deshabilitar clientes morosos");
                    alert.DeshabilitarClientesMorosos();
                    return;
                }

                if (((Opciones)opciones & Opciones.NotificarPagosPorVencer) == Opciones.NotificarPagosPorVencer)
                {
                    Console.WriteLine("Notificar pagos por vencer");
                    alert.NotificarPagosPorVencer();
                    return;
                }
                if (((Opciones)opciones & Opciones.NotificarPagosPorVencer3Cliente) == Opciones.NotificarPagosPorVencer3Cliente)
                {
                    Console.WriteLine("Notificar pagos por vencer 3 - Clientes");
                    alert.NotificarPagosPorVencerCliente3();
                    return;
                }
                if (((Opciones)opciones & Opciones.NotificarPagosPorVencer2Cliente) == Opciones.NotificarPagosPorVencer2Cliente)
                {
                    Console.WriteLine("Notificar pagos por vencer 2 - Clientes");
                    alert.NotificarPagosPorVencerCliente2();
                    return;
                }
                if (((Opciones)opciones & Opciones.NotificarPagosPorVencerCliente) == Opciones.NotificarPagosPorVencerCliente)
                {
                    Console.WriteLine("Notificar pagos por vencer 1 - Clientes");
                    alert.NotificarPagosPorVencerCliente();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);   
            }
        }

        [Flags]
        enum Opciones
        {
            NotificarClientesSinCi = 1,
            NotificarYEliminarClientesSinPagos = 2,
            NotificarYDeshabilitarClientesMorosos = 4,
            NotificarPagosPorVencer = 8,
            NotificarPagosPorVencer3Cliente = 16,
            NotificarPagosPorVencer2Cliente = 32,
            NotificarPagosPorVencerCliente = 64
        }


       
    }
}
