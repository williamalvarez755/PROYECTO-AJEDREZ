using System;
using System.Drawing;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormJuego : Form
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private Tablero tablero;
        private int turnoActual = 1;   // 1 o 2

        private Pieza? piezaSeleccionada = null;
        private int selFila = -1, selCol = -1;

        // Colores del tablero (personalizables por el usuario en futuro, por ahora clasicos)
        private Color colorCasillaClara = Color.Wheat;
        private Color colorCasillaOscura = Color.SaddleBrown;
        private Color colorSeleccion = Color.Yellow;

        private const int TAM_CASILLA = 65;
        private Panel panelTablero;
        private Label lblTurno;
        private Label lblMensaje;
        private Label lblPuntajeJ1;
        private Label lblPuntajeJ2;
        private Button btnRendirse;
        private ListBox lstMovimientos;

        public FormJuego(Jugador j1, Jugador j2)
        {
            jugador1 = j1;
            jugador2 = j2;
            tablero = new Tablero();
            tablero.InicializarPiezas(j1, j2);

            this.Text = "JUEGO DE AJEDREZ";
            this.Size = new Size(760, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            panelTablero = new Panel();
            panelTablero.Location = new Point(10, 60);
            panelTablero.Size = new Size(TAM_CASILLA * 8, TAM_CASILLA * 8);
            panelTablero.Paint += new PaintEventHandler(PanelTablero_Paint);
            panelTablero.MouseClick += new MouseEventHandler(PanelTablero_MouseClick);
            this.Controls.Add(panelTablero);

         
            lblTurno = new Label();
            lblTurno.Location = new Point(10, 10);
            lblTurno.Size = new Size(520, 40);
            lblTurno.Font = new Font("Arial", 13, FontStyle.Bold);
            lblTurno.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblTurno);

            int xLateral = TAM_CASILLA * 8 + 20;

            Label lblInstrucciones = new Label();
            lblInstrucciones.Text = "Como jugar:\n1) Haga clic en su pieza\n2) Haga clic en el destino";
            lblInstrucciones.Location = new Point(xLateral, 60);
            lblInstrucciones.Size = new Size(200, 70);
            lblInstrucciones.Font = new Font("Arial", 9);
            lblInstrucciones.BackColor = Color.LightBlue;
            lblInstrucciones.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblInstrucciones);

            lblPuntajeJ1 = new Label();
            lblPuntajeJ1.Location = new Point(xLateral, 145);
            lblPuntajeJ1.Size = new Size(200, 30);
            lblPuntajeJ1.Font = new Font("Arial", 9, FontStyle.Bold);
            lblPuntajeJ1.ForeColor = j1.ColorPiezas;
            this.Controls.Add(lblPuntajeJ1);

            lblPuntajeJ2 = new Label();
            lblPuntajeJ2.Location = new Point(xLateral, 175);
            lblPuntajeJ2.Size = new Size(200, 30);
            lblPuntajeJ2.Font = new Font("Arial", 9, FontStyle.Bold);
            lblPuntajeJ2.ForeColor = j2.ColorPiezas;
            this.Controls.Add(lblPuntajeJ2);

            Label lblHistorial = new Label();
            lblHistorial.Text = "Historial de movimientos:";
            lblHistorial.Location = new Point(xLateral, 215);
            lblHistorial.Size = new Size(200, 20);
            lblHistorial.Font = new Font("Arial", 8, FontStyle.Bold);
            this.Controls.Add(lblHistorial);

            lstMovimientos = new ListBox();
            lstMovimientos.Location = new Point(xLateral, 235);
            lstMovimientos.Size = new Size(200, 270);
            lstMovimientos.Font = new Font("Arial", 8);
            this.Controls.Add(lstMovimientos);

            btnRendirse = new Button();
            btnRendirse.Text = "RENDIRSE";
            btnRendirse.Location = new Point(xLateral, 515);
            btnRendirse.Size = new Size(200, 35);
            btnRendirse.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRendirse.BackColor = Color.OrangeRed;
            btnRendirse.ForeColor = Color.White;
            btnRendirse.Click += new EventHandler(btnRendirse_Click);
            this.Controls.Add(btnRendirse);

            lblMensaje = new Label();
            lblMensaje.Location = new Point(10, TAM_CASILLA * 8 + 65);
            lblMensaje.Size = new Size(520, 30);
            lblMensaje.Font = new Font("Arial", 9);
            lblMensaje.ForeColor = Color.DarkRed;
            lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(lblMensaje);

            ActualizarUI();
        }

        private void ActualizarUI()
        {
            string nombre = turnoActual == 1 ? jugador1.Nombre : jugador2.Nombre;
            lblTurno.Text = $"Turno de: {nombre}";
            lblTurno.ForeColor = turnoActual == 1 ? jugador1.ColorPiezas : jugador2.ColorPiezas;

            lblPuntajeJ1.Text = $"{jugador1.Nombre}: {jugador1.Puntaje} pts";
            lblPuntajeJ2.Text = $"{jugador2.Nombre}: {jugador2.Puntaje} pts";

            panelTablero.Invalidate();
        }

