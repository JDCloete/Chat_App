using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using LoginTest_Firebase.Classes;

namespace LoginTest_Firebase.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            frmRegister register = new frmRegister();
            register.ShowDialog();
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            var db = FirestoreHelper.database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

            if(data != null)
            {
                if (password == data.Password)
                {
                    MessageBox.Show("Welcome " + data.Name.ToString());

                    Hide();
                    frmMain main = new frmMain();
                    main.lblUsername.Text = data.Username.ToString();
                    main.ShowDialog();
                    
                    Close();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            else
            {
                MessageBox.Show("Fail");
            }

        }

        
    }
}
