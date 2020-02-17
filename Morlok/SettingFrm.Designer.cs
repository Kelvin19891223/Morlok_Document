namespace Morlok
{
    partial class SettingFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setting_btn_group = new System.Windows.Forms.GroupBox();
            this.setting_ok_btn = new System.Windows.Forms.Button();
            this.setting_cancel_btn = new System.Windows.Forms.Button();
            this.setting_test_btn = new System.Windows.Forms.Button();
            this.setting_admin_group = new System.Windows.Forms.GroupBox();
            this.setting_admin_confirm_pass_label = new System.Windows.Forms.Label();
            this.setting_admin_confirm_password_txt = new System.Windows.Forms.TextBox();
            this.setting_admin_pass_label = new System.Windows.Forms.Label();
            this.setting_admin_pass_txt = new System.Windows.Forms.TextBox();
            this.setting_database_group = new System.Windows.Forms.GroupBox();
            this.setting_db_confirm_password_label = new System.Windows.Forms.Label();
            this.setting_db_confirm_password_txt = new System.Windows.Forms.TextBox();
            this.setting_db_password_label = new System.Windows.Forms.Label();
            this.setting_db_user_label = new System.Windows.Forms.Label();
            this.setting_db_port_label = new System.Windows.Forms.Label();
            this.setting_db_password_txt = new System.Windows.Forms.TextBox();
            this.setting_db_user_txt = new System.Windows.Forms.TextBox();
            this.setting_db_port_txt = new System.Windows.Forms.TextBox();
            this.setting_db_server_txt = new System.Windows.Forms.TextBox();
            this.setting_db_server_label = new System.Windows.Forms.Label();
            this.setting_ftp_group = new System.Windows.Forms.GroupBox();
            this.setting_ftp_confirm_password_label = new System.Windows.Forms.Label();
            this.setting_ftp_server_label = new System.Windows.Forms.Label();
            this.setting_ftp_confirm_password_txt = new System.Windows.Forms.TextBox();
            this.setting_ftp_server_txt = new System.Windows.Forms.TextBox();
            this.setting_ftp_password_label = new System.Windows.Forms.Label();
            this.setting_ftp_port_txt = new System.Windows.Forms.TextBox();
            this.setting_ftp_user_label = new System.Windows.Forms.Label();
            this.setting_ftp_username_txt = new System.Windows.Forms.TextBox();
            this.setting_ftp_port_label = new System.Windows.Forms.Label();
            this.setting_ftp_password_txt = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_close = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl4 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl5 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl6 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.setting_db_database_name_label = new System.Windows.Forms.Label();
            this.setting_db_database_name_txt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.setting_btn_group.SuspendLayout();
            this.setting_admin_group.SuspendLayout();
            this.setting_database_group.SuspendLayout();
            this.setting_ftp_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.setting_btn_group);
            this.panel1.Controls.Add(this.setting_admin_group);
            this.panel1.Controls.Add(this.setting_database_group);
            this.panel1.Controls.Add(this.setting_ftp_group);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 572);
            this.panel1.TabIndex = 0;
            // 
            // setting_btn_group
            // 
            this.setting_btn_group.Controls.Add(this.setting_ok_btn);
            this.setting_btn_group.Controls.Add(this.setting_cancel_btn);
            this.setting_btn_group.Controls.Add(this.setting_test_btn);
            this.setting_btn_group.Location = new System.Drawing.Point(17, 515);
            this.setting_btn_group.Name = "setting_btn_group";
            this.setting_btn_group.Size = new System.Drawing.Size(373, 50);
            this.setting_btn_group.TabIndex = 27;
            this.setting_btn_group.TabStop = false;
            // 
            // setting_ok_btn
            // 
            this.setting_ok_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ok_btn.Location = new System.Drawing.Point(207, 19);
            this.setting_ok_btn.Name = "setting_ok_btn";
            this.setting_ok_btn.Size = new System.Drawing.Size(77, 23);
            this.setting_ok_btn.TabIndex = 15;
            this.setting_ok_btn.TabStop = false;
            this.setting_ok_btn.Text = "OK";
            this.setting_ok_btn.UseVisualStyleBackColor = true;
            this.setting_ok_btn.Click += new System.EventHandler(this.setting_ok_btn_Click);
            // 
            // setting_cancel_btn
            // 
            this.setting_cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_cancel_btn.Location = new System.Drawing.Point(290, 19);
            this.setting_cancel_btn.Name = "setting_cancel_btn";
            this.setting_cancel_btn.Size = new System.Drawing.Size(77, 23);
            this.setting_cancel_btn.TabIndex = 15;
            this.setting_cancel_btn.TabStop = false;
            this.setting_cancel_btn.Text = "Cancel";
            this.setting_cancel_btn.UseVisualStyleBackColor = true;
            this.setting_cancel_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // setting_test_btn
            // 
            this.setting_test_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_test_btn.Location = new System.Drawing.Point(9, 19);
            this.setting_test_btn.Name = "setting_test_btn";
            this.setting_test_btn.Size = new System.Drawing.Size(125, 23);
            this.setting_test_btn.TabIndex = 14;
            this.setting_test_btn.TabStop = false;
            this.setting_test_btn.Text = "Test Connection";
            this.setting_test_btn.UseVisualStyleBackColor = true;
            this.setting_test_btn.Click += new System.EventHandler(this.setting_test_btn_Click);
            // 
            // setting_admin_group
            // 
            this.setting_admin_group.Controls.Add(this.setting_admin_confirm_pass_label);
            this.setting_admin_group.Controls.Add(this.setting_admin_confirm_password_txt);
            this.setting_admin_group.Controls.Add(this.setting_admin_pass_label);
            this.setting_admin_group.Controls.Add(this.setting_admin_pass_txt);
            this.setting_admin_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_admin_group.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.setting_admin_group.Location = new System.Drawing.Point(17, 3);
            this.setting_admin_group.Name = "setting_admin_group";
            this.setting_admin_group.Size = new System.Drawing.Size(373, 94);
            this.setting_admin_group.TabIndex = 23;
            this.setting_admin_group.TabStop = false;
            this.setting_admin_group.Text = "Admin Setting";
            // 
            // setting_admin_confirm_pass_label
            // 
            this.setting_admin_confirm_pass_label.AutoSize = true;
            this.setting_admin_confirm_pass_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_admin_confirm_pass_label.Location = new System.Drawing.Point(6, 63);
            this.setting_admin_confirm_pass_label.Name = "setting_admin_confirm_pass_label";
            this.setting_admin_confirm_pass_label.Size = new System.Drawing.Size(116, 16);
            this.setting_admin_confirm_pass_label.TabIndex = 3;
            this.setting_admin_confirm_pass_label.Text = "Confirm Password";
            // 
            // setting_admin_confirm_password_txt
            // 
            this.setting_admin_confirm_password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_admin_confirm_password_txt.Location = new System.Drawing.Point(170, 57);
            this.setting_admin_confirm_password_txt.Name = "setting_admin_confirm_password_txt";
            this.setting_admin_confirm_password_txt.PasswordChar = '*';
            this.setting_admin_confirm_password_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_admin_confirm_password_txt.TabIndex = 2;
            // 
            // setting_admin_pass_label
            // 
            this.setting_admin_pass_label.AutoSize = true;
            this.setting_admin_pass_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_admin_pass_label.Location = new System.Drawing.Point(6, 31);
            this.setting_admin_pass_label.Name = "setting_admin_pass_label";
            this.setting_admin_pass_label.Size = new System.Drawing.Size(68, 16);
            this.setting_admin_pass_label.TabIndex = 0;
            this.setting_admin_pass_label.Text = "Password";
            // 
            // setting_admin_pass_txt
            // 
            this.setting_admin_pass_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_admin_pass_txt.Location = new System.Drawing.Point(170, 25);
            this.setting_admin_pass_txt.Name = "setting_admin_pass_txt";
            this.setting_admin_pass_txt.PasswordChar = '*';
            this.setting_admin_pass_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_admin_pass_txt.TabIndex = 1;
            // 
            // setting_database_group
            // 
            this.setting_database_group.Controls.Add(this.setting_db_database_name_label);
            this.setting_database_group.Controls.Add(this.setting_db_database_name_txt);
            this.setting_database_group.Controls.Add(this.setting_db_confirm_password_label);
            this.setting_database_group.Controls.Add(this.setting_db_confirm_password_txt);
            this.setting_database_group.Controls.Add(this.setting_db_password_label);
            this.setting_database_group.Controls.Add(this.setting_db_user_label);
            this.setting_database_group.Controls.Add(this.setting_db_port_label);
            this.setting_database_group.Controls.Add(this.setting_db_password_txt);
            this.setting_database_group.Controls.Add(this.setting_db_user_txt);
            this.setting_database_group.Controls.Add(this.setting_db_port_txt);
            this.setting_database_group.Controls.Add(this.setting_db_server_txt);
            this.setting_database_group.Controls.Add(this.setting_db_server_label);
            this.setting_database_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_database_group.ForeColor = System.Drawing.Color.White;
            this.setting_database_group.Location = new System.Drawing.Point(17, 296);
            this.setting_database_group.Name = "setting_database_group";
            this.setting_database_group.Size = new System.Drawing.Size(373, 220);
            this.setting_database_group.TabIndex = 25;
            this.setting_database_group.TabStop = false;
            this.setting_database_group.Text = "Database Setting";
            // 
            // setting_db_confirm_password_label
            // 
            this.setting_db_confirm_password_label.AutoSize = true;
            this.setting_db_confirm_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_confirm_password_label.Location = new System.Drawing.Point(6, 157);
            this.setting_db_confirm_password_label.Name = "setting_db_confirm_password_label";
            this.setting_db_confirm_password_label.Size = new System.Drawing.Size(116, 16);
            this.setting_db_confirm_password_label.TabIndex = 4;
            this.setting_db_confirm_password_label.Text = "Confirm Password";
            // 
            // setting_db_confirm_password_txt
            // 
            this.setting_db_confirm_password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_confirm_password_txt.Location = new System.Drawing.Point(170, 151);
            this.setting_db_confirm_password_txt.Name = "setting_db_confirm_password_txt";
            this.setting_db_confirm_password_txt.PasswordChar = '*';
            this.setting_db_confirm_password_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_confirm_password_txt.TabIndex = 12;
            // 
            // setting_db_password_label
            // 
            this.setting_db_password_label.AutoSize = true;
            this.setting_db_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_password_label.Location = new System.Drawing.Point(6, 125);
            this.setting_db_password_label.Name = "setting_db_password_label";
            this.setting_db_password_label.Size = new System.Drawing.Size(71, 16);
            this.setting_db_password_label.TabIndex = 10;
            this.setting_db_password_label.Text = "Password:";
            // 
            // setting_db_user_label
            // 
            this.setting_db_user_label.AutoSize = true;
            this.setting_db_user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_user_label.Location = new System.Drawing.Point(6, 92);
            this.setting_db_user_label.Name = "setting_db_user_label";
            this.setting_db_user_label.Size = new System.Drawing.Size(80, 16);
            this.setting_db_user_label.TabIndex = 9;
            this.setting_db_user_label.Text = "User Name:";
            // 
            // setting_db_port_label
            // 
            this.setting_db_port_label.AutoSize = true;
            this.setting_db_port_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_port_label.Location = new System.Drawing.Point(6, 60);
            this.setting_db_port_label.Name = "setting_db_port_label";
            this.setting_db_port_label.Size = new System.Drawing.Size(35, 16);
            this.setting_db_port_label.TabIndex = 8;
            this.setting_db_port_label.Text = "Port:";
            // 
            // setting_db_password_txt
            // 
            this.setting_db_password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_password_txt.Location = new System.Drawing.Point(170, 119);
            this.setting_db_password_txt.Name = "setting_db_password_txt";
            this.setting_db_password_txt.PasswordChar = '*';
            this.setting_db_password_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_password_txt.TabIndex = 11;
            // 
            // setting_db_user_txt
            // 
            this.setting_db_user_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_user_txt.Location = new System.Drawing.Point(170, 86);
            this.setting_db_user_txt.Name = "setting_db_user_txt";
            this.setting_db_user_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_user_txt.TabIndex = 10;
            // 
            // setting_db_port_txt
            // 
            this.setting_db_port_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_port_txt.Location = new System.Drawing.Point(170, 54);
            this.setting_db_port_txt.Name = "setting_db_port_txt";
            this.setting_db_port_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_port_txt.TabIndex = 9;
            // 
            // setting_db_server_txt
            // 
            this.setting_db_server_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_server_txt.Location = new System.Drawing.Point(170, 22);
            this.setting_db_server_txt.Name = "setting_db_server_txt";
            this.setting_db_server_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_server_txt.TabIndex = 8;
            // 
            // setting_db_server_label
            // 
            this.setting_db_server_label.AutoSize = true;
            this.setting_db_server_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_server_label.Location = new System.Drawing.Point(6, 28);
            this.setting_db_server_label.Name = "setting_db_server_label";
            this.setting_db_server_label.Size = new System.Drawing.Size(149, 16);
            this.setting_db_server_label.TabIndex = 4;
            this.setting_db_server_label.Text = "Host Name/IP Address:";
            // 
            // setting_ftp_group
            // 
            this.setting_ftp_group.Controls.Add(this.setting_ftp_confirm_password_label);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_server_label);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_confirm_password_txt);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_server_txt);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_password_label);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_port_txt);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_user_label);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_username_txt);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_port_label);
            this.setting_ftp_group.Controls.Add(this.setting_ftp_password_txt);
            this.setting_ftp_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_group.ForeColor = System.Drawing.Color.White;
            this.setting_ftp_group.Location = new System.Drawing.Point(17, 103);
            this.setting_ftp_group.Name = "setting_ftp_group";
            this.setting_ftp_group.Size = new System.Drawing.Size(373, 187);
            this.setting_ftp_group.TabIndex = 24;
            this.setting_ftp_group.TabStop = false;
            this.setting_ftp_group.Text = "Ftp Setting";
            // 
            // setting_ftp_confirm_password_label
            // 
            this.setting_ftp_confirm_password_label.AutoSize = true;
            this.setting_ftp_confirm_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_confirm_password_label.Location = new System.Drawing.Point(6, 156);
            this.setting_ftp_confirm_password_label.Name = "setting_ftp_confirm_password_label";
            this.setting_ftp_confirm_password_label.Size = new System.Drawing.Size(116, 16);
            this.setting_ftp_confirm_password_label.TabIndex = 11;
            this.setting_ftp_confirm_password_label.Text = "Confirm Password";
            // 
            // setting_ftp_server_label
            // 
            this.setting_ftp_server_label.AutoSize = true;
            this.setting_ftp_server_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_server_label.Location = new System.Drawing.Point(6, 27);
            this.setting_ftp_server_label.Name = "setting_ftp_server_label";
            this.setting_ftp_server_label.Size = new System.Drawing.Size(149, 16);
            this.setting_ftp_server_label.TabIndex = 14;
            this.setting_ftp_server_label.Text = "Host Name/IP Address:";
            // 
            // setting_ftp_confirm_password_txt
            // 
            this.setting_ftp_confirm_password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_confirm_password_txt.Location = new System.Drawing.Point(170, 150);
            this.setting_ftp_confirm_password_txt.Name = "setting_ftp_confirm_password_txt";
            this.setting_ftp_confirm_password_txt.PasswordChar = '*';
            this.setting_ftp_confirm_password_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_ftp_confirm_password_txt.TabIndex = 7;
            // 
            // setting_ftp_server_txt
            // 
            this.setting_ftp_server_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_server_txt.Location = new System.Drawing.Point(170, 21);
            this.setting_ftp_server_txt.Name = "setting_ftp_server_txt";
            this.setting_ftp_server_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_ftp_server_txt.TabIndex = 3;
            // 
            // setting_ftp_password_label
            // 
            this.setting_ftp_password_label.AutoSize = true;
            this.setting_ftp_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_password_label.Location = new System.Drawing.Point(6, 124);
            this.setting_ftp_password_label.Name = "setting_ftp_password_label";
            this.setting_ftp_password_label.Size = new System.Drawing.Size(71, 16);
            this.setting_ftp_password_label.TabIndex = 20;
            this.setting_ftp_password_label.Text = "Password:";
            // 
            // setting_ftp_port_txt
            // 
            this.setting_ftp_port_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_port_txt.Location = new System.Drawing.Point(170, 53);
            this.setting_ftp_port_txt.Name = "setting_ftp_port_txt";
            this.setting_ftp_port_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_ftp_port_txt.TabIndex = 4;
            // 
            // setting_ftp_user_label
            // 
            this.setting_ftp_user_label.AutoSize = true;
            this.setting_ftp_user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_user_label.Location = new System.Drawing.Point(6, 91);
            this.setting_ftp_user_label.Name = "setting_ftp_user_label";
            this.setting_ftp_user_label.Size = new System.Drawing.Size(80, 16);
            this.setting_ftp_user_label.TabIndex = 19;
            this.setting_ftp_user_label.Text = "User Name:";
            // 
            // setting_ftp_username_txt
            // 
            this.setting_ftp_username_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_username_txt.Location = new System.Drawing.Point(170, 85);
            this.setting_ftp_username_txt.Name = "setting_ftp_username_txt";
            this.setting_ftp_username_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_ftp_username_txt.TabIndex = 5;
            // 
            // setting_ftp_port_label
            // 
            this.setting_ftp_port_label.AutoSize = true;
            this.setting_ftp_port_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_port_label.Location = new System.Drawing.Point(6, 59);
            this.setting_ftp_port_label.Name = "setting_ftp_port_label";
            this.setting_ftp_port_label.Size = new System.Drawing.Size(35, 16);
            this.setting_ftp_port_label.TabIndex = 18;
            this.setting_ftp_port_label.Text = "Port:";
            // 
            // setting_ftp_password_txt
            // 
            this.setting_ftp_password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_ftp_password_txt.Location = new System.Drawing.Point(170, 118);
            this.setting_ftp_password_txt.Name = "setting_ftp_password_txt";
            this.setting_ftp_password_txt.PasswordChar = '*';
            this.setting_ftp_password_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_ftp_password_txt.TabIndex = 6;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Image = global::Morlok.Properties.Resources.btn_exit;
            this.btn_close.ImageActive = null;
            this.btn_close.Location = new System.Drawing.Point(378, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(22, 24);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_close.TabIndex = 13;
            this.btn_close.TabStop = false;
            this.btn_close.Zoom = 10;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel3.Size = new System.Drawing.Size(405, 24);
            this.panel3.TabIndex = 1;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel3;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.panel1;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.setting_database_group;
            this.bunifuDragControl3.Vertical = true;
            // 
            // bunifuDragControl4
            // 
            this.bunifuDragControl4.Fixed = true;
            this.bunifuDragControl4.Horizontal = true;
            this.bunifuDragControl4.TargetControl = this.setting_ftp_group;
            this.bunifuDragControl4.Vertical = true;
            // 
            // bunifuDragControl5
            // 
            this.bunifuDragControl5.Fixed = true;
            this.bunifuDragControl5.Horizontal = true;
            this.bunifuDragControl5.TargetControl = this.setting_admin_group;
            this.bunifuDragControl5.Vertical = true;
            // 
            // bunifuDragControl6
            // 
            this.bunifuDragControl6.Fixed = true;
            this.bunifuDragControl6.Horizontal = true;
            this.bunifuDragControl6.TargetControl = this.setting_btn_group;
            this.bunifuDragControl6.Vertical = true;
            // 
            // setting_db_database_name_label
            // 
            this.setting_db_database_name_label.AutoSize = true;
            this.setting_db_database_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_database_name_label.Location = new System.Drawing.Point(6, 193);
            this.setting_db_database_name_label.Name = "setting_db_database_name_label";
            this.setting_db_database_name_label.Size = new System.Drawing.Size(111, 16);
            this.setting_db_database_name_label.TabIndex = 11;
            this.setting_db_database_name_label.Text = "Database Name:";
            // 
            // setting_db_database_name_txt
            // 
            this.setting_db_database_name_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_db_database_name_txt.Location = new System.Drawing.Point(170, 187);
            this.setting_db_database_name_txt.Name = "setting_db_database_name_txt";
            this.setting_db_database_name_txt.Size = new System.Drawing.Size(197, 26);
            this.setting_db_database_name_txt.TabIndex = 13;
            // 
            // SettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingFrm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingFrm";
            this.Load += new System.EventHandler(this.SettingFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingFrm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.setting_btn_group.ResumeLayout(false);
            this.setting_admin_group.ResumeLayout(false);
            this.setting_admin_group.PerformLayout();
            this.setting_database_group.ResumeLayout(false);
            this.setting_database_group.PerformLayout();
            this.setting_ftp_group.ResumeLayout(false);
            this.setting_ftp_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox setting_btn_group;
        private System.Windows.Forms.Button setting_ok_btn;
        private System.Windows.Forms.Button setting_cancel_btn;
        private System.Windows.Forms.Button setting_test_btn;
        private System.Windows.Forms.GroupBox setting_admin_group;
        private System.Windows.Forms.Label setting_admin_confirm_pass_label;
        private System.Windows.Forms.TextBox setting_admin_confirm_password_txt;
        private System.Windows.Forms.Label setting_admin_pass_label;
        private System.Windows.Forms.TextBox setting_admin_pass_txt;
        private System.Windows.Forms.GroupBox setting_database_group;
        private System.Windows.Forms.Label setting_db_confirm_password_label;
        private System.Windows.Forms.TextBox setting_db_confirm_password_txt;
        private System.Windows.Forms.Label setting_db_password_label;
        private System.Windows.Forms.Label setting_db_user_label;
        private System.Windows.Forms.Label setting_db_port_label;
        private System.Windows.Forms.TextBox setting_db_password_txt;
        private System.Windows.Forms.TextBox setting_db_user_txt;
        private System.Windows.Forms.TextBox setting_db_port_txt;
        private System.Windows.Forms.TextBox setting_db_server_txt;
        private System.Windows.Forms.Label setting_db_server_label;
        private System.Windows.Forms.GroupBox setting_ftp_group;
        private System.Windows.Forms.Label setting_ftp_confirm_password_label;
        private System.Windows.Forms.Label setting_ftp_server_label;
        private System.Windows.Forms.TextBox setting_ftp_confirm_password_txt;
        private System.Windows.Forms.TextBox setting_ftp_server_txt;
        private System.Windows.Forms.Label setting_ftp_password_label;
        private System.Windows.Forms.TextBox setting_ftp_port_txt;
        private System.Windows.Forms.Label setting_ftp_user_label;
        private System.Windows.Forms.TextBox setting_ftp_username_txt;
        private System.Windows.Forms.Label setting_ftp_port_label;
        private System.Windows.Forms.TextBox setting_ftp_password_txt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuImageButton btn_close;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl4;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl5;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl6;
        private System.Windows.Forms.Label setting_db_database_name_label;
        private System.Windows.Forms.TextBox setting_db_database_name_txt;
    }
}