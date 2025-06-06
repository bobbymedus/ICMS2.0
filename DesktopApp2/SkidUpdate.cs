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
using System.Windows.Forms.VisualStyles;
using static DesktopApp2.FormICMSMain;

namespace ICMS
{
    public partial class SkidUpdate : Form
    {

        public int SkidID { get; set; }
        public string CoilTagSuffix { get; set; }
        public string SkidLetter { get; set; }
        public ListViewItem lvSkidItem { get; set; }

        public bool changesMade { get; set; }

        private bool loading = true;
        public SkidUpdate()
        {
            InitializeComponent();
        }

        private void SkidUpdate_Load(object sender, EventArgs e)
        {
            //this.Text = "Skid Update " + SkidID.ToString() + CoilTagSuffix + "-" + skidLetter;

            DBUtils db = new DBUtils();
            db.OpenSQLConn();

            int custid = 0;
            int branchID = 0;

            using (DbDataReader reader = db.GetSkidData(SkidID, CoilTagSuffix, SkidLetter))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tbSkidUpdateSkidWeight.Text = reader.GetValue(reader.GetOrdinal("skidWeight")).ToString().Trim();
                        tbSkidUpdateLocation.Text = reader.GetString(reader.GetOrdinal("location")).Trim();
                        tbSkidUpdateSheetWeight.Text = reader.GetDecimal(reader.GetOrdinal("sheetWeight")).ToString("G29").Trim();
                        tbSkidUpdateLength.Text = reader.GetDecimal(reader.GetOrdinal("length")).ToString("G29").Trim();
                        tbSkidUpdateWidth.Text = reader.GetDecimal(reader.GetOrdinal("width")).ToString("G29").Trim();
                        tbSkidUpdateDiag1.Text = reader.GetDecimal(reader.GetOrdinal("diagnol1")).ToString("G29").Trim();
                        tbSkidUpdateDiag2.Text = reader.GetDecimal(reader.GetOrdinal("diagnol2")).ToString("G29").Trim();
                        tbSkidUpdateMic1.Text = reader.GetDecimal(reader.GetOrdinal("mic1")).ToString("G29").Trim();
                        tbSkidUpdateMic2.Text = reader.GetDecimal(reader.GetOrdinal("mic2")).ToString("G29").Trim();
                        tbSkidUpdateMic3.Text = reader.GetDecimal(reader.GetOrdinal("mic3")).ToString("G29").Trim();
                        tbSkidUpdateComments.Text = reader.GetString(reader.GetOrdinal("comments")).Trim();
                        tbSkidUpdateSkidPrice.Text = reader.GetDecimal(reader.GetOrdinal("skidPrice")).ToString("G29").Trim();
                        tbSkidUpdatePieceCount.Text = reader.GetInt32(reader.GetOrdinal("pieceCount")).ToString().Trim();
                        tbSkidUpdateThk.Text = reader.GetDecimal(reader.GetOrdinal("thickness")).ToString("G29").Trim();
                        tbSkidUpdateThk.Tag = tbSkidUpdateThk.Text;

                        tbSkidUpdateHeat.Text = reader.GetString(reader.GetOrdinal("heat")).Trim();
                        tbSkidUpdateHeat.Tag = tbSkidUpdateHeat.Text;

                        tbSkidUpdateMillNum.Text = reader.GetString(reader.GetOrdinal("millCoilNum")).Trim();
                        tbSkidUpdateMillNum.Tag = tbSkidUpdateMillNum.Text;


                        int notprime = reader.GetInt32(reader.GetOrdinal("notPrime"));
                        custid = reader.GetInt32(reader.GetOrdinal("customerID"));
                        branchID = reader.GetInt32(reader.GetOrdinal("branchID"));
                        if (notprime > 0)
                        {
                            cbSkidUpdateNotPrime.Checked = true;
                        }
                        else
                        {
                            cbSkidUpdateNotPrime.Checked = false;
                        }
                    }
                }

