namespace DesktopApp2
{
    partial class Form1
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
            this.treeViewCustomer = new System.Windows.Forms.TreeView();
            this.checkBoxInactiveCustomers = new System.Windows.Forms.CheckBox();
            this.tabControlLocations = new System.Windows.Forms.TabControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCoil = new System.Windows.Forms.TabPage();
            this.tabPageSkid = new System.Windows.Forms.TabPage();
            this.tabPageCoilPolishOrders = new System.Windows.Forms.TabPage();
            this.tabPageReceiving = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewCustomer
            // 
            this.treeViewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewCustomer.Location = new System.Drawing.Point(-1, 36);
            this.treeViewCustomer.Name = "treeViewCustomer";
            this.treeViewCustomer.Size = new System.Drawing.Size(241, 764);
            this.treeViewCustomer.TabIndex = 0;
            // 
            // checkBoxInactiveCustomers
            // 
            this.checkBoxInactiveCustomers.AutoSize = true;
            this.checkBoxInactiveCustomers.Location = new System.Drawing.Point(5, 4);
            this.checkBoxInactiveCustomers.Name = "checkBoxInactiveCustomers";
            this.checkBoxInactiveCustomers.Size = new System.Drawing.Size(182, 21);
            this.checkBoxInactiveCustomers.TabIndex = 1;
            this.checkBoxInactiveCustomers.Text = "View Inactive Customers";
            this.checkBoxInactiveCustomers.UseVisualStyleBackColor = true;
            // 
            // tabControlLocations
            // 
            this.tabControlLocations.Location = new System.Drawing.Point(245, 2);
            this.tabControlLocations.Name = "tabControlLocations";
            this.tabControlLocations.SelectedIndex = 0;
            this.tabControlLocations.Size = new System.Drawing.Size(581, 23);
            this.tabControlLocations.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCoil);
            this.tabControl1.Controls.Add(this.tabPageSkid);
            this.tabControl1.Controls.Add(this.tabPageCoilPolishOrders);
            this.tabControl1.Controls.Add(this.tabPageReceiving);
            this.tabControl1.Location = new System.Drawing.Point(245, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 763);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageCoil
            // 
            this.tabPageCoil.Location = new System.Drawing.Point(4, 25);
            this.tabPageCoil.Name = "tabPageCoil";
            this.tabPageCoil.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCoil.Size = new System.Drawing.Size(936, 734);
            this.tabPageCoil.TabIndex = 0;
            this.tabPageCoil.Text = "Coil";
            this.tabPageCoil.UseVisualStyleBackColor = true;
            // 
            // tabPageSkid
            // 
            this.tabPageSkid.Location = new System.Drawing.Point(4, 25);
            this.tabPageSkid.Name = "tabPageSkid";
            this.tabPageSkid.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSkid.Size = new System.Drawing.Size(936, 734);
            this.tabPageSkid.TabIndex = 1;
            this.tabPageSkid.Text = "Skid";
            this.tabPageSkid.UseVisualStyleBackColor = true;
            // 
            // tabPageCoilPolishOrders
            // 
            this.tabPageCoilPolishOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageCoilPolishOrders.Name = "tabPageCoilPolishOrders";
            this.tabPageCoilPolishOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCoilPolishOrders.Size = new System.Drawing.Size(936, 734);
            this.tabPageCoilPolishOrders.TabIndex = 2;
            this.tabPageCoilPolishOrders.Text = "Coil Polish Order";
            this.tabPageCoilPolishOrders.UseVisualStyleBackColor = true;
            // 
            // tabPageReceiving
            // 
            this.tabPageReceiving.Location = new System.Drawing.Point(4, 25);
            this.tabPageReceiving.Name = "tabPageReceiving";
            this.tabPageReceiving.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReceiving.Size = new System.Drawing.Size(936, 734);
            this.tabPageReceiving.TabIndex = 3;
            this.tabPageReceiving.Text = "Receiving";
            this.tabPageReceiving.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 800);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControlLocations);
            this.Controls.Add(this.checkBoxInactiveCustomers);
            this.Controls.Add(this.treeViewCustomer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCustomer;
        private System.Windows.Forms.CheckBox checkBoxInactiveCustomers;
        private System.Windows.Forms.TabControl tabControlLocations;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCoil;
        private System.Windows.Forms.TabPage tabPageSkid;
        private System.Windows.Forms.TabPage tabPageCoilPolishOrders;
        private System.Windows.Forms.TabPage tabPageReceiving;
    }
}

