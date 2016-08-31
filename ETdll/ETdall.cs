using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

using ETGlobalVar;

namespace ETdll
{
    public class ToJasonFile
    {
        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }
        
        //private string serial(string sd)
        //{
        //    using (FileStream fs2 = File.Open("c:\\JSON.TXT", FileMode.Open))
        //    {
        //        JavaScriptSerializer jsd = new JavaScriptSerializer();
        //        string l = jsd.Serialize(sd);
        //        return sd;
        //    }
        //}

    }

    public class DAC
    {
       //string server = ".\\SQLExpress";
       //string database = "POS_001";

        //  optionsBuilder.UseSqlServer(@"Server=" + server + ";Database=" + database + ";Trusted_Connection=True;");
        //public static string CNstr = "Data Source=" + gstrServerName + " ;Initial Catalog=" + gstrDBName + ";Integrated Security=False;Persist Security Info=True;" + "User ID=" + gstrSQLid + ";Password =" + gstrPassword;        
         public static string CNstr = "Data Source=" + GlobalV.IniVar.gstrServerName + ";Database=" + GlobalV.IniVar.gstrDBName + ";Trusted_Connection=True;";
        public static DataTable SqlDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(CNstr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

    }

}


