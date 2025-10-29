using System;

namespace CustomerApp.Model
{
    public class CustomerData
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public CustomerData(string id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public CustomerData() { }
    }
}
