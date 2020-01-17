using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingRecords
{
    public partial class ViewRecords : Form
    {
        public ViewRecords()
        {
            InitializeComponent();
        }

        private void ViewRecords_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mMABOOKSDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.mMABOOKSDataSet.Products);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close the form.
            this.Close();
        }
    }
}
