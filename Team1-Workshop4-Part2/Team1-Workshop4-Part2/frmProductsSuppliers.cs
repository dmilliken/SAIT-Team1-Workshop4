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
using System.IO;

namespace Team1_Workshop4_Part2
{
    // Darcie Milliken
    // These are the methods and event handlers for the main form 
    // and any panels located on the main form frmProductsSuppliers
    // The form is designed to hide and show panels based on what the user clicks on,
    // sort of like a website

    public partial class frmProductsSuppliers : Form
    {

        // Empty objects and variables for the methods to use
        // ---------------------------------------------
        // ---------------------------------------------
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        private Product product;
        private Supplier supplier;
        private Packages package;
        public bool addPackage;
        public bool addSupplier;

        // Form Load Method
        // ---------------------------------------------
        // ---------------------------------------------
        private void frmProductsSuppliers_Load(object sender, EventArgs e)
        {
            //On form load, open the home panel
            panelHome.Visible = true;
           
        } // end method 

        // Navigation Buttons that hide and show the panels or clear the controls
        // ---------------------------------------------
        // ---------------------------------------------
        private void btnNavPackages_Click(object sender, EventArgs e)
        {
            // Show only the requested panel
            ShowOnlyThisPanel(panelPackages);

            // load the comboboxes we need
            this.LoadPackagesComboBox();
            this.LoadProductComboBox(cboProducts);

        }

        private void btnNavHome_Click(object sender, EventArgs e)
        {
            // Show only the requested panel
            ShowOnlyThisPanel(panelHome);
            

        }

        private void btnNavExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            // Show only the requested panel
            ShowOnlyThisPanel(panelProducts);
            
            // load the needed data
            this.LoadProductComboBox(comboBoxProductID);

        }

        private void btnNavSupplier_Click(object sender, EventArgs e)
        {
            // Show only the requested panel
            ShowOnlyThisPanel(panelSuppliers);

            // Load the suppliers combo box on the suppliers panel
            List<Supplier> allSuppliers = new List<Supplier>();
            allSuppliers = SupplierDB.GetAllSuppliers();

            cboSuppliers.DataSource = allSuppliers;
            cboSuppliers.ValueMember = "SupplierId";
            cboSuppliers.DisplayMember = "SupName";

            // load the product data into the combobox
            this.LoadProductComboBox(cboProductsSupNav);

        }

        private void btnNavBookings_Click(object sender, EventArgs e)
        {
            //close all other panels
            
            // open the booking panels
        }

        private void btnNavCustomers_Click(object sender, EventArgs e)
        {
            // close all other panels and open the customer panel

            ShowOnlyThisPanel(pnlMyCustomers);
        

        } //end method 

        private void ShowOnlyThisPanel(Panel PanelToOpen)
        {
            // close all other panels and open only the one the user clicks on
            panelHome.Visible = false;
            panelPackages.Visible = false;
            panelSuppliers.Visible = false;
            panelProducts.Visible = false;
            pnlAddEditSupplier.Visible = false;
            pnlAddProdToPkg.Visible = false;
            pnlMyCustomers.Visible = false;
            PanelToOpen.Visible = true;
        }

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

        // Methods that fetch and load data for the form controls 
        // ---------------------------------------------
        // ---------------------------------------------

