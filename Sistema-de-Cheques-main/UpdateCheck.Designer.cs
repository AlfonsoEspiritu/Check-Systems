namespace Sistema_de_Cheques
{
    partial class UpdateCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCheck));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBeneficiary = new System.Windows.Forms.Button();
            this.txtMount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.CheckBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnConcept = new System.Windows.Forms.Button();
            this.btnMount = new System.Windows.Forms.Button();
            this.txtBeneficiary = new System.Windows.Forms.ComboBox();
            this.txtConcept = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(184, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualizar datos del cheque";
            // 
            // btnBeneficiary
            // 
            this.btnBeneficiary.Image = ((System.Drawing.Image)(resources.GetObject("btnBeneficiary.Image")));
            this.btnBeneficiary.Location = new System.Drawing.Point(658, 146);
            this.btnBeneficiary.Name = "btnBeneficiary";
            this.btnBeneficiary.Size = new System.Drawing.Size(31, 27);
            this.btnBeneficiary.TabIndex = 18;
            this.btnBeneficiary.UseVisualStyleBackColor = true;
            this.btnBeneficiary.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtMount
            // 
            this.txtMount.Enabled = false;
            this.txtMount.Font = new System.Drawing.Font("Segoe UI Emoji", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMount.Location = new System.Drawing.Point(273, 284);
            this.txtMount.Name = "txtMount";
            this.txtMount.Size = new System.Drawing.Size(365, 30);
            this.txtMount.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(127, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Monto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(127, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Concepto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(127, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(123, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Beneficiario:";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Enabled = false;
            this.txtInvoice.Font = new System.Drawing.Font("Segoe UI Emoji", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInvoice.Location = new System.Drawing.Point(274, 98);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(364, 30);
            this.txtInvoice.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(127, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Folio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(131, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Estado";
            // 
            // cbState
            // 
            this.cbState.AutoSize = true;
            this.cbState.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbState.ForeColor = System.Drawing.SystemColors.Control;
            this.cbState.Location = new System.Drawing.Point(273, 335);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(98, 24);
            this.cbState.TabIndex = 32;
            this.cbState.Text = "Cancelado";
            this.cbState.UseVisualStyleBackColor = true;
            // 
            // btnDate
            // 
            this.btnDate.Image = ((System.Drawing.Image)(resources.GetObject("btnDate.Image")));
            this.btnDate.Location = new System.Drawing.Point(658, 191);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(31, 27);
            this.btnDate.TabIndex = 33;
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // btnConcept
            // 
            this.btnConcept.Image = ((System.Drawing.Image)(resources.GetObject("btnConcept.Image")));
            this.btnConcept.Location = new System.Drawing.Point(658, 238);
            this.btnConcept.Name = "btnConcept";
            this.btnConcept.Size = new System.Drawing.Size(31, 27);
            this.btnConcept.TabIndex = 34;
            this.btnConcept.UseVisualStyleBackColor = true;
            this.btnConcept.Click += new System.EventHandler(this.btnConcept_Click);
            // 
            // btnMount
            // 
            this.btnMount.Image = ((System.Drawing.Image)(resources.GetObject("btnMount.Image")));
            this.btnMount.Location = new System.Drawing.Point(658, 287);
            this.btnMount.Name = "btnMount";
            this.btnMount.Size = new System.Drawing.Size(31, 27);
            this.btnMount.TabIndex = 35;
            this.btnMount.UseVisualStyleBackColor = true;
            this.btnMount.Click += new System.EventHandler(this.btnMount_Click);
            // 
            // txtBeneficiary
            // 
            this.txtBeneficiary.Enabled = false;
            this.txtBeneficiary.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBeneficiary.FormattingEnabled = true;
            this.txtBeneficiary.Location = new System.Drawing.Point(273, 147);
            this.txtBeneficiary.Name = "txtBeneficiary";
            this.txtBeneficiary.Size = new System.Drawing.Size(365, 29);
            this.txtBeneficiary.TabIndex = 36;
            // 
            // txtConcept
            // 
            this.txtConcept.Enabled = false;
            this.txtConcept.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConcept.FormattingEnabled = true;
            this.txtConcept.Location = new System.Drawing.Point(273, 238);
            this.txtConcept.Name = "txtConcept";
            this.txtConcept.Size = new System.Drawing.Size(365, 29);
            this.txtConcept.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Location = new System.Drawing.Point(466, 381);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 29);
            this.btnCancel.TabIndex = 39;
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
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUpdate.Location = new System.Drawing.Point(230, 381);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 29);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Location = new System.Drawing.Point(274, 196);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(364, 28);
            this.txtDate.TabIndex = 40;
            // 
            // UpdateCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtConcept);
            this.Controls.Add(this.txtBeneficiary);
            this.Controls.Add(this.btnMount);
            this.Controls.Add(this.btnConcept);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBeneficiary);
            this.Controls.Add(this.label1);
            this.Name = "UpdateCheck";
            this.Text = "UpdateCheck";
            this.Load += new System.EventHandler(this.UpdateCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnBeneficiary;
        private TextBox txtMount;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private TextBox txtInvoice;
        private Label label2;
        private Label label7;
        private CheckBox cbState;
        private Button btnDate;
        private Button btnConcept;
        private Button btnMount;
        private ComboBox txtBeneficiary;
        private ComboBox txtConcept;
        private Button btnCancel;
        private Button btnUpdate;
        private DateTimePicker txtDate;
    }
}