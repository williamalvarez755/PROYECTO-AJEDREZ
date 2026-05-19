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
// ya termine toda la parte del codigo we xd q sueño
            lblJ2Titulo = new Label();
            lblJ2Titulo.Text = "JUGADOR 2";
            lblJ2Titulo.Font = new Font("Arial", 11, FontStyle.Bold);
            lblJ2Titulo.Location = new Point(30, 230);
            lblJ2Titulo.Size = new Size(190, 22);
            lblJ2Titulo.ForeColor = Color.DarkRed;
            this.Controls.Add(lblJ2Titulo);

            lblJ2Nombre = new Label();
            lblJ2Nombre.Text = "Nombre:";
            lblJ2Nombre.Location = new Point(30, 260);
            lblJ2Nombre.Size = new Size(70, 22);
            lblJ2Nombre.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ2Nombre);

            txtJ2Nombre = new TextBox();
            txtJ2Nombre.Text = "Pedro";
            txtJ2Nombre.Location = new Point(105, 258);
            txtJ2Nombre.Size = new Size(130, 22);
            txtJ2Nombre.Font = new Font("Arial", 9);
            this.Controls.Add(txtJ2Nombre);

            lblJ2Color = new Label();
            lblJ2Color.Text = "Color piezas:";
            lblJ2Color.Location = new Point(30, 295);
            lblJ2Color.Size = new Size(90, 22);
            lblJ2Color.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ2Color);

            panelJ2Color = new Panel();
            panelJ2Color.Location = new Point(125, 293);
            panelJ2Color.Size = new Size(40, 22);
            panelJ2Color.BackColor = colorJ2;
            panelJ2Color.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelJ2Color);

            btnJ2Color = new Button();
            btnJ2Color.Text = "Elegir";
            btnJ2Color.Location = new Point(170, 291);
            btnJ2Color.Size = new Size(65, 26);
            btnJ2Color.Font = new Font("Arial", 8);
            btnJ2Color.Click += (s, e) =>
            {
                ColorDialog dlg = new ColorDialog();
                dlg.Color = colorJ2;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    colorJ2 = dlg.Color;
                    panelJ2Color.BackColor = colorJ2;
                }
            };
            this.Controls.Add(btnJ2Color);

            lblJ2Posicion = new Label();
            lblJ2Posicion.Text = "Posicion inicial:";
            lblJ2Posicion.Location = new Point(30, 333);
            lblJ2Posicion.Size = new Size(110, 22);
            lblJ2Posicion.Font = new Font("Arial", 9);
            this.Controls.Add(lblJ2Posicion);

            cmbJ2Posicion = new ComboBox();
            cmbJ2Posicion.Location = new Point(145, 331);
            cmbJ2Posicion.Size = new Size(130, 22);
            cmbJ2Posicion.Font = new Font("Arial", 9);
            cmbJ2Posicion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJ2Posicion.Items.Add("Normal");
            cmbJ2Posicion.Items.Add("Ataque (torres al frente)");
            cmbJ2Posicion.Items.Add("Defensa (torres junto al rey)");
            cmbJ2Posicion.SelectedIndex = 0;
            this.Controls.Add(cmbJ2Posicion);

            // ===== BOTON INICIAR =====
            btnIniciarJuego = new Button();
            btnIniciarJuego.Text = "¡INICIAR JUEGO!";
            btnIniciarJuego.Location = new Point(140, 380);
            btnIniciarJuego.Size = new Size(190, 45);
            btnIniciarJuego.Font = new Font("Arial", 12, FontStyle.Bold);
            btnIniciarJuego.BackColor = Color.LimeGreen;
            btnIniciarJuego.ForeColor = Color.White;
            btnIniciarJuego.Click += new EventHandler(btnIniciarJuego_Click);
            this.Controls.Add(btnIniciarJuego);

            lblError = new Label();
            lblError.Text = "";
            lblError.Location = new Point(30, 435);
            lblError.Size = new Size(400, 22);
            lblError.Font = new Font("Arial", 8);
            lblError.ForeColor = Color.Red;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblError);
        }

        private PosicionInicial ObtenerPosicion(ComboBox cmb)
        {
            return cmb.SelectedIndex switch
            {
                1 => PosicionInicial.Ataque,
                2 => PosicionInicial.Defensa,
                _ => PosicionInicial.Normal
            };
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            string nombre1 = txtJ1Nombre.Text.Trim();
            string nombre2 = txtJ2Nombre.Text.Trim();

            if (nombre1 == "")
            {
                lblError.Text = "Ingrese el nombre del Jugador 1.";
                return;
            }
            if (nombre2 == "")
            {
                lblError.Text = "Ingrese el nombre del Jugador 2.";
                return;
            }
            if (nombre1 == nombre2)
            {
                lblError.Text = "Los nombres de los jugadores deben ser diferentes.";
                return;
            }

            Jugador j1 = new Jugador(nombre1, 1, colorJ1, ObtenerPosicion(cmbJ1Posicion));
            Jugador j2 = new Jugador(nombre2, 2, colorJ2, ObtenerPosicion(cmbJ2Posicion));

            FormJuego juego = new FormJuego(j1, j2);
            juego.ShowDialog();
        }
    }
}

           