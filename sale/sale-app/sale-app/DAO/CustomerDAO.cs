using sale_app.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sale_app.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        // Get all customer
        public List<Customer> getAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            DataTable datatable = DataProvider.Instance.ExecuteQuery("SELECT id, name, address, phone_number, note FROM customers WHERE enable = 1 ");
            foreach (DataRow item in datatable.Rows)
            {
                Customer customer = new Customer(item);
                customers.Add(customer);
            }
            return customers;
        }
        public int updateCustomerById(string name, string address, string phoneNumber, string note, string id)
        {
            string query = "UPDATE customers SET name = @name , address = @address , phone_number = @phone_number , note = @note WHERE id LIKE @id ";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, address, phoneNumber, note, id });

        }
        public int addCustomer(string name, string address, string phoneNumber, string note)
        {
            string query = "EXEC add_customer @name , @address , @phone_number , @note ";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, address, phoneNumber, note });
        }

        public List<Customer> searchCustomerByName(string search)
        {
            string name = string.Format("%{0}%", search);
            string query = "SELECT * FROM customers WHERE name LIKE @search AND enable = 1 ";
            List<Customer> customers = new List<Customer>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                customers.Add(customer);
            }
            return customers;
        }
        public int deleteCustomerById(string customerId)
        {
            string query = "DELETE FROM customers WHERE id LIKE @id ";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerId });
            return result;
        }
    }
}