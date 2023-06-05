using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFinder
{
    public class Login
    {
        Form1 myForm;
        Label label1 = new Label();
        Label label2 = new Label();

        TextBox txtEmail = new TextBox();
        TextBox txtPassword = new TextBox();

        Button btnLogin = new Button();
        Button btnCancel = new Button();

        public Login(Form1 myForm)
        {
            this.myForm = myForm;
        }

        public void EraseLogin()
        {
            myForm.Controls.Remove(label1);
            myForm.Controls.Remove(label2);

            myForm.Controls.Remove(txtEmail);
            myForm.Controls.Remove(txtPassword);

            myForm.Controls.Remove(btnCancel);
            myForm.Controls.Remove(btnLogin);
        }

        public void InitializeLogin()
        {
            myForm.Size = new System.Drawing.Size(322, 279);
            label1.Location = new Point(14, 18);
            label1.TabIndex = 2;
            label1.AutoSize = true;
            label1.Text = "Usuario";
            label2.Location = new Point(14, 76);
            label2.TabIndex = 3;
            label2.AutoSize = true;
            label2.Text = "Contraseña";

            txtEmail.Location = new Point(14, 36);
            txtEmail.Size = new Size(270, 23);
            txtEmail.TabIndex = 0;
            txtPassword.Location = new Point(14, 94);
            txtPassword.Size = new Size(270, 23);
            txtPassword.TabIndex = 1;

            btnCancel.Location = new Point(191, 192);
            btnCancel.TabIndex = 4;
            btnCancel.Size = new Size(93, 34);
            btnCancel.Text = "Cancel";
            btnLogin.Location = new Point(103, 134);
            btnLogin.TabIndex = 5;
            btnLogin.Size = new Size(101, 34);
            btnLogin.Text = "Login";

            myForm.Controls.Add(label1);
            myForm.Controls.Add(label2);

            myForm.Controls.Add(txtEmail);
            myForm.Controls.Add(txtPassword);

            myForm.Controls.Add(btnCancel);
            myForm.Controls.Add(btnLogin);
            btnCancel.Click += CancelFunction;
            btnLogin.Click += LoginFunction;
        }

        private void CancelFunction(object sender, EventArgs e)
        {
            myForm.Close();
        }

        private void LoginFunction(object sender, EventArgs e)
        {
            myForm.mydb.abrir();
            bool consulta = myForm.mydb.existe(txtEmail.Text, txtPassword.Text);
            myForm.mydb.cerrar();
            if (consulta)
            {
                myForm.mydb.abrir();
                myForm.ActiveUser = myForm.mydb.GetUser(txtEmail.Text);
                myForm.mydb.cerrar();
                EraseLogin();
                myForm.myHomeAdministrator.InitializeHomeAdministrator();
            }
            else
            {
                MessageBox.Show("El usuario no ha sido encontrado");
            }
        }
    }
}
