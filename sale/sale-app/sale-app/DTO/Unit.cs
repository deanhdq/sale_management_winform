using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_app.DTO
{
    public class Unit
    {
        private int iD;
        private string name;
        private string note;
        public Unit(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Unit(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Note = row["note"].ToString();
        }
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }
    }
}
