namespace Morlok
{
    partial class View
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
            Gnostice.Documents.FormatterSettings formatterSettings1 = new Gnostice.Documents.FormatterSettings();
            Gnostice.Documents.Spreadsheet.SpreadSheetFormatterSettings spreadSheetFormatterSettings1 = new Gnostice.Documents.Spreadsheet.SpreadSheetFormatterSettings();
            Gnostice.Documents.PageSettings pageSettings1 = new Gnostice.Documents.PageSettings();
            Gnostice.Documents.Margins margins1 = new Gnostice.Documents.Margins();
            Gnostice.Documents.Spreadsheet.SheetOptions sheetOptions1 = new Gnostice.Documents.Spreadsheet.SheetOptions();
            Gnostice.Documents.Spreadsheet.SheetOptions sheetOptions2 = new Gnostice.Documents.Spreadsheet.SheetOptions();
            Gnostice.Documents.TXTFormatterSettings txtFormatterSettings1 = new Gnostice.Documents.TXTFormatterSettings();
            Gnostice.Documents.PageSettings pageSettings2 = new Gnostice.Documents.PageSettings();
            Gnostice.Documents.Margins margins2 = new Gnostice.Documents.Margins();
            Gnostice.Graphics.RenderingSettings renderingSettings1 = new Gnostice.Graphics.RenderingSettings();
            Gnostice.Graphics.ImageRenderingSettings imageRenderingSettings1 = new Gnostice.Graphics.ImageRenderingSettings();
            Gnostice.Graphics.LineArtRenderingSettings lineArtRenderingSettings1 = new Gnostice.Graphics.LineArtRenderingSettings();
            Gnostice.Graphics.ResolutionSettings resolutionSettings1 = new Gnostice.Graphics.ResolutionSettings();
            Gnostice.Graphics.TextRenderingSettings textRenderingSettings1 = new Gnostice.Graphics.TextRenderingSettings();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.doc_viewer = new Gnostice.Documents.Controls.WinForms.DocumentViewer();
            this.btn_maximize = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.doc_viewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(594, 766);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.btn_maximize);
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 28);
            this.panel2.TabIndex = 17;
            // 
            // doc_viewer
            // 
            this.doc_viewer.AutoSize = true;
            this.doc_viewer.BackColor = System.Drawing.Color.Transparent;
            this.doc_viewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.doc_viewer.BorderWidth = 10;
            this.doc_viewer.CurrentPage = 0;
            this.doc_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doc_viewer.HScrollBar.LargeChange = 40;
            this.doc_viewer.HScrollBar.SmallChange = 20;
            this.doc_viewer.HScrollBar.Value = 0;
            this.doc_viewer.HScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.doc_viewer.Location = new System.Drawing.Point(10, 10);
            this.doc_viewer.Margin = new System.Windows.Forms.Padding(4);
            this.doc_viewer.MouseMode = Gnostice.DOM.CursorPreferences.AreaSelection;
            this.doc_viewer.Name = "doc_viewer";
            // 
            // 
            // 
            this.doc_viewer.NavigationPane.ActivePage = null;
            this.doc_viewer.NavigationPane.Location = new System.Drawing.Point(0, 0);
            this.doc_viewer.NavigationPane.Name = "";
            this.doc_viewer.NavigationPane.TabIndex = 0;
            this.doc_viewer.NavigationPane.Visibility = Gnostice.Documents.Controls.WinForms.Visibility.Auto;
            this.doc_viewer.NavigationPane.Visible = false;
            this.doc_viewer.NavigationPane.WidthPercentage = 20;
            this.doc_viewer.PageLayout = null;
            this.doc_viewer.PageRotation = Gnostice.Documents.Controls.WinForms.RotationAngle.Zero;
            this.doc_viewer.Preferences.Cursor = Gnostice.DOM.CursorPreferences.Pan;
            spreadSheetFormatterSettings1.FormattingMode = Gnostice.DOM.FormattingMode.PreferDocumentSettings;
            spreadSheetFormatterSettings1.PageOrder = Gnostice.Documents.Spreadsheet.LayoutDirection.BackwardN;
            pageSettings1.Height = 11.6929F;
            margins1.Bottom = 1F;
            margins1.Footer = 0F;
            margins1.Header = 0F;
            margins1.Left = 1F;
            margins1.Right = 1F;
            margins1.Top = 1F;
            pageSettings1.Margin = margins1;
            pageSettings1.Orientation = Gnostice.Graphics.Orientation.Portrait;
            pageSettings1.PageSize = Gnostice.Documents.PageSize.A4;
            pageSettings1.Width = 8.2677F;
            spreadSheetFormatterSettings1.PageSettings = pageSettings1;
            sheetOptions1.Print = false;
            sheetOptions1.View = true;
            spreadSheetFormatterSettings1.ShowGridlines = sheetOptions1;
            sheetOptions2.Print = false;
            sheetOptions2.View = true;
            spreadSheetFormatterSettings1.ShowHeadings = sheetOptions2;
            formatterSettings1.SpreadSheet = spreadSheetFormatterSettings1;
            txtFormatterSettings1.Font = new System.Drawing.Font("Calibri", 12F);
            pageSettings2.Height = 11.6929F;
            margins2.Bottom = 1F;
            margins2.Footer = 0F;
            margins2.Header = 0F;
            margins2.Left = 1F;
            margins2.Right = 1F;
            margins2.Top = 1F;
            pageSettings2.Margin = margins2;
            pageSettings2.Orientation = Gnostice.Graphics.Orientation.Portrait;
            pageSettings2.PageSize = Gnostice.Documents.PageSize.A4;
            pageSettings2.Width = 8.2677F;
            txtFormatterSettings1.PageSettings = pageSettings2;
            formatterSettings1.TXT = txtFormatterSettings1;
            this.doc_viewer.Preferences.FormatterSettings = formatterSettings1;
            this.doc_viewer.Preferences.KeyNavigation = true;
            imageRenderingSettings1.CompositingMode = Gnostice.Graphics.CompositingMode.SourceOver;
            imageRenderingSettings1.CompositingQuality = Gnostice.Graphics.CompositingQuality.Default;
            imageRenderingSettings1.InterpolationMode = Gnostice.Graphics.InterpolationMode.NearestNeighbor;
            imageRenderingSettings1.PixelOffsetMode = Gnostice.Graphics.PixelOffsetMode.HighQuality;
            renderingSettings1.Image = imageRenderingSettings1;
            lineArtRenderingSettings1.SmoothingMode = Gnostice.Graphics.SmoothingMode.AntiAlias;
            renderingSettings1.LineArt = lineArtRenderingSettings1;
            resolutionSettings1.DpiX = 96F;
            resolutionSettings1.DpiY = 96F;
            resolutionSettings1.ResolutionMode = Gnostice.Graphics.ResolutionMode.UseSource;
            renderingSettings1.Resolution = resolutionSettings1;
            textRenderingSettings1.TextContrast = 3;
            textRenderingSettings1.TextRenderingHint = Gnostice.Graphics.TextRenderingHint.AntiAlias;
            renderingSettings1.Text = textRenderingSettings1;
            this.doc_viewer.Preferences.RenderingSettings = renderingSettings1;
            this.doc_viewer.Preferences.Units = Gnostice.Graphics.MeasurementUnit.Inches;
            this.doc_viewer.Size = new System.Drawing.Size(574, 746);
            this.doc_viewer.TabIndex = 16;
            this.doc_viewer.VScrollBar.LargeChange = 40;
            this.doc_viewer.VScrollBar.SmallChange = 20;
            this.doc_viewer.VScrollBar.Value = 0;
            this.doc_viewer.VScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.doc_viewer.Zoom.ZoomMode = Gnostice.Documents.Controls.WinForms.ZoomMode.ActualSize;
            this.doc_viewer.Zoom.ZoomPercent = 100D;
            this.doc_viewer.Load += new System.EventHandler(this.doc_viewer_Load);
            // 
            // btn_maximize
            // 
            this.btn_maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_maximize.BackColor = System.Drawing.Color.Transparent;
            this.btn_maximize.Image = global::Morlok.Properties.Resources.Maximize_Window_50px;
            this.btn_maximize.ImageActive = null;
            this.btn_maximize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_maximize.Location = new System.Drawing.Point(540, 2);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(25, 26);
            this.btn_maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_maximize.TabIndex = 15;
            this.btn_maximize.TabStop = false;
            this.btn_maximize.Zoom = 15;
            this.btn_maximize.Click += new System.EventHandler(this.btn_maximize_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = global::Morlok.Properties.Resources.Close_Window_50px;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuImageButton1.Location = new System.Drawing.Point(566, 2);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(25, 26);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 16;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 15;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel2;
            this.bunifuDragControl1.Vertical = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "View";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.doc_viewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Gnostice.Documents.Controls.WinForms.DocumentViewer doc_viewer;
        private Bunifu.Framework.UI.BunifuImageButton btn_maximize;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}