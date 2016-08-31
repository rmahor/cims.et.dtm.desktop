using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ETdll;
using System.IO;

namespace GenerateSLlog
{
    public partial class frmSLtran : Form
    {
        public frmSLtran()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {

            dteTranDate.Text = DateTime.Now.ToString();
            dteTranDate.Format = DateTimePickerFormat.Custom; dteTranDate.CustomFormat = "MM/dd/yyyy";

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //calling Json file
            DateTime dte = dteTranDate.Value; //DateTime.Today;
            string MM = dte.Month.ToString("00");
            string DD = dte.Day.ToString("00");
            string YYYY = dte.Year.ToString();
            string DTE = MM + DD + YYYY;
            string TRNdate = MM + "/" + DD + "/" + YYYY;

            string FT = "select * from Finishedtransaction where convert(varchar(10), logdate, 101) = '" + TRNdate + "'";
            DataTable DT = DAC.SqlDataTable(FT);

            string FS = "select * from Finishedsales where convert(varchar(10), logdate, 101) = '" + TRNdate + "'";
            DataTable DT1 = DAC.SqlDataTable(FS);

            string FP = "select * from Finishedpayments where convert(varchar(10), logdate, 101) = '" + TRNdate + "'";
            DataTable DT2 = DAC.SqlDataTable(FP);

            string FI = "select * from FinishedIngredients where convert(varchar(10), logdate, 101) = '" + TRNdate + "'";
            DataTable DT3 = DAC.SqlDataTable(FI);


            ToJasonFile SLJson = new ToJasonFile();
            SLJson.DataTableToJsonWithJsonNet(DT);
            SLJson.DataTableToJsonWithJsonNet(DT1);
            SLJson.DataTableToJsonWithJsonNet(DT2);
            SLJson.DataTableToJsonWithJsonNet(DT3);

           

            DataTable BR = DAC.SqlDataTable("SELECT BRANCHCODE FROM BRANCH");
            string BranchCode = string.Empty;
            if (BR.Rows.Count > 0)
            {
                BranchCode = BR.Rows[0]["Branchcode"].ToString();
            }

            String DIRPath = @"C:\SLLOG";
            if (!Directory.Exists(DIRPath))
            {
                Directory.CreateDirectory(DIRPath);
            }
            
            using (StreamWriter file = File.CreateText(DIRPath + @"\ST"+DTE+"."+BranchCode))
            {//Finishedtransactions 
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, DT);
            }

            using (StreamWriter file = File.CreateText(DIRPath + @"\SL" + DTE + "." + BranchCode))
            {//Finishedsales
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, DT1);
            }
            using (StreamWriter file = File.CreateText(DIRPath + @"\SP" + DTE + "." + BranchCode))
            {//Finishedpayments
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, DT2);
            }
            using (StreamWriter file = File.CreateText(DIRPath + @"\SI" + DTE + "." + BranchCode))
            {//Finishedingridients 
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, DT3);
            }

            MessageBox.Show("Sales Log Generated @ " + DIRPath , "System Advisory", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
