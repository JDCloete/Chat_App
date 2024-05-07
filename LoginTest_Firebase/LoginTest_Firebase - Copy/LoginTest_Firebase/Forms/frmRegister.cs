using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginTest_Firebase.Classes;
using Google.Cloud.Firestore;

namespace LoginTest_Firebase.Forms
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var db = FirestoreHelper.database;

            if (CheckIfUserAlreadyExists())
            {
                MessageBox.Show("User Already Exists");
                return;
            }

            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.Username);
            docRef.SetAsync(data);
            MessageBox.Show("Success");
        }

        private UserData GetWriteData()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string email = txtEmail.Text.Trim();

            return new UserData()
            {
                Username = username,
                Password = password,
                Name = name,
                Surname = surname,
                Email = email,
            };
        }

        public bool CheckIfUserAlreadyExists()
        {
            string username = txtUsername.Text.Trim();

            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
