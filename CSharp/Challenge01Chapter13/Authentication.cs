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
using System.Security.Cryptography;
namespace Challenge01Chapter13
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (Local)\SQLEXPRESS2016; Initial Catalog=Users; Integrated Security = true";
            SqlConnection con = new SqlConnection(connectionString);
            
            SqlCommand command = new SqlCommand("select Password, Salt From Users where UserName = @UserName", con);
            command.Parameters.Add(new SqlParameter("@UserName",txtUser.Text));

            con.Open();
            SqlDataReader secureData = command.ExecuteReader();
            string PasswordPlusSaltHashed = null;
            string salt = null;

            if (secureData.Read())
            {
                 PasswordPlusSaltHashed = secureData[0].ToString();
                 salt = secureData[1].ToString();
            }
            con.Close();

            //byte[] PasswordPlusSaltHashedBytes = Encoding.UTF8.GetBytes(PasswordPlusSaltHashed);

            byte[] HashPasswordInBytes = Encoding.UTF8.GetBytes(txtPassword.Text + salt);
                        
            HashAlgorithm hashAlgorithm = SHA512.Create();
            byte[] hashPasswordInBytes = hashAlgorithm.ComputeHash(HashPasswordInBytes);

            StringBuilder sp = new StringBuilder();

            foreach (byte b in hashPasswordInBytes)
                sp.Append(b);

                if (sp.ToString().GetHashCode() == PasswordPlusSaltHashed.GetHashCode())
            MessageBox.Show("ok");
                else
                    MessageBox.Show("Does not exists");
            
            

        }
    }
}
