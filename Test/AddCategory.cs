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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
            setConnect();
        }
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        private DataSet ds;
        private SqlConnection setConnect()
        {
            string str = "server=.;database=FashionDB;uid = sa; pwd = 123";
            connection = new SqlConnection(str);
            return connection;
        }
        private void Create()
        {
            string query = "INSERT INTO tbCategory VALUES(@id,@name,@desc)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id.Text);
            command.Parameters.AddWithValue("@name", name.Text);
            command.Parameters.AddWithValue("@desc", desc.Text);
            adapter = new SqlDataAdapter(command);
            ds = new DataSet();
            adapter.Fill(ds, "tbCategory");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(id.Text, "^[A-Za-z0-9 ]{1,}$") && id.Text == "")
                {
                    MessageBox.Show("Id invalid.");
                    id.Focus();
                    return;
                }
                else if (!Regex.IsMatch(name.Text, "^[A-Za-z0-9 ]{1,}$") && name.Text == "")
                {
                    MessageBox.Show("Name invalid.");
                    name.Focus();
                    return;
                }
                else if (!Regex.IsMatch(desc.Text, "^[A-Za-z0-9 ]{1,}$") && desc.Text == "")
                {
                    MessageBox.Show("Description invalid.");
                    desc.Focus();
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

            id.Clear();
            name.Clear();
            desc.Clear();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
