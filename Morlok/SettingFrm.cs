using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Morlok
{
    public partial class SettingFrm : Form
    {
        public SettingFrm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void SettingFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }           
        }

        private void SettingFrm_Load(object sender, EventArgs e)
        {
            if(MainApp.language == "en")
            {
                setting_admin_group.Text = "Admin Settings";
                setting_admin_pass_label.Text = "Password:";
                setting_admin_confirm_pass_label.Text = "Confirm Password:";
                setting_ftp_group.Text = "Ftp Settings";
                setting_ftp_server_label.Text = "Host Name/IP Address:";
                setting_ftp_user_label.Text = "User Name:";
                setting_ftp_port_label.Text = "Port:";
                setting_ftp_password_label.Text = "Password:";
                setting_ftp_confirm_password_label.Text = "Confirm Password:";
                setting_database_group.Text = "Database Settings";
                setting_db_server_label.Text = "Host Name/IP Address:";
                setting_db_port_label.Text = "Port:";
                setting_db_user_label.Text = "User Name:";
                setting_db_password_label.Text = "Password:";
                setting_db_confirm_password_label.Text = "Confirm Password:";
                setting_test_btn.Text = "Test Connection";
                setting_ok_btn.Text = "OK";
                setting_cancel_btn.Text = "Cancel";
                setting_db_database_name_label.Text = "Database Name:";
            } else
            {
                setting_admin_group.Text = "Admin-Einstellungen";
                setting_admin_pass_label.Text = "Passwort:";
                setting_admin_confirm_pass_label.Text = "Passwort bestätigen:";
                setting_ftp_group.Text = "Ftp Einstellungen";
                setting_ftp_server_label.Text = "Hostname / IP-Adresse:";
                setting_ftp_user_label.Text = "Benutzername:";
                setting_ftp_port_label.Text = "Port:";
                setting_ftp_password_label.Text = "Passwort:";
                setting_ftp_confirm_password_label.Text = "Passwort bestätigen:";
                setting_database_group.Text = "Datenbankeinstellungen";
                setting_db_server_label.Text = "Hostname / IP-Adresse:";
                setting_db_port_label.Text = "Port:";
                setting_db_user_label.Text = "Benutzername:";
                setting_db_password_label.Text = "Passwort:";
                setting_db_confirm_password_label.Text = "Passwort bestätigen:";
                setting_test_btn.Text = "Verbindung testen";
                setting_ok_btn.Text = "OK";
                setting_cancel_btn.Text = "Cancel";
                setting_db_database_name_label.Text = "Name der Datenbank:";
            }


            setting_admin_pass_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.admin_pwd);
            setting_admin_confirm_password_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.admin_pwd);

            setting_ftp_server_txt.Text = MainApp.g_setting.ftp_server;
            setting_ftp_username_txt.Text = MainApp.g_setting.ftp_user;
            setting_ftp_port_txt.Text = MainApp.g_setting.ftp_port;
            setting_ftp_password_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.ftp_pass);
            setting_ftp_confirm_password_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.ftp_pass);

            setting_db_server_txt.Text = MainApp.g_setting.server_address;
            setting_db_user_txt.Text = MainApp.g_setting.db_user;
            setting_db_port_txt.Text = MainApp.g_setting.db_port;
            setting_db_password_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.db_pwd);
            setting_db_confirm_password_txt.Text = MainApp.g_aes.Decrypt(MainApp.g_setting.db_pwd);

            setting_db_database_name_txt.Text = MainApp.g_setting.db_name;
        }
        
        private void setting_test_btn_Click(object sender, EventArgs e)
        {
            if(setting_admin_pass_txt.Text != setting_admin_confirm_password_txt.Text)
            {
                if(MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_admin_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_admin_password_no_match);
                return;
            }

            if(setting_ftp_password_txt.Text != setting_ftp_confirm_password_txt.Text)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_ftp_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_ftp_password_no_match);
                return;
            }

            if(setting_db_password_txt.Text != setting_db_confirm_password_txt.Text)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_db_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_db_password_no_match);
                return;
            }

            //check
            string admin_pass = setting_admin_pass_txt.Text;
            string ftp_server = setting_ftp_server_txt.Text;
            string ftp_user = setting_ftp_username_txt.Text;
            string ftp_port = setting_ftp_port_txt.Text;
            string ftp_password = setting_ftp_password_txt.Text;
            string db_server = setting_db_server_txt.Text;
            string db_user = setting_db_user_txt.Text;
            string db_port = setting_db_port_txt.Text;
            string db_password = setting_db_password_txt.Text;
            string db_database_name = setting_db_database_name_txt.Text;

            string result = "";
            //check ftp connection
            if(!FtpConnection(ftp_server,ftp_port,ftp_user,ftp_password))
            {
                if (MainApp.language == "en")
                    result = MessagePropertys.en_ftp_con_error;
                else
                    result = MessagePropertys.de_ftp_con_error;
            }

            if(!DbConnection(db_server,db_port,db_user,db_password,db_database_name))
            {
                if (MainApp.language == "en")
                    result = result + result + MessagePropertys.en_db_con_error;
                else
                    result = result + MessagePropertys.de_db_con_error;                
            }

            if (result == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_con_suf);
                else
                    MessageBox.Show(MessagePropertys.de_con_suf);
            }                
            else
            {
                MessageBox.Show(result);
            }
                
        }

        public bool FtpConnection(string server, string port, string user, string password)
        {
            try
            {
                FtpWebRequest ftp_request; 
                ftp_request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("ftp://{0}:{1}/{2}", server, port, "check.txt")));
                ftp_request.Credentials = new NetworkCredential(user, password);
                FtpWebResponse response = (FtpWebResponse)ftp_request.GetResponse();
                response.Close();                
                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }
        }

        public static int GetExceptionNumber(MySqlException my)
        {
            if (my != null)
            {
                int number = my.Number;
                //if the number is zero, try to get the number of the inner exception
                if (number == 0 && (my = my.InnerException as MySqlException) != null)
                {
                    number = my.Number;
                }
                return number;
            }
            return -1;
        }

        public bool DbConnection(string server, string port, string user, string pass,string dbname)
        {
            bool result = false;
            try
            {
                MySqlConnection sql_con;
                MySqlCommand sql_cmd;
                string connectionString = String.Format("server = {0}; user id = {1}; password ={2}; persistsecurityinfo = True; port ={3}; database ={4}; SslMode = none; Convert Zero Datetime=True;",
                                                server, user, pass, port, dbname);
                sql_con = new MySqlConnection(connectionString);
                sql_con.Open();
                result = true;
            }
            catch (MySqlException ex)
            {
                result = false;                                          
            }
            return result;
        }

        private void setting_ok_btn_Click(object sender, EventArgs e)
        {
            if (setting_admin_pass_txt.Text != setting_admin_confirm_password_txt.Text)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_admin_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_admin_password_no_match);
                return;
            }

            if (setting_ftp_password_txt.Text != setting_ftp_confirm_password_txt.Text)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_ftp_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_ftp_password_no_match);
                return;
            }

            if (setting_db_password_txt.Text != setting_db_confirm_password_txt.Text)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_db_password_no_match);
                else
                    MessageBox.Show(MessagePropertys.de_db_password_no_match);
                return;
            }

            //check
            string admin_pass = setting_admin_pass_txt.Text;
            string ftp_server = setting_ftp_server_txt.Text;
            string ftp_user = setting_ftp_username_txt.Text;
            string ftp_port = setting_ftp_port_txt.Text;
            string ftp_password = setting_ftp_password_txt.Text;
            string db_server = setting_db_server_txt.Text;
            string db_user = setting_db_user_txt.Text;
            string db_port = setting_db_port_txt.Text;
            string db_password = setting_db_password_txt.Text;
            string db_database_name = setting_db_database_name_txt.Text;

            if (admin_pass == "" || ftp_server == "" || ftp_user == "" || ftp_port == "" || db_server == "" || db_user == "" || db_port == "" || db_database_name == "")
            {
                if(MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_empty_field);
                else
                    MessageBox.Show(MessagePropertys.de_empty_field);
            }

            string result = "";
            //check ftp connection
            if (!FtpConnection(ftp_server, ftp_port, ftp_user, ftp_password))
            {
                if (MainApp.language == "en")
                    result = MessagePropertys.en_ftp_con_error;
                else
                    result = MessagePropertys.de_ftp_con_error;
            }

            if (!DbConnection(db_server, db_port, db_user, db_password, db_database_name))
            {
                if (MainApp.language == "en")
                    result = result + result + MessagePropertys.en_db_con_error;
                else
                    result = result + MessagePropertys.de_db_con_error;
            }

            if (result != "")
            {
                MessageBox.Show(result);                
                return;
            }

            //save
            LoginFrm frm = new LoginFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //save
                MainApp.g_setting.admin_pwd = MainApp.g_aes.Encrypt(setting_admin_pass_txt.Text);
                MainApp.g_setting.ftp_server = setting_ftp_server_txt.Text;
                MainApp.g_setting.ftp_user = setting_ftp_username_txt.Text;
                MainApp.g_setting.ftp_port = setting_ftp_port_txt.Text;
                MainApp.g_setting.ftp_pass = MainApp.g_aes.Encrypt(setting_ftp_password_txt.Text);
                MainApp.g_setting.server_address = setting_db_server_txt.Text;
                MainApp.g_setting.db_user = setting_db_user_txt.Text;
                MainApp.g_setting.db_port = setting_db_port_txt.Text;
                MainApp.g_setting.db_pwd = MainApp.g_aes.Encrypt(setting_db_password_txt.Text);
                MainApp.g_setting.db_name = setting_db_database_name_txt.Text;
                MainApp.g_setting.Save();
                MainApp.LoadDBSetting();
                MainApp.LoadFtpSetting();
            }
        }
    }
}
