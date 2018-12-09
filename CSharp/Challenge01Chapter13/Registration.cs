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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSigin_Click(object sender, EventArgs e)
        {
            //1. Salt creation
            Guid salt = Guid.NewGuid();
            //2. Create hash algorithm
            HashAlgorithm hashAlgorithm = SHA512.Create();

            //3.getting bytes from merging pass plus salt
            byte[] PassInBytes = Encoding.UTF8.GetBytes(txtPassword.Text + salt.ToString());

            //4.computing hash
            byte[] hashedPassInBytes = hashAlgorithm.ComputeHash(PassInBytes);


            //5.converting hash in a string, in this code you get byte per byte and convert in a string
            StringBuilder HashedPass = new StringBuilder();

            foreach (byte b in hashedPassInBytes)
            {
                HashedPass.Append(b);
            }


            string stringConnection = @"Data Source = (Local)\SQLEXPRESS2016; Initial Catalog=Users; Integrated Security= true";
            SqlConnection con = new SqlConnection(stringConnection);

            //table is a reserved word in sql
            SqlCommand command = new SqlCommand("INSERT INTO Users(UserName, Password, Salt) VALUES(@UserName, @Password, @Salt)", con);
            command.Parameters.Add(new SqlParameter("@UserName", txtUserName.Text));
            command.Parameters.Add(new SqlParameter("@Password", HashedPass.ToString()));
            command.Parameters.AddWithValue("@Salt", salt.ToString());

            con.Open();
            int affectedRows = command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("the user has been created");

            Authentication authenticationForm = new Authentication();
            authenticationForm.Show();


        }
    }
}
