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
    public partial class Template : Form
    {
        public Template()
        {
            InitializeComponent();
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

        public void refresh_grid()
        {
            template_grid.Rows.Clear();
            DataTable dt = MainApp.g_mysql.getTemplate();
            if(dt != null && dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    template_grid.Rows.Add(dt.Rows[i]["id"],dt.Rows[i]["template"]);
                }
            }
        }

        private void Template_Load(object sender, EventArgs e)
        {
            if(MainApp.language == "en")
            {
                label1.Text = "Template";
                template_grid.Columns[1].HeaderText = "Template";
                template_grid.Columns[1].HeaderText = "Remarks";
                save_btn.Text = "SAVE";
                cancel_btn.Text = "CANCEL";
                update_btn.Text = "UPDATE";
            }
            else
            {
                label1.Text = "Vorlage";
                template_grid.Columns[1].HeaderText = "Vorlage";
                template_grid.Columns[1].HeaderText = "Bemerkungen";
                save_btn.Text = "SPAREN";
                cancel_btn.Text = "STORNIEREN";
                update_btn.Text = "AKTUALISIEREN";
            }
            refresh_grid();
            template_template.Text = "";
            template_id.Text = "";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string template = template_template.Text;
            if (template != "")
            {
                MainApp.g_mysql.insertTemplate(template);
                refresh_grid();
                template_id.Text = "";
                template_template.Text = "";
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);
            } else
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_empty_field);
                else
                    MessageBox.Show(MessagePropertys.de_empty_field);
            }            
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string id = template_id.Text;
            string template = template_template.Text;
            if(id != "" && template != "")
            {
                MainApp.g_mysql.updateTemplate(id, template);
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_success);
                else
                    MessageBox.Show(MessagePropertys.de_success);
                refresh_grid();
            } else
            {
                if (MainApp.language == "en")
                    MessageBox.Show(MessagePropertys.en_empty_field);
                else
                    MessageBox.Show(MessagePropertys.de_empty_field);
            }

            template_id.Text = "";
            template_template.Text = "";
        }

        private void template_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            
            try
            {
                if (e.ColumnIndex == 2)
                {
                    string id = template_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    MainApp.g_mysql.deleteTemplate(id);
                    refresh_grid();
                    return;
                }

                template_id.Text = template_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                template_template.Text = template_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch(Exception ex)
            {
                template_id.Text = "";
                template_template.Text = "";
            }
        }
    }
}
