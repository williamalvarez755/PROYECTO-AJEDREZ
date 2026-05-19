using System;
using System.Windows.Forms;

namespace AjedrezJuego
{
    public class FormLogin : Form
    {
        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblContrasena;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnEntrar;
        private Label lblMensaje;


        private const string USUARIO_CORRECTO = "admin";
        private const string CONTRASENA_CORRECTA = "Juego@123";
        public FormLogin()
        {
            this.Text = "JUEGO DE AJEDREZ - Login";
            this.Size = new System.Drawing.Size(400, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.LightYellow;

            lblTitulo = new Label();
            lblTitulo.Text = "    JUEGO DE AJEDREZ    ";
            lblTitulo.Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(50, 20);
            lblTitulo.Size = new System.Drawing.Size(300, 30);
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            lblUsuario = new Label();
            lblUsuario.Text = "Usuario:";
            lblUsuario.Location = new System.Drawing.Point(60, 80);
            lblUsuario.Size = new System.Drawing.Size(80, 23);
            lblUsuario.Font = new System.Drawing.Font("Arial", 10);

            txtUsuario = new TextBox();
            txtUsuario.Location = new System.Drawing.Point(150, 78);
            txtUsuario.Size = new System.Drawing.Size(170, 23);
            txtUsuario.Font = new System.Drawing.Font("Arial", 10);
             lblContrasena = new Label();

            lblContrasena.Text = "Contraseña:";
            lblContrasena.Location = new System.Drawing.Point(60, 125);
            lblContrasena.Size = new System.Drawing.Size(90, 23);
            lblContrasena.Font = new System.Drawing.Font("Arial", 10);

            txtContrasena = new TextBox();
            txtContrasena.Location = new System.Drawing.Point(150, 123);
            txtContrasena.Size = new System.Drawing.Size(170, 23);
            txtContrasena.Font = new System.Drawing.Font("Arial", 10);
            txtContrasena.PasswordChar = '*';

            btnEntrar = new Button();
            btnEntrar.Text = "ENTRAR";
            btnEntrar.Location = new System.Drawing.Point(140, 175);
            btnEntrar.Size = new System.Drawing.Size(110, 35);
            btnEntrar.Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);
            btnEntrar.BackColor = System.Drawing.Color.SteelBlue;
            btnEntrar.ForeColor = System.Drawing.Color.White;
            btnEntrar.Click += new EventHandler(btnEntrar_Click);

            lblMensaje = new Label();
            lblMensaje.Text = "";
            lblMensaje.Location = new System.Drawing.Point(60, 225);
            lblMensaje.Size = new System.Drawing.Size(270, 40);
            lblMensaje.Font = new System.Drawing.Font("Arial", 9);
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}
