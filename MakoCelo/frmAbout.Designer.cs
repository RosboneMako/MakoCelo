using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmAbout : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            PictureBox1 = new PictureBox();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            lbBold01 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label7 = new Label();
            rtbHelp = new RichTextBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.BorderStyle = BorderStyle.Fixed3D;
            PictureBox1.ErrorImage = null;
            PictureBox1.Image = (Image)resources.GetObject("PictureBox1.Image");
            PictureBox1.Location = new Point(10, 82);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(389, 244);
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.TabIndex = 6;
            PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            Label1.BackColor = Color.DimGray;
            Label1.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.ForeColor = Color.White;
            Label1.Location = new Point(12, 356);
            Label1.Name = "Label1";
            Label1.Size = new Size(85, 16);
            Label1.TabIndex = 0;
            Label1.Text = "PROGRAM: ";
            // 
            // Label2
            // 
            Label2.BackColor = Color.DimGray;
            Label2.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.ForeColor = Color.White;
            Label2.Location = new Point(12, 376);
            Label2.Name = "Label2";
            Label2.Size = new Size(85, 16);
            Label2.TabIndex = 1;
            Label2.Text = "VERSION:";
            // 
            // Label3
            // 
            Label3.BackColor = Color.DimGray;
            Label3.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.ForeColor = Color.White;
            Label3.Location = new Point(12, 396);
            Label3.Name = "Label3";
            Label3.Size = new Size(85, 16);
            Label3.TabIndex = 2;
            Label3.Text = "DATE:";
            // 
            // Label4
            // 
            Label4.BackColor = Color.DimGray;
            Label4.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.ForeColor = Color.White;
            Label4.Location = new Point(12, 416);
            Label4.Name = "Label4";
            Label4.Size = new Size(85, 16);
            Label4.TabIndex = 3;
            Label4.Text = "AUTHOR:";
            // 
            // lbBold01
            // 
            lbBold01.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            lbBold01.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, Conversions.ToByte(0));
            lbBold01.Location = new Point(104, 356);
            lbBold01.Name = "lbBold01";
            lbBold01.Size = new Size(295, 16);
            lbBold01.TabIndex = 8;
            lbBold01.Text = " MakoCELO";
            // 
            // Label5
            // 
            Label5.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            Label5.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.Location = new Point(104, 376);
            Label5.Name = "Label5";
            Label5.Size = new Size(295, 16);
            Label5.TabIndex = 9;
            Label5.Text = " 4.50 - Web Based";
            // 
            // Label6
            // 
            Label6.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            Label6.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.Location = new Point(104, 396);
            Label6.Name = "Label6";
            Label6.Size = new Size(295, 16);
            Label6.TabIndex = 14;
            Label6.Text = "Mar 22, 2021";
            // 
            // Label7
            // 
            Label7.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            Label7.Font = new Font("Arial", 9.75f, FontStyle.Italic, GraphicsUnit.Point, Conversions.ToByte(0));
            Label7.Location = new Point(104, 416);
            Label7.Name = "Label7";
            Label7.Size = new Size(295, 16);
            Label7.TabIndex = 11;
            Label7.Text = " RosboneMako";
            // 
            // rtbHelp
            // 
            rtbHelp.BackColor = Color.White;
            rtbHelp.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            rtbHelp.ForeColor = Color.White;
            rtbHelp.Location = new Point(410, 10);
            rtbHelp.Name = "rtbHelp";
            rtbHelp.ReadOnly = true;
            rtbHelp.Size = new Size(680, 507);
            rtbHelp.TabIndex = 15;
            rtbHelp.Text = "";
            // 
            // Button1
            // 
            _Button1.Location = new Point(168, 23);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(87, 43);
            _Button1.TabIndex = 16;
            _Button1.Text = "Email Test";
            _Button1.UseVisualStyleBackColor = true;
            _Button1.Visible = false;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            ClientSize = new Size(1097, 529);
            Controls.Add(_Button1);
            Controls.Add(rtbHelp);
            Controls.Add(Label7);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(lbBold01);
            Controls.Add(PictureBox1);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MakoCELO - About";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            Load += new EventHandler(frmAbout_Load);
            Shown += new EventHandler(frmAbout_Shown);
            KeyDown += new KeyEventHandler(frmAbout_KeyDown);
            ResumeLayout(false);
            PerformLayout();
        }

        internal PictureBox PictureBox1;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label lbBold01;
        internal Label Label5;
        internal Label Label6;
        internal Label Label7;
        internal RichTextBox rtbHelp;
        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }
    }
}