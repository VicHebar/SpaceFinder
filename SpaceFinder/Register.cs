using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFinder
{
    public class Register
    {
        private Form1 myForm;
        Label label1 = new Label();
        Label label2 = new Label();
        Label label3 = new Label();
        Label label4 = new Label();
        Label label5 = new Label();
        Label label6 = new Label();
        Label label7 = new Label();

        TextBox txtUserName = new TextBox();
        TextBox txtPassword = new TextBox();
        TextBox txtLastName = new TextBox();
        TextBox txtSurName = new TextBox();
        TextBox txtEmail = new TextBox();
        TextBox txtPhoneNumber = new TextBox();

        Button btnRegister = new Button();
        Button btnCancel = new Button();

        public Register(Form1 mForm)
        {
            myForm = mForm;
        }

        public void EraseRegister()
        {
            myForm.Controls.Remove(label1);
            myForm.Controls.Remove(label2);
            myForm.Controls.Remove(label3);
            myForm.Controls.Remove(label4);
            myForm.Controls.Remove(label5);
            myForm.Controls.Remove(label6);
            myForm.Controls.Remove(label7);
            myForm.Controls.Remove(txtUserName);
            myForm.Controls.Remove(txtEmail);
            myForm.Controls.Remove(txtPhoneNumber);
            myForm.Controls.Remove(txtPassword);
            myForm.Controls.Remove(txtLastName);
            myForm.Controls.Remove(txtSurName);
            myForm.Controls.Remove(btnCancel);
            myForm.Controls.Remove(btnRegister);
        }

        public void InitializeRegister()
        {
            myForm.Size = new Size(719, 344);

            label1.Location = new Point(228, 9);
            label1.AutoSize = true;
            label1.Text = "Registro para nuevos usuarios";

            label2.Location = new Point(12, 66);
            label2.AutoSize = true;
            label2.Text = "Nombre";

            label3.Location = new Point(12, 100);
            label3.AutoSize = true;
            label3.Text = "Contraseña";

            label4.Location = new Point(12, 134);
            label4.AutoSize = true;
            label4.Text = "Apellido paterno";

            label5.Location = new Point(385, 81);
            label5.AutoSize = true;
            label5.Text = "Apellido materno";

            label6.Location = new Point(385, 115);
            label6.AutoSize = true;
            label6.Text = "Correo electrónico";

            label7.Location = new Point(385, 149);
            label7.AutoSize = true;
            label7.Text = "Numero telefónico";


            txtUserName.Location = new Point(142, 62);
            txtUserName.Size = new Size(158, 23);

            txtPassword.Location = new Point(142, 100);
            txtPassword.Size = new Size(158, 23);

            txtLastName.Location = new Point(142, 134);
            txtLastName.Size = new Size(158, 23);

            txtSurName.Location = new Point(522, 77);
            txtSurName.Size = new Size(158, 23);

            txtEmail.Location = new Point(522, 111);
            txtEmail.Size = new Size(158, 23);

            txtPhoneNumber.Location = new Point(522, 149);
            txtPhoneNumber.Size = new Size(158, 23);


            btnRegister.Location = new Point(228, 245);
            btnRegister.Size = new Size(91, 36);
            btnRegister.Text = "Register";

            btnCancel.Location = new Point(372, 245);
            btnCancel.Size = new Size(91, 36);
            btnCancel.Text = "Cancel";


            myForm.Controls.Add(label1);
            myForm.Controls.Add(label2);
            myForm.Controls.Add(label3);
            myForm.Controls.Add(label4);
            myForm.Controls.Add(label5);
            myForm.Controls.Add(label6);
            myForm.Controls.Add(label7);
            myForm.Controls.Add(txtUserName);
            myForm.Controls.Add(txtEmail);
            myForm.Controls.Add(txtPhoneNumber);
            myForm.Controls.Add(txtPassword);
            myForm.Controls.Add(txtLastName);
            myForm.Controls.Add(txtSurName);
            myForm.Controls.Add(btnCancel);
            myForm.Controls.Add(btnRegister);

            btnCancel.Click += BtnCancel_Click;
            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            myForm.mydb.abrir();
            MessageBox.Show(txtUserName.Text);
            myForm.mydb.AddUser(1,txtUserName.Text, txtPassword.Text, txtLastName.Text, txtSurName.Text, 
                txtEmail.Text, txtPhoneNumber.Text, myForm.ActiveUser.ID);
            myForm.mydb.cerrar();
            MessageBox.Show("Usuario creado correctamente");
            EraseRegister();
            myForm.myHomeAdministrator.InitializeHomeAdministrator();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            EraseRegister();
            myForm.myHomeAdministrator.InitializeHomeAdministrator();
        }
    }
}
