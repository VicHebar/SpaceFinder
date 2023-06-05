using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceFinder
{
    public class Delete
    {
        private Form1 myForm;

        Label label1 = new Label();
        Label label2 = new Label();

        TextBox txtDelete = new TextBox();

        Button btnDelete = new Button();
        Button btnCancel = new Button();

        public Delete (Form1 mForm)
        {
            myForm = mForm;
        }

        public void InitializeDelete()
        {
            myForm.Size = new Size(696, 293);

            label1.Location = new Point(289, 19);
            label1.Size = new Size(184, 21);
            label1.Text = "Eliminar usuario por ID";

            label2.Location = new Point(192, 72);
            label2.Size = new Size(76, 19);
            label2.Text = "ID Usuario";

            btnDelete.Location = new Point(243, 138);
            btnDelete.Size = new Size(91, 36);
            btnDelete.Text = "Delete";

            btnCancel.Location = new Point(382, 138);
            btnCancel.Size = new Size(91, 36);
            btnCancel.Text = "Cancel";

            txtDelete.Location = new Point(289, 68);
            txtDelete.Size = new Size(158, 23);

            myForm.Controls.Add(label1);
            myForm.Controls.Add(label2);
            myForm.Controls.Add(btnCancel);
            myForm.Controls.Add(btnDelete);
            myForm.Controls.Add(txtDelete);

            btnDelete.Click += btnDelete_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aún no hay nada");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aún no hay nada");
        }
    }
}
