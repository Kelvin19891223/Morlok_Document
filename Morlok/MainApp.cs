using PCK_LIB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morlok
{

    static class MainApp
    {
        public static UserSetting g_setting;
        public static SimpleAES g_aes = new SimpleAES();
        public static string    g_user_id = "0";
        public static int   m_timer_interval = 1000;
        public static Color g_col_error = Color.FromArgb(100, Color.DarkRed);
        public static Color g_col_blank = Color.FromArgb(255, Color.White);
        public static Color g_col_working = Color.FromArgb(255, Color.Tomato);
        public static Color g_col_finished = Color.FromArgb(255, Color.Green);
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static MySQLWrapper g_mysql = new MySQLWrapper();
        public static FtpWrapper g_ftp = new FtpWrapper();
        public static MainFrm   m_main_frm;

        public static string username = "No Select";
        public static string user_id = "";
        public static int user_index = -1;
        public static string language = "en";
        public static string symptom_graph_id_1 = "";
        public static string symptom_graph_id_2 = "";

        public static int patient_column_delete = 5;
        public static int patient_column_choose = 4;
        public static int patient_column_id = 0;
        public static int patient_column_name = 1;
        public static string scannedform_anamnesis = "Anamnesis";
        public static string scannedform_special = "Special questions";
        public static string scannedform_tmj = "TMJ Anamnesis";
        public static string scannedform_snoring_anamnesis = "Snoring Anamnesis";
        public static string scannedform_snoring_recall= "Snoring Recall";
        public static string scannedform_result = "Result";
        public static string anamnesis_selected_radio = "";

        [STAThread]
        static void Main()
        {
            Load_setting();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoadDBSetting();
            LoadFtpSetting();
            
            if(!g_ftp.IsConnection())
            {
                MessageBox.Show("Ftp Connection Fail.");
                return;
            }
            
            LoginFrm frm = new LoginFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                m_main_frm = new MainFrm();
                Application.Run(m_main_frm);
            }
        }

        static public void LoadDBSetting()
        {
            g_mysql.server = g_setting.server_address;
            g_mysql.database = g_setting.db_name;
            g_mysql.uid = g_setting.db_user;
            g_mysql.password = g_aes.Decrypt(g_setting.db_pwd);
            g_mysql.port = g_setting.db_port;
            g_mysql.CreateConnection();
        }

        static public void LoadFtpSetting()
        {
            g_ftp.ftp_server = g_setting.ftp_server;
            g_ftp.ftp_port = g_setting.ftp_port;
            g_ftp.ftp_user = g_setting.ftp_user;
            g_ftp.ftp_pass = g_aes.Decrypt(g_setting.ftp_pass);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                logger.Info(ex.ToString() + "\n" + ex.StackTrace + @"Unhandled Exception");
            }
            finally
            {
                Application.Exit();
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                logger.Info(e.Exception.ToString() + "\n" + e.Exception.StackTrace + @"Thread Exception");
            }
            finally
            {
                Application.Exit();
            }
        }
        private static void Load_setting()
        {
            g_setting = UserSetting.Load();
            if (g_setting == null)
                g_setting = new UserSetting();
            return;
        }
    }

    public static class MessagePropertys
    {
        public static string en_userinfo_empty = "Please input empty field!";
        public static string de_userinfo_empty = "Bitte leeres Feld eingeben!";

        public static string en_db_connect_error = "Database connection failed. Please check the network connection.";
        public static string de_db_connect_error = "Datenbankverbindung fehlgeschlagen Bitte überprüfen Sie die Netzwerkverbindung.";

        public static string en_success = "The operation is complete.";
        public static string de_success = "Die Operation ist abgeschlossen.";

        public static string en_fail = "Operation failed.";
        public static string de_fail = "Operation fehlgeschlagen.";

        public static string en_choose = "Select";
        public static string de_choose = "wählen";

        public static string en_delete = "Delete";
        public static string de_delete = "Löschen";

        public static string en_select_alert = "Please select a patient";
        public static string de_select_alert = "Bitte wählen Sie einen Patienten aus";

        public static string en_no_select = "Patient not selected";
        public static string de_no_select = "Patient nicht ausgewählt";

        public static string en_userinfo_incorrect = "User information incorrect.";
        public static string de_userinfo_incorrect = "Benutzerinformationen falsch.";

        public static string[] en_diagnostics_checkbox = { "TMJ Anamnesis", "Snoring Anamnesis", "Apnealink", "Quisi", "Biofeedback", "EMG", "Kinematographics", "T-Scan", "Panorama", "Panorama Analysis", "Lateral X-ray", "Lateral X-ray Analysis", "MRI TMJ", "Dental Finding", "Functional Finding", "Orthodontic Models", "Model Analysis", "Photos", "Intraoral", "Extraoral", "Posture", "Manual Functional Analysis", "Instrumental Functional Analysis", "Hormones", "EAV", "Stresstest", "Substitution" ,"Hormones  "};
        public static string[] de_diagnostics_checkbox = { "CMD Anamnese", "Schnarchanamnese", "Apnealink", "Quisi", "Biofeedback", "EMG", "Kinematographie", "T-Scan", "Panorama", "Panorama Analyse", "FRS", "FRS Analyse", "MRT CMD", "Zahnärztlicher Befund", "Funktioneller Befund", "Kieferorthopädische Modelle", "Modellanalyse", "Fotos", "Intraoral", "Extraoral", "Haltung", "Manuelle Funktionsanalyse", "Instrumentelle Funktionsanalyse", "Hormone", "EAV", "Stresstest", "Substitution" , "Hormone  "};

        public static string[] en_treatment_label = { "Myocentric splint", "Daysplint", "Longterm temporaries", "Dental hygiene", "Dental treatment(Tooth Nr – )", "Periodontal treatment", "Rootcanal treatment, core ? (Tooth Nr – )", "Prosthetics (Tooth Nr – )", "Implants (Tooth Nr – )", "Orthodontics  ", "Bionator", "Expansion Plate", "Brackets", "Aligner", "CA", "Invisalign", "Snoring Splint", "Terminal splint", "Recall", "Splint", "PA", "Teeth", "Osteopathy", "Physiotherapy", "Eurythmics", "Metabolism", "Blood", "Feet", "Orthopedic", "Neurologist", "ORL", "Sleep lab", "Orthodontics   ", "Dental surgery", "Massage", "Yoga treatment", "Table Tops" };
        public static string[] de_treatment_label = { "Myozentrische Schiene", "Tagesschiene", "LZP", "PZR", "Zahnbehandlung (Tooth Nr – )", "Parodontalbehandlung", "Wurzelbehandlung, Stift ? (Tooth Nr – )", "Prothetik (Tooth Nr – )", "Implantate (Tooth Nr – )", "KFO  ", "Bionator", "Dehnplatte", "Brackets", "Aligner", "CA", "Invisalign", "Schnarcherschiene", "Abschlussschiene", "Recall", "Schiene", "PA", "Zähne", "Osteopathie", "Physiotherapie", "Eurythmie", "Metabolismus", "Blut", "Füße", "Orthopädie", "Neurologie", "HNO", "Schlaflabor", "KFO   ", "Kieferchirurgie", "Massage", "Yoga Behandlung", "Table Tops" };

        public static string[] en_chronic_treatment_label = { "Myocentric splint", "Daysplint", "Longterm temporaries", "Dental hygiene", "Dental treatment(Tooth Nr – )", "Periodontal treatment", "Rootcanal treatment, core ? (Tooth Nr – )", "Prosthetics (Tooth Nr – )" , "Implants (Tooth Nr – )", "Orthodontics  ", "Bionator", "Expansion Plate", "Brackets", "Aligner", "CA", "Invisalign", "Snoring Splint", "Terminal splint", "Recall", "Splint", "PA", "Teeth", "Osteopathy", "Physiotherapy", "Eurythmics", "Metabolism", "Blood", "Feet", "Orthopedic", "Neurologist", "ORL", "Sleep lab", "Orthodontics   ", "Dental surgery", "Massage", "Yoga treatment", "Table Tops" };
        public static string[] de_chronic_treatment_label = { "Myozentrische Schiene", "Tagesschiene", "LZP", "PZR", "Zahnbehandlung (Tooth Nr – )", "Parodontalbehandlung", "Wurzelbehandlung, Stift ? (Tooth Nr – )", "Prothetik (Tooth Nr – )", "Implantate (Tooth Nr – )", "KFO  ", "Bionator", "Dehnplatte", "Brackets", "Aligner", "CA", "Invisalign", "Schnarcherschiene", "Abschlussschiene", "Recall", "Schiene", "PA", "Zähne", "Osteopathie", "Physiotherapie", "Eurythmie", "Metabolismus", "Blut", "Füße", "Orthopädie", "Neurologie", "HNO", "Schlaflabor", "KFO   ", "Kieferchirurgie", "Massage", "Yoga Behandlung", "Table Tops" };

        public static string[] en_symptoms_label = { "Sensitive teeth", "Clicking, grinding and other sounds in the jaw joint? Where?", "Burning of mouth, tongue and palate", "Dry mouth", "Problems of the salivary gland", "Grinding and pressing of the teeth", "Tongue- and lippressing", "Pain in the jaw joint", "Mouth doesn´t open right", "Chewing only at one side – which side?", "Tension when waking up in the morning. Where?", "Tension in general.Where?", "Stiffness? Where?", "Feeling of not feeling straight. Where?", "Itchy sculp", "Headache", "Faceache", "Neckache", "Backache", "Shoulderache", "Hearing disorders", "Earnoise. Which kind? Please describe it.", "Closed feeling of the ears. Both ears?", "Earpain", "Earpressure", "Itchy ears", "Dizziness", "Pain behind the eyes", "Sensitivity against light", "Visual disturbance", "Double images", "Difficulty swallowing", "Sore throat", "Speaking difficulties", "Hawking", "Numbness. Where?", "Daytime sleepiness", "Tendency dozing off in daytime", "Morning tiredness", "Fit only in the late afternoon or in the evening", "Stress at work", "Stress in familiy", "Stress in school", "Stress somewhere else. Where?", "Breathing interruption during sleeping", "Snoring", "Short sleep", "Wake up during sleep? When?", "Not able to fall asleep", "Depression", "Excessive Demands? Why?", "Fear. Of what?", "Restlessness" };
        public static string[] de_symptoms_label = { "Empfindliche Zähne", "Knacken, Reiben oder andere Geräusche im Kiefergelenk? Wo?", "Mund-, Zungen- oder Gaumenbrennen", "Trockener Mund", "Probleme mit Speicheldrüsen?", "Knirschen  oder Pressen mit den Zähnen", "Zungen- oder Lippenpressen", "Schmerzen in den Kiefergelenken", "Mund geht nicht richtig auf", "Einseitiges Kauen – welche Seite?", "Verspannung beim Aufwachen, wo?", "Verspannung generell, wo?", "Steifheitsgefühl. Wo?", "Gefühl, nicht gerade zu sein? Wo?", "Kopfjucken", "Kopfschmerzen", "Gesichtschmerzen", "Nackenschmerzen", "Rückenschmerzen", "Schulterschmerzen", "Hörstörungen", "Ohrgeräusche. Welches? Beschreiben Sie bitte.", "Ohren zu. Beide Ohren?", "Ohrschmerzen", "Ohrdruck", "Ohrjucken", "Schwindel", "Schmerzen hinter den Augen", "Lichtempfindlichkeit", "Sehstörungen", "Doppelbilder", "Schluckbeschwerden", "Halsschmerzen", "Sprechstörungen", "Räusperzwang", "Taubheitsgefühl. Wo?", "Tagesmüdigkeit", "Tags einnicken", "Morgenmüdigkeit", "Spätnachmittags oder Abends erst fit", "Stress in Arbeit", "Stress in Familie", "Stress in Schule ", "Stress woanders. Wo?", "Atemaussetzer während des Schlafs", "Schnarchen", "Kurzer Schlaf", "Aufwachen während des Schlafs? Wann?", "Nicht einschlafen können", "Depression", "Überforderung? Warum?", "Angst. Wovor?", "Unruhe" };

        public static string[] en_symptoms_label_1 = {"Limitation with daily tasks in the last 6 months", "Limitation with family- and freetimeactivities in the last 6 months", "Limitation with work and homework in the last 6 months", "Actual pain intensity", "Strongest pain in the last 6 months", "Average pain in the last 6 months" };
        public static string[] de_symptoms_label_1 = { "Beeinträchtigung bei der alltäglichen Beschäftigung i.d. letzten 6 Monaten", "Beeinträchtigung der Teilnahme an Familien- und Freizeitaktivitäten i.d. letzten 6 Monaten", "Beeinträchtigung der Verrichtung von Arbeit/Hausarbeit i.d. letzten 6  Monaten", "Aktuelle Schmerzstärke", "Stärkster Schmerz in den letzten 6 Monaten", "Duchschnittlicher Schmerz in den letzten 6 Monaten"};

        public static string en_admin_password_no_match = "The admin password and confirmation password did not match.";
        public static string de_admin_password_no_match = "Das Admin-Passwort und das Bestätigungspasswort stimmen nicht überein.";

        public static string en_ftp_password_no_match = "The ftp password and confirmation password did not match.";
        public static string de_ftp_password_no_match = "Das FTP-Passwort und das Bestätigungspasswort stimmen nicht überein.";

        public static string en_db_password_no_match = "The database password and confirmation password did not match.";
        public static string de_db_password_no_match = "Das Datenbankkennwort und das Bestätigungskennwort stimmen nicht überein.";

        public static string en_con_suf = "Connection Successful";
        public static string de_con_suf = "Verbindung erfolgreich";

        public static string en_ftp_con_error = "Can not connect the ftp.\n";
        public static string de_ftp_con_error = "Das FTP kann nicht angeschlossen werden.\n";

        public static string en_db_con_error = "Can not connect the database.";
        public static string de_db_con_error = "Kann die Datenbank nicht verbinden.";

        public static string en_empty_field = "Please enter the empty field.";
        public static string de_empty_field = "Bitte geben Sie das leere Feld ein.";
    }
}
