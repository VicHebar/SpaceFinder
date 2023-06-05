using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceFinder
{
    public class HomeAdministrator
    {
        private Form1 myForm;

        Label label1 = new Label();
        //Label label2 = new Label();
        //Label label3 = new Label();
        //Label label4 = new Label();

        Button btnCreate = new Button();
        Button btnRead = new Button();
        Button btnUpdate = new Button();
        Button btnDelete = new Button();
        DataGridView TableRegisters = new DataGridView();

        public HomeAdministrator(Form1 mForm)
        {
            myForm = mForm;
        }

        public void InitializeHomeAdministrator()
        {
            myForm.Size = new Size(1290, 475);

            label1.Location = new Point(0, 0);
            label1.AutoSize = true;
            label1.Text = "Usuario activo: "+ myForm.ActiveUser.UserName;

            btnCreate.Location = new Point(26, 12);
            btnCreate.Size = new Size(119, 42);
            btnCreate.Text = "Crear usuario";

            btnRead.Location = new Point(26, 60);
            btnRead.Size = new Size(119, 42);
            btnRead.Text = "Mostrar registros";

            btnUpdate.Location = new Point(26, 108);
            btnUpdate.Size = new Size(119, 42);
            btnUpdate.Text = "Actualizar datos";

            btnDelete.Location = new Point(26, 156);
            btnDelete.Size = new Size(119, 42);
            btnDelete.Text = "Eliminar usuario";

            TableRegisters.Location = new Point(151, 12);
            TableRegisters.Size = new Size(1096, 385);

            myForm.Controls.Add(btnCreate);
            myForm.Controls.Add(btnRead);
            myForm.Controls.Add(btnUpdate);
            myForm.Controls.Add(btnDelete);
            myForm.Controls.Add(TableRegisters);
            myForm.Controls.Add(label1);

            btnCreate.Click += btnCreate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRead.Click += btnRead_Click;
            btnUpdate.Click += btnUpdate_Click;

            myForm.mydb.abrir();
            TableRegisters.DataSource = myForm.mydb.GetUsers();
            myForm.mydb.cerrar();
        }

        public void EraseHomeAdministrator()
        {
            myForm.Controls.Remove(btnCreate);
            myForm.Controls.Remove(btnRead);
            myForm.Controls.Remove(btnUpdate);
            myForm.Controls.Remove(btnDelete);
            myForm.Controls.Remove(TableRegisters);
            myForm.Controls.Remove(label1);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aún no hay nada");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aún no hay nada");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aún no hay nada");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EraseHomeAdministrator();
            myForm.myRegister.InitializeRegister();
        }
    }
}
