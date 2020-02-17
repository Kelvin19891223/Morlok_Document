using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

namespace PCK_LIB
{
    public class MySQLWrapper
    {
        private System.Object locker = new System.Object();
        public MySqlConnection sql_con;
        public MySqlCommand sql_cmd;

        public string server;
        public string database;
        public string uid;
        public string password;
        public string port;

        public bool log = false;

        public MySQLWrapper()
        {
        }

        public void OutLog(string str)
        {
            if (log == false)
                return;
            using (StreamWriter writer = new StreamWriter("mysql_log.txt", true))
            {
                writer.WriteLine(str);
            }
        }
        public bool ExecuteNonQuery(string txtQuery)
        {
            try
            {
                lock (locker)
                {
                    CloseConnection();
                    OutLog("\t\t#CENTRAL# Execute MySQL NonQuery: " + txtQuery);
                    OpenConnection();
                    sql_cmd = sql_con.CreateCommand();
                    sql_cmd.CommandText = txtQuery;
                    sql_cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                OutLog("Database query failed : " + ex.Message);
                return false;
            }
        }

        public DataTable ExecuteQuery(string txtQuery)
        {
            try
            {
                lock (locker)
                {
                    CloseConnection();
                    OpenConnection();
                    DataTable dt = new DataTable();
                    sql_cmd = sql_con.CreateCommand();
                    MySqlDataAdapter DB = new MySqlDataAdapter(txtQuery, sql_con);
                    DB.SelectCommand.CommandType = CommandType.Text;
                    DB.Fill(dt);
                    CloseConnection();

                    OutLog("\t\t#CENTRAL# Execute MySQL Query: " + txtQuery + " -> " + dt.Rows.Count.ToString());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                OutLog("Database query failed : " + ex.Message);
                return null;
            }
        }

        public void CreateConnection()
        {
            OutLog(">>Create MySQL connection");
            string connectionString;
            if (port == "")
                connectionString = String.Format("server = {0}; user id = {1}; password ={2}; persistsecurityinfo = True; database ={3}; SslMode = none; Convert Zero Datetime=True;",
                                                server, uid, password, database);
            else
                connectionString = String.Format("server = {0}; user id = {1}; password ={2}; persistsecurityinfo = True; port ={3}; database ={4}; SslMode = none; Convert Zero Datetime=True;",
                                                server, uid, password, port, database);
            sql_con = new MySqlConnection(connectionString);
            OutLog("<<Create MySQL connection");
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
        public bool OpenConnection()
        {
            try
            {
                sql_con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                OutLog(sql_con.ConnectionString);
                switch (GetExceptionNumber(ex))
                {
                    case 0:
                        OutLog("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        OutLog("Invalid username/password, please try again");
                        break;
                }
                OutLog(ex.Message);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                sql_con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                OutLog(ex.Message);
                return false;
            }
        }

        public bool is_connected()
        {
            lock (locker)
            {
                CloseConnection();
                bool ret = OpenConnection();
                if (ret)
                    CloseConnection();
                return ret;
            }
        }

        public static string date4sql(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //userinfo
        public int insert_user(string username, string surname, string birthday, string insurance, string company_name, string main_symptom, string referral,string beihilfe,string profession,String doctor)
        {
            try
            {
                lock (locker)
                {
                    CloseConnection();
                    OpenConnection();

                    string querys = "insert into user_info(name,surname,birthday,insurance,company_name,main_symptom,referral,beihilfe,profession,doctor) values(@name,@surname,@birthday,@insurance,@company_name,@main_symptom,@referral,@beihilfe,@profession,@doctor)";

                    //sql_cmd = sql_con.CreateCommand();
                    sql_cmd = new MySqlCommand(querys, sql_cmd.Connection);                    
                    sql_cmd.Parameters.Add("@name", MySqlDbType.VarChar, 255);
                    sql_cmd.Parameters.Add("@surname", MySqlDbType.VarChar,255);
                    sql_cmd.Parameters.Add("@birthday", MySqlDbType.VarChar, 255);
                    sql_cmd.Parameters.Add("@insurance", MySqlDbType.VarChar, 100);
                    sql_cmd.Parameters.Add("@company_name", MySqlDbType.VarChar, 500);
                    sql_cmd.Parameters.Add("@main_symptom", MySqlDbType.VarChar, 2000);
                    sql_cmd.Parameters.Add("@referral", MySqlDbType.VarChar, 1000);
                    sql_cmd.Parameters.Add("@beihilfe", MySqlDbType.VarChar, 1);                    
                    sql_cmd.Parameters.Add("@profession", MySqlDbType.VarChar, 1);
                    sql_cmd.Parameters.Add("@doctor", MySqlDbType.VarChar, 2000);

                    sql_cmd.Parameters["@name"].Value = username;
                    sql_cmd.Parameters["@surname"].Value = surname;
                    sql_cmd.Parameters["@birthday"].Value = birthday;
                    sql_cmd.Parameters["@insurance"].Value = insurance;
                    sql_cmd.Parameters["@company_name"].Value = company_name;
                    sql_cmd.Parameters["@main_symptom"].Value = main_symptom;
                    sql_cmd.Parameters["@referral"].Value = referral;
                    sql_cmd.Parameters["@beihilfe"].Value = beihilfe;
                    sql_cmd.Parameters["@profession"].Value = profession;
                    sql_cmd.Parameters["@doctor"].Value = doctor;

                    int result = sql_cmd.ExecuteNonQuery();

                    CloseConnection();
                    
                    if (result == 1)
                    {
                        DataTable dt = this.ExecuteQuery("select LAST_INSERT_ID() as cnt");
                        return Convert.ToInt32(dt.Rows[0]["cnt"]);
                    }                        
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                OutLog("Database query failed : " + ex.Message);
                return -1;
            }            
        }

        public bool update_user(string username, string surname, string birthday, string insurance, string company_name, string main_symptom, string referral, string id, string beihilfe, string profession,string doctor)
        {
            username = replaceSpecial(username);
            surname = replaceSpecial(surname);
            insurance = replaceSpecial(insurance);
            company_name = replaceSpecial(company_name);
            main_symptom = replaceSpecial(main_symptom);
            referral = replaceSpecial(referral);
            profession = replaceSpecial(profession);
            doctor = replaceSpecial(doctor);
            string query = String.Format("update user_info set name='{0}', surname='{1}', birthday='{2}', insurance='{3}', company_name='{4}', main_symptom='{5}', referral='{6}', beihilfe='{7}', profession='{8}', doctor='{9}' where user_id={10}", username, surname, birthday, insurance, company_name, main_symptom, referral, beihilfe, profession, doctor, id);
            return this.ExecuteNonQuery(query);
        }

        public DataTable getAllUserInfo(String searchTmp)
        {
            string query = "select * from user_info where deleteflag=0 order by name";
            if (searchTmp != null && searchTmp.Length != 0)
                query = String.Format("select * from user_info where deleteflag=0 and (name like '%{0}%' or surname like '%{1}%') order by name", searchTmp, searchTmp);
            return this.ExecuteQuery(query);
        }

        public DataTable getUserInfo(string id)
        {
            string query = String.Format("select * from user_info where deleteflag=0 and user_id={0}", id);
            return this.ExecuteQuery(query);
        }

        public void deleteUserInfo(string id)
        {
            //string query = String.Format("delete from user_info where user_id={0}", id);
            string query = String.Format("update user_info set deleteflag=1 where user_id={0}", id);
            this.ExecuteNonQuery(query);
        }

        //treatment
        public bool insert_treatment(string[] data, string[] txtdata, string id)
        {
            for(int i=0; i<data.Length; i++)
                data[i] = replaceSpecial(data[i]);

            for (int i = 0; i < txtdata.Length; i++)
                txtdata[i] = replaceSpecial(txtdata[i]);

            if (data != null)
            {
                string query = String.Format("insert into treatment(Myocentric_splint,Daysplint,Longterm_temporaries,Dental_hygiene,Dental_treatment,Periodontal_treatment,Rootcanal_treatment,Prosthetics,Implants,office_Orthodontics,Bionator,Expansion_Plate,Brackets,Aligner,Aligner_CA,Aligner_Invisalign,Snoring_Splint,Terminal_splint,Recall,Recall_Spint,Recall_PA,Recall_teeth,Osteopathy,Physiotherapy,Eurythmics,Metabolism,Blood,Feet,Orthopedic,Neurologist,ORL,Sleep_lab,Orthodontics,Dental_surgery,Message,Yoga_treatment,Dental_treatment_txt,Rootcanal_treatment_txt,Prosthetics_txt,Implants_txt,Snoring_Splint_txt,Recall_txt,Osteopathy_txt,Physiotherapy_txt,Eurythmics_txt,Metabolism_txt,Blood_txt,Feet_txt,Orthopedic_txt,Neurologist_txt,ORL_txt,Sleep_lab_txt,Orthodontics_txt,Dental_surgery_txt,Message_txt,Yoga_treatment_txt, tabletops,userid) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'" +
                    ",'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}')", data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]
                    , data[9], data[10], data[11], data[12], data[13], data[14], data[15], data[16], data[17], data[18], data[19], data[20], data[21], data[22], data[23], data[24], data[25], data[26], data[27], data[28], data[29], data[30], data[31], data[32], data[33], data[34], data[35], txtdata[0], txtdata[1], txtdata[2], txtdata[3], txtdata[4], txtdata[5], txtdata[6], txtdata[7], txtdata[8], txtdata[9], txtdata[10], txtdata[11], txtdata[12], txtdata[13], txtdata[14], txtdata[15], txtdata[16], txtdata[17], txtdata[18], txtdata[19], data[36], id);
                return this.ExecuteNonQuery(query);
            }
            else
                return false;
        }

        public Boolean update_treatment(string userid, int num,int flag)
        {
            string[] arry = { "Myocentric_splint", "Daysplint", "Longterm_temporaries", "Dental_hygiene", "Dental_treatment", "Periodontal_treatment", "Rootcanal_treatment", "Prosthetics" ,"Implants", "office_Orthodontics", "Bionator", "Expansion_Plate", "Brackets", "Aligner", "Aligner_CA", "Aligner_Invisalign", "Snoring_Splint", "Terminal_splint", "Recall", "Recall_Spint", "Recall_PA", "Recall_teeth", "Osteopathy", "Physiotherapy", "Eurythmics", "Metabolism", "Blood", "Feet", "Orthopedic", "Neurologist", "ORL", "Sleep_lab", "Orthodontics", "Dental_surgery", "Message", "Yoga_treatment", "tabletops" };
            string query = string.Format("update treatment set {0}='{1}' where userid={2}", arry[num - 1], flag, userid);
            return this.ExecuteNonQuery(query);
        }

        public void delete_treatment(string id)
        {
            string query = String.Format("delete from treatment where userid={0}", id);
            this.ExecuteNonQuery(query);
        }

        public DataTable getTreatment(string id)
        {
            string query = String.Format("select Myocentric_splint check_1,Daysplint check_2,Longterm_temporaries check_3,Dental_hygiene check_4,Dental_treatment check_5,Periodontal_treatment check_6,Rootcanal_treatment check_7,Prosthetics check_8,Implants check_9,office_Orthodontics check_10,Bionator check_11,Expansion_Plate check_12,Brackets check_13,Aligner check_14,Aligner_CA check_15,Aligner_Invisalign check_16,Snoring_Splint check_17,Terminal_splint check_18,Recall check_19,Recall_Spint check_20,Recall_PA check_21,Recall_teeth check_22,Osteopathy check_23,Physiotherapy check_24,Eurythmics check_25,Metabolism check_26,Blood check_27,Feet check_28,Orthopedic check_29,Neurologist check_30,ORL check_31,Sleep_lab check_32,Orthodontics check_33,Dental_surgery check_34,Message check_35,Yoga_treatment check_36,tabletops check_37,Dental_treatment_txt txt_1,Rootcanal_treatment_txt txt_2,Prosthetics_txt txt_3, Implants_txt  txt_4,Snoring_Splint_txt txt_5,Recall_txt txt_6,Osteopathy_txt txt_7,Physiotherapy_txt txt_8,Eurythmics_txt txt_9,Metabolism_txt txt_10,Blood_txt txt_11,Feet_txt txt_12,Orthopedic_txt txt_13,Neurologist_txt txt_14,ORL_txt txt_15,Sleep_lab_txt txt_16,Orthodontics_txt txt_17,Dental_surgery_txt txt_18,Message_txt txt_19,Yoga_treatment_txt txt_20 from treatment where userid={0}", id);
            return this.ExecuteQuery(query);
        }


        //diagnostic
        public bool insert_diagnostics(string[] data, string id, string fbs,string mrt)
        {
            fbs = replaceSpecial(fbs);
            mrt = replaceSpecial(mrt);
            for (int i = 0; i < data.Length; i++)
                data[i] = replaceSpecial(data[i]);

            if (data != null)
            {
                string query = String.Format("insert into diagnostic(tmj,snoring,apnealink,quisi,biofeedback,emg,kinematographics,t_scan,panorama,panorama_analysis,lateral_x,lateral_x_ray,mri_tmj,dental_finding,functional_finding," +
                    "orthodontic_model, model_analysis, photos,intraoral,extraoral,posture, manual_functional_analysis, instrumental_functional, hormones, eav, stresstest, subsitiution, fbs_txt, mrt_txt, userid) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'" +
                    ",'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')", data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]
                    , data[9], data[10], data[11], data[12], data[13], data[14], data[15], data[16], data[17], data[18], data[19], data[20], data[21], data[22], data[23], data[24], data[25], data[26], fbs, mrt, id);
                return this.ExecuteNonQuery(query);
            }
            else
                return false;
        }

        public Boolean update_diagnostics(string userid, int num,int flag)
        {
            string[] arry = { "tmj", "snoring", "apnealink", "quisi", "biofeedback", "emg", "kinematographics", "t_scan", "panorama", "panorama_analysis", "lateral_x", "lateral_x_ray", "mri_tmj", "dental_finding", "functional_finding", "orthodontic_model", "model_analysis", "photos", "intraoral", "extraoral", "posture", "manual_functional_analysis", "instrumental_functional", "hormones", "eav", "stresstest", "subsitiution"};
            string query = string.Format("update diagnostic set {0}='{1}' where userid={2}", arry[num - 1], flag,userid);
            return this.ExecuteNonQuery(query);
        }

        public void delete_diagnostics(string id)
        {
            string query = String.Format("delete from diagnostic where userid={0}", id);
            this.ExecuteNonQuery(query);
        }

        public DataTable getDiagnostic(string id)
        {
            string query = String.Format("SELECT id,tmj check_1,snoring check_2,apnealink check_3,quisi check_4,biofeedback check_5,emg check_6,kinematographics check_7,t_scan check_8," +
            "panorama check_9,panorama_analysis check_10,lateral_x check_11,lateral_x_ray check_12,mri_tmj check_13,dental_finding check_14,functional_finding check_15,orthodontic_model check_16,model_analysis check_17," +
            "photos check_18,intraoral check_19,extraoral check_20, posture check_21, manual_functional_analysis check_22,instrumental_functional check_23,hormones check_24,eav check_25,stresstest check_26,subsitiution check_27,fbs_txt,mrt_txt FROM diagnostic where userid={0}", id);
            return this.ExecuteQuery(query);
        }

        public DataTable insertScannedForm(string userid, string kind,string filetype,string filename,string date)
        {
            filename = replaceSpecial(filename);
            string query = string.Format("insert into scanned_form(userid,kind,filetype,filename,fdate) values('{0}','{1}','{2}','{3}','{4}');select LAST_INSERT_ID() as cnt", userid,kind, filetype,filename,date);
            return this.ExecuteQuery(query);
        }

        public void deleteScannedForm(string id)
        {
            string query = string.Format("delete from scanned_form where id={0}", id);
            this.ExecuteNonQuery(query);
        }

        public DataTable getScannedForm(string id, string kind, string date)
        {
            string query = "";
            if (date == "")
                query = String.Format("select * from scanned_form where userid={0} and kind='{1}'", id, kind);
            else
                query = String.Format("select * from scanned_form where userid={0} and kind='{1}' and fdate='{2}'", id, kind,date);
            return this.ExecuteQuery(query);
        }

        public DataTable getScannedFormData(string date)
        {
            string query = string.Format("select * from scanned_form where fdate='{0}'", date);
            return this.ExecuteQuery(query);
        }

        public DataTable getScannedFormByid(string id)
        {
            string query = String.Format("select * from scanned_form where id={0}", id);
            return this.ExecuteQuery(query);
        }

        public void deleteScannedFormById(string id)
        {
            string query = String.Format("delete from scanned_form where id={0}");
            this.ExecuteNonQuery(query);
        }

        public void setChronic(string date, string input, string userid, int order)
        {
            date = replaceSpecial(date);
            input = replaceSpecial(input);

            string query = String.Format("insert into chronic(orderby,date,input,userid) values('{0}','{1}','{2}',{3})", order, date, input, userid);
            this.ExecuteNonQuery(query);
        }

        public DataTable getChronic(string userid)
        {
            string query = String.Format("select * from chronic where userid={0} order by date", userid);
            return this.ExecuteQuery(query);
        }

        public void updateChronic(string date, string input, string id)
        {
            input = replaceSpecial(input);
            string query = string.Format("update chronic set date='{0}', input='{1}' where id={2}", date, input, id);
            this.ExecuteNonQuery(query);
        }

        public void deleteChronicById(string id)
        {
            string query = string.Format("delete from chronic where id={0}", id);
            this.ExecuteNonQuery(query);
        }

        public DataTable getChrnoicById(string id)
        {
            string query = String.Format("select * from chronic where id={0}", id);
            return this.ExecuteQuery(query);
        }

        public void deleteChronic(string userid)
        {
            string query = String.Format("delete from chronic where userid={0}", userid);
            this.ExecuteQuery(query);
        }

        public void deleteSymptom(string userid,string date)
        {
            string query = String.Format("delete from symptoms where userid = {0} and fdate='{1}'", userid, date);
            this.ExecuteNonQuery(query);
        }

        public void setSymptom(string userid, string title, int[] color, int order, string date)
        {
            string query = String.Format("insert into symptoms(userid,symptoms,f0,f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,forder,fdate) values({0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'{14}')", userid, title, color[0], color[1], color[2], color[3], color[4], color[5], color[6], color[7], color[8], color[9], color[10], order,date);
            this.ExecuteNonQuery(query);
        }

        public DataTable getSymptoms(string userid, string date)
        {
            string query = String.Format("select * from symptoms where userid={0} and fdate='{1}' order by forder", userid,date);
            return this.ExecuteQuery(query);
        }

        public DataTable getSymptomsByDate(string userid, string title)
        {
            string query = string.Format("select * from symptoms where userid={0} and symptoms= '{1}' order by fdate", userid,title);
            return this.ExecuteQuery(query);
        }


        public void deleteSymptom1(string userid, string date)
        {
            string query = String.Format("delete from symptoms1 where userid = {0} and fdate='{1}'", userid, date);
            this.ExecuteNonQuery(query);
        }

        public void setSymptom1(string userid, string title, int[] color, int order, string date)
        {
            string query = String.Format("insert into symptoms1(userid,symptoms,f0,f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,forder,fdate) values({0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'{14}')", userid, title, color[0], color[1], color[2], color[3], color[4], color[5], color[6], color[7], color[8], color[9], color[10], order, date);
            this.ExecuteNonQuery(query);
        }

        public DataTable getSymptoms1(string userid, string date)
        {
            string query = String.Format("select * from symptoms1 where userid={0} and fdate='{1}' order by forder", userid, date);
            return this.ExecuteQuery(query);
        }

        public DataTable getSymptomsByDate1(string userid, string title)
        {
            string query = string.Format("select * from symptoms1 where userid={0} and symptoms= '{1}' order by fdate", userid, title);
            return this.ExecuteQuery(query);
        }

        public string replaceSpecial(string temp)
        {
            string result = temp.Replace("'", "\\'");
            return result;
        }

        public void deleteTemplate(string id)
        {
            string query = string.Format("delete from template where id={0}", id);
            this.ExecuteNonQuery(query);
        }

        public DataTable getTemplate()
        {
            string query = string.Format("select * from template");
            return this.ExecuteQuery(query);
        }

        public DataTable getTemplateById(string id)
        {
            string query = string.Format("select * from template where id={0}", id);
            return this.ExecuteQuery(query);
        }

        public void insertTemplate(string template)
        {
            try
            {
                lock (locker)
                {
                    CloseConnection();
                    OpenConnection();

                    string querys = "insert into template(template) values(@template)";

                    //sql_cmd = sql_con.CreateCommand();
                    sql_cmd = new MySqlCommand(querys, sql_cmd.Connection);
                    sql_cmd.Parameters.Add("@template", MySqlDbType.VarChar, 2000);                    

                    sql_cmd.Parameters["@template"].Value = template;                                      

                    int result = sql_cmd.ExecuteNonQuery();
                    CloseConnection();                    
                }
            }
            catch (Exception ex)
            {
                OutLog("Database query failed : " + ex.Message);                
            }
        }

        public void updateTemplate(string id, string template)
        {
            template = replaceSpecial(template);
            string query = string.Format("update template set template='{0}' where id={1}", template, id);
            this.ExecuteNonQuery(query);
        }
    }
}
