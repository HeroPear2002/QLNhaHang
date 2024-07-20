namespace QLNhaHang
{
	partial class fmTest
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
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.panel1 = new System.Windows.Forms.Panel();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.button1 = new System.Windows.Forms.Button();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.panel1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(966, 597);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(966, 597);
			this.Root.TextVisible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.simpleButton2);
			this.panel1.Controls.Add(this.simpleButton1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(132, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(822, 573);
			this.panel1.TabIndex = 4;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.panel1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(946, 577);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(117, 19);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Aqua;
			this.button1.Location = new System.Drawing.Point(432, 238);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(348, 270);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
			this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.White;
			this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.White;
			this.simpleButton1.Appearance.Options.UseBackColor = true;
			this.simpleButton1.AppearanceDisabled.BackColor = System.Drawing.Color.White;
			this.simpleButton1.AppearanceDisabled.BorderColor = System.Drawing.Color.White;
			this.simpleButton1.AppearanceDisabled.Options.UseBackColor = true;
			this.simpleButton1.AppearanceDisabled.Options.UseBorderColor = true;
			this.simpleButton1.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.simpleButton1.AppearanceHovered.Options.UseBorderColor = true;
			this.simpleButton1.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.simpleButton1.AppearancePressed.Options.UseBorderColor = true;
			this.simpleButton1.Location = new System.Drawing.Point(37, 445);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(125, 41);
			this.simpleButton1.TabIndex = 1;
			this.simpleButton1.Text = "simpleButton1";
			// 
			// simpleButton2
			// 
			this.simpleButton2.Cursor = System.Windows.Forms.Cursors.No;
			this.simpleButton2.Location = new System.Drawing.Point(58, 361);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(119, 48);
			this.simpleButton2.TabIndex = 2;
			this.simpleButton2.Text = "simpleButton2";
			// 
			// fmTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(966, 597);
			this.Controls.Add(this.layoutControl1);
			this.Name = "fmTest";
			this.Text = "fmTest";
			this.Load += new System.EventHandler(this.fmTest_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
	}
}