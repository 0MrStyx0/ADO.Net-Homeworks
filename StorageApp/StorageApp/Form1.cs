using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StorageApp
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;

        SqlDataAdapter adapter = null;

        DataSet dataSet = null;

        SqlCommandBuilder commandBuilder = null;

        string connectionString;

        public Form1()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["localDbConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Products")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Products";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["Id"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Suppliers")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Suppliers";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["Id"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Product Types")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from ProductTypes";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["Id"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.Update(dataSet);
            }
            finally { conn.Close(); }
        }

        private void Checkbox1_Changed(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Enabled = true;
                button1.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = false;
                comboBox2.Text = string.Empty;
                button1.Enabled = true;
                dataGridView1.Enabled = true;
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Products";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["Id"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0) 
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select s.Id, s.[Name], t.total\r\nfrom Suppliers s\r\njoin (select SuppliersId, sum([Count]) as total from Products group by SuppliersId) t on s.Id=t.SuppliersId\r\nwhere t.total=(select max(total) from (select sum([Count]) as total from Products group by SuppliersId) subquery)";
                    adapter=new SqlDataAdapter(request, conn);
                    commandBuilder=new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally {conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select s.Id, s.[Name], t.total\r\nfrom Suppliers s\r\njoin (select SuppliersId, sum([Count]) as total from Products group by SuppliersId) t on s.Id=t.SuppliersId\r\nwhere t.total=(select min(total) from (select sum([Count]) as total from Products group by SuppliersId) subquery)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if(comboBox2.SelectedIndex == 2)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select pt.Id, pt.[Name], t.total\r\nfrom ProductTypes pt\r\njoin (select TypeId, sum([Count]) as total from Products group by TypeId) t on pt.Id=t.TypeId\r\nwhere t.total=(select max(total) from (select sum([Count]) as total from Products group by TypeId) subquery)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if(comboBox2.SelectedIndex == 3)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select pt.Id, pt.[Name], t.total\r\nfrom ProductTypes pt\r\njoin (select TypeId, sum([Count]) as total from Products group by TypeId) t on pt.Id=t.TypeId\r\nwhere t.total=(select min(total) from (select sum([Count]) as total from Products group by TypeId) subquery)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
        }
    }
}
