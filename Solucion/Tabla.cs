using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Solucion
{
    public class Tabla
    {
        public double Ancho { get; private set; }
        public double Largo { get; private set; }
        public double PrecioBase { get; private set; }
        public double Dimension { get; }
        public double Valor => Ancho * Largo * PrecioBase;
        public Tabla(double ancho, double largo, double precioBase)
        {
            if (ancho > largo)
                throw new ArgumentException("El ancho debe ser menor o igual al largo de la tabla.");
            
            Ancho = ancho;
            Largo = largo;
            PrecioBase = precioBase;
            Dimension = Ancho * Largo;
        }

        private bool CabeTablaVolteada(double anchoSolicitado, double largoSolicitado) {
            return anchoSolicitado <= this.Largo && largoSolicitado <= this.Ancho;
        }
        private bool CabeTablaOriginal(double anchoSolicitado, double largoSolicitado) {
            return largoSolicitado <= this.Largo && anchoSolicitado <= this.Ancho;
        }
        public bool CabeTabla(double anchoSolicitado, double largoSolicitado) {
            bool cabe = false;

            if (CabeTablaVolteada(anchoSolicitado, largoSolicitado) ||
                CabeTablaOriginal(anchoSolicitado, largoSolicitado)) {
                cabe = true;
            }

            return cabe;
        }

        public Tabla? Recortar(double anchoSolicitado, double largoSolicitado) {
            if (!CabeTabla(anchoSolicitado, largoSolicitado))
                return null;

            if (CabeTablaVolteada(anchoSolicitado, largoSolicitado)) {
                double largoCortar = this.Largo - anchoSolicitado;
                double anchoCortar = this.Ancho - largoSolicitado;
                this.Largo -= anchoSolicitado;
                this.Ancho -= largoSolicitado;
                return new Tabla(largoCortar, anchoCortar, PrecioBase);
            }
            else {
                double largoCortar = this.Largo - largoSolicitado;
                double anchoCortar = this.Ancho - anchoSolicitado;
                this.Largo -= largoSolicitado;
                this.Ancho -= anchoSolicitado;
                return new Tabla(largoCortar, anchoCortar, PrecioBase);
            }
        }
    }
}
