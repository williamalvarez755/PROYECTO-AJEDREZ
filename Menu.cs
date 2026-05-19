using System;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormMenu : Form
    {
        private Label lblTitulo;
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
        }
    }
}