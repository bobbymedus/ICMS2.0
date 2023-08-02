using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static DesktopApp2.FormICMSMain;

namespace ICMS
{

    public partial class CoilUpdate : Form
    {
        public int CoilID { get; set; }
        public string CoilTagSuffix { get; set; }

        public ListViewItem lvCoil { get; set; }

        public bool ChangesMade { get; set; }

        public CoilUpdate()
        {
            InitializeComponent();
            
        }

        private void btnChangeCoilCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CoilUpdate_Load(object sender, EventArgs e)
        {
            this.Text = "Coil Update " + CoilID.ToString();
            
            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            DbDataReader reader =  db.GetCoilInfo(CoilID, lvCoil.SubItems[0].Tag.ToString().Trim());
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tbCoilChangeCarbon.Text = reader.GetDecimal(reader.GetOrdinal("carbon")).ToString("G29").Trim();
                    tbCoilChangeWeight.Text = reader.GetDecimal(reader.GetOrdinal("weight")).ToString("G29").Trim();
                    tbCoilChangeWidth.Text = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                    tbCoilChangeLength.Text = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();
                    tbCoilChangeThickness.Text = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                    tbCoilChangeLocation.Text = reader.GetString(reader.GetOrdinal("location")).Trim();
                    tbCoilChangeMill.Text = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                    tbCoilChangeHeat.Text = reader.GetString(reader.GetOrdinal("heat")).Trim();
                    tbCoilChangeVendor.Text = reader.GetString(reader.GetOrdinal("vendor")).Trim();
                    tbCoilChangeCOO.Text = reader.GetString(reader.GetOrdinal("countryOfOrigin")).Trim();
                    tbCoilChangeCoilCount.Text = reader.GetInt32(reader.GetOrdinal("coilCount")).ToString().Trim();
                }
            }
            reader.Close();

            //ListViewCoilData.Items[cntr].SubItems[0].Tag = coilTagSuffix;
            //ListViewCoilData.Items[cntr].SubItems[2].Tag = alloyID;
            //ListViewCoilData.Items[cntr].SubItems[3].Tag = finishID; //putting finishid in thickness tag. easist place to hide it....
            //ListViewCoilData.Items[cntr].SubItems[4].Tag = steelTypeID;/