        private void LoadPackagesComboBox()
        {
            // This method loads the packages in the dd box so the user can choose
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

        private void LoadSuppliersComboBox()
        {
            // Load the suppliers combo box on the suppliers panel
            List<Supplier> allSuppliers = new List<Supplier>();
            allSuppliers = SupplierDB.GetAllSuppliers();

            cboSuppliers.DataSource = allSuppliers;
            cboSuppliers.ValueMember = "SupplierId";
            cboSuppliers.DisplayMember = "SupName";

            // load the product data into the combobox
            this.LoadProductComboBox(cboProductsSupNav);
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

        // Methods for buttons on the Products Panel
        // ---------------------------------------------
        // ---------------------------------------------
        private void DisplayProduct()
        {
            // Display the product object data in the form fields 
            txtProductName.Text = product.ProdName;
            btnEditProduct.Enabled = true;
            btnDeleteProduct.Enabled = true;
        }//end method

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

        // Methods for buttons on the Packages Panel
        // ---------------------------------------------
        // ---------------------------------------------

        private void GetPackageByID(int PackageId)
        {
            // get package info by ID in the combo box on the packages panel
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

            // Disable the edit button
            btnEditPackage.Enabled = false;
            

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

            // validate the values in the textboxes
            if (Validator.IsPresent(txtPackageName) && Validator.IsPresent(txtPkgDesc) &&
                Validator.IsPresent(txtPkgPrice) && Validator.IsPositveDouble(txtPkgPrice) &&
                Validator.IsPresent(txtCommission) && Validator.IsPositveDouble(txtCommission) &&
                Validator.IsWithinRange(txtCommission, 0, Convert.ToDecimal(txtPkgPrice.Text)) &&
                Validator.IsDateCorrect(dtStartDate, dtEndDate))
            {
                
                if (addPackage)
                {
                    Packages package = new Packages();
                    int PackageId;
                    // add the data from the fields to the package object
                    package.PkgName = txtPackageName.Text;
                    package.PkgDesc = txtPkgDesc.Text;
                    package.PkgStartDate = dtStartDate.Value;
                    package.PkgEndDate = dtEndDate.Value;
                    package.PkgBasePrice = Convert.ToDouble(txtPkgPrice.Text);
                    package.PkgAgencyCommission = Convert.ToDouble(txtCommission.Text);
                    
                    // try to add to the database
                    try
                    {
                        PackageId = PackagesDB.AddPackage(package);
                        MessageBox.Show("Package Successfully Added! ");
                    }// end try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    } // end catch
                    // Reload the packages combo box data
                    LoadPackagesComboBox();

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

        } // end save package method

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

        // Methods for buttons on the Suppliers Panel
        // ---------------------------------------------
        // ---------------------------------------------

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

        } // end method

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            // Convert the user input to uppercase and store
            string newSupName = txtSupplierName.Text.ToUpper();
            txtSupplierName.Text = newSupName;

            // Check to make sure the supplier name text box is non empty 
            // Try to add/edit the supplier name

            if (Validator.IsPresent(txtSupplierName))
            {

                if (addSupplier)  // adding a new supplier
                {
                    // create a new supplier and insert to database
                    supplier = new Supplier();
                    //add name data to object
                    supplier.SupName = txtSupplierName.Text;

                    //try to create the product
                    try
                    {
                        SupplierDB.AddSupplier(supplier);
                        MessageBox.Show("Supplier Successfully Added! ");
                    } //end try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }// end catch
                }//end if
                else //editing
                {

                    //get the selected supplier id
                    Supplier selectedSupplier = new Supplier();
                    selectedSupplier = (Supplier)cboSuppliers.SelectedItem;
                    

                    //make a new supplier object
                    Supplier newSupplier = new Supplier();
                    // set the supplier data
                    newSupplier.SupplierId = selectedSupplier.SupplierId;
                    newSupplier.SupName = newSupName;
                    
                    //try to edit the supplier
                    try
                    {
                        if (!SupplierDB.UpdateSupplier(selectedSupplier, newSupplier)) // if it fails
                        {
                            MessageBox.Show("Another user has edited that supplier. Please reload and try again");
                        } //end if
                        else // if it worked
                        {
                            selectedSupplier = newSupplier;
                            MessageBox.Show("Supplier Successfully Edited! ");
                            //Reload the combobox data
                            LoadSuppliersComboBox();
                            
                        }//end else

                    } // end try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    } // end catch
                }//end else
            }//end Val if

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            addSupplier = true;
            // Display the add/edit supplier panel
            lblAddEditSupplier.Text = "Add a New Supplier";
            pnlAddEditSupplier.Visible = true;

            txtSupplierName.Text = "";
            txtSupplierName.Focus();
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            addSupplier = false;
            // Display the add/edit supplier panel
            pnlAddEditSupplier.Visible = true;

            // Get the current selected supplier
            Supplier selectedSupplier = new Supplier();
            selectedSupplier = (Supplier)cboSuppliers.SelectedItem;
            int selectedSupplierId = selectedSupplier.SupplierId;

            // Display supplier name in textbox for editing
            txtSupplierName.Text = selectedSupplier.SupName;
            txtSupplierName.Focus();


        } //end method

    } // end class
}
