using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
        }
        AddNewProduct addProduct;
        private void initAddProductForm(Form form)
        {
            foreach (Form item in MdiChildren)
            {
                if (item.Text.Equals(form.Text))
                {
                    return;
                }
            }
            addProduct.MdiParent = this;
            addProduct.Show();
        }

        private void menuAddProduct_Click(object sender, EventArgs e)
        {
            addProduct = new AddNewProduct();
            initAddProductForm(addProduct);
        }

        ListProduct list;
        private void initListProductForm(Form form)
        {
            foreach (Form item in MdiChildren)
            {
                if (item.Text.Equals(form.Text))
                {
                    return;
                }
            }
            list.MdiParent = this;
            list.Show();
        }
        private void menuList_Click(object sender, EventArgs e)
        {
            list = new ListProduct();
            initListProductForm(list);
        }

        AddCategory addCa;
        private void initAddCategoryForm(Form form)
        {
            foreach (Form item in MdiChildren)
            {
                if (item.Text.Equals(form.Text))
                {
                    return;
                }
            }
            addCa.MdiParent = this;
            addCa.Show();
        }
        private void menuAddCategory_Click(object sender, EventArgs e)
        {
            addCa = new AddCategory();
            initAddCategoryForm(addCa);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
