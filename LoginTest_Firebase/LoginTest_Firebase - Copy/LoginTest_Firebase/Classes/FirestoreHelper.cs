using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using System.IO;

namespace LoginTest_Firebase.Classes
{
    internal static class FirestoreHelper
    {
        static string fireConfig = @"{
          ""type"": ""service_account"",
          ""project_id"": ""cmpg315-messaging-app"",
          ""private_key_id"": ""8d99bd7f28fb937693275776fde46e171def3dda"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCN5XFPOkIpBMdj\noDqUoOVVbqNYMCOhe3fPRD6TgmlNpqeIKT4kdOElmkhtSHJLnftZjKmxX1rKPVqx\nT+Rg3MJ7E18ipTgIQ38/evg6PEzaJdt0Pad50cA56VlEh8KJv93YR7F8bC9HLZdP\ncx2Qw2FQjFk9ZTrtRG52p3Xa4e6VJtuEMobSUT6WIqDADM42CcE4NjI1MNvvfHfa\nyPt/KpbNPJMgvxcv3/aZWhMThuYUaH1HWoVmL8OsnOXPtWiJvWxOv7aBiLVZ1JLI\n6CvkX1g9MQQmrbHwEbhAyHX10zI1aRxoFo+mO1/kxgwuk7QO4+tEPKj6rEsNO1ca\n8mZ+x+1/AgMBAAECggEAIo/fcJfVI56ZXmfZvPgPxCZlvQZEt4GWZjLONynNsm9E\nYUMCcujRKlKRD6VUyZxaa656asy6FYaqP4QhMYK0EDxgsNSjeEfQh8rRCYZEheIw\nuPiHgYGYm8J9ztZuiRTl2VdlINRNE75EG8MDUY51dqQo3G560u4XJemWKFFdxpBK\njcHtvbnUuirGG10OQE0elzUKvH5iS83rhtmCfAGk3Q7ZFNAakmzhJepOg+t4GByT\n173kPMS22sCaYTspLJfQ0Z8NuJGp0VRQmxF06nIU3sLAH5lmfUVEwpTcMShN6/8s\n/NqR9OXBN3V8yozKby3snZZOU+GQXFQk/mm15HoIMQKBgQDBq2ePO88WHRC/nWP3\nSBL1zf4/1MznkuwgcPIch/lBBcjxSO5cFOsK3E2njT96CGNkO+pUBJkmsC96lGNi\ni9Qt9iJqV5OLflmbVyS1JnMBRdFDEZtZv2dKUT5JCIU53rhKL0TKWUYAKYSibQH6\nA/hV8lxQOMZsHW0m+4+hsEpeWQKBgQC7kGTJcFCg2OpcEs/xtKxyyerwBsoQ55Hg\nLm/4vrVCGzvqyP5+mtx8t455UBLqmjGmS1F3VyYimXy/ipVCqgFXNnEDfWiTgoEk\nU3ft7lrxQvqcNRr4lQ/Qvhp/MmqcbN5Rkmz7DKeHMf+0hTp4HVtt4F37i//ANh60\ne9gnxLmflwKBgD+L/m8BMPIQl25INoTtIUuGS+al7JYPn2sFpGu4MhEj1MtXIt8T\n/guSPei8cBeaqQI6pqjq2VXYebu+9N1hBD4QhTpfggpDayONdH38H8BLKF7ZaCAK\nrdm0zrsoEI7shYvR9sBuiomDFgI1wnBG3TVWUPQBrRnMjgQ8huSG8+ABAoGABUHl\n4VOZnviVkSEh3QeQceNBB5tZHKIxD5SdpN5LnF/BDTK3F3tlxMUsZDAfZ54M2Dly\nPiMeOYgN3ByZVHYJdZVcE5n3TXMyBX+lc/DjcbHL7ob6i486E0LQ4VHbdSkEDktJ\nbLwNEhgPr9KwMd+4yVqpp7xj3dJmh+6Uv4CfJ18CgYBOJqRFlIg7vD4SnPFWCCzP\nRkwLG++/l9z4AWqGs9YWt2miMSpv+ggE4Td2/X6mOH24xMT3846T5Isn2+Y2FHvR\nZqXi1YtjVPrClPWF8zzZlpyKeg07+cDbZN8vMZNGK2IkMOnu3aJyBDW+me0JuWmz\nKmYaq0mjK2oXpaprCdc2qQ==\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-qybuq@cmpg315-messaging-app.iam.gserviceaccount.com"",
          ""client_id"": ""108058263082613844430"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-qybuq%40cmpg315-messaging-app.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";

        static string filePath = "";
        public static FirestoreDb database { get; private set; }

        public static void SetEnviornementVariable()
        {
            filePath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filePath, fireConfig);
            File.SetAttributes(filePath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            database = FirestoreDb.Create("cmpg315-messaging-app");
            File.Delete(filePath);
        }
    }
}
