using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SpaceFinder;
using System.Runtime.InteropServices.WindowsRuntime;

namespace proyecto_en_blanco
{
    public class DBUtilities
    {
        //SqlConnection connection = new SqlConnection("server=DESKTOP-OPOQ1PC\\IPN ; database=SpaceFinder ; INTEGRATED SECURITY = true");
        SqlConnection connection = new SqlConnection("server=Yggdrasil\\YGGDRASIL ; database=SpaceFinder ; INTEGRATED SECURITY = true");

        public SqlConnection abrir ()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException a)
            {
                MessageBox.Show( a.ToString() );
            }

            return connection;
        }

        public SqlConnection cerrar ()
        {
            connection.Close();
            return connection;
        }

        public bool existe (string Email, string Password)
        {
            SqlCommand comando = new SqlCommand("SELECT Email, Password FROM Users WHERE Email = @Email AND Password = @Password", connection);

            comando.Parameters.AddWithValue("Email", Email);
            comando.Parameters.AddWithValue("Password", Password);
            //Generar variables dentro del querry.

            SqlDataReader lector = comando.ExecuteReader(); //Es una tabla con valores.
            return lector.Read();
        }

        public void ShowRegisters ()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Users", connection);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
        }

        public void AddUser (string UserName, string Password, string LastName, string SurName, string Email, string PhoneNumber, int ActiveUser)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO Users (UserName, Password, LastName, SurName, Email, PhoneNumber, TimeCreation," +
                "WhoModified) VALUES (@UserName, @Password, @LastName, @SurName, @Email, @PhoneNumber, @TimeCreation, @WM)",connection);

            comando.Parameters.AddWithValue("UserName", UserName);
            comando.Parameters.AddWithValue("Password", Password);
            comando.Parameters.AddWithValue("LastName", LastName);
            comando.Parameters.AddWithValue ("SurName", SurName);
            comando.Parameters.AddWithValue("Email", Email);
            comando.Parameters.AddWithValue("PhoneNumber", PhoneNumber);
            comando.Parameters.AddWithValue("TimeCreation", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            comando.Parameters.AddWithValue("WM", ActiveUser);
            comando.ExecuteNonQuery();
        }

        public DataUser GetUser (string Email)
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", connection);

            comando.Parameters.AddWithValue("Email", Email);

            SqlDataReader lector = comando.ExecuteReader(); //Es una tabla con valores.
            if (lector.Read()) 
            {
                return new DataUser(lector);
            }
            else { return null; }
        }

        public DataTable GetUsers ()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM Users", connection);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            return tabla;
        }
    }
}
