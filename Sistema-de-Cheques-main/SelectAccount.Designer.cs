namespace Sistema_de_Cheques
{
	partial class SelectAccount
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
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.accountsTable = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelAccount = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(438, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(862, 70);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selecciona cuenta bancaria";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(826, 778);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(576, 52);
            this.button1.TabIndex = 17;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountsTable
            // 
            this.accountsTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accountsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.Balance,
            this.BankName,
            this.AccountNumber,
            this.id});
            this.accountsTable.Location = new System.Drawing.Point(220, 173);
            this.accountsTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accountsTable.Name = "accountsTable";
            this.accountsTable.RowHeadersWidth = 62;
            this.accountsTable.RowTemplate.Height = 25;
            this.accountsTable.Size = new System.Drawing.Size(1247, 510);
            this.accountsTable.TabIndex = 18;
            this.accountsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accountsTable_CellContentClick);
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.HeaderText = "Nombre";
            this.UserName.MinimumWidth = 8;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Balance.FillWeight = 70F;
            this.Balance.HeaderText = "Balance";
            this.Balance.MinimumWidth = 8;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // BankName
            // 
            this.BankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BankName.HeaderText = "Banco";
            this.BankName.MinimumWidth = 8;
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            // 
            // AccountNumber
            // 
            this.AccountNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccountNumber.FillWeight = 60F;
            this.AccountNumber.HeaderText = "Número de cuenta";
            this.AccountNumber.MinimumWidth = 8;
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 150;
            // 
            // labelAccount
            // 
            this.labelAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccount.AutoSize = true;
            this.labelAccount.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAccount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelAccount.Location = new System.Drawing.Point(220, 708);
            this.labelAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(247, 38);
            this.labelAccount.TabIndex = 19;
            this.labelAccount.Text = "Cuenta activa:";
            this.labelAccount.Click += new System.EventHandler(this.labelAccount_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(220, 778);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(576, 52);
            this.button2.TabIndex = 20;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1646, 950);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.accountsTable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectAccount";
            this.Text = "Cuentas de usuario";
            this.Load += new System.EventHandler(this.SelectAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label label5;
		private Button button1;
		private DataGridView accountsTable;
		private Label labelAccount;
		private DataGridViewTextBoxColumn UserName;
		private DataGridViewTextBoxColumn Balance;
		private DataGridViewTextBoxColumn BankName;
		private DataGridViewTextBoxColumn AccountNumber;
		private DataGridViewTextBoxColumn id;
        private Button button2;
    }
}