namespace ICMS
{
    partial class BuildATruck
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
            this.listViewBTBOLs = new System.Windows.Forms.ListView();
            this.colBTShipID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBTRelNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBTRelDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBTBranch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxBTBranch = new System.Windows.Forms.ComboBox();
            this.labelBTBranch = new System.Windows.Forms.Label();
            this.buttonBTBuildTruck = new System.Windows.Forms.Button();
            this.buttonBTCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewBTBOLs
            // 
            this.listViewBTBOLs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBTBOLs.CheckBoxes = true;
            this.listViewBTBOLs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBTShipID,
            this.colBTRelNum,
            this.colBTRelDate,
            this.colBTBranch});
            this.listViewBTBOLs.HideSelection = false;
            this.listViewBTBOLs.Location = new System.Drawing.Point(34, 28);
            this.listViewBTBOLs.Name = "listViewBTBOLs";
            this.listViewBTBOLs.Size = new System.Drawing.Size(844, 544);
            this.listViewBTBOLs.TabIndex = 0;
            this.listViewBTBOLs.UseCompatibleStateImageBehavior = false;
            this.listViewBTBOLs.View = System.Windows.Forms.View.Details;
            // 
            // colBTShipID
            // 
            this.colBTShipID.Text = "BOL#";
            this.colBTShipID.Width = 126;
            // 
            // colBTRelNum
            // 
            this.colBTRelNum.Text = "Release";
            this.colBTRelNum.Width = 147;
            // 
            // colBTRelDate
            // 
            this.colBTRelDate.Text = "Date";
            this.colBTRelDate.Width = 159;
            // 
            // colBTBranch
            // 
            this.colBTBranch.Text = "Branch";
            this.colBTBranch.Width = 183;
            // 
            // comboBoxBTBranch
            // 
            this.comboBoxBTBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBTBranch.FormattingEnabled = true;
            this.comboBoxBTBranch.Location = new System.Drawing.Point(34, 639);
            this.comboBoxBTBranch.Name = "comboBoxBTBranch";
            this.comboBoxBTBranch.Size = new System.Drawing.Size(136, 24);
            this.comboBoxBTBranch.TabIndex = 1;
            // 
            // labelBTBranch
            // 
            this.labelBTBranch.AutoSize = true;
            this.labelBTBranch.Location = new System.Drawing.Point(31, 613);
            this.labelBTBranch.Name = "labelBTBranch";
            this.labelBTBranch.Size = new System.Drawing.Size(53, 17);
            this.labelBTBranch.TabIndex = 2;
            this.labelBTBranch.Text = "Branch";
            // 
            // buttonBTBuildTruck
            // 
            this.buttonBTBuildTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBTBuildTruck.Location = new System.Drawing.Point(740, 613);
            this.buttonBTBuildTruck.Name = "buttonBTBuildTruck";
            this.buttonBTBuildTruck.Size = new System.Drawing.Size(137, 50);
            this.buttonBTBuildTruck.TabIndex = 3;
            this.buttonBTBuildTruck.Text = "Build Truck";
            this.buttonBTBuildTruck.UseVisualStyleBackColor = true;
            this.buttonBTBuildTruck.Click += new System.EventHandler(this.ButtonBTBuildTruck_Click);
            // 
            // buttonBTCancel
            // 
            this.buttonBTCancel.Location = new System.Drawing.Point(586, 613);
            this.buttonBTCancel.Name = "buttonBTCancel";
            this.buttonBTCancel.Size = new System.Drawing.Size(137, 50);
            this.buttonBTCancel.TabIndex = 4;
            this.buttonBTCancel.Text = "Cancel";
            this.buttonBTCancel.UseVisualStyleBackColor = true;
            this.buttonBTCancel.Click += new System.EventHandler(this.ButtonBTCancel_Click);
            // 
            // BuildATruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 700);
            this.Controls.Add(this.buttonBTCancel);
            this.Controls.Add(this.buttonBTBuildTruck);
            this.Controls.Add(this.labelBTBranch);
            this.Controls.Add(this.comboBoxBTBranch);
            this.Controls.Add(this.listViewBTBOLs);
            this.Name = "BuildATruck";
            this.Text = "BuildATruck";
            this.Load += new System.EventHandler(this.BuildATruck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBTBOLs;
        private System.Windows.Forms.ComboBox comboBoxBTBranch;
        private System.Windows.Forms.Label labelBTBranch;
        private System.Windows.Forms.Button buttonBTBuildTruck;
        private System.Windows.Forms.ColumnHeader colBTShipID;
        private System.Windows.Forms.ColumnHeader colBTRelNum;
        private System.Windows.Forms.ColumnHeader colBTRelDate;
        private System.Windows.Forms.ColumnHeader colBTBranch;
        private System.Windows.Forms.Button buttonBTCancel;
    }
}