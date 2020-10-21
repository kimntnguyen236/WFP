using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class ListProduct : Form
    {
        public ListProduct()
        {
            InitializeComponent();
            setConnect();
            loadCategory();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadCategory()
        {
            string query = "SELECT * FROM tbProduct";
            adapter = new SqlDataAdapter(query, connection);
            ds = new DataSet();
            adapter.Fill(ds, "tbProduct");
            var bs = new BindingSource();
            bs.DataSource = ds.Tables["tbProduct"];
            dataGridView1.DataSource = bs;

        }
    }
}
