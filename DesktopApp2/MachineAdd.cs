using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ICMS.DBUtils;

namespace ICMS
{
    public partial class MachineAdd : Form
    {

        
        public MachineAdd()
        {
            InitializeComponent();
            LoadProcesses();
            LoadFinishes();
        }

        private void LoadFinishes()
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

             using (DbDataReader reader = db.GetFinish("0", -1, 1, true))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        cbDefaultFinish.Items.Add(reader.GetString(reader.GetOrdinal("FinishDesc")).Trim());
                        cbFinishID.Items.Add(reader.GetInt32(reader.GetOrdinal("FinishID")));
                    }
                }
                reader.Close();
            }
            db.CloseSQLConn();
        }

        private void LoadProcesses()
        {
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            using (DbDataReader reader = db.GetAllProcesses())
            {
                if (reader.HasRows)
                {
                    cbProcessType.Items.Clear();
                    cbProcID.Items.Clear();

                    while (reader.Read())
                    {
                        
                        cbProcessType.Items.Add(reader.GetString(reader.GetOrdinal("processDesc")));
                        cbProcID.Items.Add(reader.GetInt32(reader.GetOrdinal("processID")));
                    }
                }


                reader.Close();
            }
            db.CloseSQLConn();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;

            cbProcID.SelectedIndex = num; 
        }

        private void cbDefaultFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string item = cb.Text;
            int num = cb.SelectedIndex;

            cbFinishID.SelectedIndex = num;
        }

        private void tbMachineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void rtbMachineDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbThicknessMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbThicknessMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbWidthMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbWidthMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbLengthMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbLengthMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbWeightMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbWeightMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbHoldDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

           
        }

        private void btAddMachine_Click(object sender, EventArgs e)
        {

            DBUtils db = new DBUtils();

            
            MachineInfo mc = new MachineInfo();

            mc.processID = Convert.ToInt32(cbProcID.Text);
            mc.machineName = tbMachineName.Text;
            mc.minThickness = Convert.ToDecimal(tbThicknessMin.Text);
            mc.maxThickness = Convert.ToDecimal(tbThicknessMax.Text);
            mc.minWidth = Convert.ToDecimal(tbWidthMin.Text);
            mc.maxWidth = Convert.ToDecimal(tbWidthMax.Text);
            mc.minLength = Convert.ToInt32(tbLengthMin.Text);
            mc.maxLength = Convert.ToInt32(tbLengthMin.Text);
            mc.minWeight = Convert.ToInt32(tbWeightMin.Text);
            mc.maxWeight = Convert.ToInt32(tbWeightMin.Text);
            mc.leadTime = ((int)numLeadTime.Value);
            mc.finishID = Convert.ToInt32(cbFinishID.Text);
            mc.HoldDown = Convert.ToInt32(tbHoldDown.Text);
            mc.machineDesc = rtbMachineDesc.Text;

            
            try
            {
                db.OpenSQLConn();
                db.InsertMachine(mc);

                MessageBox.Show(tbMachineName.Text + " added successfully!");
                this.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Error adding Machine :" + ex.Message);
            }
            

        }
    }
}
