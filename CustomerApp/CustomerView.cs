using System;
using System.Windows.Forms;
using CustomerApp.Controller;
using CustomerApp.Model;

namespace CustomerApp
{
    public partial class CustomerView : Form
    {
        private CustomerManager manager = new CustomerManager();

        public CustomerView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = manager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                manager.Add(new CustomerData(txtID.Text, txtName.Text));
                LoadData();
                MessageBox.Show("Customer added successfully");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                manager.Edit(txtID.Text, txtName.Text);
                LoadData();
                MessageBox.Show("Customer updated");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                manager.Remove(txtID.Text);
                LoadData();
                MessageBox.Show("Customer deleted");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // optional: you can leave empty
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // optional: you can leave empty
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // optional: you can leave empty
        }
    }
}
