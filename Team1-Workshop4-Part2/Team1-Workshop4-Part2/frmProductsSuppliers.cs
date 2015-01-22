using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team1_Workshop4_Part2
{
    // Darcie Milliken
    public partial class frmProductsSuppliers : Form
    {
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        private Product product;
        private Supplier supplier;

        // DM: Loads the products in the box so the user can choose
        private void LoadProductComboBox()
        { 
            List<Product> allproducts = new List<Product>();
            try
            {
                allproducts = ProductDB.GetAllProducts();
                comboBoxProductID.DataSource = allproducts;
                comboBoxProductID.ValueMember = "ProductID";
            } // end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        } // end method

        private void btnFindProducts_Click(object sender, EventArgs e)
        {
            // DM: this is the event handler for the "Find Products" button on the Products Tab
            // No need to validate since we are using a combobox

            // clear the list box
            lstSuppliers.Items.Clear();

            // Get the product ID
            int productID;
            if (Validator.IsPresent(comboBoxProductID))
            {
                // if the user set the combo box value, get and display info
                productID = Convert.ToInt32(comboBoxProductID.SelectedValue);
                this.GetProduct(productID);
                if (product == null)
                {
                    MessageBox.Show("There was a problem getting ProductID: " +  productID + ". Please choose another one.");
                } // end if
                else
                { 
                    this.DisplayProduct();
                    supplier = Products_SuppliersDB.GetProductSupplier(productID);
                    if (supplier != null)  // check to make sure there is a supplier, then display it. 
                    {
                        DisplaySuppliers(productID);
                    }

                } // end else
            } // end if 


        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // DM: This button allows the user to add a new product

            // Open Auxillary Form
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();
            addProductForm.addProduct = true;
            DialogResult result = addProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                product = addProductForm.product;
                this.DisplayProduct();
                this.LoadProductComboBox();
            }//end if
            
        }// end method

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            // DM: This button allows the user to edit an existing product
            // Enabled when the productID combo box has a value

            frmAddModifyProduct modifyProductForm = new frmAddModifyProduct();
            modifyProductForm.addProduct = false;
            modifyProductForm.product = product;
            DialogResult result = modifyProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                product = modifyProductForm.product;
                this.DisplayProduct();
            } // end if
            else if (result == DialogResult.Cancel)
            {
                this.GetProduct(product.ProductId);
                if (product != null)
                {
                    this.DisplayProduct();
                }
                else
                {
                    this.ClearControls();
                } // end else 
            } // end else
            
        } // end method

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // DM: Allows the user to delete a product
            // once a product object has been found, this button becomes enabled

            // Confirmation Message
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // If yes, try to delete
                try
                {
                    if (!ProductDB.DeleteProduct(product))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that product.", "Database Error");
                        this.GetProduct(product.ProductId);
                        if (product != null)
                            this.DisplayProduct();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                        LoadProductComboBox();  
                } // end try
                catch (Exception ex)
                {
                    MessageBox.Show("Error: There may Be dependent child objects in the database. Could not delete the product '" + product.ProdName + "'." + ex.Message, ex.GetType().ToString());
                }
            } // end if 

        } // end method

        private void frmProductsSuppliers_Load(object sender, EventArgs e)
        {
            //DM: Show the products for the user to choose
           this.LoadProductComboBox();
        } // end method 

        private void GetProduct(int ProductID)
        { 
            try 
            {
                product = ProductDB.GetProduct(ProductID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        } // end method

        private void DisplayProduct()
        {
            // Display the product object data in the form fields 
            txtProductName.Text = product.ProdName;
            btnEditProduct.Enabled = true;
            btnDeleteProduct.Enabled = true;
        }//end method


        private void ClearControls()
        {
            // this method resets the form
            txtProductName.Text = "";
            //txtSupplierID.Text = "";
            //txtSupplierName.Text= "";
            btnEditProduct.Enabled = false;
            btnDeleteProduct.Enabled = false;
            comboBoxProductID.Focus();
        } // end method

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end method

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // button that refreshes the combo box values
            LoadProductComboBox();
        } // end method 

        private void DisplaySuppliers(int productId)
        {
            // this function takes a product ID as input and creates a list of suppliers who supply that product
            // create list of suppliers
            List<Supplier> suppliers = new List<Supplier>();
            string line;
            suppliers = Products_SuppliersDB.GetProductSuppliers(productId);  // returns a list of suppliers
            foreach (Supplier s in suppliers)
            {
                line = s.SupplierId + "\t" + s.SupName;
                lstSuppliers.Items.Add(line);
                //MessageBox.Show(Convert.ToString(s.SupplierId));
            }

        }

        private void btnNavPackages_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            //panelProducts.Visible = false;
            panelPackages.Visible = true;
            

        }

        private void btnNavHome_Click(object sender, EventArgs e)
        {
            panelPackages.Visible = false;
           // panelProducts.Visible = false;
            panelHome.Visible = true;


        }

        private void btnNavExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            // close every other panel
            panelPackages.Visible = false;
            panelHome.Visible = false;
            // view the products panel
           // panelProducts.Visible = true;

        }

        private void btnNavSupplier_Click(object sender, EventArgs e)
        {
            panelPackages.Visible = false;
            //panelProducts.Visible = false;
            panelHome.Visible = false;

        }



    } // end class
}
