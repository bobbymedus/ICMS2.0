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
    public partial class InputBox : Form
    {
        public static bool wholeNumber = true;
        public static bool decNum = true;
        public static bool textAllowed = false;
        public InputBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            this.ActiveControl = textBoxInput;
        }

        

        public static DialogResult Show(String title, String message, String inputTitle, out String inputValue,string DefVal = "",bool wholeNum = false, bool textOK = false, bool decimNum = false)
        {
            InputBox inputBox = null;
            DialogResult results = DialogResult.None;

            wholeNumber = wholeNum;
            decNum = decimNum;
            textAllowed = textOK;

            using (inputBox = new InputBox() { Text = title })
            {
                inputBox.Text = title;
                inputBox.labelInput.Text = message;
                inputBox.textBoxInput.Text = DefVal;
                

                results = inputBox.ShowDialog();

                inputValue = inputBox.textBoxInput.Text;
            }

            return results;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!textAllowed)
            {
                if (wholeNumber)
                {
                    if (decNum)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    
                   
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    {
                        e.Handled = true;
                    }
                }

            
                // only allow one decimal point
                if ((e.KeyChar == '.') &&  ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOK.PerformClick();
            }
        }

    }
}
