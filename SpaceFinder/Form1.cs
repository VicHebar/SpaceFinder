using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using proyecto_en_blanco;

namespace SpaceFinder
{
    public partial class Form1 : Form
    {

        public DBUtilities mydb = new DBUtilities();
        public DataUser ActiveUser;
        
        public Login myLogin;
        public Register myRegister;
        public HomeAdministrator myHomeAdministrator;
        public Delete myDelete;

        public Form1()
        {
            InitializeComponent();
            myRegister = new Register(this);
            myLogin = new Login(this);
            myHomeAdministrator = new HomeAdministrator(this);
            myDelete = new Delete(this);

            DialogResult Populate;

            Populate = MessageBox.Show("Deseas poblar la base de datos?","Populate DB",MessageBoxButtons.YesNo);

            if(Populate == DialogResult.Yes)
            {
                mydb.abrir();
                mydb.PopulateDB();
                mydb.cerrar();
            }

            
            myLogin.InitializeLogin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
