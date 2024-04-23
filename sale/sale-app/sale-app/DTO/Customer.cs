using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DAO
{
    public class Customer
    {
        private string iD;
        private string name;
        private string address;
        private string phoneNumber;
        private string note;
        

        public Customer(string id, string name, string address, string phoneNumber, string note)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Note = note;
          
        }
        public Customer(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["name"].ToString();
            this.Address = row["address"].ToString();
            this.PhoneNumber = row["phone_number"].ToString();
            this.Note = row["note"].ToString();
        }
        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Note { get => note; set => note = value; }
       
    }
}
