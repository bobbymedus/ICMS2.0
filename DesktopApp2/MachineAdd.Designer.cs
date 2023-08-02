namespace ICMS
{
    partial class MachineAdd
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
            this.cbProcessType = new System.Windows.Forms.ComboBox();
            this.tbMachineName = new System.Windows.Forms.TextBox();
            this.tbThicknessMin = new System.Windows.Forms.TextBox();
            this.tbThicknessMax = new System.Windows.Forms.TextBox();
            this.tbWidthMin = new System.Windows.Forms.TextBox();
            this.tbWidthMax = new System.Windows.Forms.TextBox();
            this.tbLengthMax = new System.Windows.Forms.TextBox();
            this.tbLengthMin = new System.Windows.Forms.TextBox();
            this.tbWeightMax = new System.Windows.Forms.TextBox();
            this.tbWeightMin = new System.Windows.Forms.TextBox();
            this.rtbMachineDesc = new System.Windows.Forms.RichTextBox();
            this.numLeadTime = new System.Windows.Forms.NumericUpDown();
            this.cbDefaultFinish = new System.Windows.Forms.ComboBox();
            this.tbHoldDown = new System.Windows.Forms.TextBox();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblThickness = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblLeadTime = new System.Windows.Forms.Label();
            this.lblDefaultFinish = new System.Windows.Forms.Label();
            this.lblHoldDown = new System.Windows.Forms.Label();
            this.btAddMachine = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbProcID = new System.Windows.Forms.ComboBox();
            this.cbFinishID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLeadTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cbProcessType
            // 
            this.cbProcessType.FormattingEnabled = true;
            this.cbProcessType.Location = new System.Drawing.Point(115, 36);
            this.cbProcessType.Name = "cbProcessType";
            this.cbProcessType.Size = new System.Drawing.Size(262, 24);
            this.cbProcessType.TabIndex = 0;
            this.cbProcessType.SelectedIndexChanged += new System.EventHandler(this.cbProcessType_SelectedIndexChanged);
            // 
            // tbMachineName
            // 
            this.tbMachineName.Location = new System.Drawing.Point(115, 88);
            this.tbMachineName.Name = "tbMachineName";
            this.tbMachineName.Size = new System.Drawing.Size(282, 22);
            this.tbMachineName.TabIndex = 1;
            this.tbMachineName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMachineName_KeyPress);
            // 
            // tbThicknessMin
            // 
            this.tbThicknessMin.Location = new System.Drawing.Point(115, 162);
            this.tbThicknessMin.Name = "tbThicknessMin";
            this.tbThicknessMin.Size = new System.Drawing.Size(149, 22);
            this.tbThicknessMin.TabIndex = 2;
            this.tbThicknessMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbThicknessMin_KeyPress);
            // 
            // tbThicknessMax
            // 
            this.tbThicknessMax.Location = new System.Drawing.Point(287, 162);
            this.tbThicknessMax.Name = "tbThicknessMax";
            this.tbThicknessMax.Size = new System.Drawing.Size(149, 22);
            this.tbThicknessMax.TabIndex = 3;
            this.tbThicknessMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbThicknessMax_KeyPress);
            // 
            // tbWidthMin
            // 
            this.tbWidthMin.Location = new System.Drawing.Point(113, 212);
            this.tbWidthMin.Name = "tbWidthMin";
            this.tbWidthMin.Size = new System.Drawing.Size(149, 22);
            this.tbWidthMin.TabIndex = 4;
            this.tbWidthMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWidthMin_KeyPress);
            // 
            // tbWidthMax
            // 
            this.tbWidthMax.Location = new System.Drawing.Point(287, 212);
            this.tbWidthMax.Name = "tbWidthMax";
            this.tbWidthMax.Size = new System.Drawing.Size(149, 22);
            this.tbWidthMax.TabIndex = 5;
            this.tbWidthMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWidthMax_KeyPress);
            // 
            // tbLengthMax
            // 
            this.tbLengthMax.Location = new System.Drawing.Point(287, 262);
            this.tbLengthMax.Name = "tbLengthMax";
            this.tbLengthMax.Size = new System.Drawing.Size(149, 22);
            this.tbLengthMax.TabIndex = 7;
            this.tbLengthMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLengthMax_KeyPress);
            // 
            // tbLengthMin
            // 
            this.tbLengthMin.Location = new System.Drawing.Point(115, 262);
            this.tbLengthMin.Name = "tbLengthMin";
            this.tbLengthMin.Size = new System.Drawing.Size(149, 22);
            this.tbLengthMin.TabIndex = 6;
            this.tbLengthMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLengthMin_KeyPress);
            // 
            // tbWeightMax
            // 
            this.tbWeightMax.Location = new System.Drawing.Point(287, 312);
            this.tbWeightMax.Name = "tbWeightMax";
            this.tbWeightMax.Size = new System.Drawing.Size(149, 22);
            this.tbWeightMax.TabIndex = 9;
            this.tbWeightMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeightMax_KeyPress);
            // 
            // tbWeightMin
            // 
            this.tbWeightMin.Location = new System.Drawing.Point(115, 312);
            this.tbWeightMin.Name = "tbWeightMin";
            this.tbWeightMin.Size = new System.Drawing.Size(149, 22);
            this.tbWeightMin.TabIndex = 8;
            this.tbWeightMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWeightMin_KeyPress);
            // 
            // rtbMachineDesc
            // 
            this.rtbMachineDesc.Location = new System.Drawing.Point(487, 55);
            this.rtbMachineDesc.Name = "rtbMachineDesc";
            this.rtbMachineDesc.Size = new System.Drawing.Size(289, 92);
            this.rtbMachineDesc.TabIndex = 10;
            this.rtbMachineDesc.Text = "";
            this.rtbMachineDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbMachineDesc_KeyPress);
            // 
            // numLeadTime
            // 
            this.numLeadTime.Location = new System.Drawing.Point(627, 215);
            this.numLeadTime.Name = "numLeadTime";
            this.numLeadTime.Size = new System.Drawing.Size(56, 22);
            this.numLeadTime.TabIndex = 11;
            // 
            // cbDefaultFinish
            // 
            this.cbDefaultFinish.FormattingEnabled = true;
            this.cbDefaultFinish.Location = new System.Drawing.Point(627, 265);
            this.cbDefaultFinish.Name = "cbDefaultFinish";
            this.cbDefaultFinish.Size = new System.Drawing.Size(149, 24);
            this.cbDefaultFinish.TabIndex = 12;
            this.cbDefaultFinish.SelectedIndexChanged += new System.EventHandler(this.cbDefaultFinish_SelectedIndexChanged);
            // 
            // tbHoldDown
            // 
            this.tbHoldDown.Location = new System.Drawing.Point(627, 312);
            this.tbHoldDown.Name = "tbHoldDown";
            this.tbHoldDown.Size = new System.Drawing.Size(149, 22);
            this.tbHoldDown.TabIndex = 13;
            this.tbHoldDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHoldDown_KeyPress);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(52, 39);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(57, 16);
            this.lblProcess.TabIndex = 14;
            this.lblProcess.Text = "Process";
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(11, 91);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(98, 16);
            this.lblMachineName.TabIndex = 15;
            this.lblMachineName.Text = "Machine Name";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(155, 131);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(28, 16);
            this.lblMin.TabIndex = 16;
            this.lblMin.Text = "Min";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(349, 131);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(32, 16);
            this.lblMax.TabIndex = 17;
            this.lblMax.Text = "Max";
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Location = new System.Drawing.Point(40, 165);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(69, 16);
            this.lblThickness.TabIndex = 18;
            this.lblThickness.Text = "Thickness";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(66, 215);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(41, 16);
            this.lblWidth.TabIndex = 19;
            this.lblWidth.Text = "Width";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(60, 265);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(47, 16);
            this.lblLength.TabIndex = 20;
            this.lblLength.Text = "Length";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(40, 315);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(49, 16);
            this.lblWeight.TabIndex = 21;
            this.lblWeight.Text = "Weight";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(484, 36);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(129, 16);
            this.lblDesc.TabIndex = 22;
            this.lblDesc.Text = "Machine Description";
            // 
            // lblLeadTime
            // 
            this.lblLeadTime.AutoSize = true;
            this.lblLeadTime.Location = new System.Drawing.Point(549, 218);
            this.lblLeadTime.Name = "lblLeadTime";
            this.lblLeadTime.Size = new System.Drawing.Size(72, 16);
            this.lblLeadTime.TabIndex = 23;
            this.lblLeadTime.Text = "Lead Time";
            // 
            // lblDefaultFinish
            // 
            this.lblDefaultFinish.AutoSize = true;
            this.lblDefaultFinish.Location = new System.Drawing.Point(534, 268);
            this.lblDefaultFinish.Name = "lblDefaultFinish";
            this.lblDefaultFinish.Size = new System.Drawing.Size(87, 16);
            this.lblDefaultFinish.TabIndex = 24;
            this.lblDefaultFinish.Text = "Default Finish";
            // 
            // lblHoldDown
            // 
            this.lblHoldDown.AutoSize = true;
            this.lblHoldDown.Location = new System.Drawing.Point(511, 315);
            this.lblHoldDown.Name = "lblHoldDown";
            this.lblHoldDown.Size = new System.Drawing.Size(110, 16);
            this.lblHoldDown.TabIndex = 25;
            this.lblHoldDown.Text = "Hold Down Width";
            // 
            // btAddMachine
            // 
            this.btAddMachine.Location = new System.Drawing.Point(613, 392);
            this.btAddMachine.Name = "btAddMachine";
            this.btAddMachine.Size = new System.Drawing.Size(162, 35);
            this.btAddMachine.TabIndex = 26;
            this.btAddMachine.Text = "Add Machine";
            this.btAddMachine.UseVisualStyleBackColor = true;
            this.btAddMachine.Click += new System.EventHandler(this.btAddMachine_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(424, 392);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(162, 35);
            this.btCancel.TabIndex = 27;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbProcID
            // 
            this.cbProcID.FormattingEnabled = true;
            this.cbProcID.Location = new System.Drawing.Point(64, 382);
            this.cbProcID.Name = "cbProcID";
            this.cbProcID.Size = new System.Drawing.Size(146, 24);
            this.cbProcID.TabIndex = 28;
            // 
            // cbFinishID
            // 
            this.cbFinishID.FormattingEnabled = true;
            this.cbFinishID.Location = new System.Drawing.Point(232, 382);
            this.cbFinishID.Name = "cbFinishID";
            this.cbFinishID.Size = new System.Drawing.Size(149, 24);
            this.cbFinishID.TabIndex = 29;
            // 
            // MachineAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbFinishID);
            this.Controls.Add(this.cbProcID);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAddMachine);
            this.Controls.Add(this.lblHoldDown);
            this.Controls.Add(this.lblDefaultFinish);
            this.Controls.Add(this.lblLeadTime);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblThickness);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMachineName);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.tbHoldDown);
            this.Controls.Add(this.cbDefaultFinish);
            this.Controls.Add(this.numLeadTime);
            this.Controls.Add(this.rtbMachineDesc);
            this.Controls.Add(this.tbWeightMax);
            this.Controls.Add(this.tbWeightMin);
            this.Controls.Add(this.tbLengthMax);
            this.Controls.Add(this.tbLengthMin);
            this.Controls.Add(this.tbWidthMax);
            this.Controls.Add(this.tbWidthMin);
            this.Controls.Add(this.tbThicknessMax);
            this.Controls.Add(this.tbThicknessMin);
            this.Controls.Add(this.tbMachineName);
            this.Controls.Add(this.cbProcessType);
            this.Name = "MachineAdd";
            this.Text = "Machine Add";
            ((System.ComponentModel.ISupportInitialize)(this.numLeadTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProcessType;
        private System.Windows.Forms.TextBox tbMachineName;
        private System.Windows.Forms.TextBox tbThicknessMin;
        private System.Windows.Forms.TextBox tbThicknessMax;
        private System.Windows.Forms.TextBox tbWidthMin;
        private System.Windows.Forms.TextBox tbWidthMax;
        private System.Windows.Forms.TextBox tbLengthMax;
        private System.Windows.Forms.TextBox tbLengthMin;
        private System.Windows.Forms.TextBox tbWeightMax;
        private System.Windows.Forms.TextBox tbWeightMin;
        private System.Windows.Forms.RichTextBox rtbMachineDesc;
        private System.Windows.Forms.NumericUpDown numLeadTime;
        private System.Windows.Forms.ComboBox cbDefaultFinish;
        private System.Windows.Forms.TextBox tbHoldDown;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblLeadTime;
        private System.Windows.Forms.Label lblDefaultFinish;
        private System.Windows.Forms.Label lblHoldDown;
        private System.Windows.Forms.Button btAddMachine;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ComboBox cbProcID;
        private System.Windows.Forms.ComboBox cbFinishID;
    }
}