                reader.Close();
            }

            using (DbDataReader reader = db.GetBranchInfo(custid))
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string bDesc = reader.GetString(reader.GetOrdinal("branchDescShort")).Trim() + "-" +
                                                    reader.GetString(reader.GetOrdinal("branchDescLong")).Trim();
                        cbSkidUpdateBranch.Items.Add(bDesc);
                        int currBID = reader.GetInt32(reader.GetOrdinal("branchID"));
                        cbSkidUpdateBranchID.Items.Add(currBID);
                        if (branchID == currBID)
                        {
                            cbSkidUpdateBranch.Text = bDesc;
                            cbSkidUpdateBranchID.Text = currBID.ToString();

                        }
                    }
                    cbSkidUpdateBranch.Visible = true;
                }
                else
                {
                    cbSkidUpdateBranch.Visible = false;
                }
                reader.Close();

            }

            int skTypeID = Convert.ToInt32(lvSkidItem.SubItems[6].Tag);
            using (DbDataReader reader = db.GetSkidTypeData())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string skTpDesc = reader.GetString(reader.GetOrdinal("skidDescription")).Trim();
                        cbSkidUpdateSkidType.Items.Add(skTpDesc);
                        int skID = reader.GetInt32(reader.GetOrdinal("skidTypeID"));
                        cbSkidUpdateSkidTypeID.Items.Add(skID);
                        if (skTypeID == skID)
                        {
                            cbSkidUpdateSkidType.Text = skTpDesc;
                            cbSkidUpdateSkidTypeID.Text = skID.ToString().Trim();

                        }

                    }
                }
                reader.Close();
            }

            int SteelID = Convert.ToInt32(lvSkidItem.SubItems[10].Tag);
            int stID = 0;
            string stDesc = "";
            using (DbDataReader reader = db.GetSteelTypes())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string strDesc = reader.GetString(reader.GetOrdinal("SteelDesc")).Trim();
                        cbSkidChangeSteelType.Items.Add(strDesc);
                        int skID = reader.GetInt32(reader.GetOrdinal("SteelTypeID"));
                        cbSkidChangeSteelTypeID.Items.Add(skID);
                        if (SteelID == skID)
                        {
                            stDesc = strDesc;
                            stID = skID;
                            cbSkidUpdateAlloy.Tag = stID;

                        }
                    }
                }
                reader.Close();
            }

            cbSkidChangeSteelType.Text = stDesc;
            cbSkidChangeSteelTypeID.Text = stID.ToString();


            

            db.CloseSQLConn();
            loading = false;

        }

        private void btnSkidChangeCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cbSkidUpdateBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;

            if (item != null)
            {
                cbSkidUpdateBranch.SelectedIndex = num;
                cbSkidUpdateBranchID.Text = cbSkidUpdateBranchID.Items[num].ToString();
            }

            
        }

        private void cbSkidChangeSteelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;

            if (item != null)
            {
                cbSkidChangeSteelType.SelectedIndex = num;
                cbSkidChangeSteelTypeID.Text = cbSkidChangeSteelTypeID.Items[num].ToString();
            }

            cbSkidUpdateAlloy.Items.Clear();
            cbSkidUpdateAlloyID.Items.Clear();
            cbSkidUpdateFinish.Items.Clear();
            cbSkidUpdateFinishID.Items.Clear();

           

            if (cbSkidUpdateAlloyID.Text.Length > 0)
            {
                if (Convert.ToInt32(cbSkidUpdateAlloy.Tag) != Convert.ToInt32(cbSkidUpdateAlloyID.Text))
                {
                    //trying to change steel types.
                    cbSkidUpdateAlloy.Text = "";
                    cbSkidUpdateAlloyID.Text = "";
                    cbSkidUpdateFinish.Text = "";
                    cbSkidUpdateFinishID.Text = "";
                }
            }
            DBUtils db = new DBUtils();

            db.OpenSQLConn();

            LoadCbSkidChangAlloy(db);

            LoadCbSkidChangeFinish(db);

            db.CloseSQLConn();

        }
        private void LoadCbSkidChangAlloy(DBUtils db)
        {

            cbSkidUpdateAlloy.Items.Clear();
            cbSkidUpdateAlloyID.Items.Clear();



            using (DbDataReader reader = db.GetAlloyData(-1, Convert.ToInt32(cbSkidChangeSteelTypeID.Text)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int alloyid = reader.GetInt32(reader.GetOrdinal("AlloyID"));
                        string alloydesc = reader.GetString(reader.GetOrdinal("AlloyDesc")).Trim();

                        cbSkidUpdateAlloy.Items.Add(alloydesc);
                        cbSkidUpdateAlloyID.Items.Add(alloyid);
                        if (alloyid == Convert.ToInt32(lvSkidItem.SubItems[3].Tag))
                        {
                            cbSkidUpdateAlloy.Text = alloydesc;
                            cbSkidUpdateAlloyID.Text = alloyid.ToString();

                        }
                    }
                }
                reader.Close();
            }

           
                
        }

        private void LoadCbSkidChangeFinish(DBUtils db)
        {

            cbSkidUpdateFinish.Items.Clear();
            cbSkidUpdateFinishID.Items.Clear();
            DbDataReader reader = db.GetFinish("-1", -1, Convert.ToInt32(cbSkidChangeSteelTypeID.Text));

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int finishid = reader.GetInt32(reader.GetOrdinal("FinishID"));
                    string finishdesc = reader.GetString(reader.GetOrdinal("FinishDesc")).Trim();

                    cbSkidUpdateFinish.Items.Add(finishdesc);
                    cbSkidUpdateFinishID.Items.Add(finishid);
                    if (finishid == Convert.ToInt32(lvSkidItem.SubItems[4].Tag))
                    {
                        cbSkidUpdateFinish.Text = finishdesc;
                        cbSkidUpdateFinishID.Text = finishid.ToString();

                    }
                }
            }
            reader.Close();
        }

        private void cbSkidUpdateAlloy_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;

            if (item != null)
            {
                cbSkidUpdateAlloy.SelectedIndex = num;
                cbSkidUpdateAlloyID.Text = cbSkidUpdateAlloyID.Items[num].ToString();
            }
        }

        private void cbSkidUpdateFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;

            if (item != null)
            {
                cbSkidUpdateFinish.SelectedIndex = num;
                cbSkidUpdateFinishID.Text = cbSkidUpdateFinishID.Items[num].ToString();
            }
        }

        private void cbSkidUpdateSkidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;


            string item = cb.Text.Trim();
            int num = cb.SelectedIndex;

            if (item != null)
            {
                cbSkidUpdateSkidType.SelectedIndex = num;
                cbSkidUpdateSkidTypeID.Text = cbSkidUpdateSkidTypeID.Items[num].ToString();
            }
        }

        private void btnSkidChangeChange_Click(object sender, EventArgs e)
        {
            DBUtils db = new DBUtils();
            SkidData sdInfo = new SkidData();

            db.OpenSQLConn();


            sdInfo.skidID = SkidID;
            sdInfo.coilTagSuffix = CoilTagSuffix;
            sdInfo.letter = SkidLetter;

            sdInfo.location = tbSkidUpdateLocation.Text;
            sdInfo.sheetWeight = Convert.ToDecimal(tbSkidUpdateSheetWeight.Text); 
            sdInfo.length = Convert.ToDecimal(tbSkidUpdateLength.Text);
            sdInfo.width = Convert.ToDecimal(tbSkidUpdateWidth.Text);
            sdInfo.pieceCount = Convert.ToInt32(tbSkidUpdatePieceCount.Text);
            sdInfo.comments = tbSkidUpdateComments.Text;
            sdInfo.diagnol1 = Convert.ToDecimal(tbSkidUpdateDiag1.Text);
            sdInfo.diagnol2 = Convert.ToDecimal(tbSkidUpdateDiag2.Text);
            sdInfo.mic1 = Convert.ToDecimal(tbSkidUpdateMic1.Text);
            sdInfo.mic2 = Convert.ToDecimal(tbSkidUpdateMic2.Text);
            sdInfo.mic3 = Convert.ToDecimal(tbSkidUpdateMic3.Text);
            sdInfo.alloyID = Convert.ToInt32(cbSkidUpdateAlloyID.Text);
            sdInfo.finishID = Convert.ToInt32(cbSkidUpdateFinishID.Text);
            sdInfo.skidTypeID = Convert.ToInt32(cbSkidUpdateSkidTypeID.Text);
            sdInfo.skidPrice = Convert.ToDecimal(tbSkidUpdateSkidPrice.Text); 
            sdInfo.branchID = Convert.ToInt32(cbSkidUpdateBranchID.Text);
            if (cbSkidUpdateNotPrime.Checked)
            {
                sdInfo.notPrime = 1;
            }
            else
            {
                sdInfo.notPrime = 0;    
            }
            

            int cnt = db.UpdateSkidInfo(sdInfo);

            if (!tbSkidUpdateThk.Text.Equals(tbSkidUpdateThk.Tag.ToString().Trim()) ||
                !tbSkidUpdateHeat.Text.Equals(tbSkidUpdateHeat.Tag.ToString().Trim()) ||
                !tbSkidUpdateMillNum.Text.Equals(tbSkidUpdateMillNum.Tag.ToString().Trim()))
            {
                decimal thk = Convert.ToDecimal(tbSkidUpdateThk.Text);
                db.updateCoilThickness(sdInfo.skidID, sdInfo.coilTagSuffix, thk, tbSkidUpdateMillNum.Text.Trim(),tbSkidUpdateHeat.Text.Trim());
            }

            db.CloseSQLConn();

            changesMade = true; 

            this.Close();
            
        }

        private void tbSkidUpdateLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbSkidUpdateComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tbSkidUpdatePieceCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSkidUpdateSheetWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateLength_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateWidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateDiag1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateDiag2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateMic1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateMic2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateMic3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateSkidPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSkidUpdateSkidWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSkidUpdateSkidWeight_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (tbSkidUpdateSkidWeight.Text.Length > 0 && tbSkidUpdatePieceCount.Text.Length > 0)
                {
                    tbSkidUpdateSheetWeight.Text = (Convert.ToDecimal(tbSkidUpdateSkidWeight.Text) / Convert.ToDecimal(tbSkidUpdatePieceCount.Text)).ToString();
                }
            }
            
            
        }

        private void tbSkidUpdateThk_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
