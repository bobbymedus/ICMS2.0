namespace ICMS
{
    partial class TransferItem
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
            this.chkLsBxCustomer = new System.Windows.Forms.CheckedListBox();
            this.chkBxListCustIDs = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chkLsBxCustomer
            // 
            this.chkLsBxCustomer.CheckOnClick = true;
            this.chkLsBxCustomer.FormattingEnabled = true;
            this.chkLsBxCustomer.Location = new System.Drawing.Point(33, 17);
            this.chkLsBxCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLsBxCustomer.Name = "chkLsBxCustomer";
            this.chkLsBxCustomer.Size = new System.Drawing.Size(320, 454);
            this.chkLsBxCustomer.TabIndex = 0;
            this.chkLsBxCustomer.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLsBxCustomer_ItemCheck);
            this.chkLsBxCustomer.SelectedIndexChanged += new System.EventHandler(this.chkLsBxCustomer_SelectedIndexChanged);
            // 
            // chkBxListCustIDs
            // 
            this.chkBxListCustIDs.FormattingEnabled = true;
            this.chkBxListCustIDs.Location = new System.Drawing.Point(357, 84);
            this.chkBxListCustIDs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBxListCustIDs.Name = "chkBxListCustIDs";
            this.chkBxListCustIDs.Size = new System.Drawing.Size(48, 34);
            this.chkBxListCustIDs.TabIndex = 1;
            this.chkBxListCustIDs.Visible = false;
            // 
            // TransferItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 496);
            this.Controls.Add(this.chkBxListCustIDs);
            this.Controls.Add(this.chkLsBxCustomer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TransferItem";
            this.Text = "TransferItem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkLsBxCustomer;
        private System.Windows.Forms.CheckedListBox chkBxListCustIDs;
    }
}