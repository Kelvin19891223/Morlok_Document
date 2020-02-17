using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO;
using Bunifu.Framework.UI;
using ZedGraph;
using System.Reflection;

namespace Morlok
{
    public partial class MainFrm : Form
    {
        [Browsable(true)]
        [Description("Occurs when current UI culture is changed")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Property Changed")]

        public event EventHandler CultureChanged;

        protected CultureInfo culture;
        protected ComponentResourceManager resManager;
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //DateTimePicker dtp = new DateTimePicker();
        Rectangle _rectangle;
        public MainFrm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            change_lang(MainApp.g_setting.lang);
            refresh_patient_grid("");
            //dtp.Format = DateTimePickerFormat.Custom;
            //chronic_form_grid.Controls.Add(dtp);
            //dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            chronic_form_grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            symptoms_grid.DoubleBuffered(true);
            symptoms_grid1.DoubleBuffered(true);
            Gnostice.Documents.Framework.ActivateLicense("9FF1-3795-0499-1670-D8B7-5731-E636-0FAE-07C9-EC81-335B-752E");
            
        }


        // Borderless resize
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                btn_maximize.Image = Properties.Resources.Restore_Window_50px;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btn_maximize.Image = Properties.Resources.Maximize_Window_50px;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_en_Click(object sender, EventArgs e)
        {
            change_lang("en");
        }

        private void btn_de_Click(object sender, EventArgs e)
        {
            change_lang("de");
        }

        void select_panel(string name)
        {
            Bunifu.Framework.UI.BunifuFlatButton[] btns = new Bunifu.Framework.UI.BunifuFlatButton[] { mnu_patient, mnu_chronic, mnu_anamnesis, mnu_symptoms, mnu_diagnostic, mnu_treatment, mnu_scanned };
            foreach (var btn in btns)
                btn.selected = false;

            switch (name)
            {
                case "patient":
                    panel_patient.BringToFront();
                    mnu_patient.selected = true;
                    lab_header.Text = mnu_patient.Text.Trim();
                    break;
                case "chronic":
                    panel_chronic.BringToFront();
                    mnu_chronic.selected = true;
                    lab_header.Text = mnu_chronic.Text.Trim();
                    break;
                case "anamnesis":
                    panel_anamnesis.BringToFront();
                    mnu_anamnesis.selected = true;
                    lab_header.Text = mnu_anamnesis.Text.Trim();
                    break;
                case "symptoms":
                    panel_symptoms.BringToFront();
                    mnu_symptoms.selected = true;
                    lab_header.Text = mnu_symptoms.Text.Trim();
                    break;
                case "diagnostic":
                    panel_diagnostic.BringToFront();
                    mnu_diagnostic.selected = true;
                    lab_header.Text = mnu_diagnostic.Text.Trim();
                    break;
                case "treatment":
                    panel_treatment.BringToFront();
                    mnu_treatment.selected = true;
                    lab_header.Text = mnu_treatment.Text.Trim();
                    break;
                case "scan":
                    panel_scan.BringToFront();
                    mnu_scanned.selected = true;
                    lab_header.Text = mnu_scanned.Text.Trim();
                    break;
            }
        }
        void change_lang(string lang)
        {
            string[] en_patient_label = { "Name", "Surname", "Birthday", "Insurance", "Company Name", "Main symptom", "Referral","Profession","Doctor" };
            string[] de_patient_label = { "Name", "Vorname", "Geburtstag", "Versicherung", "Name der Firma", "Hauptsymptom", "Überweiser", "Beruf","Doktor" };
            
            string[] patient_label = new String[en_patient_label.Length];
            string[] treatment_label = new String[MessagePropertys.en_treatment_label.Length];
            string[] diagnostics_checkbox = new String[MessagePropertys.en_diagnostics_checkbox.Length];
            int selectedindex;
            switch (lang)
            {
                case "en":
                    bar_lang.Left = btn_en.Left;
                    search_label.Text = "Search";
                    search_btn.Text = "Search";
                    // menu
                    mnu_patient.Text = "   Patient";
                    mnu_chronic.Text = "   Chronic";
                    mnu_anamnesis.Text = "   Anamnesis";
                    mnu_symptoms.Text = "   Symptoms";
                    mnu_diagnostic.Text = "   Diagnostic";
                    mnu_treatment.Text = "   Treatment";
                    mnu_scanned.Text = "   Scanned Forms";

                    //set label
                    patient_label = en_patient_label;
                    treatment_label = MessagePropertys.en_treatment_label;
                    patient_button_save.Text = "Add";                    
                    patient_update_button.Text = "Update";
                    diagnostics_checkbox = MessagePropertys.en_diagnostics_checkbox;
                    

                    //treatment title                    
                    MainApp.language = "en";
                    //treatment_save_btn.Text = "SAVE";
                    treatment_group_1.Text = "In Office";
                    treatment_group_2.Text = "Out of Office";
                    patient_button_new.Text = "New";

                    //patient grid title                    
                    patient_grid.Columns[1].HeaderText = "Name";
                    patient_grid.Columns[2].HeaderText = "Surname";
                    patient_grid.Columns[3].HeaderText = "Birthday";
                    patient_grid.Columns[4].HeaderText = "Remarks";
                    patient_checkbox_bei.Visible = true;

                    selectedindex = patient_insurance.SelectedIndex;
                    patient_insurance.Items.Clear();
                    patient_insurance.Items.Add("Social");
                    patient_insurance.Items.Add("Private");
                    patient_insurance.Items.Add("Supplementary");
                    patient_insurance.SelectedIndex = selectedindex;

                    //chronic
                    chronic_label1.Text = "Diagnostic";
                    chronic_label2.Text = "Treatment";
                    chronic_btn.Text = "SAVE";
                    chronic_form_grid.Columns[1].HeaderText = "Date";
                    chronic_form_grid.Columns[2].HeaderText = "Input";
                    chronic_form_grid.Columns[3].HeaderText = "Remarks";
                    chronic_grid_add_btn.Text = "ADD";
                    chronic_template.Text = "TEMPLATE";
                    chronic_print.Text = "PRINT";
                    //diagnostics
                    //diagnostic_form_button.Text = "SAVE";
                    //top menu user info

                    //scanform
                    scan_anamnesis_btn.Text = "Upload";
                    scan_special_questions_btn.Text = "Upload";
                    scan_tmj_btn.Text = "Upload";
                    scan_snoring_anamnesis_btn.Text = "Upload";
                    scan_snoring_recall_btn.Text = "Upload";
                    scan_result_btn.Text = "Upload";
                    //anamnesis
                    anamnesis_tab.Text = "Anamnesis";
                    special_questions_tab.Text = "Special questions";
                    tmj_anamnesis_tab.Text = "TMJ Anamnesis";
                    snoring_anamnesis_tab.Text = "Snoring Anamnesis";
                    snoring_recall_tab.Text = "Snoring Recall";
                    result_tab.Text = "Results";

                    anamnesis_radio_anamnesis.Text = "Anamnesis";
                    anamnesis_radio_special.Text = "Special questions";
                    anamnesis_radio_tmj.Text = "TMJ Anamnesis";
                    anamnesis_radio_snoring_anamnesis.Text = "Snoring Anamnesis";
                    anamnesis_radio_snoring_recall.Text = "Snoring Recall";
                    anamnesis_radio_result.Text = "Results";
                    //symptoms
                    symptoms_grid.Columns[1].HeaderText = "In this scale please document the actual situation";
                    symptom_btn_save.Text = "SAVE";

                    anamnesis_radio_all.Text = "Show All";
                    scan_radio_all.Text = "Show All";
                    //scan right menu
                    removeFromListToolStripMenuItem.Text = "Remove from list";
                    if (MainApp.user_id == "")
                        user_name.Text = MessagePropertys.en_no_select;
                    break;
                case "de":
                    bar_lang.Left = btn_de.Left;
                    search_label.Text = "Suche";
                    search_btn.Text = "Suche";
                    // menu
                    mnu_patient.Text = "   Patient";
                    mnu_chronic.Text = "   Chronik";
                    mnu_anamnesis.Text = "   Anamnese";
                    mnu_symptoms.Text = "   Symptome";
                    mnu_diagnostic.Text = "   Diagnostik";
                    mnu_treatment.Text = "   Behandlung";
                    mnu_scanned.Text = "   Gescannte Formulare";

                    //set label
                    patient_label = de_patient_label;
                    treatment_label = MessagePropertys.de_treatment_label;
                    patient_button_save.Text = "Hinzufügen";
                    patient_update_button.Text = "Aktualisieren";
                    diagnostics_checkbox = MessagePropertys.de_diagnostics_checkbox;
                    patient_button_new.Text = "Neu";

                    //chronic
                    chronic_form_grid.Columns[1].HeaderText = "Datum";
                    chronic_form_grid.Columns[2].HeaderText = "Eingabe";
                    chronic_form_grid.Columns[3].HeaderText = "Bemerkungen";
                    chronic_template.Text = "VORLAGE";
                    chronic_grid_add_btn.Text = "HINZUFÜGEN";
                    chronic_print.Text = "Drucken";
                    //treatment title
                    MainApp.language = "de";

                    //patient grid title
                    patient_grid.Columns[1].HeaderText = "Name";
                    patient_grid.Columns[2].HeaderText = "Vorname";
                    patient_grid.Columns[3].HeaderText = "Geburtstag";
                    patient_grid.Columns[4].HeaderText = "Bemerkungen";
                    chronic_label1.Text = "Diagnostik";
                    chronic_label2.Text = "Behandlung";
                    chronic_btn.Text = "SICHERN";
                    patient_checkbox_bei.Visible = false;

                    selectedindex = patient_insurance.SelectedIndex;
                    patient_insurance.Items.Clear();
                    patient_insurance.Items.Add("Gesetzlich");
                    patient_insurance.Items.Add("Privat");
                    patient_insurance.Items.Add("Zusatzversicherung");
                    patient_insurance.SelectedIndex = selectedindex;

                    //treatment
                    //treatment_save_btn.Text = "SICHERN";
                    treatment_group_1.Text = "In der Praxis";
                    treatment_group_2.Text = "Interdisziplinär";                    

                    //diagnostics
                    //diagnostic_form_button.Text = "SICHERN";

                    //anamnesis
                    anamnesis_tab.Text = "Anamnese";
                    special_questions_tab.Text = "Spezialfragen";
                    tmj_anamnesis_tab.Text = "CMD Anamnese";
                    snoring_anamnesis_tab.Text = "Schnarchanamnese";
                    snoring_recall_tab.Text = "Schnarchrecall";
                    result_tab.Text = "Befunde";

                    anamnesis_radio_anamnesis.Text = "Anamnese";
                    anamnesis_radio_special.Text = "Spezialfragen";
                    anamnesis_radio_tmj.Text = "CMD Anamnese";
                    anamnesis_radio_snoring_anamnesis.Text = "Schnarchanamnese";
                    anamnesis_radio_snoring_recall.Text = "Schnarchrecall";
                    anamnesis_radio_result.Text = "Befunde";
                    //scanform
                    scan_anamnesis_btn.Text = "Hochladen";
                    scan_special_questions_btn.Text = "Hochladen";
                    scan_tmj_btn.Text = "Hochladen";
                    scan_snoring_anamnesis_btn.Text = "Hochladen";
                    scan_snoring_recall_btn.Text = "Hochladen";
                    scan_result_btn.Text = "Hochladen";
                    //symptom
                    symptoms_grid.Columns[1].HeaderText = "In dieser Skala bitte die jetzige Situation dokumentieren";
                    symptom_btn_save.Text = "SICHERN";
                    //scan right menu
                    removeFromListToolStripMenuItem.Text = "Aus der Liste entfernen";

                    anamnesis_radio_all.Text = "Alle anzeigen";
                    scan_radio_all.Text = "Alle anzeigen";

                    if (MainApp.user_id == "")
                        user_name.Text = MessagePropertys.de_no_select;
                    break;
            }

            //patient
            try
            {
                for (int i = 1; i <= patient_label.Length; i++)
                {
                    System.Windows.Forms.Label label = this.Controls.Find("patient_label" + i.ToString(), true).FirstOrDefault() as System.Windows.Forms.Label;
                    label.Text = patient_label[i - 1];
                }
            } catch (Exception e)
            {
                logger.Error("Can't find patient label object");
            }

            //treatment
            try
            {                
                //treatment checkbox
                for (int i = 1; i <= treatment_label.Length; i++)
                {
                    System.Windows.Forms.Label label = this.Controls.Find("treatment_form_label_" + i.ToString(), true).FirstOrDefault() as System.Windows.Forms.Label;
                    label.Text = treatment_label[i - 1];
                }
            }
            catch (Exception e)
            {
                logger.Error("Can't find treatment object");
            }

            //diagnostics
            try
            {
                for (int i = 1; i <= diagnostics_checkbox.Length; i++)
                {
                    System.Windows.Forms.Label label = this.Controls.Find("diagnostic_form_label_" + i.ToString(), true).FirstOrDefault() as System.Windows.Forms.Label;
                    label.Text = diagnostics_checkbox[i - 1];
                }
            } catch (Exception e)
            {
                logger.Error("Can't find diagnostics object");
            }

            refresh_patient_grid(search_txt.Text);
            refresh_symptoms();
        }

