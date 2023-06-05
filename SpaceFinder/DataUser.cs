using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFinder
{
    public class DataUser
    {
        public int ID;
        public int Role;
        public string UserName;
        public string Password;
        public string LastName;
        public string SurName;
        public string Email;
        public string PhoneNumber;
        public DateTime CreationTime;

        public DataUser(SqlDataReader data)
        {
            ID = Convert.ToInt32(data[0].ToString());
            Role = Convert.ToInt32(data[1].ToString());
            UserName = data[2].ToString();
            Password = data[3].ToString();
            LastName = data[4].ToString();
            SurName = data[5].ToString();
            Email = data[6].ToString();
            PhoneNumber = data[7].ToString();
            CreationTime = DateTime.Parse(data[8].ToString());
        }
    }

}
