using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morlok
{
    public partial class ChronicPrint : Form
    {
        public ChronicPrint()
        {
            InitializeComponent();
        }

        private void ChronicPrint_Load(object sender, EventArgs e)
        {
            const string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
            bool bolWritable = true;
            string strNameF = "footer";
            string strNameH = "header";
            object oValue = "";
            Microsoft.Win32.RegistryKey oKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strKey, bolWritable);
            oKey.SetValue(strNameF, oValue);
            oKey.SetValue(strNameH, oValue);
            oKey.Close();

            DataTable dt = MainApp.g_mysql.getUserInfo(MainApp.user_id);
            DataTable chronic = MainApp.g_mysql.getChronic(MainApp.user_id);

            string tmp = "";
            tmp = "<html><head><style>@media print {#header, #footer {display:none;}}</style></head><body>" +
                "<table width='100%' height='100%' cellspacing='0' cellpadding='0' >" +
                "<tr><td height='20' align='center'><span style='font-size:20px;'>Chronic</span></td></tr>" +
                "<tr height='30'><td><span>Name: " +
                dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["surname"].ToString() +
                "</span></td></tr>" +
                "<tr height='30'><td><span>Birthday: " +
                dt.Rows[0]["birthday"].ToString() +
                "</span></td></tr>" +
                "<tr height='30'><td><span>Main Symptom: " +
                dt.Rows[0]["main_symptom"].ToString() +
                "</span></td></tr>" +
                "<tr><td><table width='100%' border='1' cellspacing='0' cellpadding='0' >" +
                "<tr height='20'><td width='100'>Date</td><td>Input</td></tr>";

                if (chronic != null && chronic.Rows.Count > 0)
                {
                    for (int i = 0; i < chronic.Rows.Count; i++)
                    {
                    //chronic_form_grid.Rows.Add(chronic.Rows[i]["id"].ToString(), chronic.Rows[i]["date"].ToString(), chronic.Rows[i]["input"].ToString());
                        tmp = tmp + "<tr><td align='top'>" +
                        chronic.Rows[i]["date"].ToString() +
                        "</td><td valign='top'>" +
                        chronic.Rows[i]["input"].ToString() +
                        "</td></tr>";
                    }
                }
                tmp = tmp + "<tr><td></td></tr></table></td></tr>" +
                "</body></html>";

            webBrowser1.DocumentText = tmp;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {                        
            webBrowser1.Print();         
        }
    }
}
