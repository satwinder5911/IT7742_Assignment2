namespace CustomerAppTests.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public bool IsStaff { get; set; }

        public Customer(string name, bool isStaff = false)
        {
            Name = name;
            IsStaff = isStaff;
        }

        public Customer() { }
    }
}
