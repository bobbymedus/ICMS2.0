using DesktopApp2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    public partial class ShearInputBox : Form
    {

        
        
        
        private decimal maxLength;
        private decimal maxWidth;

        public FormICMSMain SOForm;

        public ShearInputBox()
        {
            InitializeComponent();
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonAddMore_Click(object sender, EventArgs e)
        {
            AddCut();
            textBoxPieces.Text = "";
            textBoxWidth.Text = "";
            textBoxLength.Text = "";
            textBoxPieces.Focus();
        }

        private void AddCut()
        {
            if (textBoxPieces.Text == null || textBoxPieces.Text == "")
            {
                MessageBox.Show("You must have a piece count.");
                textBoxPieces.Focus();
                return;
            }
            if (Convert.ToInt32(textBoxPieces.Text) <= 0)
            {
                MessageBox.Show("There has to be at least 1 piece.");
                textBoxPieces.Focus();
                return;
            }
            if (textBoxWidth.Text != null && textBoxWidth.Text != "")
            {
                if (Convert.ToDecimal(textBoxWidth.Text) > maxWidth)
                {
                    MessageBox.Show("The Width cannot be greater than " + maxWidth.ToString() + ".");
                    textBoxWidth.Focus();
                }
                else
                {
                    if (textBoxLength.Text != null && textBoxLength.Text != "")
                    {

                        if (Convert.ToDecimal(textBoxLength.Text) > maxLength)
                        {
                            MessageBox.Show("The Length cannot be greater than " + maxLength.ToString() + ".");
                            textBoxLength.Focus();
                        }
                        else
                        {
                            TreeView tv = SOForm.GetTreeView();
                            int so = SOForm.GetSelectedRow();
                            if (so >= 0)
                            {
                                string width = textBoxWidth.Text;
                                string length = textBoxLength.Text;
                                string pieces = textBoxPieces.Text;
                                if (!radioButtonTotal.Checked)
                                {
                                    pieces = Convert.ToString(Convert.ToInt32(pieces) * Convert.ToInt32(labelSourceP.Text));
                                }

                                if (checkBoxGauer.Checked)
                                {
                                    tv.Nodes[so].Nodes.Add(pieces + " - " + width + "X" + length + " *Gauer");

                                }
                                else
                                {
                                    tv.Nodes[so].Nodes.Add(pieces + " - " + width + "X" + length);

                                }

                                tv.ExpandAll();
                            }
                            
                            
                        }

                    }
                }


            }
        }
        private void ButtonFinished_Click(object sender, EventArgs e)
        {

            if (textBoxPieces.Text.Length > 0 && 
                textBoxWidth.Text.Length > 0 && 
                textBoxLength.Text.Length > 0)
            {
                AddCut();
            }
            
            this.Close();
            
            
        }

        private void TextBoxPieces_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPieces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void TextBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBoxLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void ShearInputBox_Load(object sender, EventArgs e)
        {
            maxLength = SOForm.GetLength();
            maxWidth = SOForm.GetWidth();
            labelSourceA.Text = SOForm.GetAlloy();
            labelHeat.Text = SOForm.GetHeat();
            labelSourceL.Text = maxLength.ToString();
            labelSourceP.Text = SOForm.GetPieces().ToString();
            labelSourceW.Text = SOForm.GetWidth().ToString();
            textBoxPieces.Focus();

        }

        private void LabelSourceW_Click(object sender, EventArgs e)
        {

        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            SOForm.NextLine();
        }


        private void ButtonPrevLine_Click(object sender, EventArgs e)
        {
            SOForm.PrevLine();
        }
    }
}
