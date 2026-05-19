namespace AjedrezJuego
{
    public class Tablero
    {
        // crear matriz con cnombre casilla (herbert no te vayas a confundir con las variables xd )
        public Pieza[,] casillas;

        public Tablero(Jugador jugador1, Jugador jugador2)
        {
            casillas = new Pieza[8, 8];


            int f;
            int c;
            for (f = 0; f < 8; f = f + 1)
            {
                for (c = 0; c < 8; c = c + 1)
                {
                    casillas[f, c] = null;
                }
            }

            // Jugador 1
            ColocarPiezasJugador(jugador1, 7, 6);

            // Jugador 2 
            ColocarPiezasJugador(jugador2, 0, 1);
        }

        //pa colocar las piezas depedne que seelecciona el user
        public void ColocarPiezasJugador(Jugador jugador, int filaTrasera, int filaSoldados)
        {
            int n = jugador.numero;

            casillas[filaSoldados, 2] = new Pieza("SOL", n, filaSoldados, 2);
            casillas[filaSoldados, 3] = new Pieza("SOL", n, filaSoldados, 3);
            casillas[filaSoldados, 4] = new Pieza("SOL", n, filaSoldados, 4);
            casillas[filaSoldados, 5] = new Pieza("SOL", n, filaSoldados, 5);

            casillas[filaTrasera, 4] = new Pieza("REY", n, filaTrasera, 4);

            if (jugador.posicionInicial == "ataque")
            {
                casillas[filaSoldados, 0] = new Pieza("TOR", n, filaSoldados, 0);
                casillas[filaSoldados, 7] = new Pieza("TOR", n, filaSoldados, 7);
            }
            else if (jugador.posicionInicial == "defensa")
            {
                casillas[filaTrasera, 3] = new Pieza("TOR", n, filaTrasera, 3);
                casillas[filaTrasera, 5] = new Pieza("TOR", n, filaTrasera, 5);
            }
            else
            {
                casillas[filaTrasera, 0] = new Pieza("TOR", n, filaTrasera, 0);
                casillas[filaTrasera, 7] = new Pieza("TOR", n, filaTrasera, 7);
            }
        }
        // Valida el movimiento y ve si es correcto xd
        public string ValidarMovimiento(int origenFila, int origenCol, int destinoFila, int destinoCol, int jugadorActual)
        {
            // valida que la posicion de origen sea correcta
            if (origenFila < 0 || origenFila > 7)
            {
                return "El origen esta fuera del tablero.";
            }
            if (origenCol < 0 || origenCol > 7)
            {
                return "El origen esta fuera del tablero.";
            }

            // Validar que el destino
            if (destinoFila < 0 || destinoFila > 7)
            {
                return "El destino esta fuera del tablero.";
            }
            if (destinoCol < 0 || destinoCol > 7)
            {
                return "El destino esta fuera del tablero.";
            }
         
            Pieza pieza = casillas[origenFila, origenCol];

            if (pieza == null)
            {
                return "No hay ninguna pieza en el origen.";
            }

            // No puede mover xq es del rival
            if (pieza.jugador != jugadorActual)
            {
                return "Esa pieza no es suya.";
            }

            // Tomar lo que hay en el destino
            Pieza destino = casillas[destinoFila, destinoCol];

            // No puede meter la pieza aqui xq esta ocupada por otra
            if (destino != null)
            {
                if (destino.jugador == jugadorActual)
                {
                    return "Hay una pieza propia en el destino.";
                }
            }

            // Calcular el cambio en filas y columnas
            int dFila = destinoFila - origenFila;
            int dCol = destinoCol - origenCol;


            if (dFila == 0 && dCol == 0)
            {
                return "Debe mover la pieza a una casilla diferente.";
            }

            // Reglas rey
            // no toques lo del rey y la torre porfa, es que si no se me complica el codigo xddddd
            if (pieza.tipo == "REY")
            {

                int absF = dFila;
                if (absF < 0)
                {
                    absF = -absF;
                }
                int absC = dCol;
                if (absC < 0)
                {
                    absC = -absC;
                }
                if (absF > 1 || absC > 1)
                {
                    return "El Rey solo se mueve una casilla.";
                }
            }
            else if (pieza.tipo == "TOR")
            {

                if (dFila != 0 && dCol != 0)
                {
                    return "La Torre solo se mueve en linea recta.";
                }

                int pasoFila = 0;
                int pasoCol = 0;
                if (dFila > 0)
                {
                    pasoFila = 1;
                }
                if (dFila < 0)
                {
                    pasoFila = -1;
                }
                if (dCol > 0)
                {
                    pasoCol = 1;
                }
                if (dCol < 0)
                {
                    pasoCol = -1;
                }
                 int fActual = origenFila + pasoFila;
                int cActual = origenCol + pasoCol;
                while (fActual != destinoFila || cActual != destinoCol)
                {
                    if (casillas[fActual, cActual] != null)
                    {
                        return "La Torre no puede saltar otras piezas.";
                    }
                    fActual = fActual + pasoFila;
                    cActual = cActual + pasoCol;
                }
            }
            else if (pieza.tipo == "SOL")
            {
  
                int direccion;
                if (pieza.jugador == 1)
                {
                    direccion = -1;
                }
                else
                {
                    direccion = 1;
                }

                if (destino == null)
                {
  
                    if (dFila != direccion || dCol != 0)
                    {
                        return "El Soldado avanza una casilla al frente, o ataca en diagonal.";
                    }
                }
                else
                {

                    int absC = dCol;
                    if (absC < 0)
                    {
                        absC = -absC;
                    }
                    if (dFila != direccion || absC != 1)
                    {
                        return "El Soldado solo ataca en diagonal hacia adelante.";
                    }
                }
            }
            else
            {
                return "Tipo de pieza desconocido.";
            }

            return "";
        }

        public Pieza EjecutarMovimiento(int origenFila, int origenCol, int destinoFila, int destinoCol)
        {
            Pieza piezaMovida = casillas[origenFila, origenCol];
            Pieza capturada = casillas[destinoFila, destinoCol];

            if (capturada != null)
            {
                capturada.viva = false;
            }

            casillas[origenFila, origenCol] = null;
            piezaMovida.fila = destinoFila;
            piezaMovida.columna = destinoCol;
            casillas[destinoFila, destinoCol] = piezaMovida;

            return capturada;
        }

        public bool TieneRey(int jugador)
        {
            int f;
            int c;
            for (f = 0; f < 8; f = f + 1)
            {
                for (c = 0; c < 8; c = c + 1)
                {
                    Pieza p = casillas[f, c];
                    if (p != null)
                    {
                        if (p.tipo == "REY" && p.jugador == jugador)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool TienePiezas(int jugador)
        {
            int f;
            int c;
            for (f = 0; f < 8; f = f + 1)
            {
                for (c = 0; c < 8; c = c + 1)
                {
                    Pieza p = casillas[f, c];
                    if (p != null)
                    {
                        if (p.jugador == jugador)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

//ahi esta me debes mi coca  porq me lo eavente yogi