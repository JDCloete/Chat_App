using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace LoginTest_Firebase.Classes
{
    [FirestoreData]
    internal class Messages
    {
        [FirestoreProperty]
        public string Message { get; set; }

        [FirestoreProperty]
        public string Receiver { get; set; }

        [FirestoreProperty]
        public string Sender { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }
    }
}
