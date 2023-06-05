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
            UserName = data[1].ToString();
            Password = data[2].ToString();
            LastName = data[3].ToString();
            SurName = data[4].ToString();
            Email = data[5].ToString();
            PhoneNumber = data[6].ToString();
            CreationTime = DateTime.Parse(data[7].ToString());
        }
    }

}
