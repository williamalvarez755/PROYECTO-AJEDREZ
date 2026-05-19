using System;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormMenu : Form
    {
        private Label lblTitulo;
        private Button btnIniciar;
        private Button btnReglas;
        private Button btnPuntaje;
        public FormMenu()
        {
            this.Text = "JUEGO DE AJEDREZ - Menu Principal";
            this.Size = new System.Drawing.Size(380, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.LightCyan;

            lblTitulo = new Label();
            lblTitulo.Text = "     JUEGO DE TABLERO     ";
            lblTitulo.Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(30, 25);
            lblTitulo.Size = new System.Drawing.Size(310, 30);
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            btnIniciar = new Button();
            btnIniciar.Text = "1. Iniciar Partida";
            btnIniciar.Location = new System.Drawing.Point(90, 90);
            btnIniciar.Size = new System.Drawing.Size(190, 45);
            btnIniciar.Font = new System.Drawing.Font("Arial", 11);
            btnIniciar.BackColor = System.Drawing.Color.LimeGreen;
            btnIniciar.ForeColor = System.Drawing.Color.White;
            btnIniciar.Click += new EventHandler(btnIniciar_Click);

            btnReglas = new Button();
            btnReglas.Text = "2. Ver Reglas del Juego";
            btnReglas.Location = new System.Drawing.Point(90, 150);
            btnReglas.Size = new System.Drawing.Size(190, 45);
            btnReglas.Font = new System.Drawing.Font("Arial", 11);
            btnReglas.BackColor = System.Drawing.Color.RoyalBlue;
            btnReglas.ForeColor = System.Drawing.Color.White;
            btnReglas.Click += new EventHandler(btnReglas_Click);

            btnPuntaje = new Button();
            btnPuntaje.Text = "3. Ver Puntaje Mas Alto";
            btnPuntaje.Location = new System.Drawing.Point(90, 210);
            btnPuntaje.Size = new System.Drawing.Size(190, 45);
            btnPuntaje.Font = new System.Drawing.Font("Arial", 11);
            btnPuntaje.BackColor = System.Drawing.Color.Goldenrod;
            btnPuntaje.ForeColor = System.Drawing.Color.White;
            btnPuntaje.Click += new EventHandler(btnPuntaje_Click);
        }
    }
}