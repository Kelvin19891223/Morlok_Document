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
    public partial class UpdateForm : Form
    {
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

        public string id;
        public int order;
        public UpdateForm(string id,int order)
        {
            this.id = id;
            this.order = order;
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            if(id != null)
            {
                DataTable dt = MainApp.g_mysql.getChrnoicById(id);
                if (dt != null && dt.Rows.Count != 0)
                {
                    string date = dt.Rows[0]["date"].ToString();
                    string input = dt.Rows[0]["input"].ToString();
                    updateform_date.Text = date;
                    updateform_input.Text = input;
                }
            }

            if(MainApp.language == "en")
            {
                label1.Text = "Date";
                label2.Text = "Input";
                btn_save.Text = "SAVE";
                btn_cancel.Text = "CANCEL";
            }
            else
            {
                label1.Text = "Datum";
                label2.Text = "Eingang";
                btn_save.Text = "SICHERN";
                btn_cancel.Text = "STORNIEREN";
            }

            try
            {
                DataTable dt = MainApp.g_mysql.getTemplate();
                if(dt != null && dt.Rows.Count > 0)
                {
                    ContextMenu cmu = new ContextMenu();
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string content = dt.Rows[i]["template"].ToString();
                        if (content.Length > 20)
                        {
                            content = content.Substring(0, 20);
                            content = content + "...";
                        }
                        MenuItem m_preview = new MenuItem(content);
                        m_preview.Select += M_preview_Select;
                        m_preview.Click += M_preview_Click; ;
                        cmu.MenuItems.Add(m_preview);
                    }

                    updateform_input.ContextMenu = cmu;
                }
            } catch(Exception ex)
            {

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string date = updateform_date.Value.ToString("yyyy-MM-dd");
            string input = updateform_input.Text;
            if (id != "")
            {
                MainApp.g_mysql.updateChronic(date, input, id);
            } else
            {
                MainApp.g_mysql.setChronic(date,input,MainApp.user_id,order);
            }

            if (MainApp.language == "en")
                MessageBox.Show(MessagePropertys.en_success);
            else
                MessageBox.Show(MessagePropertys.de_success);

            DialogResult = DialogResult.No;
            Close();

            MainApp.m_main_frm.refresh_chronic_data();
        }

        private void updateform_input_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                
            }
        }

        private void M_preview_Select(object sender, EventArgs e)
        {
            
        }

        private void M_preview_Click(object sender, EventArgs e)
        {
            var cmu = updateform_input.ContextMenu;
            var m = (MenuItem)sender;

            DataTable dt = MainApp.g_mysql.getTemplate();
            string content = dt.Rows[m.Index]["template"].ToString();
            int index = updateform_input.SelectionStart;
            string tmp = updateform_input.Text;
            string temp = tmp.Substring(0, index) + content + tmp.Substring(index);
            updateform_input.Text = temp;
            updateform_input.SelectionStart = index + content.Length;
        }

        private void update_context_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
