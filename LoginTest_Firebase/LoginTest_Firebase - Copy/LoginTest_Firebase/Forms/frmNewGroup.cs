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
    public partial class 
        frmNewGroup : Form
    {
        public frmNewGroup()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            frmMain main = new frmMain();
            main.lblUsername.Text = lblUsername.Text.ToString();
            main.ShowDialog();
            Close();
        }

        private void frmNewGroup_Load(object sender, EventArgs e)
        {
            var db = FirestoreHelper.database;
            var collectionRef = db.Collection("UserData");
            QuerySnapshot querySnapshot = collectionRef.GetSnapshotAsync().Result;

            List<UserData> dataList = new List<UserData>();

            foreach (var document in querySnapshot.Documents)
            {
                UserData userData = document.ConvertTo<UserData>();
                if (userData.Username != lblUsername.Text)
                {
                    dataList.Add(userData);
                }


            }
            foreach (var userData in dataList)
            {
                cmbMembers.Items.Add($"{ userData.Username}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clbMembers.Items.Add(cmbMembers.SelectedItem.ToString());
            cmbMembers.Items.RemoveAt(cmbMembers.SelectedIndex);
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            var db = FirestoreHelper.database;
            var collectionRef = db.Collection("Groups");

            // Define the data to be written (example using a dictionary)
            Dictionary<string, object> data = new Dictionary<string, object>();

            data.Add("Name", txtName.Text);
            data.Add("Description", txtSurname.Text);
            data.Add("Member_1", lblUsername.Text);

            // Iterate through the items in the ListBox and add them to the data dictionary
            int iCount = 1;
            foreach (var item in clbMembers.Items)
            {
                iCount++;
                // Assuming each item in the ListBox is a string
                string fieldName = "Member_" + iCount.ToString(); // Use the item as the field name
                string fieldValue = clbMembers.Items[(iCount-2)].ToString(); // You need to define this method to get the field value from somewhere

                // Add the field to the data dictionary
                data.Add(fieldName, fieldValue);
            }

            /*
            {
                { "Name", txtName.Text },
                { "Description", txtSurname.Text },
                { "Member_1", lblUsername.Text }
            // Add more fields as needed...
            };*/

            // Add the data to the collection
            await collectionRef.AddAsync(data);

            MessageBox.Show("Group created Successfully!", "Group Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            frmMain main = new frmMain();
            main.lblUsername.Text = lblUsername.Text.ToString();
            main.ShowDialog();
            Close();
        }
    }
}
