using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MakoCelo
{
    [DesignerGenerated()]
    public partial class frmNotes : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotes));
            tbN04 = new TextBox();
            tbN03 = new TextBox();
            tbN02 = new TextBox();
            tbN01 = new TextBox();
            tbN05 = new TextBox();
            tbN10 = new TextBox();
            tbN09 = new TextBox();
            tbN08 = new TextBox();
            tbN07 = new TextBox();
            tbN06 = new TextBox();
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _Button2 = new Button();
            _Button2.Click += new EventHandler(Button2_Click);
            _Button3 = new Button();
            _Button3.Click += new EventHandler(Button3_Click);
            _Button4 = new Button();
            _Button4.Click += new EventHandler(Button4_Click);
            _Button5 = new Button();
            _Button5.Click += new EventHandler(Button5_Click);
            _Button6 = new Button();
            _Button6.Click += new EventHandler(Button6_Click);
            _Button7 = new Button();
            _Button7.Click += new EventHandler(Button7_Click);
            _Button8 = new Button();
            _Button8.Click += new EventHandler(Button8_Click);
            _Button9 = new Button();
            _Button9.Click += new EventHandler(Button9_Click);
            _Button10 = new Button();
            _Button10.Click += new EventHandler(Button10_Click);
            Label1 = new Label();
            _cmOK = new Button();
            _cmOK.Click += new EventHandler(cmOK_Click);
            _cmCancel = new Button();
            _cmCancel.Click += new EventHandler(cmCancel_Click);
            cboMode = new ComboBox();
            Label2 = new Label();
            Label3 = new Label();
            cboSpeed = new ComboBox();
            Label4 = new Label();
            cboHoldTime = new ComboBox();
            tbDelim = new TextBox();
            Label5 = new Label();
            _cboAlign = new ComboBox();
            _cboAlign.SelectedIndexChanged += new EventHandler(cboAlign_SelectedIndexChanged);
            Label6 = new Label();
            lbXOff = new Label();
            tbXoff = new TextBox();
            lbYoff = new Label();
            tbYoff = new TextBox();
            _Button11 = new Button();
            _Button11.Click += new EventHandler(Button11_Click);
            _Button12 = new Button();
            _Button12.Click += new EventHandler(Button12_Click);
            _Button13 = new Button();
            _Button13.Click += new EventHandler(Button13_Click);
            ToolTip1 = new ToolTip(components);
            _cmRotUp = new Button();
            _cmRotUp.Click += new EventHandler(cmRotUp_Click);
            _cmRotDn = new Button();
            _cmRotDn.Click += new EventHandler(cmRotDn_Click);
            SuspendLayout();
            // 
            // tbN04
            // 
            tbN04.BackColor = Color.White;
            tbN04.ForeColor = Color.Black;
            tbN04.Location = new Point(15, 105);
            tbN04.Name = "tbN04";
            tbN04.Size = new Size(467, 20);
            tbN04.TabIndex = 4;
            // 
            // tbN03
            // 
            tbN03.BackColor = Color.White;
            tbN03.ForeColor = Color.Black;
            tbN03.Location = new Point(15, 80);
            tbN03.Name = "tbN03";
            tbN03.Size = new Size(467, 20);
            tbN03.TabIndex = 3;
            // 
            // tbN02
            // 
            tbN02.BackColor = Color.White;
            tbN02.ForeColor = Color.Black;
            tbN02.Location = new Point(15, 55);
            tbN02.Name = "tbN02";
            tbN02.Size = new Size(467, 20);
            tbN02.TabIndex = 2;
            // 
            // tbN01
            // 
            tbN01.BackColor = Color.White;
            tbN01.ForeColor = Color.Black;
            tbN01.Location = new Point(15, 30);
            tbN01.Name = "tbN01";
            tbN01.Size = new Size(467, 20);
            tbN01.TabIndex = 1;
            // 
            // tbN05
            // 
            tbN05.BackColor = Color.White;
            tbN05.ForeColor = Color.Black;
            tbN05.Location = new Point(15, 130);
            tbN05.Name = "tbN05";
            tbN05.Size = new Size(467, 20);
            tbN05.TabIndex = 5;
            // 
            // tbN10
            // 
            tbN10.BackColor = Color.White;
            tbN10.ForeColor = Color.Black;
            tbN10.Location = new Point(15, 255);
            tbN10.Name = "tbN10";
            tbN10.Size = new Size(467, 20);
            tbN10.TabIndex = 10;
            // 
            // tbN09
            // 
            tbN09.BackColor = Color.White;
            tbN09.ForeColor = Color.Black;
            tbN09.Location = new Point(15, 230);
            tbN09.Name = "tbN09";
            tbN09.Size = new Size(467, 20);
            tbN09.TabIndex = 9;
            // 
            // tbN08
            // 
            tbN08.BackColor = Color.White;
            tbN08.ForeColor = Color.Black;
            tbN08.Location = new Point(15, 205);
            tbN08.Name = "tbN08";
            tbN08.Size = new Size(467, 20);
            tbN08.TabIndex = 8;
            // 
            // tbN07
            // 
            tbN07.BackColor = Color.White;
            tbN07.ForeColor = Color.Black;
            tbN07.Location = new Point(15, 180);
            tbN07.Name = "tbN07";
            tbN07.Size = new Size(467, 20);
            tbN07.TabIndex = 7;
            // 
            // tbN06
            // 
            tbN06.BackColor = Color.White;
            tbN06.ForeColor = Color.Black;
            tbN06.Location = new Point(15, 155);
            tbN06.Name = "tbN06";
            tbN06.Size = new Size(467, 20);
            tbN06.TabIndex = 6;
            // 
            // Button1
            // 
            _Button1.Location = new Point(485, 30);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(32, 20);
            _Button1.TabIndex = 18;
            _Button1.Text = "Clr";
            _Button1.UseVisualStyleBackColor = true;
            // 
            // Button2
            // 
            _Button2.Location = new Point(485, 55);
            _Button2.Name = "_Button2";
            _Button2.Size = new Size(32, 20);
            _Button2.TabIndex = 19;
            _Button2.Text = "Clr";
            _Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            _Button3.Location = new Point(485, 80);
            _Button3.Name = "_Button3";
            _Button3.Size = new Size(32, 20);
            _Button3.TabIndex = 20;
            _Button3.Text = "Clr";
            _Button3.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            _Button4.Location = new Point(485, 105);
            _Button4.Name = "_Button4";
            _Button4.Size = new Size(32, 20);
            _Button4.TabIndex = 21;
            _Button4.Text = "Clr";
            _Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            _Button5.Location = new Point(485, 130);
            _Button5.Name = "_Button5";
            _Button5.Size = new Size(32, 20);
            _Button5.TabIndex = 22;
            _Button5.Text = "Clr";
            _Button5.UseVisualStyleBackColor = true;
            // 
            // Button6
            // 
            _Button6.Location = new Point(485, 155);
            _Button6.Name = "_Button6";
            _Button6.Size = new Size(32, 20);
            _Button6.TabIndex = 23;
            _Button6.Text = "Clr";
            _Button6.UseVisualStyleBackColor = true;
            // 
            // Button7
            // 
            _Button7.Location = new Point(485, 180);
            _Button7.Name = "_Button7";
            _Button7.Size = new Size(32, 20);
            _Button7.TabIndex = 24;
            _Button7.Text = "Clr";
            _Button7.UseVisualStyleBackColor = true;
            // 
            // Button8
            // 
            _Button8.Location = new Point(485, 205);
            _Button8.Name = "_Button8";
            _Button8.Size = new Size(32, 20);
            _Button8.TabIndex = 25;
            _Button8.Text = "Clr";
            _Button8.UseVisualStyleBackColor = true;
            // 
            // Button9
            // 
            _Button9.Location = new Point(485, 230);
            _Button9.Name = "_Button9";
            _Button9.Size = new Size(32, 20);
            _Button9.TabIndex = 26;
            _Button9.Text = "Clr";
            _Button9.UseVisualStyleBackColor = true;
            // 
            // Button10
            // 
            _Button10.Location = new Point(485, 255);
            _Button10.Name = "_Button10";
            _Button10.Size = new Size(32, 20);
            _Button10.TabIndex = 27;
            _Button10.Text = "Clr";
            _Button10.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(210, 13);
            Label1.TabIndex = 130;
            Label1.Text = "Enter the text to display for this note object.";
            // 
            // cmOK
            // 
            _cmOK.Location = new Point(551, 32);
            _cmOK.Name = "_cmOK";
            _cmOK.Size = new Size(105, 37);
            _cmOK.TabIndex = 131;
            _cmOK.Text = "OK";
            _cmOK.UseVisualStyleBackColor = true;
            // 
            // cmCancel
            // 
            _cmCancel.Location = new Point(551, 77);
            _cmCancel.Name = "_cmCancel";
            _cmCancel.Size = new Size(105, 37);
            _cmCancel.TabIndex = 132;
            _cmCancel.Text = "Cancel";
            _cmCancel.UseVisualStyleBackColor = true;
            // 
            // cboMode
            // 
            cboMode.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.ForeColor = Color.White;
            cboMode.FormattingEnabled = true;
            cboMode.Location = new Point(125, 295);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(105, 21);
            cboMode.TabIndex = 11;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(10, 300);
            Label2.Name = "Label2";
            Label2.Size = new Size(107, 13);
            Label2.TabIndex = 134;
            Label2.Text = "Text Animation Mode";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(10, 325);
            Label3.Name = "Label3";
            Label3.Size = new Size(111, 13);
            Label3.TabIndex = 135;
            Label3.Text = "Text Animation Speed";
            // 
            // cboSpeed
            // 
            cboSpeed.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            cboSpeed.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSpeed.ForeColor = Color.White;
            cboSpeed.FormattingEnabled = true;
            cboSpeed.Location = new Point(125, 320);
            cboSpeed.Name = "cboSpeed";
            cboSpeed.Size = new Size(105, 21);
            cboSpeed.TabIndex = 12;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(10, 350);
            Label4.Name = "Label4";
            Label4.Size = new Size(104, 13);
            Label4.TabIndex = 137;
            Label4.Text = "Animation Hold Time";
            // 
            // cboHoldTime
            // 
            cboHoldTime.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            cboHoldTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHoldTime.ForeColor = Color.White;
            cboHoldTime.FormattingEnabled = true;
            cboHoldTime.Location = new Point(125, 345);
            cboHoldTime.Name = "cboHoldTime";
            cboHoldTime.Size = new Size(105, 21);
            cboHoldTime.TabIndex = 13;
            // 
            // tbDelim
            // 
            tbDelim.BackColor = Color.White;
            tbDelim.ForeColor = Color.Black;
            tbDelim.Location = new Point(355, 295);
            tbDelim.Name = "tbDelim";
            tbDelim.Size = new Size(125, 20);
            tbDelim.TabIndex = 15;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(255, 300);
            Label5.Name = "Label5";
            Label5.Size = new Size(99, 13);
            Label5.TabIndex = 140;
            Label5.Text = "Message Seperator";
            // 
            // cboAlign
            // 
            _cboAlign.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)), Conversions.ToInteger(Conversions.ToByte(64)));
            _cboAlign.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAlign.ForeColor = Color.White;
            _cboAlign.FormattingEnabled = true;
            _cboAlign.Location = new Point(125, 370);
            _cboAlign.Name = "_cboAlign";
            _cboAlign.Size = new Size(105, 21);
            _cboAlign.TabIndex = 14;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(10, 375);
            Label6.Name = "Label6";
            Label6.Size = new Size(77, 13);
            Label6.TabIndex = 142;
            Label6.Text = "Text Alignment";
            // 
            // lbXOff
            // 
            lbXOff.AutoSize = true;
            lbXOff.Location = new Point(255, 325);
            lbXOff.Name = "lbXOff";
            lbXOff.Size = new Size(69, 13);
            lbXOff.TabIndex = 143;
            lbXOff.Text = "Text X Offset";
            // 
            // tbXoff
            // 
            tbXoff.BackColor = Color.White;
            tbXoff.ForeColor = Color.Black;
            tbXoff.Location = new Point(355, 320);
            tbXoff.Name = "tbXoff";
            tbXoff.Size = new Size(125, 20);
            tbXoff.TabIndex = 16;
            // 
            // lbYoff
            // 
            lbYoff.AutoSize = true;
            lbYoff.Location = new Point(255, 350);
            lbYoff.Name = "lbYoff";
            lbYoff.Size = new Size(69, 13);
            lbYoff.TabIndex = 145;
            lbYoff.Text = "Text Y Offset";
            // 
            // tbYoff
            // 
            tbYoff.BackColor = Color.White;
            tbYoff.ForeColor = Color.Black;
            tbYoff.Location = new Point(355, 345);
            tbYoff.Name = "tbYoff";
            tbYoff.Size = new Size(125, 20);
            tbYoff.TabIndex = 17;
            // 
            // Button11
            // 
            _Button11.Location = new Point(485, 295);
            _Button11.Name = "_Button11";
            _Button11.Size = new Size(32, 20);
            _Button11.TabIndex = 28;
            _Button11.Text = "Clr";
            _Button11.UseVisualStyleBackColor = true;
            // 
            // Button12
            // 
            _Button12.Location = new Point(485, 320);
            _Button12.Name = "_Button12";
            _Button12.Size = new Size(32, 20);
            _Button12.TabIndex = 29;
            _Button12.Text = "Clr";
            _Button12.UseVisualStyleBackColor = true;
            // 
            // Button13
            // 
            _Button13.Location = new Point(485, 345);
            _Button13.Name = "_Button13";
            _Button13.Size = new Size(32, 20);
            _Button13.TabIndex = 30;
            _Button13.Text = "Clr";
            _Button13.UseVisualStyleBackColor = true;
            // 
            // cmRotUp
            // 
            _cmRotUp.Location = new Point(551, 163);
            _cmRotUp.Name = "_cmRotUp";
            _cmRotUp.Size = new Size(105, 37);
            _cmRotUp.TabIndex = 146;
            _cmRotUp.Text = "Rotate Notes Up";
            _cmRotUp.UseVisualStyleBackColor = true;
            // 
            // cmRotDn
            // 
            _cmRotDn.Location = new Point(551, 206);
            _cmRotDn.Name = "_cmRotDn";
            _cmRotDn.Size = new Size(105, 37);
            _cmRotDn.TabIndex = 147;
            _cmRotDn.Text = "Rotate Notes Dn";
            _cmRotDn.UseVisualStyleBackColor = true;
            // 
            // frmNotes
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)), Conversions.ToInteger(Conversions.ToByte(232)));
            ClientSize = new Size(682, 417);
            Controls.Add(_cmRotDn);
            Controls.Add(_cmRotUp);
            Controls.Add(_Button13);
            Controls.Add(_Button12);
            Controls.Add(_Button11);
            Controls.Add(tbYoff);
            Controls.Add(lbYoff);
            Controls.Add(tbXoff);
            Controls.Add(lbXOff);
            Controls.Add(Label6);
            Controls.Add(_cboAlign);
            Controls.Add(Label5);
            Controls.Add(tbDelim);
            Controls.Add(cboHoldTime);
            Controls.Add(Label4);
            Controls.Add(cboSpeed);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(cboMode);
            Controls.Add(_cmCancel);
            Controls.Add(_cmOK);
            Controls.Add(Label1);
            Controls.Add(_Button10);
            Controls.Add(_Button9);
            Controls.Add(_Button8);
            Controls.Add(_Button7);
            Controls.Add(_Button6);
            Controls.Add(_Button5);
            Controls.Add(_Button4);
            Controls.Add(_Button3);
            Controls.Add(_Button2);
            Controls.Add(_Button1);
            Controls.Add(tbN10);
            Controls.Add(tbN09);
            Controls.Add(tbN08);
            Controls.Add(tbN07);
            Controls.Add(tbN06);
            Controls.Add(tbN05);
            Controls.Add(tbN04);
            Controls.Add(tbN03);
            Controls.Add(tbN02);
            Controls.Add(tbN01);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmNotes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MakoCELO - Note Definition";
            Load += new EventHandler(frmNotes_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox tbN04;
        internal TextBox tbN03;
        internal TextBox tbN02;
        internal TextBox tbN01;
        internal TextBox tbN05;
        internal TextBox tbN10;
        internal TextBox tbN09;
        internal TextBox tbN08;
        internal TextBox tbN07;
        internal TextBox tbN06;
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

        private Button _Button2;

        internal Button Button2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button2 != null)
                {
                    _Button2.Click -= Button2_Click;
                }

                _Button2 = value;
                if (_Button2 != null)
                {
                    _Button2.Click += Button2_Click;
                }
            }
        }

        private Button _Button3;

        internal Button Button3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button3 != null)
                {
                    _Button3.Click -= Button3_Click;
                }

                _Button3 = value;
                if (_Button3 != null)
                {
                    _Button3.Click += Button3_Click;
                }
            }
        }

        private Button _Button4;

        internal Button Button4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button4 != null)
                {
                    _Button4.Click -= Button4_Click;
                }

                _Button4 = value;
                if (_Button4 != null)
                {
                    _Button4.Click += Button4_Click;
                }
            }
        }

        private Button _Button5;

        internal Button Button5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button5 != null)
                {
                    _Button5.Click -= Button5_Click;
                }

                _Button5 = value;
                if (_Button5 != null)
                {
                    _Button5.Click += Button5_Click;
                }
            }
        }

        private Button _Button6;

        internal Button Button6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button6 != null)
                {
                    _Button6.Click -= Button6_Click;
                }

                _Button6 = value;
                if (_Button6 != null)
                {
                    _Button6.Click += Button6_Click;
                }
            }
        }

        private Button _Button7;

        internal Button Button7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button7 != null)
                {
                    _Button7.Click -= Button7_Click;
                }

                _Button7 = value;
                if (_Button7 != null)
                {
                    _Button7.Click += Button7_Click;
                }
            }
        }

        private Button _Button8;

        internal Button Button8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button8 != null)
                {
                    _Button8.Click -= Button8_Click;
                }

                _Button8 = value;
                if (_Button8 != null)
                {
                    _Button8.Click += Button8_Click;
                }
            }
        }

        private Button _Button9;

        internal Button Button9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button9 != null)
                {
                    _Button9.Click -= Button9_Click;
                }

                _Button9 = value;
                if (_Button9 != null)
                {
                    _Button9.Click += Button9_Click;
                }
            }
        }

        private Button _Button10;

        internal Button Button10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button10 != null)
                {
                    _Button10.Click -= Button10_Click;
                }

                _Button10 = value;
                if (_Button10 != null)
                {
                    _Button10.Click += Button10_Click;
                }
            }
        }

        internal Label Label1;
        private Button _cmOK;

        internal Button cmOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmOK != null)
                {
                    _cmOK.Click -= cmOK_Click;
                }

                _cmOK = value;
                if (_cmOK != null)
                {
                    _cmOK.Click += cmOK_Click;
                }
            }
        }

        private Button _cmCancel;

        internal Button cmCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmCancel != null)
                {
                    _cmCancel.Click -= cmCancel_Click;
                }

                _cmCancel = value;
                if (_cmCancel != null)
                {
                    _cmCancel.Click += cmCancel_Click;
                }
            }
        }

        internal ComboBox cboMode;
        internal Label Label2;
        internal Label Label3;
        internal ComboBox cboSpeed;
        internal Label Label4;
        internal ComboBox cboHoldTime;
        internal TextBox tbDelim;
        internal Label Label5;
        private ComboBox _cboAlign;

        internal ComboBox cboAlign
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAlign;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAlign != null)
                {
                    _cboAlign.SelectedIndexChanged -= cboAlign_SelectedIndexChanged;
                }

                _cboAlign = value;
                if (_cboAlign != null)
                {
                    _cboAlign.SelectedIndexChanged += cboAlign_SelectedIndexChanged;
                }
            }
        }

        internal Label Label6;
        internal Label lbXOff;
        internal TextBox tbXoff;
        internal Label lbYoff;
        internal TextBox tbYoff;
        private Button _Button11;

        internal Button Button11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button11 != null)
                {
                    _Button11.Click -= Button11_Click;
                }

                _Button11 = value;
                if (_Button11 != null)
                {
                    _Button11.Click += Button11_Click;
                }
            }
        }

        private Button _Button12;

        internal Button Button12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button12 != null)
                {
                    _Button12.Click -= Button12_Click;
                }

                _Button12 = value;
                if (_Button12 != null)
                {
                    _Button12.Click += Button12_Click;
                }
            }
        }

        private Button _Button13;

        internal Button Button13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button13 != null)
                {
                    _Button13.Click -= Button13_Click;
                }

                _Button13 = value;
                if (_Button13 != null)
                {
                    _Button13.Click += Button13_Click;
                }
            }
        }

        internal ToolTip ToolTip1;
        private Button _cmRotUp;

        internal Button cmRotUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmRotUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmRotUp != null)
                {
                    _cmRotUp.Click -= cmRotUp_Click;
                }

                _cmRotUp = value;
                if (_cmRotUp != null)
                {
                    _cmRotUp.Click += cmRotUp_Click;
                }
            }
        }

        private Button _cmRotDn;

        internal Button cmRotDn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmRotDn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmRotDn != null)
                {
                    _cmRotDn.Click -= cmRotDn_Click;
                }

                _cmRotDn = value;
                if (_cmRotDn != null)
                {
                    _cmRotDn.Click += cmRotDn_Click;
                }
            }
        }
    }
}