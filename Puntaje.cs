using System;
using System.Drawing;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormPuntaje : Form
    {
        public FormPuntaje()
        {
            this.Text = "Puntaje Mas Alto";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightGoldenrodYellow;

            Label lblTitulo = new Label();
            lblTitulo.Text = "=== PUNTAJE MAS ALTO ===";
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Size = new Size(280, 25);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            Label lblInfo = new Label();
            lblInfo.Font = new Font("Arial", 11);
            lblInfo.Location = new Point(30, 70);
            lblInfo.Size = new Size(280, 60);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;

            if (PuntajeRecord.HayRecord())
            {
                lblInfo.Text = $"Jugador: {PuntajeRecord.NombreGanador}\nPuntaje: {PuntajeRecord.MejorPuntaje} puntos";
                lblInfo.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblInfo.Text = "Aún no hay puntajes registrados";
                lblInfo.ForeColor = Color.Gray;
            }
            this.Controls.Add(lblInfo);

            Button btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(120, 145);
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.Font = new Font("Arial", 10);
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);
        }
    }
}
