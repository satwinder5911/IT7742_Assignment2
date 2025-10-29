using System;
using System.Collections.Generic;
using CustomerApp.Model;

namespace CustomerApp.Controller
{
    public class CustomerManager
    {
        private List<CustomerData> customerList = new List<CustomerData>();

        public List<CustomerData> GetAll()
        {
            return customerList;
        }

        public void Add(CustomerData cust)
        {
            if (string.IsNullOrWhiteSpace(cust.Id) || string.IsNullOrWhiteSpace(cust.FullName))
                throw new Exception("ID and Name cannot be empty");
            customerList.Add(cust);
        }

        public void Edit(string id, string newName)
        {
            CustomerData found = customerList.Find(c => c.Id == id);
            if (found == null)
                throw new Exception("Customer not found");
            found.FullName = newName;
        }

        public void Remove(string id)
        {
            CustomerData found = customerList.Find(c => c.Id == id);
            if (found == null)
                throw new Exception("Customer not found");
            customerList.Remove(found);
        }
    }
}
