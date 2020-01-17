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
    public partial class FrmUpdate : Form
    {
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            //fill product code combo box
            LoadAllCodes();

        }
        Product product = new Product();
        public void LoadAllCodes()
        {
            //declare list to store product codes. Run the select all products method.
            List<string> lstCodes = ProductDB.SelectAllProducts();

            try
            {
                //go through each item in the list and add to the combo box.
                foreach (var item in lstCodes)
                {
                    cboProducts.Items.Add(item);
                }
                //cboProductCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //set ProdCode property to value chosen in the combo box
            product.ProdCode = cboProducts.SelectedItem.ToString();

            //run Select Query to fill in the form.
            ProductDB.SelectProduct(product);

            //set form controls to equal the values from the select statement.
            txtPrice.Text = product.Price.ToString("c2");
            txtDescription.Text = product.Description;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Check the User wants to update.
            DialogResult result = MessageBox.Show("Are You Sure You Want to Update Product Code: " + product.ProdCode, "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        //create new product instance to hold what changes
                        Product newProduct = new Product();
                        try
                        {
                            newProduct.Description = txtDescription.Text;
                            newProduct.Price = Convert.ToDecimal(txtPrice.Text.Replace("$",""));

                            //pass original values when form loaded and new values after text box changes.
                            ProductDB.UpdateProduct(product, newProduct);

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            //empty controls
                            ClearControls();
                            //Reload Controls
                            LoadAllCodes();
                            
                        }
                        break;
                    }
                case DialogResult.No:
                    {
                        
                         break;
                    }
            } 
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            //close the form
            this.Close();
        }

        private void ClearControls()
        {
            cboProducts.Items.Clear();
            txtDescription.Text = "";
            txtPrice.Text = "";

        }
    }
}
