using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CCLevelChanger
{
    public partial class MainForm : Form
    {
        const string defaultSavingDir = @"C:\Users\user\Application Data\Cenega\Creature Conflict - The Clan Wars\save";

        string selectedFile = "";

        const uint numberOfLevels = 54;

        readonly Dictionary<string, string> fileNameToPath = new Dictionary<string, string>();

        // Development note (should not care):
        // For NET48 JsonSerializer requires:
        // System.Runtime.ComiplerServices.Unsafe
        // System.Text.Json
        // System.Memory
        readonly Dictionary<string, Dictionary<string, string>> campaings = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(Properties.Resources.LevelsList);

        public MainForm()
        {
            InitializeComponent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            levelsComboBox.Enabled = false;
            campaignsComboBox.Enabled = false;
            saveButton.Enabled = false;

            FillSavesList();
            FillComboBoxes();
        }

        /// <summary>
        /// Fills savesListBox with the names of saves files from the game saving directory.
        /// Also fills the fileNameToPath dictionary.
        /// </summary>
        private void FillSavesList()
        {
            DirectoryInfo savesDir = new DirectoryInfo(defaultSavingDir);
            savesListBox.Items.Clear();
            fileNameToPath.Clear();

            if (savesDir.Exists)
                foreach (FileInfo file in savesDir.GetFiles())
                    if (file.Extension == ".sav")
                    {
                        savesListBox.Items.Add(file.Name);
                        fileNameToPath[file.Name] = file.FullName;
                    }
        }

        /// <summary>
        /// Fills campaignsComboBox with campaign names.
        /// </summary>
        private void FillComboBoxes()
        {
            campaignsComboBox.Items.Clear();
            foreach (var Campaing in campaings)
                campaignsComboBox.Items.Add(Campaing.Key);
        }

        /// <summary>
        /// Activates combo boxes.
        /// </summary>
        private void ActiveComboBoxes()
        {
            levelsComboBox.Enabled = true;
            campaignsComboBox.Enabled = true;
        }

        /// <summary>
        /// Exports the level number from the selected save file and updates the combo boxes according to the obtained value.
        /// </summary>
        private void UpdateComboBoxes()
        {
            uint levelNumberFromFile;
            try
            {
                FileEditor saveEditor = new FileEditor(selectedFile);
                levelNumberFromFile = saveEditor.SaveInfo.Level % numberOfLevels;
            }
            catch
            {
                levelsComboBox.SelectedIndex = 0;
                campaignsComboBox.SelectedIndex = 0;
                saveButton.Enabled = true;
                return;
            }

            bool breakLoop = false;
            foreach (var Campaign in campaings)
            {
                foreach (var Entry in Campaign.Value)
                {
                    if (UInt32.Parse(Entry.Value) == levelNumberFromFile)
                    {
                        campaignsComboBox.SelectedItem = Campaign.Key;
                        levelsComboBox.SelectedItem = Entry.Key;

                        breakLoop = true;
                        break;
                    }
                }
                if (breakLoop)
                    break;
            }

            saveButton.Enabled = true;
        }

        /// <summary>
        /// When the campaign is changed, the levelsComboBox gets updated with the appropriate missions.
        /// </summary>
        private void CampaignsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            levelsComboBox.Items.Clear();
            foreach (var Entry in campaings[campaignsComboBox.SelectedItem.ToString()])
                levelsComboBox.Items.Add(Entry.Key);

            levelsComboBox.SelectedIndex = 0;
        }

        private void RefreshButton_Click(object sender, System.EventArgs e)
        {
            FillSavesList();
        }

        private void SavesListBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (savesListBox.SelectedItem != null)
            {
                selectedFile = fileNameToPath[savesListBox.SelectedItem.ToString()];
                filePathTextBox.Text = selectedFile;
                ActiveComboBoxes();
                UpdateComboBoxes();
            }
        }

        private void OpenFileButton_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select a file.",
                Filter = "Save files (*.sav)|*.sav|All files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                filePathTextBox.Text = selectedFile;
                savesListBox.SelectedItem = null;
                UpdateComboBoxes();
                ActiveComboBoxes();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            FileEditor saveEditor = new FileEditor(selectedFile);
            try
            {
                string selectedCampaing = campaignsComboBox.SelectedItem.ToString();
                string selectedLevel = levelsComboBox.SelectedItem.ToString();

                uint levelNumber = UInt32.Parse(campaings[selectedCampaing][selectedLevel]);
                saveEditor.ChangeLevel(levelNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("The file was modified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show(Properties.Resources.About, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}