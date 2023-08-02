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
    public partial class TransferItem : Form
    {

        private int returnCustID = -1;
        private string returnCustName = "";
       
        public void addItem(string custname, int custid)
        {
            chkLsBxCustomer.Items.Add(custname);
            chkBxListCustIDs.Items.Add(custid);
        }
        public int getCustID()
        {
            return returnCustID;
        }
        public string getCustName()
        {
            return returnCustName;
        }
        public TransferItem()
        {
            
            InitializeComponent();
            chkLsBxCustomer.Items.Clear();
            chkBxListCustIDs.Items.Clear();
        }

        private void chkLsBxCustomer_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            returnCustID = Convert.ToInt32(chkBxListCustIDs.Items[e.Index]);
            returnCustName =chkLsBxCustomer.Items[e.Index].ToString();
            this.Close();
        }
    }
}