        private void mnu_patient_Click(object sender, EventArgs e)
        {            
            select_panel("patient");
            refresh_patient_grid(search_txt.Text);
        }

        private void mnu_chronic_Click(object sender, EventArgs e)
        {
            select_panel("chronic");
            refresh_chronic_data();
            //dtp.Visible = false;            
        }

        private void mnu_anamnesis_Click(object sender, EventArgs e)
        {
            select_panel("anamnesis");
            anamnesis_docview.CloseDocument();
            MainApp.anamnesis_selected_radio = MainApp.scannedform_anamnesis;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_anamnesis);
            anamnesis_radio_anamnesis.Checked = true;
        }

        private void mnu_symptoms_Click(object sender, EventArgs e)
        {
            select_panel("symptoms");
            refresh_symptoms();
            symptom_grid1_label.Text = symptoms_grid1.Rows[0].Cells[1].Value.ToString();
            drawSymptomGraph1(symptoms_grid1.Rows[0].Cells[1].Value.ToString());

            symptom_grid_label.Text = symptoms_grid.Rows[0].Cells[1].Value.ToString();
            drawSymptomGraph(symptoms_grid.Rows[0].Cells[1].Value.ToString());

            MainApp.symptom_graph_id_2 = symptoms_grid1.Rows[0].Cells[1].Value.ToString();
            MainApp.symptom_graph_id_1 = symptoms_grid.Rows[0].Cells[1].Value.ToString();
        }

        private void mnu_diagnostic_Click(object sender, EventArgs e)
        {
            select_panel("diagnostic");
            refresh_userinfo(MainApp.user_id);
        }

        private void mnu_treatment_Click(object sender, EventArgs e)
        {
            select_panel("treatment");
            refresh_userinfo(MainApp.user_id);
        }

        private void mnu_scanned_Click(object sender, EventArgs e)
        {
            select_panel("scan");
            refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
            scanform_snoring_recall_viewer.CloseDocument();
            scanform_snoring_anamnesis_viewer.CloseDocument();
            scanform_tmj_viewer.CloseDocument();
            scanform_anamnesis_viewer.CloseDocument();
            scanform_special_viewer.CloseDocument();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            if (menu_pane.Width == 220)
            {
                menu_pane.Width = 50;
            }
            else
            {
                menu_pane.Width = 220;
            }
        }

