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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public int NumberOfChats = 0;

        private void frmMain_Load(object sender, EventArgs e)
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
                lstContacts.Items.Add($"{ userData.Username}");
                NumberOfChats++;
            }

            MessageBox.Show("Number of Chats: " + NumberOfChats.ToString());

            List<string> groupMembers = new List<string>();
            var collectionRefG = db.Collection("Groups");
            QuerySnapshot querySnapshotG = collectionRefG.GetSnapshotAsync().Result;

            foreach (var document in querySnapshotG.Documents)
            {
                var documentData = document.ToDictionary();

                // Access group name and description
                string groupName = documentData.ContainsKey("Name") ? documentData["Name"].ToString() : string.Empty;
                string groupDescription = documentData.ContainsKey("Description") ? documentData["Description"].ToString() : string.Empty;
                

                // Iterate through document fields to find members
                foreach (var field in documentData)
                {
                    if (field.Key != "Name" && field.Key != "Description") // Skip groupName and description fields
                    {
                        groupMembers.Add(field.Value.ToString());

                        if (field.Value.ToString() == lblUsername.Text)
                        {
                            lstContacts.Items.Add(groupName);
                        }
                        
                    }
                }
                
            }


            lstContacts.SelectedIndex = 0;
            txtMessage.Focus();
            DisplayCurrentChat();

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            /*string message = txtMessage.Text;
            string messageSender = lblUsername.Text;
            string messageReceiver = lstContacts.SelectedItem.ToString();
            DateTime messageTime = DateTime.Now;*/

            /*lstMessagees.Items.Add(message);
            lstMessagees.Items.Add(messageSender);
            lstMessagees.Items.Add(messageReceiver);
            lstMessagees.Items.Add(messageTime.ToString("HH:mm, dd/MM/yy"));*/

            var db = FirestoreHelper.database;

            var data = GetMessageWriteData();
            DocumentReference docRef = await db.Collection("Messages").AddAsync(data);

            MessageBox.Show("Success");

            DisplayCurrentChat();
        }

        private Messages GetMessageWriteData()
        {
            string message = txtMessage.Text;
            string messageSender = lblUsername.Text;
            string messageReceiver = lstContacts.SelectedItem.ToString();
            DateTime messageTime = DateTime.UtcNow;

            return new Messages()
            {
                Message = message,
                Sender = messageSender,
                Receiver = messageReceiver,
                Date = messageTime,
            };
        }

        private void DisplayCurrentChat()
        {
            lstMessagees.Items.Clear();
            rtbMessages.Clear();

            string messageSender = lblUsername.Text;
            string messageReceiver = lstContacts.SelectedItem.ToString();

            var db = FirestoreHelper.database;
            var collectionRef = db.Collection("Messages");
            QuerySnapshot querySnapshot = collectionRef.GetSnapshotAsync().Result;

            List<Messages> filteredAndOrderedMessages = new List<Messages>();

            foreach (var document in querySnapshot.Documents)
            {
                Messages message = document.ConvertTo<Messages>();
                if (lstContacts.SelectedIndex >= NumberOfChats)
                {
                    if (message.Receiver == messageReceiver)
                    {
                        filteredAndOrderedMessages.Add(message);
                    }
                }
                else
                {
                    if ((message.Sender == messageSender) && (message.Receiver == messageReceiver))
                    {
                        filteredAndOrderedMessages.Add(message);
                    }
                    else if ((message.Receiver == messageSender) && (message.Sender == messageReceiver))
                    {
                        filteredAndOrderedMessages.Add(message);
                    }
                }
                
                
            }

            filteredAndOrderedMessages = filteredAndOrderedMessages.OrderBy(msg => msg.Date).ToList();

            foreach (var message in filteredAndOrderedMessages)
            {
                lstMessagees.Items.Add("Sender: " + message.Sender + " Reciever: " + message.Receiver );
                lstMessagees.Items.Add("Message: " + message.Message);
                lstMessagees.Items.Add("Date: " + message.Date.ToString("HH:mm, dd/MM/yy"));
                lstMessagees.Items.Add(" ");

                rtbMessages.AppendText("Sender: " + message.Sender + " Reciever: " + message.Receiver + "\n");
                rtbMessages.AppendText("Message: " + message.Message + "\n");
                rtbMessages.AppendText("Date: " + message.Date.ToString("HH:mm, dd/MM/yy") + "\n");
                rtbMessages.AppendText(" " + "\n");

            }

        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DisplayCurrentChat();
          
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            Hide();
            frmNewGroup groups = new frmNewGroup();
            groups.lblUsername.Text = lblUsername.Text.ToString();
            groups.ShowDialog();
            Close();
        }
    }
}