// el resto del codigo ahi se fue :v
private void PanelTablero_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    // Color de la casilla
                    Color fondo;
                    if (f == selFila && c == selCol)
                        fondo = colorSeleccion;
                    else
                        fondo = ((f + c) % 2 == 0) ? colorCasillaClara : colorCasillaOscura;

                    Rectangle rect = new Rectangle(c * TAM_CASILLA, f * TAM_CASILLA, TAM_CASILLA, TAM_CASILLA);
                    g.FillRectangle(new SolidBrush(fondo), rect);
                    g.DrawRectangle(Pens.Black, rect);

                    // Dibujar pieza
                    Pieza? pieza = tablero.ObtenerPieza(f, c);
                    if (pieza != null && pieza.Viva)
                    {
                        Color colorPieza = pieza.Jugador == 1 ? jugador1.ColorPiezas : jugador2.ColorPiezas;
                        string texto = pieza.Simbolo();

                        // Fondo de la pieza (circulo/ovalo)
                        Rectangle ovalRect = new Rectangle(c * TAM_CASILLA + 5, f * TAM_CASILLA + 8, TAM_CASILLA - 10, TAM_CASILLA - 18);
                        g.FillEllipse(new SolidBrush(colorPieza), ovalRect);
                        g.DrawEllipse(Pens.Black, ovalRect);

                        // Texto encima
                        Font fuente = new Font("Arial", 8, FontStyle.Bold);
                        SizeF tamTexto = g.MeasureString(texto, fuente);
                        float tx = c * TAM_CASILLA + (TAM_CASILLA - tamTexto.Width) / 2f;
                        float ty = f * TAM_CASILLA + (TAM_CASILLA - tamTexto.Height) / 2f;

                        // Color de texto contraste
                        Color textoColor = EsColorOscuro(colorPieza) ? Color.White : Color.Black;
                        g.DrawString(texto, fuente, new SolidBrush(textoColor), tx, ty);
                    }
                }
            }

            // Numeros y letras del borde
            Font fuenteBorde = new Font("Arial", 7);
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int i = 0; i < 8; i++)
            {
                g.DrawString((8 - i).ToString(), fuenteBorde, Brushes.Black, 2, i * TAM_CASILLA + 2);
                g.DrawString(letras[i], fuenteBorde, Brushes.Black, i * TAM_CASILLA + TAM_CASILLA - 12, TAM_CASILLA * 8 - 14);
            }
        }

        private bool EsColorOscuro(Color c)
        {
            return (c.R * 0.299 + c.G * 0.587 + c.B * 0.114) < 128;
        }

        private void PanelTablero_MouseClick(object? sender, MouseEventArgs e)
        {
            int col = e.X / TAM_CASILLA;
            int fila = e.Y / TAM_CASILLA;

            if (fila < 0 || fila > 7 || col < 0 || col > 7) return;

            lblMensaje.Text = "";

            if (piezaSeleccionada == null)
            {
                // Primera seleccion: elegir pieza
                Pieza? pieza = tablero.ObtenerPieza(fila, col);
                if (pieza == null)
                {
                    lblMensaje.Text = "No hay ninguna pieza en esa casilla.";
                    return;
                }
                if (pieza.Jugador != turnoActual)
                {
                    lblMensaje.Text = "Esa pieza no es suya. Es el turno de " +
                        (turnoActual == 1 ? jugador1.Nombre : jugador2.Nombre) + ".";
                    return;
                }
                piezaSeleccionada = pieza;
                selFila = fila;
                selCol = col;
                panelTablero.Invalidate();
            }
            else
            {
                // Segunda seleccion: mover
                if (fila == selFila && col == selCol)
                {
                    // Deseleccionar
                    piezaSeleccionada = null;
                    selFila = -1;
                    selCol = -1;
                    panelTablero.Invalidate();
                    return;
                }

                string? error = tablero.ValidarMovimiento(piezaSeleccionada, fila, col, turnoActual);
                if (error != null)
                {
                    lblMensaje.Text = "Movimiento invalido: " + error;
                    piezaSeleccionada = null;
                    selFila = -1; selCol = -1;
                    panelTablero.Invalidate();
                    return;
                }

                // Ejecutar movimiento
                string movDesc = $"{(turnoActual == 1 ? jugador1.Nombre : jugador2.Nombre)}: " +
                    $"{piezaSeleccionada.Simbolo()} ({selFila},{selCol})->({fila},{col})";

                Pieza? capturada = tablero.EjecutarMovimiento(piezaSeleccionada, fila, col);

                if (capturada != null)
                {
                    int puntos = capturada.PuntosAlEliminar();
                    if (turnoActual == 1)
                        jugador1.SumarPuntos(puntos);
                    else
                        jugador2.SumarPuntos(puntos);

                    movDesc += $" [captura {capturada.Simbolo()} +{puntos}pts]";
                    lblMensaje.Text = $"¡Captura! {capturada.Simbolo()} eliminado. +{puntos} puntos.";

                    // Verificar victoria
                    if (!tablero.ReyVivo(capturada.Jugador) || !tablero.TienePiezas(capturada.Jugador))
                    {
                        lstMovimientos.Items.Add(movDesc);
                        TerminarJuego(turnoActual);
                        return;
                    }
                }

                lstMovimientos.Items.Add(movDesc);
                lstMovimientos.SelectedIndex = lstMovimientos.Items.Count - 1;

                piezaSeleccionada = null;
                selFila = -1; selCol = -1;

                // Cambiar turno
                turnoActual = turnoActual == 1 ? 2 : 1;
                ActualizarUI();
            }
        }
    }
}