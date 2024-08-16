using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StationeryCompany
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
            comboBox2.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Text = string.Empty;

            if (comboBox1.Text == "Product Types")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from ProductsTypes";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["ProductTypeID"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Products")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Products";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["ProductID"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Sale Managers")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from SalesManagers";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["ManagerID"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Clients")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Clients";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["ClientID"].ReadOnly = true;
                }
                finally { conn.Close(); }
            }
            else if (comboBox1.Text == "Sales")
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Sales";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["SaleID"].ReadOnly = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
                textBox1.Enabled = false;
                textBox1.Text = string.Empty;
                button2.Enabled = false;
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string query = "select * from Products";
                    adapter = new SqlDataAdapter(query, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    dataGridView1.Columns["ProductID"].ReadOnly = true;
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
                    string request = "select ProductName, Quantity\r\nfrom Products\r\nwhere Quantity=(select max(Quantity) from Products)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select ProductName, Quantity\r\nfrom Products\r\nwhere Quantity=(select min(Quantity) from Products)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select ProductName, CostPrice\r\nfrom Products\r\nwhere CostPrice=(select min(CostPrice) from Products)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select ProductName, CostPrice\r\nfrom Products\r\nwhere CostPrice=(select max(CostPrice) from Products)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if(comboBox2.SelectedIndex == 7)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select s.SaleID, p.ProductName, s.QuantitySold, s.UnitPrice, s.SaleDate\r\nfrom Sales s\r\nJOIN Products p ON s.ProductID = p.ProductID\r\nwhere s.SaleDate=(select max(SaleDate) from Sales)";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 8)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select pt.ProductTypeName, avg(p.Quantity) as Average\r\nfrom ProductsTypes pt\r\njoin Products p on p.ProductTypeID=pt.ProductTypeID\r\ngroup by pt.ProductTypeName\r\norder by Average";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 9)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 sm.ManagerName, sum(s.QuantitySold) as TotalSold\r\nfrom SalesManagers sm\r\njoin Sales s on sm.ManagerID=s.ManagerID\r\ngroup by sm.ManagerName\r\norder by TotalSold desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 10)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 sm.ManagerName, sum(s.QuantitySold* s.UnitPrice) as TotalProfit\r\nfrom SalesManagers sm\r\njoin Sales s on s.ManagerID=sm.ManagerID\r\ngroup by sm.ManagerName\r\norder by TotalProfit desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 11)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 c.ClientName, sum(s.QuantitySold*s.UnitPrice) as TotalSpent\r\nfrom Clients c\r\njoin Sales s on s.ClientID=c.ClientID\r\ngroup by c.ClientName\r\norder by TotalSpent desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 12)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 pt.ProductTypeName, sum(s.QuantitySold) as Total\r\nfrom ProductsTypes pt\r\njoin Products p on p.ProductTypeID=pt.ProductTypeID\r\njoin Sales s on s.ProductID=p.ProductID\r\ngroup by pt.ProductTypeName\r\norder by Total desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 13)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 pt.ProductTypeName, sum(s.QuantitySold*s.UnitPrice) as TotalProfit\r\nfrom ProductsTypes pt\r\njoin Products p on p.ProductTypeID=pt.ProductTypeID\r\njoin Sales s on s.ProductID=p.ProductID\r\ngroup by pt.ProductTypeName\r\norder by TotalProfit desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 14)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string request = "select top 1 p.ProductName, sum(s.QuantitySold) as TotalUnitsSold\r\nfrom Sales s\r\njoin Products p on s.ProductID = p.ProductID\r\ngroup by p.ProductID, p.ProductName\r\norder by TotalUnitsSold desc";
                    adapter = new SqlDataAdapter(request, conn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }

            if (comboBox2.SelectedIndex == 4 || comboBox2.SelectedIndex == 5 || comboBox2.SelectedIndex == 6)
            {
                textBox1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = string.Empty;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 4)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string Type = textBox1.Text;
                    string request = "select p.ProductName,pt.ProductTypeName\r\nfrom Products p\r\njoin ProductsTypes pt on p.ProductTypeID=pt.ProductTypeID\r\nwhere pt.ProductTypeName= @Type";
                    adapter = new SqlDataAdapter(request, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Type", Type);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if(comboBox2.SelectedIndex == 5)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string ManagerName = textBox1.Text;
                    string request = "select p.ProductName, sm.ManagerName\r\nfrom Products p\r\njoin Sales s on p.ProductID=s.ProductID\r\njoin SalesManagers sm on s.ManagerID=sm.ManagerID\r\nwhere sm.ManagerName=@ManagerName";
                    adapter = new SqlDataAdapter(request, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ManagerName", ManagerName);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
            else if (comboBox2.SelectedIndex == 6)
            {
                dataSet = new DataSet();
                try
                {
                    conn.Open();
                    string CompanyName = textBox1.Text;
                    string request = "select p.ProductName, c.ClientName\r\nfrom Products p\r\njoin Sales s on p.ProductID=s.ProductID\r\njoin Clients c on s.ClientID=c.ClientID\r\nwhere c.ClientName=@CompanyName";
                    adapter = new SqlDataAdapter(request, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                finally { conn.Close(); }
            }
        }
    }
}
