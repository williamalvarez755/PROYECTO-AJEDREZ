using System;
using System.Drawing;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormJuego : Form
    {
        // ----- Datos del juego -----
        public Jugador jugador1;
        public Jugador jugador2;
        public Tablero tablero;
        public int turnoActual;          // 1 o 2

        // Seleccion de la pieza a mover
        public int origenFila;
        public int origenColumna;
        public bool piezaSeleccionada;

        // Tamano de cada casilla en pixeles
        public int TAM_CASILLA = 60;

        // ----- Controles de la interfaz -----
        public Panel panelTablero;
        public Label lblTurno;
        public Label lblMensaje;
        public Label lblPuntajeJ1;
        public Label lblPuntajeJ2;
        public Label lblComoJugar;
        public Button btnRendirse;

        public FormJuego(Jugador j1, Jugador j2)
        {

            jugador1 = j1;
            jugador2 = j2;
            tablero = new Tablero(jugador1, jugador2);

            turnoActual = 1;
            piezaSeleccionada = false;
            origenFila = -1;
            origenColumna = -1;

            this.Text = "Juego de Tablero - Partida";
            this.Size = new Size(740, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            // Etiqueta del turno
            lblTurno = new Label();
            lblTurno.Location = new Point(15, 10);
            lblTurno.Size = new Size(500, 35);
            lblTurno.Font = new Font("Arial", 13, FontStyle.Bold);
            lblTurno.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblTurno);

            panelTablero = new Panel();
            panelTablero.Location = new Point(15, 55);
            panelTablero.Size = new Size(TAM_CASILLA * 8, TAM_CASILLA * 8);
            panelTablero.Paint += new PaintEventHandler(panelTablero_Paint);
            panelTablero.MouseClick += new MouseEventHandler(panelTablero_MouseClick);
            this.Controls.Add(panelTablero);


            int xLateral = TAM_CASILLA * 8 + 30;

            lblPuntajeJ1 = new Label();
            lblPuntajeJ1.Location = new Point(xLateral, 60);
            lblPuntajeJ1.Size = new Size(190, 30);
            lblPuntajeJ1.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPuntajeJ1.ForeColor = jugador1.colorPiezas;
            this.Controls.Add(lblPuntajeJ1);

            lblPuntajeJ2 = new Label();
            lblPuntajeJ2.Location = new Point(xLateral, 95);
            lblPuntajeJ2.Size = new Size(190, 30);
            lblPuntajeJ2.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPuntajeJ2.ForeColor = jugador2.colorPiezas;
            this.Controls.Add(lblPuntajeJ2);

            lblComoJugar = new Label();
            string instrucciones = "";
            instrucciones = instrucciones + "COMO JUGAR:\r\n";
            instrucciones = instrucciones + "1) Haga clic en su pieza.\r\n";
            instrucciones = instrucciones + "2) Haga clic en la casilla\r\n";
            instrucciones = instrucciones + "    destino.\r\n";
            instrucciones = instrucciones + "\r\n";
            instrucciones = instrucciones + "PIEZAS:\r\n";
            instrucciones = instrucciones + "  REY = Rey\r\n";
            instrucciones = instrucciones + "  TOR = Torre\r\n";
            instrucciones = instrucciones + "  SOL = Soldado\r\n";
            instrucciones = instrucciones + "\r\n";
            instrucciones = instrucciones + "Cada jugador usa el color\r\n";
            instrucciones = instrucciones + "que eligio al inicio.";
            lblComoJugar.Text = instrucciones;
            lblComoJugar.Location = new Point(xLateral, 135);
            lblComoJugar.Size = new Size(190, 250);
            lblComoJugar.Font = new Font("Arial", 9);
            lblComoJugar.BackColor = Color.LightBlue;
            lblComoJugar.BorderStyle = BorderStyle.FixedSingle;
            lblComoJugar.TextAlign = ContentAlignment.TopLeft;
            this.Controls.Add(lblComoJugar);

            btnRendirse = new Button();
            btnRendirse.Text = "RENDIRSE";
            btnRendirse.Location = new Point(xLateral, 400);
            btnRendirse.Size = new Size(190, 40);
            btnRendirse.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRendirse.BackColor = Color.OrangeRed;
            btnRendirse.ForeColor = Color.White;
            btnRendirse.Click += new EventHandler(btnRendirse_Click);
            this.Controls.Add(btnRendirse);

            // Etiqueta de mensajes (errores, capturas, etc.)
            lblMensaje = new Label();
            lblMensaje.Location = new Point(15, TAM_CASILLA * 8 + 60);
            lblMensaje.Size = new Size(700, 25);
            lblMensaje.Font = new Font("Arial", 10);
            lblMensaje.ForeColor = Color.DarkRed;
            this.Controls.Add(lblMensaje);

            ActualizarPantalla();
        }
        public bool EsColorOscuro(Color color)
        {
            int suma = color.R + color.G + color.B;
            if (suma < 380)
            {
                return true;
            }
            return false;
        }


        public void ActualizarPantalla()
        {
            string nombreTurno;
            if (turnoActual == 1)
            {
                nombreTurno = jugador1.nombre;
                lblTurno.ForeColor = jugador1.colorPiezas;
            }
            else
            {
                nombreTurno = jugador2.nombre;
                lblTurno.ForeColor = jugador2.colorPiezas;
            }
            lblTurno.Text = "Turno de: " + nombreTurno;

            lblPuntajeJ1.Text = jugador1.nombre + ": " + jugador1.puntaje + " puntos";
            lblPuntajeJ2.Text = jugador2.nombre + ": " + jugador2.puntaje + " puntos";

            panelTablero.Invalidate();
        }

        public void panelTablero_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fuentePieza = new Font("Arial", 10, FontStyle.Bold);

            int f;
            int c;
            for (f = 0; f < 8; f = f + 1)
            {
                for (c = 0; c < 8; c = c + 1)
                {
                    // Color de fondo de la casilla
                    Color fondo;
                    if (piezaSeleccionada == true && f == origenFila && c == origenColumna)
                    {
                        fondo = Color.Yellow;
                    }
                    else if ((f + c) % 2 == 0)
                    {
                        fondo = Color.Wheat;
                    }
                    else
                    {
                        fondo = Color.SaddleBrown;
                    }

                    Rectangle rect = new Rectangle(c * TAM_CASILLA, f * TAM_CASILLA, TAM_CASILLA, TAM_CASILLA);
                    SolidBrush brocha = new SolidBrush(fondo);
                    g.FillRectangle(brocha, rect);
                    g.DrawRectangle(Pens.Black, rect);

                    Pieza pieza = tablero.casillas[f, c];
                    if (pieza != null)
                    {
                        if (pieza.viva == true)
                        {
                            // Tomar el color de las piezas del jugador correspondiente
                            Color colorPieza;
                            if (pieza.jugador == 1)
                            {
                                colorPieza = jugador1.colorPiezas;
                            }
                            else
                            {
                                colorPieza = jugador2.colorPiezas;
                            }

                            Color colorTexto;
                            if (EsColorOscuro(colorPieza) == true)
                            {
                                colorTexto = Color.White;
                            }
                            else
                            {
                                colorTexto = Color.Black;
                            }

                            Rectangle circ = new Rectangle(
                                c * TAM_CASILLA + 5,
                                f * TAM_CASILLA + 8,
                                TAM_CASILLA - 10,
                                TAM_CASILLA - 18);
                            SolidBrush brochaPieza = new SolidBrush(colorPieza);
                            g.FillEllipse(brochaPieza, circ);
                            g.DrawEllipse(Pens.Black, circ);

                            // Texto encima del circulo
                            SizeF tamTexto = g.MeasureString(pieza.tipo, fuentePieza);
                            float tx = c * TAM_CASILLA + (TAM_CASILLA - tamTexto.Width) / 2;
                            float ty = f * TAM_CASILLA + (TAM_CASILLA - tamTexto.Height) / 2;
                            SolidBrush brochaTexto = new SolidBrush(colorTexto);
                            g.DrawString(pieza.tipo, fuentePieza, brochaTexto, tx, ty);
                        }
                    }
                }
            }
        }

        // Maneja el clic del mouse sobre el tablero.
        public void panelTablero_MouseClick(object sender, MouseEventArgs e)
        {
            int columna = e.X / TAM_CASILLA;
            int fila = e.Y / TAM_CASILLA;

            // Validar que el clic este dentro del tablero
            if (fila < 0 || fila > 7)
            {
                return;
            }
            if (columna < 0 || columna > 7)
            {
                return;
            }

            lblMensaje.Text = "";

            if (piezaSeleccionada == false)
            {
                // ----- Primera seleccion: elegir una pieza -----
                Pieza pieza = tablero.casillas[fila, columna];

                if (pieza == null)
                {
                    lblMensaje.Text = "No hay pieza en esa casilla.";
                    return;
                }

                if (pieza.jugador != turnoActual)
                {
                    string nombre;
                    if (turnoActual == 1)
                    {
                        nombre = jugador1.nombre;
                    }
                    else
                    {
                        nombre = jugador2.nombre;
                    }
                    lblMensaje.Text = "Esa pieza no es suya. Es el turno de " + nombre + ".";
                    return;
                }

                origenFila = fila;
                origenColumna = columna;
                piezaSeleccionada = true;
                panelTablero.Invalidate();
            }
            else
            {
                // ----- Segunda seleccion: elegir el destino -----

                // Si hace clic en la misma pieza, la deselecciona
                if (fila == origenFila && columna == origenColumna)
                {
                    piezaSeleccionada = false;
                    origenFila = -1;
                    origenColumna = -1;
                    panelTablero.Invalidate();
                    return;
                }

                // Validar el movimiento usando las reglas del tablero
                string error = tablero.ValidarMovimiento(origenFila, origenColumna, fila, columna, turnoActual);
                if (error != "")
                {
                    lblMensaje.Text = "Movimiento invalido: " + error;
                    piezaSeleccionada = false;
                    origenFila = -1;
                    origenColumna = -1;
                    panelTablero.Invalidate();
                    return;
                }

                Pieza capturada = tablero.EjecutarMovimiento(origenFila, origenColumna, fila, columna);

                // Si hubo captura, sumar puntos y avisar
                if (capturada != null)
                {
                    int puntos = capturada.PuntosAlEliminar();
                    if (turnoActual == 1)
                    {
                        jugador1.SumarPuntos(puntos);
                    }
                    else
                    {
                        jugador2.SumarPuntos(puntos);
                    }

                    string nombrePieza = "";
                    if (capturada.tipo == "REY")
                    {
                        nombrePieza = "Rey";
                    }
                    else if (capturada.tipo == "TOR")
                    {
                        nombrePieza = "Torre";
                    }
                    else if (capturada.tipo == "SOL")
                    {
                        nombrePieza = "Soldado";
                    }

                    MessageBox.Show(
                        "Captura! Se elimino un " + nombrePieza + " del rival.\r\n" +
                        "+" + puntos + " puntos.",
                        "Captura",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Verificar si el juego ha terminado
                    int jugadorRival = capturada.jugador;
                    if (tablero.TieneRey(jugadorRival) == false)
                    {
                        piezaSeleccionada = false;
                        origenFila = -1;
                        origenColumna = -1;
                        ActualizarPantalla();
                        TerminarJuego(turnoActual);
                        return;
                    }
                    if (tablero.TienePiezas(jugadorRival) == false)
                    {
                        piezaSeleccionada = false;
                        origenFila = -1;
                        origenColumna = -1;
                        ActualizarPantalla();
                        TerminarJuego(turnoActual);
                        return;
                    }
                }

                piezaSeleccionada = false;
                origenFila = -1;
                origenColumna = -1;

                // Cambiar el turno
                if (turnoActual == 1)   
                {
                    turnoActual = 2;
                }
                else
                {
                    turnoActual = 1;
                }

                ActualizarPantalla();
            }
        }

        public void TerminarJuego(int ganador)
        {
            Jugador jGanador;
            Jugador jPerdedor;

            if (ganador == 1)
            {
                jGanador = jugador1;
                jPerdedor = jugador2;
            }
            else
            {
                jGanador = jugador2;
                jPerdedor = jugador1;
            }

            PuntajeRecord.Actualizar(jGanador.nombre, jGanador.puntaje);

            string mensaje = "";
            mensaje = mensaje + "Gano " + jGanador.nombre + "!\r\n\r\n";
            mensaje = mensaje + jGanador.nombre + ": " + jGanador.puntaje + " puntos\r\n";
            mensaje = mensaje + jPerdedor.nombre + ": " + jPerdedor.puntaje + " puntos";

            MessageBox.Show(mensaje, "FIN DEL JUEGO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

        public void btnRendirse_Click(object sender, EventArgs e)
        {
            string nombre;
            if (turnoActual == 1)
            {
                nombre = jugador1.nombre;
            }
            else
            {
                nombre = jugador2.nombre;
            }

            DialogResult respuesta = MessageBox.Show(
                nombre + ", seguro que se desea rendir?",
                "Rendirse",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                int ganador;
                if (turnoActual == 1)
                {
                    ganador = 2;
                }
                else
                {
                    ganador = 1;
                }
                TerminarJuego(ganador);
            }
        }
    }
}