            reader = db.GetSteelTypes();
            int sID = 0;
            string sdesc = "";

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    int stID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));
                    string stDesc = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();

                    cbCoilChangeSteelType.Items.Add(stDesc);
                    cbCoilChangeSteelTypeID.Items.Add(stID);
                    if (stID == Convert.ToInt32(lvCoil.SubItems[4].Tag))
                    {
                        sID = stID;
                        sdesc = stDesc;
                        cbCoilChangeAlloy.Tag = stID;

                    }

                }
            }
            reader.Close();

            cbCoilChangeSteelType.Text = sdesc;
            cbCoilChangeSteelTypeID.Text = sID.ToString();

            LoadCbCoilChangAlloy(db);

            LoadCbCoilChangFinish(db);


            

           



            db.CloseSQLConn ();

            

        }

        private void LoadCbCoilChangAlloy( DBUtils db)
        {

            cbCoilChangeAlloy.Items.Clear(); 
            cbCoilChangeAlloyID.Items.Clear();
            DbDataReader  reader = db.GetAlloyData(-1, Convert.ToInt32(cbCoilChangeSteelTypeID.Text));

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int alloyid = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                    string alloydesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();

                    cbCoilChangeAlloy.Items.Add(alloydesc);
                    cbCoilChangeAlloyID.Items.Add(alloyid);
                    if (alloyid == Convert.ToInt32(lvCoil.SubItems[2].Tag))
                    {
                        cbCoilChangeAlloy.Text = alloydesc;
                        cbCoilChangeAlloyID.Text = alloyid.ToString();

                    }
                }
            }
            reader.Close();
        }

        private void LoadCbCoilChangFinish(DBUtils db)
        {

            cbCoilChangeFinish.Items.Clear();
            cbCoilChangeFinishID.Items.Clear();
            DbDataReader reader = db.GetFinish("-1",-1, Convert.ToInt32(cbCoilChangeSteelTypeID.Text));

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int finishid = reader.GetInt32(reader.GetOrdinal("FinishID"));
                    string finishdesc = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();

                    cbCoilChangeFinish.Items.Add(finishdesc);
                    cbCoilChangeFinishID.Items.Add(finishid);
                    if (finishid == Convert.ToInt32(lvCoil.SubItems[3].Tag))
                    {
                        cbCoilChangeFinish.Text = finishdesc;
                        cbCoilChangeFinishID.Text = finishid.ToString();

                    }
                }
            }
            reader.Close();
        }

        private void tbCoilChangeCarbon_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbCoilChangeSteelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;
            
            if (item != null)
            {
                cbCoilChangeSteelTypeID.SelectedIndex = num;
                cbCoilChangeSteelTypeID.Text = cbCoilChangeSteelTypeID.Items[num].ToString();           
            }

            cbCoilChangeAlloy.Items.Clear();
            cbCoilChangeAlloyID.Items.Clear();
            cbCoilChangeFinish.Items.Clear();
            cbCoilChangeFinishID.Items.Clear();

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            if (cbCoilChangeAlloyID.Text.Length > 0)
            {
                if (Convert.ToInt32(cbCoilChangeAlloy.Tag) != Convert.ToInt32(cbCoilChangeAlloyID.Text))
                {
                    //trying to change steel types.
                    cbCoilChangeAlloy.Text = "";
                    cbCoilChangeAlloyID.Text = "";
                    cbCoilChangeFinish.Text = "";
                    cbCoilChangeFinishID.Text = "";
                }
            }
            
           
            LoadCbCoilChangAlloy(db);

            LoadCbCoilChangFinish(db);

            

        }

   
        private void cbCoilChangeAlloy_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            
            int num = cb.SelectedIndex;
            cbCoilChangeAlloyID.SelectedIndex = num;

        }

        private void cbCoilChangeFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            int num = cb.SelectedIndex;
            cbCoilChangeFinishID.SelectedIndex = num;
        }

        private void tbCoilChangeWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbCoilChangeCoilCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      

        private void tbCoilChangeWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbCoilChangeLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbCoilChangeThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbCoilChangeCarbon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnChangeCoilChange_Click(object sender, EventArgs e)
        {
            DBUtils db = new DBUtils();
            

            

                db.OpenSQLConn();

            CoilInfo ci = new CoilInfo();

            ci.coilTagID = CoilID;
            ci.coilTagSuffix = CoilTagSuffix;
            ci.weight = Convert.ToInt32(tbCoilChangeWeight.Text);
            ci.width = Convert.ToDecimal(tbCoilChangeWidth.Text);
            ci.length = Convert.ToDecimal(tbCoilChangeLength.Text);
            ci.thickness = Convert.ToDecimal(tbCoilChangeThickness.Text);
            ci.location = tbCoilChangeLocation.Text;
            ci.millCoilNum = tbCoilChangeMill.Text;
            ci.heat = tbCoilChangeHeat.Text;
            ci.vendor = tbCoilChangeVendor.Text;
            ci.countryOfOrigin = tbCoilChangeCOO.Text;
            ci.coilCount = Convert.ToInt32(tbCoilChangeCoilCount.Text);
            ci.carbon = Convert.ToDecimal(tbCoilChangeCarbon.Text); 
            ci.alloyID = Convert.ToInt32(cbCoilChangeAlloyID.Text); 
            ci.finishID = Convert.ToInt32(cbCoilChangeFinishID.Text);

            int g = db.UpdateCoilInfo(ci);


            if (g <= 0)
            {
                MessageBox.Show("Something went wrong");
            }
            else
            {
                lvCoil.SubItems[5].Text = tbCoilChangeWeight.Text;
                lvCoil.SubItems[4].Text = tbCoilChangeWidth.Text;
                lvCoil.SubItems[6].Text = tbCoilChangeLength.Text;
                lvCoil.SubItems[3].Text = tbCoilChangeThickness.Text;
                lvCoil.SubItems[2].Text = tbCoilChangeLocation.Text;
                lvCoil.SubItems[7].Text = tbCoilChangeMill.Text;
                lvCoil.SubItems[8].Text = tbCoilChangeHeat.Text;
                lvCoil.SubItems[10].Text = tbCoilChangeVendor.Text;
                lvCoil.SubItems[16].Text   = tbCoilChangeCOO.Text;
                lvCoil.SubItems[15].Text = tbCoilChangeCoilCount.Text;
                lvCoil.SubItems[9].Text = tbCoilChangeCarbon.Text;
                lvCoil.SubItems[2].Text = cbCoilChangeAlloy.Text + " " + cbCoilChangeFinish.Text;
                lvCoil.SubItems[2].Tag = cbCoilChangeAlloyID.Text;
                lvCoil.SubItems[3].Tag = cbCoilChangeFinishID.Text;
                lvCoil.SubItems[4].Tag = cbCoilChangeSteelTypeID.Text;

            }
            db.CloseSQLConn();


            ChangesMade = true;


            this.Close();


        }

        
        private void tbCoilChangeLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCoilChangeMill_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCoilChangeHeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCoilChangeVendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbCoilChangeCOO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
