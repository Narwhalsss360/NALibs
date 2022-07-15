using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Installer
{
    public partial class InstallerForm : Form
    {
        string ExecutablePath = string.Empty;
        FileStream DirectoriesFile;
        const bool OverwriteDestinationDirectory = true;

        public InstallerForm()
        {
            InitializeComponent();
            Load += LoadDirectories;
            FormClosing += SaveDirectories;
        }

        void SaveDirectories(object Sender, FormClosingEventArgs Args)
        {
            Args.Cancel = true;

            if (!File.Exists(Path.Combine(ExecutablePath, "dirs")))
            {
                File.Create(Path.Combine(ExecutablePath, "dirs"));
            }

            string OutputString = SourceTextBox.Text + "\n" + DestinationTextBox.Text;
            byte[] OutputBytes = Encoding.UTF8.GetBytes(OutputString);

            DirectoriesFile.Write(OutputBytes, 0, OutputBytes.Length);

            DirectoriesFile.Close();
            Args.Cancel = false;
        }

        void LoadDirectories(object Sender, EventArgs Args)
        {
            ExecutablePath = Assembly.GetExecutingAssembly().Location;
            int index = ExecutablePath.LastIndexOf("\\");

            ExecutablePath = ExecutablePath.Remove(index, ExecutablePath.Length - index);
            if (File.Exists(Path.Combine(ExecutablePath, "dirs")))
            {
                DirectoriesFile = new FileStream(Path.Combine(ExecutablePath, "dirs"), FileMode.Open, FileAccess.ReadWrite);

                byte[] InputBytes = new byte[DirectoriesFile.Length];
                DirectoriesFile.Read(InputBytes, 0, (int)DirectoriesFile.Length);
                string InputString = Encoding.UTF8.GetString(InputBytes, 0, InputBytes.Length);

                if (!string.IsNullOrEmpty(InputString))
                {
                    SourceTextBox.Text = InputString.Substring(0, InputString.IndexOf("\n"));
                    InputString = InputString.Remove(0, InputString.IndexOf("\n") + 1);
                    if (OverwriteDestinationDirectory)
                    {
                        DestinationTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Arduino\\libraries";
                    }
                    else
                    {
                        DestinationTextBox.Text = InputString;
                    }
                }
            }
        }

        void CopyDirectory(string Source, string Destination, bool Recursive = true)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(Source);

            if (!DirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {DirInfo.FullName}");
            }

            DirectoryInfo[] SubDirs = DirInfo.GetDirectories();

            Directory.CreateDirectory(Destination);

            foreach (FileInfo File in DirInfo.GetFiles())
            {
                string FileDestination = Path.Combine(Destination, File.Name);
                File.CopyTo(FileDestination);
            }

            if (Recursive)
            {
                foreach (DirectoryInfo SubDirInfo in SubDirs)
                {
                    string NewDirectory = Path.Combine(Destination, SubDirInfo.Name);
                    CopyDirectory(SubDirInfo.FullName, NewDirectory, true);
                }
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            NColorCheckbox.Checked = true;
            NDefsCheckbox.Checked = true;
            NEventsCheckbox.Checked = true;
            NFuncsCheckbox.Checked = true;
            NHCSR04Checkbox.Checked = true;
            NPushCheckbox.Checked = true;
            NRotaryCheckbox.Checked = true;
            NStreamComCheckbox.Checked = true;
            NTimerCheckbox.Checked = true;
            NWireCheckbox.Checked = true;
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            NColorCheckbox.Checked = false;
            NDefsCheckbox.Checked = false;
            NEventsCheckbox.Checked = false;
            NFuncsCheckbox.Checked = false;
            NHCSR04Checkbox.Checked = false;
            NPushCheckbox.Checked = false;
            NRotaryCheckbox.Checked = false;
            NStreamComCheckbox.Checked = false;
            NTimerCheckbox.Checked = false;
            NWireCheckbox.Checked = false;
        }

        private void CopySelectedButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedButton_Click(null, null);

            if (NColorCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NColor", $"{DestinationTextBox.Text}\\NColor");
            }

            if (NDefsCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NDefs", $"{DestinationTextBox.Text}\\NDefs");
            }

            if (NEventsCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NEvents", $"{DestinationTextBox.Text}\\NEvents");
            }

            if (NFuncsCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NFuncs", $"{DestinationTextBox.Text}\\NFuncs");
            }

            if (NHCSR04Checkbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NHC-SR04", $"{DestinationTextBox.Text}\\NHC-SR04");
            }

            if (NPushCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NPush", $"{DestinationTextBox.Text}\\NPush");
            }

            if (NRotaryCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NRotary", $"{DestinationTextBox.Text}\\NRotary");
            }

            if (NStreamComCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NStreamCom", $"{DestinationTextBox.Text}\\NStreamCom");
            }

            if (NTimerCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NTimer", $"{DestinationTextBox.Text}\\NTimer");
            }

            if (NWireCheckbox.Checked)
            {
                CopyDirectory($"{SourceTextBox.Text}\\NWire", $"{DestinationTextBox.Text}\\NWire");
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            if (NColorCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NColor"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NColor", true);
                }
            }

            if (NDefsCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NDefs"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NDefs", true);
                }
            }

            if (NEventsCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NEvents"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NEvents", true);
                }
            }

            if (NFuncsCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NFuncs"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NFuncs", true);
                }
            }

            if (NHCSR04Checkbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NHC-SR04"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NHC-SR04", true);
                }
            }

            if (NPushCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NPush"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NPush", true);
                }
            }

            if (NRotaryCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NRotary"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NRotary", true);
                }
            }

            if (NStreamComCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NSerialCom"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NSerialCom", true);
                }
            }

            if (NTimerCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NTimer"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NTimer", true);
                }
            }

            if (NWireCheckbox.Checked)
            {
                if (Directory.Exists($"{DestinationTextBox.Text}\\NWire"))
                {
                    Directory.Delete($"{DestinationTextBox.Text}\\NWire", true);
                }
            }
        }
    }
}