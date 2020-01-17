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
    public partial class FrmAdd : Form
    {
        public FrmAdd()
        {
            InitializeComponent();
        }

        //set new product object
        public Product ProductToAdd;

        private void btnAdd_Click(object sender, EventArgs e)
        {
         
            try
            {

                //instantiate new product object
                ProductToAdd = new Product();

                //assign property values to associated textbox values.
                ProductToAdd.Price = Convert.ToDecimal(txtPrice.Text);
                ProductToAdd.Description = txtDescription.Text;
                ProductToAdd.ProdCode = txtCode.Text;

               //run the addproduct method and begin the insert process.
                ProductDB.AddProduct(ProductToAdd);
             

            }
            catch (FormatException)
            {
                //ensure price is in a decimal format
                MessageBox.Show("Data Entered In Wrong Format", "Format Error");
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            finally
            {
                //clear out entries
                txtCode.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //show the view form
            ViewRecords FrmView = new ViewRecords();
            FrmView.Show();
        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close the form.
            this.Close();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show the view form
            ViewRecords FrmView = new ViewRecords();
            FrmView.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Delete Form
            DeleteRecords FrmDelete = new DeleteRecords();
            FrmDelete.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show Update Form
            FrmUpdate frmUpdate = new FrmUpdate();
            frmUpdate.Show();
        }
    }
}
