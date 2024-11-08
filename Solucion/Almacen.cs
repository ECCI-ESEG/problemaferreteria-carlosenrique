namespace Solucion
{
    public class Almacen
    {
        private int CapacidadMaxima { get; set; }
        public List<Tabla> Tablas { get; set; }
        public Almacen(int capacidadMaxima)
        {
            if (capacidadMaxima > 500) {
                throw new ArgumentException("El almacen tiene una capacidad maxima de 500 tablas.");
            }
            CapacidadMaxima = capacidadMaxima;
            Tablas = new List<Tabla>();
        }
        public void AgregarTabla(Tabla tabla) {
            if (Tablas.Count == CapacidadMaxima)
                throw new Exception("El almacen esta lleno.");
            
            Tablas.Add(tabla);
            
            Tablas = Tablas
                .OrderBy(t => t.Ancho)
                .ThenBy(t => t.Largo)
                .ToList();
        }
    }
}
