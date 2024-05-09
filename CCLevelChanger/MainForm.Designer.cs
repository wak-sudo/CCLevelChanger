
namespace CCLevelChanger
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.levelsComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.savesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.campaignsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.infoLabel.Location = new System.Drawing.Point(10, 6);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(183, 13);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Files from the default saving path:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(10, 137);
            this.filePathTextBox.Multiline = true;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.filePathTextBox.Size = new System.Drawing.Size(293, 39);
            this.filePathTextBox.TabIndex = 3;
            this.filePathTextBox.WordWrap = false;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(157, 111);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(146, 21);
            this.openFileButton.TabIndex = 4;
            this.openFileButton.Text = "Open a different file";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // levelsComboBox
            // 
            this.levelsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelsComboBox.DropDownWidth = 170;
            this.levelsComboBox.FormattingEnabled = true;
            this.levelsComboBox.Location = new System.Drawing.Point(199, 49);
            this.levelsComboBox.Name = "levelsComboBox";
            this.levelsComboBox.Size = new System.Drawing.Size(104, 21);
            this.levelsComboBox.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(198, 75);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 31);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // savesListBox
            // 
            this.savesListBox.FormattingEnabled = true;
            this.savesListBox.Location = new System.Drawing.Point(10, 24);
            this.savesListBox.Name = "savesListBox";
            this.savesListBox.Size = new System.Drawing.Size(183, 82);
            this.savesListBox.TabIndex = 7;
            this.savesListBox.SelectedValueChanged += new System.EventHandler(this.SavesListBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.Location = new System.Drawing.Point(199, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Level select:";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(10, 111);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(141, 21);
            this.RefreshButton.TabIndex = 9;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // campaignsComboBox
            // 
            this.campaignsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.campaignsComboBox.FormattingEnabled = true;
            this.campaignsComboBox.Location = new System.Drawing.Point(199, 24);
            this.campaignsComboBox.Name = "campaignsComboBox";
            this.campaignsComboBox.Size = new System.Drawing.Size(104, 21);
            this.campaignsComboBox.TabIndex = 10;
            this.campaignsComboBox.SelectedIndexChanged += new System.EventHandler(this.CampaignsComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 186);
            this.Controls.Add(this.campaignsComboBox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savesListBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.levelsComboBox);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.infoLabel);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Creature Conflict Level Changer";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.ComboBox levelsComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ListBox savesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox campaignsComboBox;
    }
}

