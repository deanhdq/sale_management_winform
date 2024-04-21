using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace sale_app.DAO
{

    class UnitDAO
    {
        private static UnitDAO instance;

        public static UnitDAO Instance
        {
            get { if (instance == null) instance = new UnitDAO(); return UnitDAO.instance; }
            private set { UnitDAO.instance = value; }
        }

        private UnitDAO() { }


        public List<Unit> getAllUnits()
        {
            List<Unit> units = new List<Unit>();
            string query = "SELECT * FROM units";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Unit unit = new Unit(item);
                units.Add(unit);
            }
            return units;
        }
        public List<Unit> getUnitByProductId(int pId)
        {
            List<Unit> units = new List<Unit>();
            string query = "SELECT u.id,u.name, u.note FROM products p JOIN price p2 ON p.id = p2.product_id JOIN dbo.units u on u.id = p2.unit_id WHERE p.id = @pID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { pId });
            foreach (DataRow item in data.Rows)
            {
                Unit unit = new Unit(item);
                units.Add(unit);
            }
            return units;
        }
        public List<Unit> searchUnitByName(string search)
        {
            string name = string.Format("%{0}%", search);
            List<Unit> units = new List<Unit>();
            string query = "SELECT * FROM units WHERE name like @name ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            foreach (DataRow item in data.Rows)
            {
                Unit unit = new Unit(item);
                units.Add(unit);
            }
            return units;
        }
        public int deleteUnit(string uId)
        {
            string query = "DELETE FROM units WHERE id LIKE @id ";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { uId });
            return result;
        }
        public int addUnit(string name, string note)
        {
            string query = "INSERT INTO units(name, note) VALUES ( @name , @note )";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, note });
            return result;
        }
        public int editUnit(string name, string note, string id)
        {
            string query = "UPDATE units SET name = @name , note = @note WHERE id = @id ";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, note, id });
            return result;
        }

        public List<Unit> getUnitsById(string id)
        {
            List<Unit> units = new List<Unit>();
            string query = "SELECT * FROM units WHERE id = @id ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {id});
            foreach (DataRow item in data.Rows)
            {
                Unit unit = new Unit(item);
                units.Add(unit);
            }
            return units;
        }

    }


}

