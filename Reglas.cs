using System;
using System.Drawing;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormReglas : Form
    {
        public FormReglas()
        {
            this.Text = "Reglas del Juego";
            this.Size = new Size(500, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightCyan;

            Label lblTitulo = new Label();
            lblTitulo.Text = "=== REGLAS DEL JUEGO ===";
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 15);
            lblTitulo.Size = new Size(430, 25);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            string reglas = @"PIEZAS:
REY  : Se mueve 1 casilla en cualquier direccion.
TOR  : Se mueve en linea recta (no salta piezas).
SOL  : Avanza 1 casilla al frente. Ataca en diagonal.
             El soldado NO puede retroceder.

TURNOS:
Los jugadores se turnan de uno en uno.
Haga clic en su pieza y luego en la casilla destino.
Si hace clic dos veces en la misma pieza la deselecciona.

ATAQUE:
Si mueve su pieza a donde esta el rival, lo captura.
La pieza capturada se elimina del tablero.

PUNTAJE:
Soldado capturado  = 10 puntos
Torre capturada    = 10 puntos
Rey capturado      = 60 puntos

CONDICION DE VICTORIA:
Capture el rey del oponente, o
El oponente pierda todas sus piezas.

POSICION INICIAL:
ATAQUE  : Las torres van al frente junto a los soldados.
DEFENSA : Las torres protegen al rey en la fila trasera.
NORMAL  : Las torres en las esquinas de la fila trasera.";
        }
    }
}