namespace ICMS
{
    partial class ShearInputBox
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
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxPieces = new System.Windows.Forms.TextBox();
            this.labelPieces = new System.Windows.Forms.Label();
            this.buttonFinished = new System.Windows.Forms.Button();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.buttonAddMore = new System.Windows.Forms.Button();
            this.buttonNextLine = new System.Windows.Forms.Button();
            this.labelHeat = new System.Windows.Forms.Label();
            this.labelSourceW = new System.Windows.Forms.Label();
            this.labelSourceL = new System.Windows.Forms.Label();
            this.labelSourceA = new System.Windows.Forms.Label();
            this.labelSourceP = new System.Windows.Forms.Label();
            this.groupBoxTotalOrPiece = new System.Windows.Forms.GroupBox();
            this.radioButtonPerSheet = new System.Windows.Forms.RadioButton();
            this.radioButtonTotal = new System.Windows.Forms.RadioButton();
            this.checkBoxGauer = new System.Windows.Forms.CheckBox();
            this.buttonPrevLine = new System.Windows.Forms.Button();
            this.groupBoxTotalOrPiece.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(154, 102);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(107, 22);
            this.textBoxWidth.TabIndex = 2;
            this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxWidth_KeyPress);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(270, 105);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 17);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X";
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(296, 102);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(107, 22);
            this.textBoxLength.TabIndex = 3;
            this.textBoxLength.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            this.textBoxLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxLength_KeyPress);
            // 
            // textBoxPieces
            // 
            this.textBoxPieces.Location = new System.Drawing.Point(23, 102);
            this.textBoxPieces.Name = "textBoxPieces";
            this.textBoxPieces.Size = new System.Drawing.Size(95, 22);
            this.textBoxPieces.TabIndex = 1;
            this.textBoxPieces.TextChanged += new System.EventHandler(this.TextBoxPieces_TextChanged);
            this.textBoxPieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPieces_KeyPress);
            // 
            // labelPieces
            // 
            this.labelPieces.AutoSize = true;
            this.labelPieces.Location = new System.Drawing.Point(23, 84);
            this.labelPieces.Name = "labelPieces";
            this.labelPieces.Size = new System.Drawing.Size(50, 17);
            this.labelPieces.TabIndex = 4;
            this.labelPieces.Text = "Pieces";
            // 
            // buttonFinished
            // 
            this.buttonFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFinished.Location = new System.Drawing.Point(256, 184);
            this.buttonFinished.Name = "buttonFinished";
            this.buttonFinished.Size = new System.Drawing.Size(147, 31);
            this.buttonFinished.TabIndex = 5;
            this.buttonFinished.Text = "Finished";
            this.buttonFinished.UseVisualStyleBackColor = true;
            this.buttonFinished.Click += new System.EventHandler(this.ButtonFinished_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(154, 84);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(44, 17);
            this.labelWidth.TabIndex = 7;
            this.labelWidth.Text = "Width";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(297, 84);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(52, 17);
            this.labelLength.TabIndex = 8;
            this.labelLength.Text = "Length";
            // 
            // buttonAddMore
            // 
            this.buttonAddMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddMore.Location = new System.Drawing.Point(23, 184);
            this.buttonAddMore.Name = "buttonAddMore";
            this.buttonAddMore.Size = new System.Drawing.Size(147, 31);
            this.buttonAddMore.TabIndex = 4;
            this.buttonAddMore.Text = "Add Another";
            this.buttonAddMore.UseVisualStyleBackColor = true;
            this.buttonAddMore.Click += new System.EventHandler(this.ButtonAddMore_Click);
            // 
            // buttonNextLine
            // 
            this.buttonNextLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextLine.Location = new System.Drawing.Point(196, 140);
            this.buttonNextLine.Name = "buttonNextLine";
            this.buttonNextLine.Size = new System.Drawing.Size(93, 31);
            this.buttonNextLine.TabIndex = 6;
            this.buttonNextLine.Text = "Next Line";
            this.buttonNextLine.UseVisualStyleBackColor = true;
            this.buttonNextLine.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelHeat
            // 
            this.labelHeat.AutoSize = true;
            this.labelHeat.Location = new System.Drawing.Point(23, 9);
            this.labelHeat.Name = "labelHeat";
            this.labelHeat.Size = new System.Drawing.Size(38, 17);
            this.labelHeat.TabIndex = 11;
            this.labelHeat.Text = "Heat";
            // 
            // labelSourceW
            // 
            this.labelSourceW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSourceW.AutoSize = true;
            this.labelSourceW.Location = new System.Drawing.Point(266, 9);
            this.labelSourceW.Name = "labelSourceW";
            this.labelSourceW.Size = new System.Drawing.Size(44, 17);
            this.labelSourceW.TabIndex = 12;
            this.labelSourceW.Text = "Width";
            this.labelSourceW.Click += new System.EventHandler(this.LabelSourceW_Click);
            // 
            // labelSourceL
            // 
            this.labelSourceL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSourceL.AutoSize = true;
            this.labelSourceL.Location = new System.Drawing.Point(349, 9);
            this.labelSourceL.Name = "labelSourceL";
            this.labelSourceL.Size = new System.Drawing.Size(52, 17);
            this.labelSourceL.TabIndex = 13;
            this.labelSourceL.Text = "Length";
            // 
            // labelSourceA
            // 
            this.labelSourceA.AutoSize = true;
            this.labelSourceA.Location = new System.Drawing.Point(100, 9);
            this.labelSourceA.Name = "labelSourceA";
            this.labelSourceA.Size = new System.Drawing.Size(38, 17);
            this.labelSourceA.TabIndex = 14;
            this.labelSourceA.Text = "Alloy";
            // 
            // labelSourceP
            // 
            this.labelSourceP.AutoSize = true;
            this.labelSourceP.Location = new System.Drawing.Point(177, 9);
            this.labelSourceP.Name = "labelSourceP";
            this.labelSourceP.Size = new System.Drawing.Size(50, 17);
            this.labelSourceP.TabIndex = 15;
            this.labelSourceP.Text = "Pieces";
            // 
            // groupBoxTotalOrPiece
            // 
            this.groupBoxTotalOrPiece.Controls.Add(this.radioButtonPerSheet);
            this.groupBoxTotalOrPiece.Controls.Add(this.radioButtonTotal);
            this.groupBoxTotalOrPiece.Location = new System.Drawing.Point(23, 29);
            this.groupBoxTotalOrPiece.Name = "groupBoxTotalOrPiece";
            this.groupBoxTotalOrPiece.Size = new System.Drawing.Size(312, 43);
            this.groupBoxTotalOrPiece.TabIndex = 16;
            this.groupBoxTotalOrPiece.TabStop = false;
            this.groupBoxTotalOrPiece.Text = "Total or Per Piece";
            // 
            // radioButtonPerSheet
            // 
            this.radioButtonPerSheet.AutoSize = true;
            this.radioButtonPerSheet.Location = new System.Drawing.Point(173, 20);
            this.radioButtonPerSheet.Name = "radioButtonPerSheet";
            this.radioButtonPerSheet.Size = new System.Drawing.Size(137, 21);
            this.radioButtonPerSheet.TabIndex = 1;
            this.radioButtonPerSheet.Text = "Pieces per Sheet";
            this.radioButtonPerSheet.UseVisualStyleBackColor = true;
            // 
            // radioButtonTotal
            // 
            this.radioButtonTotal.AutoSize = true;
            this.radioButtonTotal.Checked = true;
            this.radioButtonTotal.Location = new System.Drawing.Point(16, 20);
            this.radioButtonTotal.Name = "radioButtonTotal";
            this.radioButtonTotal.Size = new System.Drawing.Size(115, 21);
            this.radioButtonTotal.TabIndex = 0;
            this.radioButtonTotal.TabStop = true;
            this.radioButtonTotal.Text = "Total# Pieces";
            this.radioButtonTotal.UseVisualStyleBackColor = true;
            // 
            // checkBoxGauer
            // 
            this.checkBoxGauer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxGauer.AutoSize = true;
            this.checkBoxGauer.Location = new System.Drawing.Point(23, 140);
            this.checkBoxGauer.Name = "checkBoxGauer";
            this.checkBoxGauer.Size = new System.Drawing.Size(70, 21);
            this.checkBoxGauer.TabIndex = 17;
            this.checkBoxGauer.Text = "Gauer";
            this.checkBoxGauer.UseVisualStyleBackColor = true;
            // 
            // buttonPrevLine
            // 
            this.buttonPrevLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevLine.Location = new System.Drawing.Point(310, 140);
            this.buttonPrevLine.Name = "buttonPrevLine";
            this.buttonPrevLine.Size = new System.Drawing.Size(93, 31);
            this.buttonPrevLine.TabIndex = 18;
            this.buttonPrevLine.Text = "Prev Line";
            this.buttonPrevLine.UseVisualStyleBackColor = true;
            this.buttonPrevLine.Click += new System.EventHandler(this.ButtonPrevLine_Click);
            // 
            // ShearInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 227);
            this.Controls.Add(this.buttonPrevLine);
            this.Controls.Add(this.checkBoxGauer);
            this.Controls.Add(this.groupBoxTotalOrPiece);
            this.Controls.Add(this.labelSourceP);
            this.Controls.Add(this.labelSourceA);
            this.Controls.Add(this.labelSourceL);
            this.Controls.Add(this.labelSourceW);
            this.Controls.Add(this.labelHeat);
            this.Controls.Add(this.buttonNextLine);
            this.Controls.Add(this.buttonAddMore);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.buttonFinished);
            this.Controls.Add(this.labelPieces);
            this.Controls.Add(this.textBoxPieces);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.textBoxWidth);
            this.Name = "ShearInputBox";
            this.Text = "ShearInputBox";
            this.Load += new System.EventHandler(this.ShearInputBox_Load);
            this.groupBoxTotalOrPiece.ResumeLayout(false);
            this.groupBoxTotalOrPiece.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.TextBox textBoxPieces;
        private System.Windows.Forms.Label labelPieces;
        private System.Windows.Forms.Button buttonFinished;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Button buttonAddMore;
        private System.Windows.Forms.Button buttonNextLine;
        private System.Windows.Forms.Label labelHeat;
        private System.Windows.Forms.Label labelSourceW;
        private System.Windows.Forms.Label labelSourceL;
        private System.Windows.Forms.Label labelSourceA;
        private System.Windows.Forms.Label labelSourceP;
        private System.Windows.Forms.GroupBox groupBoxTotalOrPiece;
        private System.Windows.Forms.RadioButton radioButtonPerSheet;
        private System.Windows.Forms.RadioButton radioButtonTotal;
        private System.Windows.Forms.CheckBox checkBoxGauer;
        private System.Windows.Forms.Button buttonPrevLine;
    }
}