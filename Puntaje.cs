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
            lblTitulo.Text = "    PUNTAJE MAS ALTO   ";
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Size = new Size(280, 25);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);
        }
    }
}