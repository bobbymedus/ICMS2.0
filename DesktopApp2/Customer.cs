using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICMS
{
    public partial class Customer : Form
    {

        bool enteredLongName = false;
        
        public Customer()
        {
            InitializeComponent();
            PopulateFields();
            tbShortCustName.Focus();

        }

        private bool doAnything = false;

        private void PopulateFields()
        {
            tbCountry.Text = "US";
            tbLeadTimeOveride.Text = "-1";
            tbWeightFormula.Text = "1"; 
            tbPriceTier.Text = "0";



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            
            if (CheckField(tbShortCustName,"Short Customer Name"))
            {
                return;
            }
            if (CheckField(tbLongCustName, "Long Customer Name"))
            {
                return;
            }
            if (CheckField(tbAddress1, "Address 1"))
            {
                return;
            }
            
            if (CheckField(tbCity, "City"))
            {
                return;
            }
            if (CheckField(tbState, "State"))
            {
                return;
            }
            if (CheckField(tbZip, "Zip Code"))
            {
                return;
            }
            if (CheckField(tbCountry, "Country"))
            {
                return;
            }
            if (CheckField(tbPhone, "Phone"))
            {
                return;
            }
            
            if (CheckField(tbContactName, "Contact Name"))
            {
                return;
            }
            if (CheckField(tbEmail, "Email"))
            {
                return;
            }
            if (CheckField(tbMaxSkidWeight, "Max Skid Weight"))
            {
                return;
            }
            if (CheckField(tbPriceTier, "Price Tier"))
            {
                return;
            }
            if (CheckField(tbWeightFormula, "Weight Formula"))
            {
                return;
            }
            if (CheckField(tbQBName, "Quick Book Name"))
            {
                return;
            }
            if (CheckField(tbPhone, "Phone"))
            {
                return;
            }
            if (CheckField(tbLeadTimeOveride, "Lead Time Override"))
            {
                return;
            }
            
            DBUtils db = new DBUtils();

            DBUtils.CustomerInfo ci = new DBUtils.CustomerInfo();

            db.OpenSQLConn();

            SqlTransaction tran = db.StartTrans();

            try
            {
                
                ci.ShortName = tbShortCustName.Text.Trim();
                ci.LongName = tbLongCustName.Text.Trim();
                ci.Address1 = tbAddress1.Text.Trim();
                ci.Address2 = tbAddress2.Text.Trim();
                ci.City = tbCity.Text.Trim();
                ci.StateCode = tbState.Text.Trim();
                ci.Zip = tbZip.Text.Trim();
                ci.Country = tbCountry.Text.Trim();
                ci.Phone = tbPhone.Text.Trim();
                ci.Fax = tbFax.Text.Trim();
                ci.ContactName = tbContactName.Text.Trim();
                ci.Email = tbEmail.Text.Trim();
                ci.MaxSkidWeight = Convert.ToInt32(tbMaxSkidWeight.Text.Trim());
                ci.PriceTier = Convert.ToInt32(tbPriceTier.Text.Trim());
                ci.WeightFormula = Convert.ToInt32(tbWeightFormula.Text.Trim());
                ci.isActive = 1;
                ci.QuickBookName = tbQBName.Text.Trim();
                ci.leadTime = Convert.ToInt32(tbLeadTimeOveride.Text.Trim());
                ci.Packaging = rtbPackaging.Text.Trim();

                

                ci.custID = db.InsertCustomer(ci, tran);

                //add 0 branch

                db.InsertBranchInfo(ci.custID, "None", "None",true, tran);
                

                tran.Commit();
                doAnything = true;
                MessageBox.Show(ci.ShortName + " was added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
                
            }

            






        }
        public bool DoAnything()
        {
            return doAnything;
        }

        private bool CheckField(TextBox tx, string messageinfo)
        {
            if (tx.Text == null || tx.Text.Equals(""))
            {
                MessageBox.Show(messageinfo + " is a required field!");
                tx.Focus();
                return true;
            }

            return false;
        }

        private void tbMaxSkidWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
           
        }

        private void tbLeadTimeOveride_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow minus sign at the beginning
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
        }

        private void tbWeightFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

        }

        private void tbPriceTier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbShortCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (!enteredLongName)
            {
                if (e.KeyChar != '\b')
                {
                    tbLongCustName.Text += e.KeyChar;
                }
                else
                {
                    if (tbLongCustName.Text.Length > 0)
                    {
                        tbLongCustName.Text = tbLongCustName.Text.Substring(0, tbLongCustName.Text.Length - 1);
                    }
                    
                }
                
            }
            
        }

        private void tbLongCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            enteredLongName = true;
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbState_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbContactName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbQBName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void rtbPackaging_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
