using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
            setConnect();
            loadComboBox();
        }
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        private DataSet ds;

        public BindingSource bs;

        public SqlConnection setConnect()
        {
            string str = "server=.;database=FashionDB;uid = sa; pwd = 123";
            connection = new SqlConnection(str);
            return connection;
        }
        public void loadComboBox()
        {
            string sql = "SELECT * FROM tbCategory";
            adapter = new SqlDataAdapter(sql, connection);
            ds = new DataSet();
            bs = new BindingSource();
            adapter.Fill(ds, "tbCategory");
            bs.DataSource = ds.Tables["tbCategory"];
            comboBox1.DataSource = bs;
            // DisplayMember dùng cho không phải khóa chính
            comboBox1.ValueMember = "CategoryName"; // ValueMember dùng cho khóa chính
        }
        private void Create()
        {
            string query = "INSERT INTO tbProduct VALUES(@proName,@quantity,@cate)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@proName", name.Text);
            command.Parameters.AddWithValue("@quantity", quan.Text);
            command.Parameters.AddWithValue("@cate", comboBox1.SelectedValue.ToString());
            adapter = new SqlDataAdapter(command);
            ds = new DataSet();
            adapter.Fill(ds, "tbProduct");
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(name.Text, "^[A-Za-z0-9 ]{1,}$") && name.Text == "")
                {
                    MessageBox.Show("Name invalid.");
                    name.Focus();
                    return;
                }
                else if (!Regex.IsMatch(quan.Text, "^[1-9]{1}[0-9]{0,}$"))
                {
                    MessageBox.Show("Quantity invalid.");
                    quan.Focus();
                    return;
                }
                else
                {
                    Create();
                    MessageBox.Show("Congratulation");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            name.Clear();
            quan.Clear();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
