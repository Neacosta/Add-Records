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
    public partial class DeleteRecords : Form
    {
        public DeleteRecords()
        {
            InitializeComponent();
        }

        Product product = new Product();
        private void frmDelete_Click(object sender, EventArgs e)
        {
            product.ProdCode = cboProductCode.SelectedItem.ToString(); 
            //Display a Confirmation
            //Get input from user
            DialogResult result = MessageBox.Show("Are You Sure You Want To Delete ProductCode " + product.ProdCode, "Remove Record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                //if user wants to proceed with delete then.
                case DialogResult.Yes:
                    {
                        //Run the delete product method
                        ProductDB.DeleteProduct(product);
                       
                        //clear all controls
                        ClearForm();
                       
                        //refresh the product code lsit.
                        LoadAllCodes();
                        break;
                    } 
                //if user does not want to proceed with delete then.
                case DialogResult.No:
                    {
                        //clear all controls
                        ClearForm();
                        break;
                    }
            }
            
            

           
        }

        public void ClearForm()
        {
            //clear controls on the form.
            cboProductCode.Items.Clear();
            txtDescription.Text = "";
            lblPrice.Text = "";
        }

        private void DeleteRecords_Load(object sender, EventArgs e)
        {
            //Clear all controls
            ClearForm();
            //load all product codes.
            LoadAllCodes();
            
        }
        public void LoadAllCodes()
        {
            //declare list to store product codes. Run the select all products method.
            List<string> lstCodes = ProductDB.SelectAllProducts();

            try
            {
                //go through each item in the list and add to the combo box.
                foreach (var item in lstCodes)
                {
                    cboProductCode.Items.Add(item);
                }
                //cboProductCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void cboProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = new Product();

            //set ProdCode property to value chosen in the combo box
            product.ProdCode = cboProductCode.SelectedItem.ToString();

            //run Select Query to fill in the form.
            ProductDB.SelectProduct(product);

            //set form controls to equal the values from the select statement.
            lblPrice.Text = product.Price.ToString("c2");
            txtDescription.Text = product.Description;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //close this form.
            this.Close();
        }
    }
}
