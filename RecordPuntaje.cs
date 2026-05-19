namespace AjedrezJuego
{
    // Clase para guardar el record global en memoria durante la sesion
    public static class PuntajeRecord
    {
        public static string NombreGanador { get; private set; } = "";
        public static int MejorPuntaje { get; private set; } = -1;

        public static void IntentarActualizar(string nombre, int puntaje)
        {
            if (MejorPuntaje < 0 || puntaje > MejorPuntaje)
            {
                MejorPuntaje = puntaje;
                NombreGanador = nombre;
            }
        }

        public static bool HayRecord()
        {
            return MejorPuntaje >= 0;
        }
    }
}
