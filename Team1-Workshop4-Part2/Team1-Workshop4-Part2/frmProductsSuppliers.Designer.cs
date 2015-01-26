namespace Team1_Workshop4_Part2
{
    partial class frmProductsSuppliers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.comboBoxProductID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnFindProducts = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageSupplier = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSuppliers = new System.Windows.Forms.ListBox();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNavHome = new System.Windows.Forms.Button();
            this.btnNavProducts = new System.Windows.Forms.Button();
            this.btnNavSupplier = new System.Windows.Forms.Button();
            this.btnNavMySales = new System.Windows.Forms.Button();
            this.btnNavBookings = new System.Windows.Forms.Button();
            this.btnNavCustomers = new System.Windows.Forms.Button();
            this.btnNavAgents = new System.Windows.Forms.Button();
            this.btnNavPackages = new System.Windows.Forms.Button();
            this.panelHome = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNavExit = new System.Windows.Forms.Button();
            this.panelPackages = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDeletePackage = new System.Windows.Forms.Button();
            this.btnEditPackage = new System.Windows.Forms.Button();
            this.btnAddPackage = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFindPackage = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxPackages = new System.Windows.Forms.ComboBox();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPkgPrice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lstPkgProducts = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            this.tabPageSupplier.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.panelPackages.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageSupplier);
            this.tabControl1.Location = new System.Drawing.Point(323, 579);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.btnClose);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 22);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProducts.Size = new System.Drawing.Size(542, 399);
            this.tabPageProducts.TabIndex = 1;
            this.tabPageProducts.Text = "Products";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(399, 88);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(413, 295);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 32);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Enabled = false;
            this.btnDeleteProduct.Location = new System.Drawing.Point(282, 205);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(78, 32);
            this.btnDeleteProduct.TabIndex = 12;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Enabled = false;
            this.btnEditProduct.Location = new System.Drawing.Point(162, 205);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(78, 32);
            this.btnEditProduct.TabIndex = 11;
            this.btnEditProduct.Text = "Edit";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(40, 205);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(78, 32);
            this.btnAddProduct.TabIndex = 10;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // comboBoxProductID
            // 
            this.comboBoxProductID.FormattingEnabled = true;
            this.comboBoxProductID.Location = new System.Drawing.Point(107, 90);
            this.comboBoxProductID.Name = "comboBoxProductID";
            this.comboBoxProductID.Size = new System.Drawing.Size(94, 21);
            this.comboBoxProductID.TabIndex = 1;
            this.comboBoxProductID.Tag = "Product ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(107, 138);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(172, 22);
            this.txtProductName.TabIndex = 8;
            this.txtProductName.Tag = "Product Name";
            // 
            // btnFindProducts
            // 
            this.btnFindProducts.Location = new System.Drawing.Point(239, 88);
            this.btnFindProducts.Name = "btnFindProducts";
            this.btnFindProducts.Size = new System.Drawing.Size(130, 23);
            this.btnFindProducts.TabIndex = 7;
            this.btnFindProducts.Text = "Find Product Info";
            this.btnFindProducts.UseVisualStyleBackColor = true;
            this.btnFindProducts.Click += new System.EventHandler(this.btnFindProducts_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product ID:";
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.Controls.Add(this.btnDeleteSupplier);
            this.tabPageSupplier.Controls.Add(this.btnEditSupplier);
            this.tabPageSupplier.Controls.Add(this.btnAddSupplier);
            this.tabPageSupplier.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupplier.Size = new System.Drawing.Size(542, 399);
            this.tabPageSupplier.TabIndex = 0;
            this.tabPageSupplier.Text = "Supplier";
            this.tabPageSupplier.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Suppliers of this product";
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.Location = new System.Drawing.Point(65, 297);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(393, 186);
            this.lstSuppliers.TabIndex = 8;
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Enabled = false;
            this.btnDeleteSupplier.Location = new System.Drawing.Point(287, 295);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(78, 32);
            this.btnDeleteSupplier.TabIndex = 7;
            this.btnDeleteSupplier.Text = "Delete";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Enabled = false;
            this.btnEditSupplier.Location = new System.Drawing.Point(167, 295);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(78, 32);
            this.btnEditSupplier.TabIndex = 6;
            this.btnEditSupplier.Text = "Edit";
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(45, 295);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(78, 32);
            this.btnAddSupplier.TabIndex = 5;
            this.btnAddSupplier.Text = "Add";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(355, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Travel Experts Database Access";
            // 
            // btnNavHome
            // 
            this.btnNavHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavHome.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavHome.Location = new System.Drawing.Point(1, 52);
            this.btnNavHome.Name = "btnNavHome";
            this.btnNavHome.Size = new System.Drawing.Size(199, 56);
            this.btnNavHome.TabIndex = 3;
            this.btnNavHome.Text = "Home Screen";
            this.btnNavHome.UseVisualStyleBackColor = false;
            this.btnNavHome.Click += new System.EventHandler(this.btnNavHome_Click);
            // 
            // btnNavProducts
            // 
            this.btnNavProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavProducts.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavProducts.Location = new System.Drawing.Point(1, 163);
            this.btnNavProducts.Name = "btnNavProducts";
            this.btnNavProducts.Size = new System.Drawing.Size(199, 56);
            this.btnNavProducts.TabIndex = 4;
            this.btnNavProducts.Text = "Products";
            this.btnNavProducts.UseVisualStyleBackColor = false;
            this.btnNavProducts.Click += new System.EventHandler(this.btnNavProducts_Click);
            // 
            // btnNavSupplier
            // 
            this.btnNavSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavSupplier.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSupplier.Location = new System.Drawing.Point(1, 218);
            this.btnNavSupplier.Name = "btnNavSupplier";
            this.btnNavSupplier.Size = new System.Drawing.Size(199, 56);
            this.btnNavSupplier.TabIndex = 5;
            this.btnNavSupplier.Text = "Suppliers";
            this.btnNavSupplier.UseVisualStyleBackColor = false;
            this.btnNavSupplier.Click += new System.EventHandler(this.btnNavSupplier_Click);
            // 
            // btnNavMySales
            // 
            this.btnNavMySales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavMySales.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavMySales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavMySales.Location = new System.Drawing.Point(1, 442);
            this.btnNavMySales.Name = "btnNavMySales";
            this.btnNavMySales.Size = new System.Drawing.Size(199, 56);
            this.btnNavMySales.TabIndex = 6;
            this.btnNavMySales.Text = "My Sales";
            this.btnNavMySales.UseVisualStyleBackColor = false;
            // 
            // btnNavBookings
            // 
            this.btnNavBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavBookings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBookings.Location = new System.Drawing.Point(1, 331);
            this.btnNavBookings.Name = "btnNavBookings";
            this.btnNavBookings.Size = new System.Drawing.Size(199, 56);
            this.btnNavBookings.TabIndex = 7;
            this.btnNavBookings.Text = "My Bookings";
            this.btnNavBookings.UseVisualStyleBackColor = false;
            // 
            // btnNavCustomers
            // 
            this.btnNavCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavCustomers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCustomers.Location = new System.Drawing.Point(1, 386);
            this.btnNavCustomers.Name = "btnNavCustomers";
            this.btnNavCustomers.Size = new System.Drawing.Size(199, 56);
            this.btnNavCustomers.TabIndex = 8;
            this.btnNavCustomers.Text = "My Customers";
            this.btnNavCustomers.UseVisualStyleBackColor = false;
            // 
            // btnNavAgents
            // 
            this.btnNavAgents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavAgents.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAgents.Location = new System.Drawing.Point(1, 274);
            this.btnNavAgents.Name = "btnNavAgents";
            this.btnNavAgents.Size = new System.Drawing.Size(199, 56);
            this.btnNavAgents.TabIndex = 10;
            this.btnNavAgents.Text = "Agents";
            this.btnNavAgents.UseVisualStyleBackColor = false;
            // 
            // btnNavPackages
            // 
            this.btnNavPackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavPackages.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavPackages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPackages.Location = new System.Drawing.Point(1, 107);
            this.btnNavPackages.Name = "btnNavPackages";
            this.btnNavPackages.Size = new System.Drawing.Size(199, 56);
            this.btnNavPackages.TabIndex = 11;
            this.btnNavPackages.Text = "Packages";
            this.btnNavPackages.UseVisualStyleBackColor = false;
            this.btnNavPackages.Click += new System.EventHandler(this.btnNavPackages_Click);
            // 
            // panelHome
            // 
            this.panelHome.Controls.Add(this.label7);
            this.panelHome.Controls.Add(this.label6);
            this.panelHome.Location = new System.Drawing.Point(212, 56);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(596, 496);
            this.panelHome.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Maybe some SQL Query will display here.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Home Tab";
            // 
            // btnNavExit
            // 
            this.btnNavExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNavExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNavExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavExit.Location = new System.Drawing.Point(1, 499);
            this.btnNavExit.Name = "btnNavExit";
            this.btnNavExit.Size = new System.Drawing.Size(199, 56);
            this.btnNavExit.TabIndex = 14;
            this.btnNavExit.Text = "Exit";
            this.btnNavExit.UseVisualStyleBackColor = false;
            this.btnNavExit.Click += new System.EventHandler(this.btnNavExit_Click);
            // 
            // panelPackages
            // 
            this.panelPackages.Controls.Add(this.lstPkgProducts);
            this.panelPackages.Controls.Add(this.label17);
            this.panelPackages.Controls.Add(this.label16);
            this.panelPackages.Controls.Add(this.txtPkgPrice);
            this.panelPackages.Controls.Add(this.label15);
            this.panelPackages.Controls.Add(this.txtCommission);
            this.panelPackages.Controls.Add(this.label14);
            this.panelPackages.Controls.Add(this.txtPkgDesc);
            this.panelPackages.Controls.Add(this.label13);
            this.panelPackages.Controls.Add(this.txtEndDate);
            this.panelPackages.Controls.Add(this.label12);
            this.panelPackages.Controls.Add(this.txtStartDate);
            this.panelPackages.Controls.Add(this.btnDeletePackage);
            this.panelPackages.Controls.Add(this.btnEditPackage);
            this.panelPackages.Controls.Add(this.btnAddPackage);
            this.panelPackages.Controls.Add(this.label8);
            this.panelPackages.Controls.Add(this.btnFindPackage);
            this.panelPackages.Controls.Add(this.label11);
            this.panelPackages.Controls.Add(this.comboBoxPackages);
            this.panelPackages.Controls.Add(this.txtPackageName);
            this.panelPackages.Controls.Add(this.label10);
            this.panelPackages.Location = new System.Drawing.Point(812, 56);
            this.panelPackages.Name = "panelPackages";
            this.panelPackages.Size = new System.Drawing.Size(596, 496);
            this.panelPackages.TabIndex = 13;
            this.panelPackages.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(883, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "DO NOT DRAG AND DROP PANELS";
            // 
            // panelProducts
            // 
            this.panelProducts.Controls.Add(this.label1);
            this.panelProducts.Controls.Add(this.btnRefresh);
            this.panelProducts.Controls.Add(this.lstSuppliers);
            this.panelProducts.Controls.Add(this.btnDeleteProduct);
            this.panelProducts.Controls.Add(this.btnEditProduct);
            this.panelProducts.Controls.Add(this.label9);
            this.panelProducts.Controls.Add(this.btnAddProduct);
            this.panelProducts.Controls.Add(this.label4);
            this.panelProducts.Controls.Add(this.btnFindProducts);
            this.panelProducts.Controls.Add(this.label3);
            this.panelProducts.Controls.Add(this.comboBoxProductID);
            this.panelProducts.Controls.Add(this.txtProductName);
            this.panelProducts.Location = new System.Drawing.Point(212, 56);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(596, 496);
            this.panelProducts.TabIndex = 16;
            this.panelProducts.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Maintain Products";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(285, 25);
            this.label10.TabIndex = 2;
            this.label10.Text = "Maintain Travel Packages";
            // 
            // btnDeletePackage
            // 
            this.btnDeletePackage.Enabled = false;
            this.btnDeletePackage.Location = new System.Drawing.Point(286, 400);
            this.btnDeletePackage.Name = "btnDeletePackage";
            this.btnDeletePackage.Size = new System.Drawing.Size(78, 32);
            this.btnDeletePackage.TabIndex = 20;
            this.btnDeletePackage.Text = "Delete";
            this.btnDeletePackage.UseVisualStyleBackColor = true;
            // 
            // btnEditPackage
            // 
            this.btnEditPackage.Enabled = false;
            this.btnEditPackage.Location = new System.Drawing.Point(166, 400);
            this.btnEditPackage.Name = "btnEditPackage";
            this.btnEditPackage.Size = new System.Drawing.Size(78, 32);
            this.btnEditPackage.TabIndex = 19;
            this.btnEditPackage.Text = "Edit";
            this.btnEditPackage.UseVisualStyleBackColor = true;
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Location = new System.Drawing.Point(44, 400);
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Size = new System.Drawing.Size(78, 32);
            this.btnAddPackage.TabIndex = 18;
            this.btnAddPackage.Text = "Add";
            this.btnAddPackage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Select a Package";
            // 
            // btnFindPackage
            // 
            this.btnFindPackage.Location = new System.Drawing.Point(301, 90);
            this.btnFindPackage.Name = "btnFindPackage";
            this.btnFindPackage.Size = new System.Drawing.Size(130, 23);
            this.btnFindPackage.TabIndex = 15;
            this.btnFindPackage.Text = "Find Package Info";
            this.btnFindPackage.UseVisualStyleBackColor = true;
            this.btnFindPackage.Click += new System.EventHandler(this.btnFindPackage_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Package Name:";
            // 
            // comboBoxPackages
            // 
            this.comboBoxPackages.FormattingEnabled = true;
            this.comboBoxPackages.Location = new System.Drawing.Point(126, 91);
            this.comboBoxPackages.Name = "comboBoxPackages";
            this.comboBoxPackages.Size = new System.Drawing.Size(155, 21);
            this.comboBoxPackages.TabIndex = 13;
            this.comboBoxPackages.Tag = "Product ID";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Enabled = false;
            this.txtPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName.Location = new System.Drawing.Point(126, 139);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(222, 22);
            this.txtPackageName.TabIndex = 16;
            this.txtPackageName.Tag = "Product Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Start Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Enabled = false;
            this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(126, 181);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(222, 22);
            this.txtStartDate.TabIndex = 21;
            this.txtStartDate.Tag = "Product Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 223);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Enabled = false;
            this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(126, 218);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(222, 22);
            this.txtEndDate.TabIndex = 23;
            this.txtEndDate.Tag = "Product Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 257);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Description:";
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.Enabled = false;
            this.txtPkgDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgDesc.Location = new System.Drawing.Point(126, 252);
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(222, 22);
            this.txtPkgDesc.TabIndex = 25;
            this.txtPkgDesc.Tag = "Product Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(47, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Commission:";
            // 
            // txtCommission
            // 
            this.txtCommission.Enabled = false;
            this.txtCommission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommission.Location = new System.Drawing.Point(126, 327);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(222, 22);
            this.txtCommission.TabIndex = 27;
            this.txtCommission.Tag = "Product Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(47, 299);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Retail price:";
            // 
            // txtPkgPrice
            // 
            this.txtPkgPrice.Enabled = false;
            this.txtPkgPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgPrice.Location = new System.Drawing.Point(126, 294);
            this.txtPkgPrice.Name = "txtPkgPrice";
            this.txtPkgPrice.Size = new System.Drawing.Size(222, 22);
            this.txtPkgPrice.TabIndex = 29;
            this.txtPkgPrice.Tag = "Product Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(394, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Products in this Package";
            // 
            // lstPkgProducts
            // 
            this.lstPkgProducts.FormattingEnabled = true;
            this.lstPkgProducts.Location = new System.Drawing.Point(382, 181);
            this.lstPkgProducts.Name = "lstPkgProducts";
            this.lstPkgProducts.Size = new System.Drawing.Size(161, 186);
            this.lstPkgProducts.TabIndex = 15;
            // 
            // frmProductsSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1365, 784);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelPackages);
            this.Controls.Add(this.btnNavExit);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.btnNavPackages);
            this.Controls.Add(this.btnNavAgents);
            this.Controls.Add(this.btnNavCustomers);
            this.Controls.Add(this.btnNavBookings);
            this.Controls.Add(this.btnNavMySales);
            this.Controls.Add(this.btnNavSupplier);
            this.Controls.Add(this.btnNavProducts);
            this.Controls.Add(this.btnNavHome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmProductsSuppliers";
            this.Text = "Travel Experts Database Access";
            this.Load += new System.EventHandler(this.frmProductsSuppliers_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            this.tabPageSupplier.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            this.panelPackages.ResumeLayout(false);
            this.panelPackages.PerformLayout();
            this.panelProducts.ResumeLayout(false);
            this.panelProducts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSupplier;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnFindProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxProductID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSuppliers;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnNavHome;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavSupplier;
        private System.Windows.Forms.Button btnNavMySales;
        private System.Windows.Forms.Button btnNavBookings;
        private System.Windows.Forms.Button btnNavCustomers;
        private System.Windows.Forms.Button btnNavAgents;
        private System.Windows.Forms.Button btnNavPackages;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNavExit;
        private System.Windows.Forms.Panel panelPackages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstPkgProducts;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPkgPrice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPkgDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Button btnDeletePackage;
        private System.Windows.Forms.Button btnEditPackage;
        private System.Windows.Forms.Button btnAddPackage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFindPackage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxPackages;
        private System.Windows.Forms.TextBox txtPackageName;
    }
}

