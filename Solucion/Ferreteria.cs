using System;

namespace Solucion
{
    public class Ferreteria
    {
        public Almacen Almacen { get; set; }
        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            Almacen = new Almacen(500);
            Almacen.AgregarTabla(
                new Tabla(anchoInicial, largoInicial, precioBase)
            );
        }
        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {
            int resultado = -1;
            foreach (Tabla tabla in Almacen.Tablas) {
                Tabla? tablaResiduo = tabla.Recortar(anchoSolicitado, largoSolicitado);
                
                if (tablaResiduo is not null) {
                    Almacen.AgregarTabla(tablaResiduo);
                    resultado = 0;
                    break;
                }
            }
            return resultado;
        }
    }
}