namespace ThreadedProjectTerm2
{
    partial class frmAgents
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
            System.Windows.Forms.Label agencyIDLabel;
            System.Windows.Forms.Label agentIDLabel;
            System.Windows.Forms.Label agtBusPhoneLabel;
            System.Windows.Forms.Label agtEmailLabel;
            System.Windows.Forms.Label agtFirstNameLabel;
            System.Windows.Forms.Label agtLastNameLabel;
            System.Windows.Forms.Label agtMiddleInitialLabel;
            System.Windows.Forms.Label agtPositionLabel;
            this.agentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.agencyIDTextBox = new System.Windows.Forms.TextBox();
            this.agentIDTextBox = new System.Windows.Forms.TextBox();
            this.agtBusPhoneTextBox = new System.Windows.Forms.TextBox();
            this.agtEmailTextBox = new System.Windows.Forms.TextBox();
            this.agtFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.agtLastNameTextBox = new System.Windows.Forms.TextBox();
            this.agtMiddleInitialTextBox = new System.Windows.Forms.TextBox();
            this.agtPositionTextBox = new System.Windows.Forms.TextBox();
            agencyIDLabel = new System.Windows.Forms.Label();
            agentIDLabel = new System.Windows.Forms.Label();
            agtBusPhoneLabel = new System.Windows.Forms.Label();
            agtEmailLabel = new System.Windows.Forms.Label();
            agtFirstNameLabel = new System.Windows.Forms.Label();
            agtLastNameLabel = new System.Windows.Forms.Label();
            agtMiddleInitialLabel = new System.Windows.Forms.Label();
            agtPositionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.agentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // agencyIDLabel
            // 
            agencyIDLabel.AutoSize = true;
            agencyIDLabel.Location = new System.Drawing.Point(494, 148);
            agencyIDLabel.Name = "agencyIDLabel";
            agencyIDLabel.Size = new System.Drawing.Size(60, 13);
            agencyIDLabel.TabIndex = 1;
            agencyIDLabel.Text = "Agency ID:";
            // 
            // agentIDLabel
            // 
            agentIDLabel.AutoSize = true;
            agentIDLabel.Location = new System.Drawing.Point(217, 67);
            agentIDLabel.Name = "agentIDLabel";
            agentIDLabel.Size = new System.Drawing.Size(52, 13);
            agentIDLabel.TabIndex = 3;
            agentIDLabel.Text = "Agent ID:";
            // 
            // agtBusPhoneLabel
            // 
            agtBusPhoneLabel.AutoSize = true;
            agtBusPhoneLabel.Location = new System.Drawing.Point(461, 67);
            agtBusPhoneLabel.Name = "agtBusPhoneLabel";
            agtBusPhoneLabel.Size = new System.Drawing.Size(93, 13);
            agtBusPhoneLabel.TabIndex = 5;
            agtBusPhoneLabel.Text = "Agent Bus Phone:";
            // 
            // agtEmailLabel
            // 
            agtEmailLabel.AutoSize = true;
            agtEmailLabel.Location = new System.Drawing.Point(488, 95);
            agtEmailLabel.Name = "agtEmailLabel";
            agtEmailLabel.Size = new System.Drawing.Size(66, 13);
            agtEmailLabel.TabIndex = 7;
            agtEmailLabel.Text = "Agent Email:";
            // 
            // agtFirstNameLabel
            // 
            agtFirstNameLabel.AutoSize = true;
            agtFirstNameLabel.Location = new System.Drawing.Point(178, 95);
            agtFirstNameLabel.Name = "agtFirstNameLabel";
            agtFirstNameLabel.Size = new System.Drawing.Size(91, 13);
            agtFirstNameLabel.TabIndex = 9;
            agtFirstNameLabel.Text = "Agent First Name:";
            // 
            // agtLastNameLabel
            // 
            agtLastNameLabel.AutoSize = true;
            agtLastNameLabel.Location = new System.Drawing.Point(177, 122);
            agtLastNameLabel.Name = "agtLastNameLabel";
            agtLastNameLabel.Size = new System.Drawing.Size(92, 13);
            agtLastNameLabel.TabIndex = 11;
            agtLastNameLabel.Text = "Agent Last Name:";
            // 
            // agtMiddleInitialLabel
            // 
            agtMiddleInitialLabel.AutoSize = true;
            agtMiddleInitialLabel.Location = new System.Drawing.Point(170, 148);
            agtMiddleInitialLabel.Name = "agtMiddleInitialLabel";
            agtMiddleInitialLabel.Size = new System.Drawing.Size(99, 13);
            agtMiddleInitialLabel.TabIndex = 13;
            agtMiddleInitialLabel.Text = "Agent Middle Initial:";
            // 
            // agtPositionLabel
            // 
            agtPositionLabel.AutoSize = true;
            agtPositionLabel.Location = new System.Drawing.Point(476, 122);
            agtPositionLabel.Name = "agtPositionLabel";
            agtPositionLabel.Size = new System.Drawing.Size(78, 13);
            agtPositionLabel.TabIndex = 15;
            agtPositionLabel.Text = "Agent Position:";
            // 
            // agentBindingSource
            // 
            this.agentBindingSource.DataSource = typeof(TravelExpertsClasses.Agent);
            // 
            // agentDataGridView
            // 
            this.agentDataGridView.AutoGenerateColumns = false;
            this.agentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.agentDataGridView.DataSource = this.agentBindingSource;
            this.agentDataGridView.Location = new System.Drawing.Point(11, 254);
            this.agentDataGridView.Name = "agentDataGridView";
            this.agentDataGridView.ReadOnly = true;
            this.agentDataGridView.Size = new System.Drawing.Size(850, 219);
            this.agentDataGridView.TabIndex = 1;
            this.agentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AgentID";
            this.dataGridViewTextBoxColumn1.FillWeight = 75F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Agent ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AgtFirstName";
            this.dataGridViewTextBoxColumn2.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 105;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AgtLastName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AgtMiddleInitial";
            this.dataGridViewTextBoxColumn4.FillWeight = 60F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Middle Initial";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AgtBusPhone";
            this.dataGridViewTextBoxColumn5.HeaderText = "Business Phone";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "AgtEmail";
            this.dataGridViewTextBoxColumn6.HeaderText = "Email Address";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AgtPosition";
            this.dataGridViewTextBoxColumn7.FillWeight = 80F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Position";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "AgencyID";
            this.dataGridViewTextBoxColumn8.FillWeight = 70F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Agency ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(agencyIDLabel);
            this.panel1.Controls.Add(this.agencyIDTextBox);
            this.panel1.Controls.Add(agentIDLabel);
            this.panel1.Controls.Add(this.agentIDTextBox);
            this.panel1.Controls.Add(agtBusPhoneLabel);
            this.panel1.Controls.Add(this.agtBusPhoneTextBox);
            this.panel1.Controls.Add(agtEmailLabel);
            this.panel1.Controls.Add(this.agtEmailTextBox);
            this.panel1.Controls.Add(agtFirstNameLabel);
            this.panel1.Controls.Add(this.agtFirstNameTextBox);
            this.panel1.Controls.Add(agtLastNameLabel);
            this.panel1.Controls.Add(this.agtLastNameTextBox);
            this.panel1.Controls.Add(agtMiddleInitialLabel);
            this.panel1.Controls.Add(this.agtMiddleInitialTextBox);
            this.panel1.Controls.Add(agtPositionLabel);
            this.panel1.Controls.Add(this.agtPositionTextBox);
            this.panel1.Controls.Add(this.agentDataGridView);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 495);
            this.panel1.TabIndex = 2;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(277, 202);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 26);
            this.UpdateButton.TabIndex = 21;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(486, 202);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 26);
            this.DeleteButton.TabIndex = 20;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(709, 202);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 26);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(59, 202);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 26);
            this.AddButton.TabIndex = 18;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Agents:       Click on a Cell to Modify it.";
            // 
            // agencyIDTextBox
            // 
            this.agencyIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgencyID", true));
            this.agencyIDTextBox.Location = new System.Drawing.Point(573, 145);
            this.agencyIDTextBox.Name = "agencyIDTextBox";
            this.agencyIDTextBox.Size = new System.Drawing.Size(120, 20);
            this.agencyIDTextBox.TabIndex = 2;
            // 
            // agentIDTextBox
            // 
            this.agentIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgentID", true));
            this.agentIDTextBox.Location = new System.Drawing.Point(290, 64);
            this.agentIDTextBox.Name = "agentIDTextBox";
            this.agentIDTextBox.ReadOnly = true;
            this.agentIDTextBox.Size = new System.Drawing.Size(116, 20);
            this.agentIDTextBox.TabIndex = 4;
            // 
            // agtBusPhoneTextBox
            // 
            this.agtBusPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtBusPhone", true));
            this.agtBusPhoneTextBox.Location = new System.Drawing.Point(573, 64);
            this.agtBusPhoneTextBox.Name = "agtBusPhoneTextBox";
            this.agtBusPhoneTextBox.Size = new System.Drawing.Size(120, 20);
            this.agtBusPhoneTextBox.TabIndex = 6;
            // 
            // agtEmailTextBox
            // 
            this.agtEmailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtEmail", true));
            this.agtEmailTextBox.Location = new System.Drawing.Point(573, 92);
            this.agtEmailTextBox.Name = "agtEmailTextBox";
            this.agtEmailTextBox.Size = new System.Drawing.Size(120, 20);
            this.agtEmailTextBox.TabIndex = 8;
            // 
            // agtFirstNameTextBox
            // 
            this.agtFirstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtFirstName", true));
            this.agtFirstNameTextBox.Location = new System.Drawing.Point(290, 92);
            this.agtFirstNameTextBox.Name = "agtFirstNameTextBox";
            this.agtFirstNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.agtFirstNameTextBox.TabIndex = 10;
            // 
            // agtLastNameTextBox
            // 
            this.agtLastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtLastName", true));
            this.agtLastNameTextBox.Location = new System.Drawing.Point(290, 119);
            this.agtLastNameTextBox.Name = "agtLastNameTextBox";
            this.agtLastNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.agtLastNameTextBox.TabIndex = 12;
            // 
            // agtMiddleInitialTextBox
            // 
            this.agtMiddleInitialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtMiddleInitial", true));
            this.agtMiddleInitialTextBox.Location = new System.Drawing.Point(290, 145);
            this.agtMiddleInitialTextBox.Name = "agtMiddleInitialTextBox";
            this.agtMiddleInitialTextBox.Size = new System.Drawing.Size(116, 20);
            this.agtMiddleInitialTextBox.TabIndex = 14;
            // 
            // agtPositionTextBox
            // 
            this.agtPositionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.agentBindingSource, "AgtPosition", true));
            this.agtPositionTextBox.Location = new System.Drawing.Point(573, 119);
            this.agtPositionTextBox.Name = "agtPositionTextBox";
            this.agtPositionTextBox.Size = new System.Drawing.Size(120, 20);
            this.agtPositionTextBox.TabIndex = 16;
            // 
            // frmAgents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 494);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAgents";
            this.Text = "frmAgents";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAgents_FormClosed);
            this.Load += new System.EventHandler(this.frmAgents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agentDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource agentBindingSource;
        private System.Windows.Forms.DataGridView agentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox agencyIDTextBox;
        private System.Windows.Forms.TextBox agentIDTextBox;
        private System.Windows.Forms.TextBox agtBusPhoneTextBox;
        private System.Windows.Forms.TextBox agtEmailTextBox;
        private System.Windows.Forms.TextBox agtFirstNameTextBox;
        private System.Windows.Forms.TextBox agtLastNameTextBox;
        private System.Windows.Forms.TextBox agtMiddleInitialTextBox;
        private System.Windows.Forms.TextBox agtPositionTextBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AddButton;
    }
}