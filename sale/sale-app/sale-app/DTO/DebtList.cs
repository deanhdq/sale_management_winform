using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sale_app.Utils;

namespace sale_app.DTO
{
    internal class DebtList
    {
        private int cId;
        private string name;
        private string address;
        private string phoneNumber;
        private string debtTotal;

        public DebtList(int customerId, string name, string address, string phoneNumber, string debtTotal)
        {
            this.CId = customerId;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.DebtTotal = debtTotal;
        }
        public DebtList(DataRow row)
        {
            this.CId = (int)row["customer_id"];
            this.Name = (string)row["name"];
            this.Address = (string)row["address"];
            this.PhoneNumber = (string)row["phone_number"];
            this.DebtTotal = NumberComon.Instance.ConvertToCurrency(Int32.Parse(row["debts_total"].ToString()));
        }
        public int CId { get => cId; set => cId = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string DebtTotal { get => debtTotal; set => debtTotal = value; }
    }
}
