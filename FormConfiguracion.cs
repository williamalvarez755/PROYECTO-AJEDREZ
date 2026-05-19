using System;
using System.Drawing;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormConfiguracion : Form
    {

        private Label lblJ1Titulo;
        private Label lblJ1Nombre;
        private TextBox txtJ1Nombre;
        private Label lblJ1Color;
        private Button btnJ1Color;
        private Panel panelJ1Color;
        private Label lblJ1Posicion;
        private ComboBox cmbJ1Posicion;


        private Label lblJ2Titulo;
        private Label lblJ2Nombre;
        private TextBox txtJ2Nombre;
        private Label lblJ2Color;
        private Button btnJ2Color;
        private Panel panelJ2Color;
        private Label lblJ2Posicion;
        private ComboBox cmbJ2Posicion;

        private Button btnIniciarJuego;
        private Label lblError;

        private Color colorJ1 = Color.Blue;
        private Color colorJ2 = Color.Red;

        public FormConfiguracion()
        {
            this.Text = "Configurar Partida";
            this.Size = new Size(480, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightGoldenrodYellow;

            Label lblTitulo = new Label();
            lblTitulo.Text = "--- Configuracion de la Partida ---";
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(60, 15);
            lblTitulo.Size = new Size(360, 25);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            // ===== JUGADOR 1 =====
            lblJ1Titulo = new Label();
            lblJ1Titulo.Text = "JUGADOR 1";
            lblJ1Titulo.Font = new Font("Arial", 11, FontStyle.Bold);
            lblJ1Titulo.Location = new Point(30, 55);
            lblJ1Titulo.Size = new Size(190, 22);
            lblJ1Titulo.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblJ1Titulo);

            lblJ1Nombre = new Label();
            lblJ1Nombre.Text = "Nombre:";
            lblJ1Nombre.Location = new Point(30, 85);
            lblJ1Nombre.Size = new Size(70, 22);
            lblJ1Nombre.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ1Nombre);

            txtJ1Nombre = new TextBox();
            txtJ1Nombre.Text = "Juan";
            txtJ1Nombre.Location = new Point(105, 83);
            txtJ1Nombre.Size = new Size(130, 22);
            txtJ1Nombre.Font = new Font("Arial", 9);
            this.Controls.Add(txtJ1Nombre);

            lblJ1Color = new Label();
            lblJ1Color.Text = "Color piezas:";
            lblJ1Color.Location = new Point(30, 120);
            lblJ1Color.Size = new Size(90, 22);
            lblJ1Color.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ1Color);

            panelJ1Color = new Panel();
            panelJ1Color.Location = new Point(125, 118);
            panelJ1Color.Size = new Size(40, 22);
            panelJ1Color.BackColor = colorJ1;
            panelJ1Color.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelJ1Color);

            btnJ1Color = new Button();
            btnJ1Color.Text = "Elegir";
            btnJ1Color.Location = new Point(170, 116);
            btnJ1Color.Size = new Size(65, 26);
            btnJ1Color.Font = new Font("Arial", 8);
            btnJ1Color.Click += (s, e) =>
            {
                ColorDialog dlg = new ColorDialog();
                dlg.Color = colorJ1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    colorJ1 = dlg.Color;
                    panelJ1Color.BackColor = colorJ1;
                }
            };
            this.Controls.Add(btnJ1Color);

            lblJ1Posicion = new Label();
            lblJ1Posicion.Text = "Posicion inicial:";
            lblJ1Posicion.Location = new Point(30, 158);
            lblJ1Posicion.Size = new Size(110, 22);
            lblJ1Posicion.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ1Posicion);

            cmbJ1Posicion = new ComboBox();
            cmbJ1Posicion.Location = new Point(145, 156);
            cmbJ1Posicion.Size = new Size(130, 22);
            cmbJ1Posicion.Font = new Font("Arial", 9);
            cmbJ1Posicion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJ1Posicion.Items.Add("Normal");
            cmbJ1Posicion.Items.Add("Ataque (torres al frente)");
            cmbJ1Posicion.Items.Add("Defensa (torres junto al rey)");
            cmbJ1Posicion.SelectedIndex = 0;
            this.Controls.Add(cmbJ1Posicion);

            // posicion J1
            Label lblDescJ1 = new Label();
            lblDescJ1.Text = "Ataque = torres van al frente | Defensa = torres protegen al rey";
            lblDescJ1.Location = new Point(30, 183);
            lblDescJ1.Size = new Size(300, 30);
            lblDescJ1.Font = new Font("Arial", 7, FontStyle.Italic);
            lblDescJ1.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDescJ1);

            // linea astetiks
            Label sep = new Label();
            sep.BorderStyle = BorderStyle.Fixed3D;
            sep.Location = new Point(20, 220);
            sep.Size = new Size(430, 2);
            this.Controls.Add(sep);


//copia la misma babossada para el j2 solo cambia possiones y los colres y create otro ya te deje las clases ahi solo no la freges


           