        private void patient_button_save_Click(object sender, EventArgs e)
        {
            //get value from UI
            string name = patient_textbox_name.Text;
            string surname = patient_textbox_surname.Text;
            string birthday = patient_birthday.Value.ToShortDateString();
            string company_name = patient_textbox_company.Text;
            string insurance = patient_insurance.SelectedIndex.ToString();
            string profession = patient_textbox_profession.Text;
            string bei = patient_checkbox_bei.Checked?"1":"0";
            if (MainApp.language == "de")
                bei = "0";
            
            string main_symptom = patient_textbox_main_symptom.Text;
            string refeeral = patient_textbox_referral.Text;
            string doctor = patient_textbox_doctor.Text;

            if (name == null || surname == null || birthday == null || name.Length == 0 || surname.Length == 0 || birthday.Length == 0 || profession.Length == 0 || doctor.Length == 0)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_userinfo_empty);
                else
                    MessageBox.Show(MessagePropertys.de_userinfo_empty);
                return;
            }

            //insert value to mysql
            int result = MainApp.g_mysql.insert_user(name, surname, birthday, insurance, company_name, main_symptom, refeeral, bei, profession, doctor);

            if (result != -1)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);
                refresh_patient_grid(search_txt.Text);

                MainApp.user_id = result.ToString();// patient_grid.Rows[patient_grid.Rows.Count - 1].Cells[MainApp.patient_column_id].Value.ToString();
                for (int i = 0; i < patient_grid.Rows.Count; i++)
                    if (patient_grid.Rows[i].Cells[0].Value.ToString() == result.ToString())
                        MainApp.user_index = i;
                //MainApp.user_index = patient_grid.Rows.Count - 1;
                refresh_userinfo(MainApp.user_id);
                refresh_patient_grid(search_txt.Text);
            } else
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
            }

            //update grid            
            patient_textbox_name.Text = "";
            patient_textbox_surname.Text = "";
            patient_birthday.Value = DateTime.Today.AddDays(-1);
            patient_textbox_company.Text = "";
            patient_insurance.Text = "";
            patient_textbox_main_symptom.Text = "";
            patient_textbox_referral.Text = "";
            patient_checkbox_bei.Checked = false;
        }       

        public void refresh_patient_grid(String searchTmp)
        {
            DataTable dt = MainApp.g_mysql.getAllUserInfo(searchTmp);
            
            if (dt != null)
            {
                patient_grid.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    patient_grid.Rows.Add(dt.Rows[i]["user_id"], dt.Rows[i]["name"].ToString(), dt.Rows[i]["surname"].ToString(), dt.Rows[i]["birthday"].ToString());
                    patient_grid.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    if(MainApp.user_id == dt.Rows[i]["user_id"].ToString())
                    {
                        patient_grid.Rows[i].Selected = true;
                        patient_grid.CurrentCell = patient_grid.Rows[i].Cells[1];
                    }
                }
            }
        }

        private void patientGridView_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //click delete button
            if(e.ColumnIndex == MainApp.patient_column_delete && e.RowIndex < patient_grid.Rows.Count)
            {
                string id = patient_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                MainApp.g_mysql.deleteUserInfo(id);
                if(MainApp.user_id == id)
                {
                    MainApp.user_id = "";
                    
                }
                refresh_userinfo(MainApp.user_id);
                refresh_patient_grid(search_txt.Text);
                return;
            }

            //click choose button
            //if (e.ColumnIndex == MainApp.patient_column_choose && e.RowIndex < patient_grid.Rows.Count)
            if(patient_grid.Rows.Count > 0)
            {
                string id = patient_grid.Rows[e.RowIndex].Cells[MainApp.patient_column_id].Value.ToString();
                string name = patient_grid.Rows[e.RowIndex].Cells[MainApp.patient_column_name].Value.ToString();
                MainApp.user_id = id;
                MainApp.user_index = e.RowIndex;
                refresh_userinfo(MainApp.user_id);
            }            
        }

        private void refresh_userinfo(string id)
        {            
            try
            {
                //init scanned form
                MainApp.username = "";
                DataTable dt = MainApp.g_mysql.getUserInfo(id);
                if (dt != null)
                {
                    patient_textbox_name.Text = dt.Rows[0]["name"].ToString();
                    patient_textbox_surname.Text = dt.Rows[0]["surname"].ToString();
                    string birth = dt.Rows[0]["birthday"].ToString();
                    patient_birthday.Value = Convert.ToDateTime(birth);
                    patient_textbox_company.Text = dt.Rows[0]["company_name"].ToString();
                    patient_textbox_profession.Text = dt.Rows[0]["profession"].ToString();
                    patient_textbox_doctor.Text = dt.Rows[0]["doctor"].ToString();
                    if(dt.Rows[0]["insurance"].ToString() == "1")
                    {
                        patient_insurance.SelectedIndex = 1;
                    } else if (dt.Rows[0]["insurance"].ToString() == "0")
                    {
                        patient_insurance.SelectedIndex = 0;
                    } else if (dt.Rows[0]["insurance"].ToString() == "2")
                    {
                        patient_insurance.SelectedIndex = 2;
                    }

                    patient_textbox_main_symptom.Text = dt.Rows[0]["main_symptom"].ToString();
                    patient_textbox_referral.Text = dt.Rows[0]["referral"].ToString();
                    if (dt.Rows[0]["beihilfe"].ToString() == "1")
                        patient_checkbox_bei.Checked = true;
                    else
                        patient_checkbox_bei.Checked = false;
                    MainApp.username = dt.Rows[0]["name"].ToString() + "  " + dt.Rows[0]["surname"].ToString() + "  " + dt.Rows[0]["birthday"].ToString();
                }

                user_name.Text = MainApp.username;
                if (MainApp.user_id == "")
                {
                    
                    if (MainApp.language == "en")
                        user_name.Text = MessagePropertys.en_no_select;
                    else
                        user_name.Text = MessagePropertys.de_no_select;
                    return;
                }

                DataTable treatment = MainApp.g_mysql.getTreatment(MainApp.user_id);                
                if(treatment != null && treatment.Rows.Count > 0)
                {
                    for (int i = 1; i <= 37; i++)
                    {
                        BunifuCheckbox checkbox = this.Controls.Find("treatment_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                        if (treatment.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "1" || treatment.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2")
                            checkbox.Checked = true;
                        else
                            checkbox.Checked = false;
                    }
                    
                    for (int i = 1; i <= 19; i++)
                    {
                        TextBox txtbox = this.Controls.Find("treatment_form_txt_" + i.ToString(), true).FirstOrDefault() as TextBox;
                        txtbox.Text = treatment.Rows[0][string.Format("txt_{0}",i.ToString())].ToString();
                    }

                    if (treatment_form_checkbox_5.Checked)
                        treatment_form_txt_1.Enabled = true;
                    else
                        treatment_form_txt_1.Enabled = false;

                    if (treatment_form_checkbox_7.Checked)
                        treatment_form_txt_2.Enabled = true;
                    else
                        treatment_form_txt_2.Enabled = false;

                    if (treatment_form_checkbox_9.Checked)
                        treatment_form_txt_4.Enabled = true;
                    else
                        treatment_form_txt_4.Enabled = false;

                    if (treatment_form_checkbox_17.Checked)
                        treatment_form_txt_5.Enabled = true;
                    else
                        treatment_form_txt_5.Enabled = false;

                    if (treatment_form_checkbox_19.Checked)
                        treatment_form_txt_6.Enabled = true;
                    else
                        treatment_form_txt_6.Enabled = false;

                    for(int i=23; i<=36; i++)
                    {
                        BunifuCheckbox checkbox = this.Controls.Find("treatment_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                        TextBox txt = this.Controls.Find("treatment_form_txt_" + (i-16).ToString(), true).FirstOrDefault() as TextBox;
                        if (checkbox.Checked)
                            txt.Enabled = true;
                        else
                            txt.Enabled = false;
                    }
                    
                } else
                {
                    for (int i = 1; i <= 37; i++)
                    {
                        BunifuCheckbox checkbox = this.Controls.Find("treatment_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                        checkbox.Checked = false;
                    }

                    for (int i = 1; i <= 20; i++)
                    {
                        TextBox txtbox = this.Controls.Find("treatment_form_txt_" + i.ToString(), true).FirstOrDefault() as TextBox;
                        txtbox.Enabled = false;
                        txtbox.Text = "";
                    }
                }


                DataTable diagnostic = MainApp.g_mysql.getDiagnostic(MainApp.user_id);
                if (diagnostic != null && diagnostic.Rows.Count > 0)
                {
                    for (int i = 1; i < 28; i++)
                    {
                        BunifuCheckbox checkbox = this.Controls.Find("diagnostic_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                        if (diagnostic.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "1" || diagnostic.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2") 
                            checkbox.Checked = true;
                        else
                            checkbox.Checked = false;
                    }

                    if (diagnostic_form_checkbox_11.Checked)
                    {
                        diagnostic__fbs_txt.Enabled = true;
                        diagnostic__fbs_txt.Text = diagnostic.Rows[0]["fbs_txt"].ToString();
                    } else
                    {
                        diagnostic_mjt_txt.Text = "";
                        diagnostic_mjt_txt.Enabled = false;
                    }
                    if (diagnostic_form_checkbox_13.Checked)
                    {
                        diagnostic_mjt_txt.Enabled = true;
                        diagnostic_mjt_txt.Text = diagnostic.Rows[0]["mrt_txt"].ToString();
                    } else
                    {
                        diagnostic_mjt_txt.Enabled = false;
                        diagnostic_mjt_txt.Text = "";
                    }
                }
                else
                {
                    for (int i = 1; i <= 27; i++)
                    {
                        BunifuCheckbox checkbox = this.Controls.Find("diagnostic_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                        checkbox.Checked = false;
                    }
                    diagnostic_mjt_txt.Enabled = false;
                    diagnostic__fbs_txt.Enabled = false;
                    diagnostic_mjt_txt.Text = "";
                    diagnostic__fbs_txt.Text = "";
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void patient_update_button_Click(object sender, EventArgs e)
        {
            //get value from UI
            string name = patient_textbox_name.Text;
            string surname = patient_textbox_surname.Text;
            string birthday = patient_birthday.Value.ToShortDateString();
            string insurance = patient_insurance.SelectedIndex.ToString();
            string company_name = patient_textbox_company.Text;
            string bei = patient_checkbox_bei.Checked ? "1" : "0";
            string profession = patient_textbox_profession.Text;
            string doctor = patient_textbox_doctor.Text;
            if (MainApp.language == "de")
                bei = "0";
            string main_symptom = patient_textbox_main_symptom.Text;
            string refeeral = patient_textbox_referral.Text;
            string id = MainApp.user_id;

            if(id == null || id.Length == 0)
            {
                if(MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }

            if (name == null || surname == null || birthday == null || name.Length == 0 || surname.Length == 0 || birthday.Length == 0 || profession.Length == 0 || doctor.Length == 0)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_userinfo_empty);
                else
                    MessageBox.Show(MessagePropertys.de_userinfo_empty);

                return;
            }
         
            if (MainApp.g_mysql.update_user(name, surname, birthday, insurance, company_name, main_symptom, refeeral,id, bei, profession, doctor))
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);   
                refresh_userinfo(MainApp.user_id);
            }
            else
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
            }

            //update grid
            refresh_patient_grid(search_txt.Text);
        }
        
        public void save_diagnostic()
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);

                return;
            }

            DataTable row = MainApp.g_mysql.getDiagnostic(MainApp.user_id);
            string[] data = new string[27];
            for (int i = 1; i <= 27; i++)
            {
                BunifuCheckbox checkbox = panel_diagnostic.Controls.Find("diagnostic_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                data[i - 1] = checkbox.Checked ? "1" : "0";
                if(checkbox.Checked)
                {
                    if(row.Rows[0][i].ToString() == "2")
                    {
                        data[i - 1] = "2";
                    }
                }
            }

            
            string fbs = diagnostic__fbs_txt.Text;
            string mrt = diagnostic_mjt_txt.Text;
            MainApp.g_mysql.delete_diagnostics(MainApp.user_id);
            if (MainApp.g_mysql.insert_diagnostics(data, MainApp.user_id, fbs, mrt))
            {
                //if (MainApp.language == "en")
                //    MessageBox.Show(MessagePropertys.en_success);
                //else
                //    MessageBox.Show(MessagePropertys.de_success);
            }
        }
        private void diagnostic_form_btn_Click(object sender, EventArgs e)
        {
            //if (MainApp.user_id == "")
            //{
            //    if (MainApp.language == "en")
            //        MessageBox.Show(MessagePropertys.en_select_alert);
            //    else
            //        MessageBox.Show(MessagePropertys.de_select_alert);

            //    return;
            //}

            //string[] data = new string[27];
            //for (int i = 1; i <= 27; i++)
            //{
            //    BunifuCheckbox checkbox = panel_diagnostic.Controls.Find("diagnostic_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
            //    data[i - 1] = checkbox.Checked ? "1" : "0";
            //}

            //string fbs = diagnostic__fbs_txt.Text;
            //string mrt = diagnostic_mjt_txt.Text;
            //MainApp.g_mysql.delete_diagnostics(MainApp.user_id);
            //if (MainApp.g_mysql.insert_diagnostics(data, MainApp.user_id,fbs,mrt))
            //{
            //    if (MainApp.language == "en")
            //        MessageBox.Show(MessagePropertys.en_success);
            //    else
            //        MessageBox.Show(MessagePropertys.de_success);
            //}
            save_diagnostic();
        }

        public byte[] fileRead(string filename)
        {
            FileStream imgStream = File.OpenRead(filename);
            byte[] blob = new byte[imgStream.Length];
            imgStream.Read(blob, 0, (int)imgStream.Length);
            imgStream.Dispose();
            return blob;
        }
        
        public void refresh_scannedForm_Imagelist(string type)
        {            
            string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
            if (scan_radio_all.Checked)
                date = "";
            DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, type, date);

            if (dt != null)
            {
                ListView tmp;
                if (type == MainApp.scannedform_anamnesis)
                {
                    scan_anamnesis_listview.Items.Clear();
                    tmp = scan_anamnesis_listview;
                }
                else if (type == MainApp.scannedform_special)
                {
                    scan_special_questions_listview.Items.Clear();
                    tmp = scan_special_questions_listview;
                }
                else if (type == MainApp.scannedform_tmj)
                {
                    scan_tmj_listview.Items.Clear();
                    tmp = scan_tmj_listview;
                }
                else if (type == MainApp.scannedform_snoring_anamnesis)
                {
                    scan_snoring_anamnesis_listview.Items.Clear();
                    tmp = scan_snoring_anamnesis_listview;
                }
                else if(type == MainApp.scannedform_snoring_recall)
                {
                    scan_snoring_recall_listview.Items.Clear();
                    tmp = scan_snoring_recall_listview;
                }
                else
                {
                    scan_result_listview.Items.Clear();
                    tmp = scan_result_listview;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["filetype"].ToString() == ".pdf")
                    {
                        tmp.Items.Add(string.Format("{0} ({1})", dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 1);
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".doc" || dt.Rows[i]["filetype"].ToString() == ".docx")
                    {
                        tmp.Items.Add(string.Format("{0} ({1})", dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 2);
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".jpg" || dt.Rows[i]["filetype"].ToString() == ".jpeg" || dt.Rows[i]["filetype"].ToString() == ".png")
                    {
                        tmp.Items.Add(string.Format("{0} ({1})", dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 0);
                    }
                }              
            }
        }

        private void scan_anamnesis_btn_Click(object sender, EventArgs e)
        {
            string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_anamnesis, Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if(id != "")
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }

        private void scan_anamnesis_item_change(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_anamnesis,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_anamnesis_viewer.CloseDocument();
                    scanform_anamnesis_viewer.LoadDocument(ms);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void scan_special_questions_btn_Click(object sender, EventArgs e)
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_special,Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_special);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if (id != "")                        
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }        

        private void scan_tab_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
                refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
            else if (e.TabPageIndex == 1)
                refresh_scannedForm_Imagelist(MainApp.scannedform_special);
            else if (e.TabPageIndex == 2)
                refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
            else if (e.TabPageIndex == 3)
                refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
            else if (e.TabPageIndex == 4)
                refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
            else if (e.TabPageIndex == 5)
                refresh_scannedForm_Imagelist(MainApp.scannedform_result);
        }

        private void scan_tmj_btn_Click(object sender, EventArgs e)
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_tmj,Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if (id != "")
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }

        private void scan_snoring_anamnesis_btn_Click(object sender, EventArgs e)
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_snoring_anamnesis,Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if (id != "")
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }

        private void scan_snoring_recall_btn_Click(object sender, EventArgs e)
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_snoring_recall,Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if (id != "")
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }

        private void scan_special_questions_item_change(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_special,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_special_viewer.CloseDocument();
                    scanform_special_viewer.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void scan_tmj_item_change(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_tmj,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_tmj_viewer.CloseDocument();
                    scanform_tmj_viewer.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void scan_snoring_anamnesis_item_change(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_snoring_anamnesis,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_snoring_anamnesis_viewer.CloseDocument();
                    scanform_snoring_anamnesis_viewer.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void scan_snoring_recall_item_change(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_snoring_recall,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_snoring_recall_viewer.CloseDocument();
                    scanform_snoring_recall_viewer.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void anamnesis_radio_anamnesis_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_anamnesis;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_anamnesis);
        }

        private void anamnesis_radio_special_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_special;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_special);
        }

        private void anamnesis_radio_tmj_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_tmj;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_tmj);
        }

        private void anamnesis_radio_snoring_anamnesis_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_anamnesis;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_anamnesis);
        }

        private void anamnesis_radio_snoring_recall_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_recall;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_recall);
        }

        public void refresh_anamnesis_form_Imagelist(string type)
        {
            string date = anamnesis_datepicker.Value.ToString("yyyy-MM-dd");
            if (anamnesis_radio_all.Checked)
                date = "";
            DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, type,date);

            if (dt != null)
            {
                anamnesis_form_listview.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["filetype"].ToString() == ".pdf")
                    {
                        anamnesis_form_listview.Items.Add(string.Format("{0} ({1})",dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 1);                        
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".doc" || dt.Rows[i]["filetype"].ToString() == ".docx")
                    {
                        anamnesis_form_listview.Items.Add(string.Format("{0} ({1})", dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 2);                        
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".jpg" || dt.Rows[i]["filetype"].ToString() == ".jpeg" || dt.Rows[i]["filetype"].ToString() == ".png")
                    {
                        anamnesis_form_listview.Items.Add(string.Format("{0} ({1})", dt.Rows[i]["filename"].ToString(), dt.Rows[i]["fdate"].ToString()), 0);                        
                    }
                }
            }         
        }

        private void anamnesis_form_listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = anamnesis_datepicker.Value.ToString("yyyy-MM-dd");
                    if (anamnesis_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.anamnesis_selected_radio,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    anamnesis_docview.CloseDocument();
                    anamnesis_docview.LoadDocument(ms);

                }
            }
            catch (Exception ex)
            {

            }
        }

        //treatment input
        private void treatment_dental_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_5.Checked)
                treatment_form_txt_1.Enabled = true;
            else
            {
                treatment_form_txt_1.Enabled = false;
                treatment_form_txt_1.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_7_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_7.Checked)
                treatment_form_txt_2.Enabled = true;
            else
            {
                treatment_form_txt_2.Enabled = false;
                treatment_form_txt_2.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_8_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_9.Checked)
                treatment_form_txt_4.Enabled = true;
            else
            {
                treatment_form_txt_4.Enabled = false;
                treatment_form_txt_4.Text = "";
            }
            treatment_save();
        }
        private void treatment_form_checkbox_16_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_17.Checked)
                treatment_form_txt_5.Enabled = true;
            else
            {
                treatment_form_txt_5.Enabled = false;
                treatment_form_txt_5.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_18_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_19.Checked)
                treatment_form_txt_6.Enabled = true;
            else
            {
                treatment_form_txt_6.Enabled = false;
                treatment_form_txt_6.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_22_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_23.Checked)
                treatment_form_txt_7.Enabled = true;
            else
            {
                treatment_form_txt_7.Enabled = false;
                treatment_form_txt_7.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_23_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_24.Checked)
                treatment_form_txt_8.Enabled = true;
            else
            {
                treatment_form_txt_8.Enabled = false;
                treatment_form_txt_8.Text = "";
            }
            treatment_save();
        }
        private void treatment_form_checkbox_24_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_25.Checked)
                treatment_form_txt_9.Enabled = true;
            else
            {                
                treatment_form_txt_9.Enabled = false;
                treatment_form_txt_9.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_25_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_26.Checked)
                treatment_form_txt_10.Enabled = true;
            else
            {
                treatment_form_txt_10.Enabled = false;
                treatment_form_txt_10.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_26_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_27.Checked)
                treatment_form_txt_11.Enabled = true;
            else
            {
                treatment_form_txt_11.Enabled = false;
                treatment_form_txt_11.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_27_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_28.Checked)
                treatment_form_txt_12.Enabled = true;
            else
            {         
                treatment_form_txt_12.Enabled = false;
                treatment_form_txt_12.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_28_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_29.Checked)
                treatment_form_txt_13.Enabled = true;
            else
            {
                treatment_form_txt_13.Enabled = false;
                treatment_form_txt_13.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_29_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_30.Checked)
                treatment_form_txt_14.Enabled = true;
            else
            {
                treatment_form_txt_14.Enabled = false;
                treatment_form_txt_14.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_30_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_31.Checked)
                treatment_form_txt_15.Enabled = true;
            else
            {
                treatment_form_txt_15.Enabled = false;
                treatment_form_txt_15.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_31_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_32.Checked)
                treatment_form_txt_16.Enabled = true;
            else
            {
                treatment_form_txt_16.Enabled = false;
                treatment_form_txt_16.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_32_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_33.Checked)
                treatment_form_txt_17.Enabled = true;
            else
            {
                treatment_form_txt_17.Enabled = false;
                treatment_form_txt_17.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_33_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_34.Checked)
                treatment_form_txt_18.Enabled = true;
            else
            {
                treatment_form_txt_18.Enabled = false;
                treatment_form_txt_18.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_34_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_35.Checked)
                treatment_form_txt_19.Enabled = true;
            else
            {
                treatment_form_txt_19.Enabled = false;
                treatment_form_txt_19.Text = "";
            }
            treatment_save();
        }

        private void treatment_form_checkbox_35_OnChange(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_36.Checked)
                treatment_form_txt_20.Enabled = true;
            else
            {
                treatment_form_txt_20.Enabled = false;
                treatment_form_txt_20.Text = "";
            }
            treatment_save();
        }

        public void treatment_save()
        {
            try
            {
                if (MainApp.user_id == "")
                {
                    if (MainApp.language == "en")
                        MessageBox.Show(MessagePropertys.en_select_alert);
                    else
                        MessageBox.Show(MessagePropertys.de_select_alert);

                    return;
                }

                string[] data = new string[37];
                string[] txtdata = new string[20];
                DataTable row = MainApp.g_mysql.getTreatment(MainApp.user_id);
                for (int i = 1; i < 38; i++)
                {
                    BunifuCheckbox checkbox = this.Controls.Find("treatment_form_checkbox_" + i.ToString(), true).FirstOrDefault() as BunifuCheckbox;
                    if (checkbox.Checked)
                    {
                        if(row.Rows[0][i-1].ToString() == "2")
                            data[i - 1] = "2";
                        else
                            data[i - 1] = "1";
                    }
                    else
                        data[i - 1] = "0";
                }

                for (int i = 1; i < 21; i++)
                {
                    TextBox txtbox = this.Controls.Find("treatment_form_txt_" + i.ToString(), true).FirstOrDefault() as TextBox;
                    txtdata[i - 1] = txtbox.Text;
                }
                MainApp.g_mysql.delete_treatment(MainApp.user_id);
                MainApp.g_mysql.insert_treatment(data, txtdata, MainApp.user_id);
                //if (MainApp.language == "en")
                //    MessageBox.Show(MessagePropertys.en_success);
                //else
                //    MessageBox.Show(MessagePropertys.de_success);
            }
            catch (Exception ex)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
            }

        }

        private void treatment_save_btn_Click(object sender, EventArgs e)
        {
            treatment_save();
        }

        public void refresh_chronic_data()
        {
            chronic_form_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            if (MainApp.user_id == "")
                return;
            DataTable treatment = MainApp.g_mysql.getTreatment(MainApp.user_id);
            chronic_treatment_list.Items.Clear();
            
            if (treatment != null && treatment.Rows.Count > 0)
            {
                int count = 0;
                int[] ary = { 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
                string temp = "";
                int txtCount = 1;
                for (int i = 1; i <= 37; i++)
                {
                    temp = "";
                    if (ary[i - 1] == 1)
                    {
                        temp = treatment.Rows[0][string.Format("txt_{0}", txtCount)].ToString();
                        txtCount++;
                    }
                    if (treatment.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "1" || treatment.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2")
                    {
                        string txt = "";
                        if (MainApp.language == "en")
                            txt = MessagePropertys.en_chronic_treatment_label[i - 1];
                        else
                            txt = MessagePropertys.de_chronic_treatment_label[i - 1];

                        if (temp != "")
                            txt = txt + " [" + temp + "] ";
                        chronic_treatment_list.Items.Add(txt);                        
                        if (treatment.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2")
                            chronic_treatment_list.SetItemChecked(count, true);
                        count++;
                    }
                }
            }


            DataTable diagnostic = MainApp.g_mysql.getDiagnostic(MainApp.user_id);
            chronic_diagnostic_list.Items.Clear();
            if (diagnostic != null && diagnostic.Rows.Count > 0)
            {                
                int count = 0;
                for (int i = 1; i <= 27; i++)
                {                    
                    if (diagnostic.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "1" || diagnostic.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2")
                    {
                        string txt = "";
                        if (MainApp.language == "en")
                            txt = MessagePropertys.en_diagnostics_checkbox[i - 1];
                        else
                            txt = MessagePropertys.de_diagnostics_checkbox[i - 1];
                        
                        if (i == 11 && diagnostic.Rows[0]["fbs_txt"].ToString() != "")
                            txt = txt + " [" + diagnostic.Rows[0]["fbs_txt"] + "]";

                        if (i == 13 && diagnostic.Rows[0]["mrt_txt"].ToString() != "")
                            txt = txt + " [" + diagnostic.Rows[0]["mrt_txt"] + "]";

                        chronic_diagnostic_list.Items.Add(txt);

                        if(diagnostic.Rows[0][string.Format("check_{0}", i.ToString())].ToString() == "2")
                            chronic_diagnostic_list.SetItemChecked(count, true);
                        count++;
                    }
                }                
            }

            DataTable chronic = MainApp.g_mysql.getChronic(MainApp.user_id);
            chronic_form_grid.Rows.Clear();
            if (chronic != null && chronic.Rows.Count>0)
            {                
                for (int i=0; i<chronic.Rows.Count; i++)
                {                    
                    chronic_form_grid.Rows.Add(chronic.Rows[i]["id"].ToString(),chronic.Rows[i]["date"].ToString(), chronic.Rows[i]["input"].ToString());
                }
            }
            
            //chronic_form_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        public void save_chronic()
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            //diagnostics
            try
            {
                string[] dig_arry = new string[MessagePropertys.en_diagnostics_checkbox.Length];
                if (MainApp.language == "en")
                    dig_arry = MessagePropertys.en_diagnostics_checkbox;
                else
                    dig_arry = MessagePropertys.de_diagnostics_checkbox;

                foreach (object item in chronic_diagnostic_list.Items)
                {
                    string txt = item.ToString();
                    for (int i = 1; i <= 27; i++)
                    {
                        if (txt.StartsWith(dig_arry[i - 1]))
                        {
                            //ith txt update
                            if (chronic_diagnostic_list.CheckedItems.Contains(item))
                                MainApp.g_mysql.update_diagnostics(MainApp.user_id, i, 2);
                            else
                                MainApp.g_mysql.update_diagnostics(MainApp.user_id, i, 1);
                        }
                    }
                }

                string[] treat_arry = new string[MessagePropertys.en_treatment_label.Length];
                if (MainApp.language == "en")
                    treat_arry = MessagePropertys.en_treatment_label;
                else
                    treat_arry = MessagePropertys.de_treatment_label;

                foreach (object item in chronic_treatment_list.Items)
                {
                    string txt = item.ToString();
                    for (int i = 1; i <= treat_arry.Length; i++)
                    {
                        int index = txt.LastIndexOf("(");

                        if (index != -1)
                        {
                            if (treat_arry[i - 1].StartsWith(txt.Substring(0, index)))
                            {
                                if (chronic_treatment_list.CheckedItems.Contains(item))
                                    MainApp.g_mysql.update_treatment(MainApp.user_id, i, 2);
                                else
                                    MainApp.g_mysql.update_treatment(MainApp.user_id, i, 1);

                            }
                        }
                        else
                        {
                            if (txt.IndexOf(treat_arry[i - 1]) == 0)
                            {
                                if (chronic_treatment_list.CheckedItems.Contains(item))
                                    MainApp.g_mysql.update_treatment(MainApp.user_id, i, 2);
                                else
                                    MainApp.g_mysql.update_treatment(MainApp.user_id, i, 1);
                            }
                        }
                    }
                }

                /*MainApp.g_mysql.deleteChronic(MainApp.user_id);
                for (int i = 0; i < chronic_form_grid.Rows.Count; i++)
                {
                    string a = chronic_form_grid.Rows[i].Cells[1].Value!=null?chronic_form_grid.Rows[i].Cells[1].Value.ToString():"";
                    string b = chronic_form_grid.Rows[i].Cells[2].Value!=null?chronic_form_grid.Rows[i].Cells[2].Value.ToString():"";
                    if(!(a == "" && b==""))
                        MainApp.g_mysql.setChronic(a, b, MainApp.user_id, i);
                }*/

                //if (MainApp.language == "en")
                //    MessageBox.Show(MessagePropertys.en_success);
                //else
                //    MessageBox.Show(MessagePropertys.de_success);
                //refresh_chronic_data();
            }
            catch (Exception ex)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
                logger.Info(ex.StackTrace);
            }
        }
        private void chronic_btn_Click(object sender, EventArgs e)
        {
            save_chronic();
        }

        private void header_pane_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                btn_maximize.Image = Properties.Resources.Restore_Window_50px;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btn_maximize.Image = Properties.Resources.Maximize_Window_50px;
            }
        }

        public void refresh_symptoms()
        {
            symptom_grid_label.Text = "";
            symptom_grid1_label.Text = "";
            //symptoms_grid
            symptoms_grid.Rows.Clear();
            for (int i = 0; i < MessagePropertys.en_symptoms_label.Length; i++)
            {
                if(MainApp.language == "en")
                {
                    symptoms_grid.Rows.Add(i, MessagePropertys.en_symptoms_label[i],"","","","","", "", "", "", "", "");
                } else
                {
                    symptoms_grid.Rows.Add(i, MessagePropertys.de_symptoms_label[i], "", "", "", "", "", "", "", "", "", "");
                }
            }

            symptoms_grid1.Rows.Clear();
            for (int i = 0; i < MessagePropertys.en_symptoms_label_1.Length; i++)
            {
                if (MainApp.language == "en")
                {
                    symptoms_grid1.Rows.Add(i, MessagePropertys.en_symptoms_label_1[i], "", "", "", "", "", "", "", "", "", "");
                }
                else
                {
                    symptoms_grid1.Rows.Add(i, MessagePropertys.de_symptoms_label_1[i], "", "", "", "", "", "", "", "", "", "");
                }
            }

            if (MainApp.user_id == "")
                return;

            string date = symptom_datapicker.Value.ToString("yyyy-MM-dd");

            DataTable symp = MainApp.g_mysql.getSymptoms(MainApp.user_id, date);
            if (symp != null && symp.Rows.Count > 0)
            {
                for (int i = 0; i < symp.Rows.Count; i++)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        if (symp.Rows[i][string.Format("f{0}", k)].ToString() == "1")
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.Red;
                            symptoms_grid.Rows[i].Cells[k + 2].Style = style;
                        }
                        else
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.White;
                            symptoms_grid.Rows[i].Cells[k + 2].Style = style;
                        }
                    }
                }
            }

            DataTable symp1 = MainApp.g_mysql.getSymptoms1(MainApp.user_id, date);
            if (symp1 != null && symp1.Rows.Count > 0)
            {
                for (int i = 0; i < symp1.Rows.Count; i++)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        if (symp1.Rows[i][string.Format("f{0}", k)].ToString() == "1")
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.Red;
                            symptoms_grid1.Rows[i].Cells[k + 2].Style = style;
                        }
                        else
                        {
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.BackColor = Color.White;
                            symptoms_grid1.Rows[i].Cells[k + 2].Style = style;
                        }
                    }
                }
            }
        }

        public void drawSymptomGraph(string title)
        {
            if (MainApp.user_id == "")
                return;
            symptom_grid_label.Text = title;
            DataTable dt = MainApp.g_mysql.getSymptomsByDate(MainApp.user_id,title);
            if(dt != null & dt.Rows.Count > 0)
            {
                //draw graph

                //double[] y = { 1, 2, 3, 9, 1, 15, 3, 7, 2 };
                //string[] schools = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };
                double[] y = new double[dt.Rows.Count];
                string[] date = new string[dt.Rows.Count];
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    date[i] = dt.Rows[i]["fdate"].ToString();
                    y[i] = 0;
                    for(int k=10; k>=0; k--)
                    {
                        if(dt.Rows[i][string.Format("f{0}",k)].ToString() == "1")
                        {
                            y[i] = k;
                            break;
                        }
                    }
                }

                //generate pane                
                var pane = symptom_graph.GraphPane;
                pane.CurveList.Clear();
                pane.GraphObjList.Clear();

                pane.XAxis.Scale.IsVisible = true;
                pane.YAxis.Scale.IsVisible = true;

                pane.XAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MajorGrid.IsVisible = true;

                pane.XAxis.Scale.TextLabels = date;
                pane.XAxis.Type = AxisType.Text;
                
                //var pointsCurve;

                LineItem pointsCurve = pane.AddCurve("", null, y, Color.Black);
                pointsCurve.Line.IsVisible = true;
                pointsCurve.Line.Width = 3.0F;
                //Create your own scale of colors.

                pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
                pointsCurve.Symbol.Fill.Type = FillType.Solid;
                pointsCurve.Symbol.Type = SymbolType.Circle;
                pointsCurve.Symbol.Border.IsVisible = true;
                
                pane.AxisChange();
                symptom_graph.Refresh();
            }
        }

        public void drawSymptomGraph1(string title)
        {
            if (MainApp.user_id == "")
                return;
            symptom_grid1_label.Text = title;
            DataTable dt = MainApp.g_mysql.getSymptomsByDate1(MainApp.user_id, title);
            if (dt != null & dt.Rows.Count > 0)
            {
                //draw graph

                //double[] y = { 1, 2, 3, 9, 1, 15, 3, 7, 2 };
                //string[] schools = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };
                double[] y = new double[dt.Rows.Count];
                string[] date = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    date[i] = dt.Rows[i]["fdate"].ToString();
                    y[i] = 0;
                    for (int k = 10; k >= 0; k--)
                    {
                        if (dt.Rows[i][string.Format("f{0}", k)].ToString() == "1")
                        {
                            y[i] = k;
                            break;
                        }
                    }
                }

                //generate pane                
                var pane = symptom_graph1.GraphPane;
                pane.CurveList.Clear();
                pane.GraphObjList.Clear();

                pane.XAxis.Scale.IsVisible = true;
                pane.YAxis.Scale.IsVisible = true;

                pane.XAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MajorGrid.IsVisible = true;

                pane.XAxis.Scale.TextLabels = date;
                pane.XAxis.Type = AxisType.Text;

                //var pointsCurve;

                LineItem pointsCurve = pane.AddCurve("", null, y, Color.Black);
                pointsCurve.Line.IsVisible = true;
                pointsCurve.Line.Width = 3.0F;
                //Create your own scale of colors.

                pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
                pointsCurve.Symbol.Fill.Type = FillType.Solid;
                pointsCurve.Symbol.Type = SymbolType.Circle;
                pointsCurve.Symbol.Border.IsVisible = true;

                pane.AxisChange();
                symptom_graph1.Refresh();
            }
        }
        private void symptoms_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > symptoms_grid.RowCount)
                return;

            symptom_grid_label.Text = symptoms_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            drawSymptomGraph(symptoms_grid.Rows[e.RowIndex].Cells[1].Value.ToString());
            MainApp.symptom_graph_id_1 = symptoms_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (e.ColumnIndex < 1)
                return;

            for (int i = 0; i < 11; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.White;
                symptoms_grid.Rows[e.RowIndex].Cells[i+2].Style = style;
            }

            if (e.ColumnIndex == 1)
            {
                symptom_save();
                return;
            }
            //2~12 (f0~f10)
            for (int i=0; i<e.ColumnIndex-1; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Red;
                symptoms_grid.Rows[e.RowIndex].Cells[i+2].Style = style;
            }

            symptom_save();
        }

        private void symptom_save()
        {
            try
            {
                if (MainApp.user_id == "")
                {
                    if (MainApp.language == "en")
                        MessageBox.Show(MessagePropertys.en_select_alert);
                    else
                        MessageBox.Show(MessagePropertys.de_select_alert);
                    return;
                }
                string date = symptom_datapicker.Value.ToString("yyyy-MM-dd");
                MainApp.g_mysql.deleteSymptom(MainApp.user_id, date);
                MainApp.g_mysql.deleteSymptom1(MainApp.user_id, date);
                for (int i = 0; i < symptoms_grid.Rows.Count; i++)
                {
                    string symptom = symptoms_grid.Rows[i].Cells[1].Value.ToString();
                    int[] col = new int[11];
                    for (int k = 2; k < 13; k++)
                    {
                        if (symptoms_grid.Rows[i].Cells[k].Style.BackColor == Color.Red)
                            col[k - 2] = 1;
                        else
                            col[k - 2] = 0;
                    }
                    MainApp.g_mysql.setSymptom(MainApp.user_id, symptom, col, i, date);
                }

                for (int i = 0; i < symptoms_grid1.Rows.Count; i++)
                {
                    string symptom = symptoms_grid1.Rows[i].Cells[1].Value.ToString();
                    int[] col = new int[11];
                    for (int k = 2; k < 13; k++)
                    {
                        if (symptoms_grid1.Rows[i].Cells[k].Style.BackColor == Color.Red)
                            col[k - 2] = 1;
                        else
                            col[k - 2] = 0;
                    }
                    MainApp.g_mysql.setSymptom1(MainApp.user_id, symptom, col, i, date);
                }

                /*if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);*/
                //refresh_symptoms();
                drawSymptomGraph(MainApp.symptom_graph_id_1);
                drawSymptomGraph1(MainApp.symptom_graph_id_2);
            }
            catch (Exception ex)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
            }
        }

        private void symptom_btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainApp.user_id == "")
                {
                    if (MainApp.language == "en")
                        MessageBox.Show(MessagePropertys.en_select_alert);
                    else
                        MessageBox.Show(MessagePropertys.de_select_alert);
                    return;
                }
                string date = symptom_datapicker.Value.ToString("yyyy-MM-dd");
                MainApp.g_mysql.deleteSymptom(MainApp.user_id, date);
                MainApp.g_mysql.deleteSymptom1(MainApp.user_id, date);
                for (int i = 0; i < symptoms_grid.Rows.Count; i++)
                {
                    string symptom = symptoms_grid.Rows[i].Cells[1].Value.ToString();
                    int[] col = new int[11];
                    for (int k = 2; k < 13; k++)
                    {
                        if (symptoms_grid.Rows[i].Cells[k].Style.BackColor == Color.Red)
                            col[k - 2] = 1;
                        else
                            col[k - 2] = 0;
                    }
                    MainApp.g_mysql.setSymptom(MainApp.user_id, symptom, col, i, date);
                }

                for (int i = 0; i < symptoms_grid1.Rows.Count; i++)
                {
                    string symptom = symptoms_grid1.Rows[i].Cells[1].Value.ToString();
                    int[] col = new int[11];
                    for (int k = 2; k < 13; k++)
                    {
                        if (symptoms_grid1.Rows[i].Cells[k].Style.BackColor == Color.Red)
                            col[k - 2] = 1;
                        else
                            col[k - 2] = 0;
                    }
                    MainApp.g_mysql.setSymptom1(MainApp.user_id, symptom, col, i, date);
                }

                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);
                refresh_symptoms();
                drawSymptomGraph(MainApp.symptom_graph_id_1);
                drawSymptomGraph1(MainApp.symptom_graph_id_2);
            }
            catch(Exception ex)
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_fail);
                else
                    MessageBox.Show(MessagePropertys.de_fail);
            }
        }        

        private void symptom_datapicker_onValueChanged(object sender, EventArgs e)
        {
            refresh_symptoms();
            symptom_grid1_label.Text = symptoms_grid1.Rows[0].Cells[1].Value.ToString();
            drawSymptomGraph1(symptoms_grid1.Rows[0].Cells[1].Value.ToString());

            symptom_grid_label.Text = symptoms_grid.Rows[0].Cells[1].Value.ToString();
            drawSymptomGraph(symptoms_grid.Rows[0].Cells[1].Value.ToString());
        }

        private void symptoms_grid_SelectionChanged(object sender, EventArgs e)
        {
            symptoms_grid.ClearSelection();
        }

        private void symptoms_grid1_SelectionChanged(object sender, EventArgs e)
        {
            symptoms_grid1.ClearSelection();            
        }

        private void diagnostic_form_checkbox_11_OnChange(object sender, EventArgs e)
        {
            if (diagnostic_form_checkbox_11.Checked)
                diagnostic__fbs_txt.Enabled = true;
            else
            {
                diagnostic__fbs_txt.Enabled = false;
                diagnostic__fbs_txt.Text = "";
            }
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_13_OnChange(object sender, EventArgs e)
        {
            if (diagnostic_form_checkbox_13.Checked)
                diagnostic_mjt_txt.Enabled = true;
            else
            {
                diagnostic_mjt_txt.Enabled = false;
                diagnostic_mjt_txt.Text = "";
            }
            save_diagnostic();
        }

        private void symptoms_grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > symptoms_grid1.RowCount)
                return;

            symptom_grid1_label.Text = symptoms_grid1.Rows[e.RowIndex].Cells[1].Value.ToString();
            drawSymptomGraph1(symptoms_grid1.Rows[e.RowIndex].Cells[1].Value.ToString());
            MainApp.symptom_graph_id_2 = symptoms_grid1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (e.ColumnIndex < 1)
                return;

            for (int i = 0; i < 11; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.White;
                symptoms_grid1.Rows[e.RowIndex].Cells[i + 2].Style = style;
            }

            if (e.ColumnIndex == 1)
            {
                symptom_save();
                return;
            }

            //2~12 (f0~f10)
            for (int i = 0; i < e.ColumnIndex - 1; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Red;
                symptoms_grid1.Rows[e.RowIndex].Cells[i + 2].Style = style;
            }

            symptom_save();
        }

        private void chronic_form_grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown -= new KeyEventHandler(dataGridViewTextBox_KeyDown);
            e.Control.KeyDown += new KeyEventHandler(dataGridViewTextBox_KeyDown);
        }
        public string value = "";
        private void dataGridViewTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var c = chronic_form_grid.CurrentCell;
            if (e.KeyCode == Keys.Enter && c.ColumnIndex == 2)
            {
                DataGridViewRow row = chronic_form_grid.Rows[chronic_form_grid.CurrentCell.RowIndex];
                row.Height = row.Height + 16;
            }
        }
        

        private void chronic_form_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            /*if(chronic_form_grid.Rows[e.RowIndex].Cells[1].Value != null)
                dtp.Text = chronic_form_grid.Rows[e.RowIndex].Cells[1].Value.ToString();*/

            /*if (e.ColumnIndex != 1)
                dtp.Visible = false;*/
            /*switch (chronic_form_grid.Columns[e.ColumnIndex].Name)
            {
                case "chronic_grid_date":
                    _rectangle = chronic_form_grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_rectangle.Width, _rectangle.Height);
                    dtp.Location = new Point(_rectangle.X, _rectangle.Y);
                    dtp.Visible = true;
                    break;
            }*/
            

            /*if (e.RowIndex < 0 || e.RowIndex >= (chronic_form_grid.Rows.Count-1))
                return;*/
            
            if(e.ColumnIndex == 3)
            {
                string id = chronic_form_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                MainApp.g_mysql.deleteChronicById(id);
                refresh_chronic_data();
            }

            try
            {
                string date = DateTime.Parse(chronic_form_grid.Rows[e.RowIndex].Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
                if (date == "")
                    return;
                DataTable dt = MainApp.g_mysql.getScannedFormData(date);
                chronic_listview.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string filetype = dt.Rows[i]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[i]["id"], dt.Rows[i]["filetype"]);


                    if (dt.Rows[i]["filetype"].ToString() == ".pdf")
                    {
                        chronic_listview.Items.Add(dt.Rows[i]["filename"].ToString(), 1);
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".doc" || dt.Rows[i]["filetype"].ToString() == ".docx")
                    {
                        chronic_listview.Items.Add(dt.Rows[i]["filename"].ToString(), 2);
                    }
                    else if (dt.Rows[i]["filetype"].ToString() == ".jpg" || dt.Rows[i]["filetype"].ToString() == ".jpeg" || dt.Rows[i]["filetype"].ToString() == ".png")
                    {
                        chronic_listview.Items.Add(dt.Rows[i]["filename"].ToString(), 0);
                    }
                }
            } catch(Exception ex)
            {

            }
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            /*if(chronic_form_grid.CurrentCell.ColumnIndex == 1)
                chronic_form_grid.CurrentCell.Value = dtp.Text.ToString();*/
        }

        private void chronic_form_grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dtp.Visible = false;
        }

        private void chronic_form_grid_Scroll(object sender, ScrollEventArgs e)
        {
            //dtp.Visible = false;
        }

        private void chronic_form_grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            /*chronic_form_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dtp.Visible = false;*/
        }

        private void chronic_form_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*chronic_form_grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtp.Visible = false;*/
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            SettingFrm setting_form = new SettingFrm();
            setting_form.ShowDialog();
        }

        private void scan_result_btn_Click(object sender, EventArgs e)
        {
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Anamnesis";
            dlg.Filter = "*.jpg files|*.jpg|*.png files|*.png|*.jpeg files|*.jpeg|*.pdf files|*.pdf|*.doc files|*.doc|*.docx files|*.docx";
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string id = "";
                try
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    DataTable data = MainApp.g_mysql.insertScannedForm(MainApp.user_id, MainApp.scannedform_result, Path.GetExtension(dlg.FileName).ToLower(), dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1),date);
                    id = data.Rows[0]["cnt"].ToString();
                    string name = MainApp.user_id + "_" + data.Rows[0]["cnt"].ToString() + dlg.FileName.Substring(dlg.FileName.LastIndexOf('.'));
                    MainApp.g_ftp.Upload(name, dlg.FileName);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not upload the files");
                    if (id != "")
                        MainApp.g_mysql.deleteScannedFormById(id);
                }

            }
        }

        private void scan_result_listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                    if (scan_radio_all.Checked)
                        date = "";
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_result,date);
                    string filetype = dt.Rows[e.ItemIndex]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[e.ItemIndex]["id"], dt.Rows[e.ItemIndex]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    scanform_result_viewer.CloseDocument();
                    scanform_result_viewer.LoadDocument(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void anamnesis_radio_result_CheckedChanged(object sender, EventArgs e)
        {
            MainApp.anamnesis_selected_radio = MainApp.scannedform_result;
            refresh_anamnesis_form_Imagelist(MainApp.scannedform_result);
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string date = scan_datepicker.Value.ToString("yyyy-MM-dd");
                if (scan_anamnesis_listview.SelectedItems.Count > 0)
                {
                    int index = scan_anamnesis_listview.SelectedItems[0].Index; 
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_anamnesis,date);                    
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_anamnesis_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
                }

                if (scan_special_questions_listview.SelectedItems.Count > 0)
                {
                    int index = scan_special_questions_listview.SelectedItems[0].Index;
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_special, date);
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_special_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_special);
                }

                if (scan_tmj_listview.SelectedItems.Count > 0)
                {
                    int index = scan_tmj_listview.SelectedItems[0].Index;
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_tmj, date);
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_tmj_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
                }

                if (scan_snoring_anamnesis_listview.SelectedItems.Count > 0)
                {
                    int index = scan_snoring_anamnesis_listview.SelectedItems[0].Index;
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_snoring_anamnesis, date);
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_snoring_anamnesis_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
                }

                if (scan_snoring_recall_listview.SelectedItems.Count > 0)
                {
                    int index = scan_snoring_recall_listview.SelectedItems[0].Index;
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_snoring_recall, date);
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_snoring_recall_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
                }

                if (scan_result_listview.SelectedItems.Count > 0)
                {
                    int index = scan_result_listview.SelectedItems[0].Index;
                    DataTable dt = MainApp.g_mysql.getScannedForm(MainApp.user_id, MainApp.scannedform_result, date);
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[index]["id"], dt.Rows[index]["filetype"]);
                    string id = dt.Rows[index]["id"].ToString();
                    scanform_result_viewer.CloseDocument();
                    MainApp.g_mysql.deleteScannedForm(id);
                    MainApp.g_ftp.Delete(filename);
                    refresh_scannedForm_Imagelist(MainApp.scannedform_result);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void scan_datepicker_ValueChanged(object sender, EventArgs e)
        {
            string date = anamnesis_datepicker.Value.ToString("yyyy-MM-dd");
            refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_special);
            refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
            refresh_scannedForm_Imagelist(MainApp.scannedform_result);
        }

        private void anamnesis_datepicker_ValueChanged(object sender, EventArgs e)
        {
            if(anamnesis_radio_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_anamnesis);
            }

            if (anamnesis_radio_special.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_special;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_special);
            }

            if (anamnesis_radio_tmj.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_tmj;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_tmj);
            }

            if (anamnesis_radio_snoring_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_anamnesis);
            }

            if (anamnesis_radio_snoring_recall.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_recall;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_recall);
            }

            if (anamnesis_radio_result.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_result;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_result);
            }
        }

        private void chronic_listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void chronic_listview_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var sel = chronic_listview.SelectedIndices;

                if (sel.Count == 1 && sel[0] >= 0)
                {
                    int idx = sel[0];
                    int index = chronic_form_grid.CurrentCell.RowIndex;

                    string date = DateTime.Parse(chronic_form_grid.Rows[index].Cells[1].Value.ToString()).ToString("yyyy-MM-dd");
                    DataTable dt = MainApp.g_mysql.getScannedFormData(date);
                    string filetype = dt.Rows[idx]["filetype"].ToString();
                    string filename = String.Format("{0}_{1}{2}", MainApp.user_id, dt.Rows[idx]["id"], dt.Rows[idx]["filetype"]);
                    byte[] content_ftp = MainApp.g_ftp.DownLoad(filename);
                    MemoryStream ms = new MemoryStream(content_ftp);
                    View view = new View(ms);
                    view.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open file");
            }
        }

        private void scan_radio_all_CheckedChanged(object sender, EventArgs e)
        {
            if (scan_radio_all.Checked)
                scan_datepicker.Enabled = false;
            else
                scan_datepicker.Enabled = true;
            
            refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_special);
            refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
            refresh_scannedForm_Imagelist(MainApp.scannedform_result);
        }

        private void scan_radio_select_CheckedChanged(object sender, EventArgs e)
        {
            refresh_scannedForm_Imagelist(MainApp.scannedform_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_special);
            refresh_scannedForm_Imagelist(MainApp.scannedform_tmj);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_anamnesis);
            refresh_scannedForm_Imagelist(MainApp.scannedform_snoring_recall);
            refresh_scannedForm_Imagelist(MainApp.scannedform_result);
        }

        private void anamnesis_radio_all_CheckedChanged(object sender, EventArgs e)
        {
            if (anamnesis_radio_all.Checked)
                anamnesis_datepicker.Enabled = false;
            else
                anamnesis_datepicker.Enabled = true;

            if (anamnesis_radio_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_anamnesis);
            }

            if (anamnesis_radio_special.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_special;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_special);
            }

            if (anamnesis_radio_tmj.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_tmj;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_tmj);
            }

            if (anamnesis_radio_snoring_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_anamnesis);
            }

            if (anamnesis_radio_snoring_recall.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_recall;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_recall);
            }

            if (anamnesis_radio_result.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_result;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_result);
            }
        }

        private void anamnesis_radio_select_CheckedChanged(object sender, EventArgs e)
        {
            if (anamnesis_radio_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_anamnesis);
            }

            if (anamnesis_radio_special.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_special;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_special);
            }

            if (anamnesis_radio_tmj.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_tmj;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_tmj);
            }

            if (anamnesis_radio_snoring_anamnesis.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_anamnesis;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_anamnesis);
            }

            if (anamnesis_radio_snoring_recall.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_snoring_recall;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_snoring_recall);
            }

            if (anamnesis_radio_result.Checked)
            {
                MainApp.anamnesis_selected_radio = MainApp.scannedform_result;
                refresh_anamnesis_form_Imagelist(MainApp.scannedform_result);
            }
        }

        private void chronic_grid_add_btn_Click(object sender, EventArgs e)
        {
            int row = chronic_form_grid.Rows.Count + 1;
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_no_select);
                else
                    MessageBox.Show(MessagePropertys.de_no_select);
                return;
            }
            UpdateForm update = new UpdateForm("", row);
            update.ShowDialog();
        }

        private void chronic_form_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = chronic_form_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                UpdateForm update = new UpdateForm(id, e.RowIndex);
                update.ShowDialog();
            } catch(Exception ex)
            {

            }
        }

        private void chronic_template_Click(object sender, EventArgs e)
        {
            Template temp = new Template();
            temp.ShowDialog();
        }

        private void symptoms_grid1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if(e.KeyCode == Keys.Delete)
            {
                int index = symptoms_grid1.CurrentCell.RowIndex;

                if (index < 0)
                    return;
                if (index > symptoms_grid1.Rows.Count)
                    return;

                for (int i = 0; i < 11; i++)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.White;
                    symptoms_grid.Rows[index].Cells[i + 2].Style = style;
                }
                symptom_save();
            }*/
        }

        private void chronic_print_Click(object sender, EventArgs e)
        {
            //printDialog1.Document = printDocument1;
            //if(printDialog1.ShowDialog() == DialogResult.OK )
            //{
            //    printDocument1.Print();
            //}
            if (MainApp.user_id == "")
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_select_alert);
                else
                    MessageBox.Show(MessagePropertys.de_select_alert);
                return;
            }
            ChronicPrint temp = new ChronicPrint();
            temp.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float width = ((float)this.ClientRectangle.Width);
            SizeF size = e.Graphics.MeasureString("Chronic", new Font("Arial", 40, FontStyle.Bold));
            e.Graphics.DrawString("Chronic", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, (width-size.Width)/2, 125);
        }

        private void patient_button_new_Click(object sender, EventArgs e)
        {
            MainApp.user_index = -1;
            MainApp.user_id = "";
            patient_textbox_name.Text = "";
            patient_textbox_surname.Text = "";
            patient_birthday.Value = DateTime.Today.AddDays(-1);
            patient_textbox_company.Text = "";
            patient_insurance.Text = "";
            patient_textbox_main_symptom.Text = "";
            patient_textbox_referral.Text = "";
            patient_textbox_profession.Text = "";
            patient_textbox_doctor.Text = "";
            patient_checkbox_bei.Checked = false;
            refresh_userinfo(MainApp.user_id);
        }

        private void treatment_form_checkbox_8_OnChange_1(object sender, EventArgs e)
        {
            if (treatment_form_checkbox_8.Checked)
                treatment_form_txt_3.Enabled = true;
            else
            {
                treatment_form_txt_3.Enabled = false;
                treatment_form_txt_3.Text = "";
            }
            treatment_save();
        }

        private void search_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                refresh_patient_grid(search_txt.Text);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            refresh_patient_grid(search_txt.Text);
        }

        private void treatment_form_checkbox_1_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_2_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_3_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_37_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_4_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_1_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_6_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_2_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_3_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_4_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_10_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_11_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_12_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_13_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_14_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_15_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_16_OnChange_1(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_5_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_18_OnChange_1(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_6_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_20_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_21_OnChange(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_checkbox_22_OnChange_1(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_7_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_8_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_9_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_10_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_11_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_12_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_13_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_14_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_15_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_16_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_17_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_18_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_19_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void treatment_form_txt_20_TextChanged(object sender, EventArgs e)
        {
            treatment_save();
        }

        private void diagnostic_form_checkbox_1_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_2_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_3_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_4_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_5_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_6_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_7_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_8_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_9_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_10_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic__fbs_txt_TextChanged(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_12_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_mjt_txt_TextChanged(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_14_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_15_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_16_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_17_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_18_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_19_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_20_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_21_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_22_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_23_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_24_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_25_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_26_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void diagnostic_form_checkbox_27_OnChange(object sender, EventArgs e)
        {
            save_diagnostic();
        }

        private void chronic_diagnostic_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            save_chronic();
        }

        private void chronic_treatment_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            save_chronic();
        }
    }

    public static class ControlExtensions
    {
        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
}
