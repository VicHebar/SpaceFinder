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
        List <string> Names = new List<string>() { "Juan", "Luis", "Victor"};
        List <string> Passwwords = new List<string>() {"123", "321", "135"};
        List <string> LastNames = new List<string>() {"Hernandez", "Perez", "Milagros"};
        List <string> Emails = new List<string>();
        List <string> PhoneNumbers = new List<string>() {"4421163882","5521237214","6677903412"};

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

        public void AddUser (int Role, string UserName, string Password, string LastName, string SurName, string Email, string PhoneNumber, int ActiveUser)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO Users (Role, UserName, Password, LastName, SurName, Email, PhoneNumber, TimeCreation," +
                "WhoModified) VALUES (@Role, @UserName, @Password, @LastName, @SurName, @Email, @PhoneNumber, @TimeCreation, @WM)",connection);

            comando.Parameters.AddWithValue("Role", Role);
            comando.Parameters.AddWithValue("UserName", UserName);
            comando.Parameters.AddWithValue("Password", Password);
            comando.Parameters.AddWithValue("LastName", LastName);
            comando.Parameters.AddWithValue("SurName", SurName);
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

        public void PopulateDB()
        {
            Random rnd = new Random();
            string email;
            foreach(string name in Names)
            {
                foreach(string lastName in LastNames)
                {
                    foreach(string surName in LastNames)
                    {
                        foreach(string password in Passwwords)
                        {
                            foreach(string phone in PhoneNumbers)
                            {
                                email = name + "_" + lastName[0] + surName[0] + phone[0] + "_" + password + "@mail.com";
                                AddUser(rnd.Next(1, 4), name, password, lastName, surName, email, phone, 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
