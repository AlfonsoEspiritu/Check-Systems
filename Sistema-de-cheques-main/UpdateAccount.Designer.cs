namespace Sistema_de_Cheques
{
	partial class UpdateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAccount));
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnEditName = new System.Windows.Forms.Button();
            this.btnEditBankName = new System.Windows.Forms.Button();
            this.btnEditAccountNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(485, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(433, 62);
            this.label5.TabIndex = 27;
            this.label5.Text = "Actualizar datos";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Location = new System.Drawing.Point(765, 708);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(481, 62);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.Location = new System.Drawing.Point(193, 708);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(481, 62);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Actualizar datos";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(168, 661);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1095, 3);
            this.panel2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(176, 491);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 38);
            this.label3.TabIndex = 23;
            this.label3.Text = "Número de cuenta";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Enabled = false;
            this.txtAccountNumber.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAccountNumber.Location = new System.Drawing.Point(176, 537);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountNumber.Multiline = true;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(988, 52);
            this.txtAccountNumber.TabIndex = 22;
            this.txtAccountNumber.Leave += new System.EventHandler(this.txtAccountNumber_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(176, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 38);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nombre del banco";
            // 
            // txtBankName
            // 
            this.txtBankName.Enabled = false;
            this.txtBankName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBankName.Location = new System.Drawing.Point(176, 373);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBankName.Multiline = true;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(985, 54);
            this.txtBankName.TabIndex = 20;
            this.txtBankName.Leave += new System.EventHandler(this.txtBankName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(176, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(176, 232);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(985, 52);
            this.txtName.TabIndex = 16;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // btnEditName
            // 
            this.btnEditName.BackColor = System.Drawing.Color.Silver;
            this.btnEditName.FlatAppearance.BorderSize = 0;
            this.btnEditName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEditName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditName.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEditName.Image = ((System.Drawing.Image)(resources.GetObject("btnEditName.Image")));
            this.btnEditName.Location = new System.Drawing.Point(1200, 232);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(46, 52);
            this.btnEditName.TabIndex = 29;
            this.btnEditName.UseVisualStyleBackColor = false;
            this.btnEditName.Click += new System.EventHandler(this.btnEditName_Click);
            // 
            // btnEditBankName
            // 
            this.btnEditBankName.BackColor = System.Drawing.Color.Silver;
            this.btnEditBankName.FlatAppearance.BorderSize = 0;
            this.btnEditBankName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEditBankName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditBankName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBankName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditBankName.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEditBankName.Image = ((System.Drawing.Image)(resources.GetObject("btnEditBankName.Image")));
            this.btnEditBankName.Location = new System.Drawing.Point(1202, 375);
            this.btnEditBankName.Name = "btnEditBankName";
            this.btnEditBankName.Size = new System.Drawing.Size(44, 52);
            this.btnEditBankName.TabIndex = 30;
            this.btnEditBankName.UseVisualStyleBackColor = false;
            this.btnEditBankName.Click += new System.EventHandler(this.btnEditBankName_Click);
            // 
            // btnEditAccountNumber
            // 
            this.btnEditAccountNumber.BackColor = System.Drawing.Color.Silver;
            this.btnEditAccountNumber.FlatAppearance.BorderSize = 0;
            this.btnEditAccountNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnEditAccountNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditAccountNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAccountNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditAccountNumber.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEditAccountNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAccountNumber.Image")));
            this.btnEditAccountNumber.Location = new System.Drawing.Point(1199, 537);
            this.btnEditAccountNumber.Name = "btnEditAccountNumber";
            this.btnEditAccountNumber.Size = new System.Drawing.Size(46, 52);
            this.btnEditAccountNumber.TabIndex = 31;
            this.btnEditAccountNumber.UseVisualStyleBackColor = false;
            this.btnEditAccountNumber.Click += new System.EventHandler(this.btnEditAccountNumber_Click);
            // 
            // UpdateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1371, 817);
            this.Controls.Add(this.btnEditAccountNumber);
            this.Controls.Add(this.btnEditBankName);
            this.Controls.Add(this.btnEditName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UpdateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateAccount";
            this.Load += new System.EventHandler(this.UpdateAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label label5;
		private Button btnCancel;
		private Button btnUpdate;
		private Panel panel2;
		private Label label3;
		private TextBox txtAccountNumber;
		private Label label4;
		private TextBox txtBankName;
		private Label label1;
		private TextBox txtName;
		private Button btnEditName;
		private Button btnEditBankName;
		private Button btnEditAccountNumber;
	}
}