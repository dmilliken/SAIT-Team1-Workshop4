using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team1_Workshop4_Part2;

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
        private Packages package;
        public bool addPackage;

        //// DM: Loads the products in the box so the user can choose
        //private void LoadProductComboBox()
        //{ 
        //    List<Product> allproducts = new List<Product>();
        //    try
        //    {
        //        allproducts = ProductDB.GetAllProducts();
                
        //        //creating a list of products that are in the current selected package
        //        int PackageId = Convert.ToInt32(comboBoxPackages.SelectedValue);
        //        List<Product> packageproducts = new List<Product>();
        //        packageproducts = Packages_Products_SuppliersDB.GetProductsByPackageID(PackageId);

        //        //remnove existing products from the list of products tha the user can choose from

        //        List<Product> selectableProducts = new List<Product>();   

        //        cboProducts.DataSource = allproducts;
                
        //        cboProducts.ValueMember = "ProductID";
        //        cboProducts.DisplayMember = "ProdName";


        //    } // end try
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, ex.GetType().ToString());
        //    }
        //} // end method

        // DM: Loads the packages in the dd box so the user can choose
        private void LoadPackagesComboBox()
        {
            List<Packages> allpackages = new List<Packages>();
            try
            {
                allpackages = PackagesDB.GetAllPackages();
                comboBoxPackages.DataSource = allpackages;
                comboBoxPackages.DisplayMember = "PkgName"; // this doesn't work?
                comboBoxPackages.ValueMember = "PackageId"; 
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


        } // end find products

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
                LoadProductComboBox(cboProducts); 
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
                    LoadProductComboBox(cboProducts);  
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
           //this.LoadProductComboBox();
           //this.LoadPackagesComboBox();
           //this.LoadProductComboBox(cboProducts);
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
            LoadProductComboBox(cboProducts);
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
            panelProducts.Visible = false;
            panelSuppliers.Visible = false;
            panelPackages.Visible = true;

            // load the comboboxes we need
            this.LoadPackagesComboBox();
            this.LoadProductComboBox(cboProducts);

        }

        private void btnNavHome_Click(object sender, EventArgs e)
        {
            panelPackages.Visible = false;
            panelProducts.Visible = false;
            panelSuppliers.Visible = false;
            pnlAddProdToPkg.Visible = false;
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
            pnlAddProdToPkg.Visible = false;
            panelSuppliers.Visible = false;
            // view the products panel
            panelProducts.Visible = true;

            // load the needed data
            this.LoadProductComboBox(comboBoxProductID);

        }

        private void btnNavSupplier_Click(object sender, EventArgs e)
        {
            // close every other panel
            panelPackages.Visible = false;
            panelProducts.Visible = false;
            panelHome.Visible = false;
            pnlAddProdToPkg.Visible = false;

            // open the panel
            panelSuppliers.Visible = true;

            // Load the suppliers combo box on the suppliers panel
            List<Supplier> allSuppliers = new List<Supplier>();
            allSuppliers = SupplierDB.GetAllSuppliers();

            cboSuppliers.DataSource = allSuppliers;
            cboSuppliers.ValueMember = "SupplierId";
            cboSuppliers.DisplayMember = "SupName";

            // load the product data into the combobox
            this.LoadProductComboBox(cboProductsSupNav);

        }

        // get package info by ID in the combo box on the packages panel
        private void GetPackageByID(int PackageId)
        {
            try
            {
                package = PackagesDB.GetPackage(PackageId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        } // end method

        private List<Product> DisplayPackage()
        {
            // displays the package object data in the appropriate textboxes
            txtPackageName.Text = package.PkgName;
            //txtStartDate.Text = package.PkgStartDate.ToString();
            //txtEndDate.Text = package.PkgEndDate;
            txtPkgDesc.Text = package.PkgDesc;
            txtPkgPrice.Text = package.PkgBasePrice.ToString();
            txtCommission.Text = package.PkgAgencyCommission.ToString();
            
            // playing with the datetime thing
            DateTime startdate = new DateTime();
            startdate = Convert.ToDateTime(package.PkgStartDate);
            dtStartDate.Value = startdate;

            DateTime enddate = new DateTime();
            enddate = Convert.ToDateTime(package.PkgEndDate);
            dtEndDate.Value = enddate;

            // Display the products in this package in the listbox
            int PackageId = Convert.ToInt32(comboBoxPackages.SelectedValue);
            List<Product> packageproducts = new List<Product>();
            packageproducts = Packages_Products_SuppliersDB.GetProductsByPackageID(PackageId);
            
            string line;
            foreach (Product p in packageproducts)
            {
                line = Convert.ToString(p.ProdName);
                lstPkgProducts.Items.Add(line);
            } // end for

            //enable the edit and delete buttons
            btnEditPackage.Enabled = true;
            btnDeletePackage.Enabled = true;

            return packageproducts;
        }

        private void btnFindPackage_Click(object sender, EventArgs e)
        {
            // Fill the package info boxes with data from the package object

            // clear the products listbox
            lstPkgProducts.Items.Clear();

            // disable the textboxes
            txtPackageName.Enabled = false;
            txtPkgDesc.Enabled = false;
            //txtStartDate.Enabled = false;
            //txtEndDate.Enabled = false;
            txtPkgPrice.Enabled = false;
            txtCommission.Enabled = false;
            dtStartDate.Enabled = false;
            dtEndDate.Enabled = false;

            // Get the package ID
            int PackageId;

            if (Validator.IsPresent(comboBoxPackages))
            {
                // if the user set the combo box value, get and display info
                PackageId = Convert.ToInt32(comboBoxPackages.SelectedValue);
                this.GetPackageByID(PackageId);
                if (package == null)
                {
                    MessageBox.Show("There was a problem getting Package #: " + PackageId + ". Please choose another one.");
                } //end if
                else 
                {
                    // if the package is not empty, display the package details in teh textboxes
                    this.DisplayPackage();

                }// end else
            }//end if
        } // end method

        private void LoadProductComboBox(ComboBox comboBox)
        {
            // Load data into the provided product combo box. Made to be re-used multiple times.
            List<Product> allproducts = new List<Product>();
            try
            {
                allproducts = ProductDB.GetAllProducts();
                comboBox.DataSource = allproducts;
                comboBox.DisplayMember = "ProdName";
                comboBox.ValueMember = "ProductID";
                

            } // end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        } // end method

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            // This is the event handler for the "Add Package" button on the packages panel

            // set the value for addPackage 
            addPackage = true;

            // If the combobox has a value, set it to the null string
            comboBoxPackages.SelectedValue = "";

            // Enable and clear the textboxes
            txtPackageName.Text = "";
            txtPackageName.Enabled = true;
            txtPackageName.Focus();

            txtPkgDesc.Text = "";
            txtPkgDesc.Enabled = true;

            //txtStartDate.Text = "";
            //txtStartDate.Enabled = true;

            //txtEndDate.Text = "";
            //txtEndDate.Enabled = true;

            dtStartDate.Enabled = true;
            dtEndDate.Enabled = true;

            txtPkgPrice.Text = "";
            txtPkgPrice.Enabled = true;

            txtCommission.Text = "";
            txtCommission.Enabled = true;

            // Make the "Save Package" button visible
            btnSavePackage.Visible = true;

            // Make the Products panel visible
            pnlAddProdToPkg.Visible = true;
            

        } // end method

        private void btnEditPackage_Click(object sender, EventArgs e)
        {
            // This is the event handler for the "Edit Package" button in the packages panel

            // Set the value for addPackage
            addPackage = false;

            // Enable the textboxes
            txtPackageName.Enabled = true;
            txtPackageName.Focus();

            txtPkgDesc.Enabled = true;

            //txtStartDate.Enabled = true;

            //txtEndDate.Enabled = true;

            dtStartDate.Enabled = true;
            dtEndDate.Enabled = true;

            txtPkgPrice.Enabled = true;

            txtCommission.Enabled = true;

            // Make the "Save Package" button visible
            btnSavePackage.Visible = true;

            // Make the Products panel visible
            pnlAddProdToPkg.Visible = true;
            
        }

        private void btnDeletePackage_Click(object sender, EventArgs e)
        {
            // This is the event handler for deleting a package
            // Will get to this if we have time. 
        } // end method 

        private void btnSavePackage_Click(object sender, EventArgs e)
        {
            // This is the event handler for the "Save Package" button.

            // if addPkg == true
            // do that stuff
            //otherwise, edit mode

            // validate the values
            if (Validator.IsPresent(txtPackageName) && Validator.IsPresent(txtPkgDesc) &&
                Validator.IsPresent(txtPkgPrice) && Validator.IsPositveDouble(txtPkgPrice) &&
                Validator.IsPresent(txtCommission) && Validator.IsPositveDouble(txtCommission) &&
                Validator.IsWithinRange(txtCommission, 0, Convert.ToDecimal(txtPkgPrice.Text)))
            {
                
                if (addPackage)
                {
                // verify the data is legit
                // add a new package
                
                } // end if for add pkg
                else // edit the package
                { 
                    // make a new package object
                    Packages newPackage = new Packages();
                    newPackage.PackageID = package.PackageID;

                    // fill the edit textfields into the new object
                    newPackage.PkgName = txtPackageName.Text;
                    newPackage.PkgDesc = txtPkgDesc.Text;
                    newPackage.PkgStartDate = dtStartDate.Value;

                    newPackage.PkgEndDate = dtEndDate.Value;
                    newPackage.PkgBasePrice = Convert.ToDouble(txtPkgPrice.Text);
                    newPackage.PkgAgencyCommission = Convert.ToDouble(txtCommission.Text);

                    // Try to update the database
                    try
                    {
                        // if it fails, display an error
                        if (!PackagesDB.EditPackage(package, newPackage))
                        {
                            MessageBox.Show("Another user has updated or " +
                                    "deleted that package.", "Database Error");
                        } // end if
                        else // updating works
                        {
                            // create the new package
                            package = newPackage;
                            // display a success message to the user
                            MessageBox.Show("Package updated! ");
                        }//end else
                    }//end try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }//end catch

                } // end else
 
            }// end validator if

            

        }

        private void btnAddProdToPkg_Click(object sender, EventArgs e)
        {

            // save the selected product to the package (if it doesn't already exist)

            
            int selectedproductid = Convert.ToInt32(cboProducts.SelectedValue);
            int selectedSupplierId = Convert.ToInt32(cboProductSuppliers.SelectedValue);
            int selectedPackageId = Convert.ToInt32(comboBoxPackages.SelectedValue);
            Product selectedproduct = new Product();
            Supplier selectedSupplier = new Supplier();
            
            try
            {
                // get the product and supplier obejcts and their IDs
                selectedproduct = ProductDB.GetProduct(selectedproductid);
                string selectedproductname = selectedproduct.ProdName;

                // display in the listbox lstPkgProducts
                lstPkgProducts.Items.Add(selectedproductname);

                // get the productsupplier ID
                int ProductSupplierId;
                ProductSupplierId = Products_SuppliersDB.GetProductSupplierId(selectedproductid, selectedSupplierId);
                // get the package ID

                // insert into packages_products_suppliers
                Packages_Products_SuppliersDB.AddProductToPackage(selectedPackageId, ProductSupplierId);
            } //end try
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there was an error." + ex.Message, ex.GetType().ToString());
            }//end catch
            

        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = new Product();
            selectedProduct = (Product)cboProducts.SelectedItem;
            int productID = selectedProduct.ProductId; 

            // load the list of suppliers for the selected item
            cboProductSuppliers.Enabled = true;

            List<Supplier> productSuppliers = new List<Supplier>();
            productSuppliers = Products_SuppliersDB.GetProductSuppliers(productID);

            // populate the combo box
            cboProductSuppliers.DataSource = productSuppliers;
            cboProductSuppliers.ValueMember = "SupplierId";
            cboProductSuppliers.DisplayMember = "SupName";

        }

        private void btnFindProductsBySupplier_Click(object sender, EventArgs e)
        {
            // Clear the products listbox from the last supplier
            lstProductsBySupplier.Items.Clear();

            // Display products by the selected supplier
            //Start by grabbing the selected supplier
            Supplier selectedSupplier = new Supplier();
            selectedSupplier = (Supplier)cboSuppliers.SelectedItem;
            int selectedSupplierId = selectedSupplier.SupplierId;
            
            // Find and display their products
            List<Product> productsBySelectedSupplier = new List<Product>();
            productsBySelectedSupplier = Products_SuppliersDB.GetProductsBySupplier(selectedSupplierId);

            // populate the list box 
            foreach (Product p in productsBySelectedSupplier)
            {
                string item = p.ProdName;
                lstProductsBySupplier.Items.Add(item);
            }//end for
        }

        private void btnRemoveProductFromSupplier_Click(object sender, EventArgs e)
        {
            // This is the event handler for the "Remove Product" button on the supplier panel
            Product selectedProduct = new Product();
            string selectedProductName = (string)lstProductsBySupplier.SelectedItem;
            selectedProduct = ProductDB.GetProductByName(selectedProductName);
            
            Supplier selectedSupplier = (Supplier)cboSuppliers.SelectedItem;

            // remove the product from the list

            lstProductsBySupplier.Items.Remove(selectedProductName);


            // delete the correct entry in the Product_Suppliers table

            // Confirm that this is what the user wants
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // If yes, try to delete
                try
                {
                    if (!Products_SuppliersDB.RemoveProductFromSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that product.", "Database Error");
                        //this.GetProduct(product.ProductId);
                        //if (product != null)
                        //    this.DisplayProduct();
                        //else
                        //    this.ClearControls();
                    }
                    else
                        this.ClearControls();
                    LoadProductComboBox(cboProducts);
                } // end try
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not delete the product. " + ex.Message, ex.GetType().ToString());
                }
            } // end if 
        }

        private void btnAddProductToSupplier_Click(object sender, EventArgs e)
        {
            // This is the event handler for the 'Add product to supplier' button on the supplier panel. 
            // It creates an entry in the Products_Suppliers Table

            // Get the selected product ID and the current supplierID
            Product selectedProduct = new Product();
            selectedProduct = (Product)cboProductsSupNav.SelectedItem;

            Supplier selectedSupplier = new Supplier();
            selectedSupplier = (Supplier)cboSuppliers.SelectedItem;
            // Try to create the entry
            try
            {
                // try to add the product to the database
                Products_SuppliersDB.AddProductToSupplier(selectedProduct.ProductId, selectedSupplier.SupplierId);

                // Display a confirmation message 
                MessageBox.Show("Product successfully added! ");

                // show product in the list box
                lstProductsBySupplier.Items.Add(selectedProduct.ProdName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong in adding the data: " + ex.Message);
            }

   

        } //end method 

    } // end class
}
