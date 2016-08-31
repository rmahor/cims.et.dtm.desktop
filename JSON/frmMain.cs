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

using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using ETdll;

using GenerateSLlog;

namespace JSON
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSales_Click(object sender, EventArgs e)
        {

            frmSLtran frm = new frmSLtran();
            frm.ShowDialog();
            
        }





    }
}

