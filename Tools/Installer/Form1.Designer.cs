namespace Installer
{
    partial class InstallerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
            this.SourceLabel = new System.Windows.Forms.Label();
            this.LibrariesLabel = new System.Windows.Forms.Label();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.NColorCheckbox = new System.Windows.Forms.CheckBox();
            this.NDefsCheckbox = new System.Windows.Forms.CheckBox();
            this.NFuncsCheckbox = new System.Windows.Forms.CheckBox();
            this.NEventsCheckbox = new System.Windows.Forms.CheckBox();
            this.NHCSR04Checkbox = new System.Windows.Forms.CheckBox();
            this.NPushCheckbox = new System.Windows.Forms.CheckBox();
            this.NRotaryCheckbox = new System.Windows.Forms.CheckBox();
            this.NSerialComCheckbox = new System.Windows.Forms.CheckBox();
            this.NTimerCheckbox = new System.Windows.Forms.CheckBox();
            this.NWireCheckbox = new System.Windows.Forms.CheckBox();
            this.CopySelectedButton = new System.Windows.Forms.Button();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(12, 9);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(44, 13);
            this.SourceLabel.TabIndex = 0;
            this.SourceLabel.Text = "Source:";
            // 
            // LibrariesLabel
            // 
            this.LibrariesLabel.AutoSize = true;
            this.LibrariesLabel.Location = new System.Drawing.Point(12, 35);
            this.LibrariesLabel.Name = "LibrariesLabel";
            this.LibrariesLabel.Size = new System.Drawing.Size(49, 13);
            this.LibrariesLabel.TabIndex = 1;
            this.LibrariesLabel.Text = "Libraries:";
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Location = new System.Drawing.Point(67, 6);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(360, 20);
            this.SourceTextBox.TabIndex = 2;
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(67, 32);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.Size = new System.Drawing.Size(360, 20);
            this.DestinationTextBox.TabIndex = 3;
            // 
            // NColorCheckbox
            // 
            this.NColorCheckbox.AutoSize = true;
            this.NColorCheckbox.Location = new System.Drawing.Point(15, 58);
            this.NColorCheckbox.Name = "NColorCheckbox";
            this.NColorCheckbox.Size = new System.Drawing.Size(58, 17);
            this.NColorCheckbox.TabIndex = 4;
            this.NColorCheckbox.Text = "NColor";
            this.NColorCheckbox.UseVisualStyleBackColor = true;
            // 
            // NDefsCheckbox
            // 
            this.NDefsCheckbox.AutoSize = true;
            this.NDefsCheckbox.Location = new System.Drawing.Point(15, 81);
            this.NDefsCheckbox.Name = "NDefsCheckbox";
            this.NDefsCheckbox.Size = new System.Drawing.Size(56, 17);
            this.NDefsCheckbox.TabIndex = 5;
            this.NDefsCheckbox.Text = "NDefs";
            this.NDefsCheckbox.UseVisualStyleBackColor = true;
            // 
            // NFuncsCheckbox
            // 
            this.NFuncsCheckbox.AutoSize = true;
            this.NFuncsCheckbox.Location = new System.Drawing.Point(15, 127);
            this.NFuncsCheckbox.Name = "NFuncsCheckbox";
            this.NFuncsCheckbox.Size = new System.Drawing.Size(63, 17);
            this.NFuncsCheckbox.TabIndex = 6;
            this.NFuncsCheckbox.Text = "NFuncs";
            this.NFuncsCheckbox.UseVisualStyleBackColor = true;
            // 
            // NEventsCheckbox
            // 
            this.NEventsCheckbox.AutoSize = true;
            this.NEventsCheckbox.Location = new System.Drawing.Point(15, 104);
            this.NEventsCheckbox.Name = "NEventsCheckbox";
            this.NEventsCheckbox.Size = new System.Drawing.Size(67, 17);
            this.NEventsCheckbox.TabIndex = 7;
            this.NEventsCheckbox.Text = "NEvents";
            this.NEventsCheckbox.UseVisualStyleBackColor = true;
            // 
            // NHCSR04Checkbox
            // 
            this.NHCSR04Checkbox.AutoSize = true;
            this.NHCSR04Checkbox.Location = new System.Drawing.Point(15, 150);
            this.NHCSR04Checkbox.Name = "NHCSR04Checkbox";
            this.NHCSR04Checkbox.Size = new System.Drawing.Size(79, 17);
            this.NHCSR04Checkbox.TabIndex = 8;
            this.NHCSR04Checkbox.Text = "NHC-SR04";
            this.NHCSR04Checkbox.UseVisualStyleBackColor = true;
            // 
            // NPushCheckbox
            // 
            this.NPushCheckbox.AutoSize = true;
            this.NPushCheckbox.Location = new System.Drawing.Point(15, 173);
            this.NPushCheckbox.Name = "NPushCheckbox";
            this.NPushCheckbox.Size = new System.Drawing.Size(58, 17);
            this.NPushCheckbox.TabIndex = 9;
            this.NPushCheckbox.Text = "NPush";
            this.NPushCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NPushCheckbox.UseVisualStyleBackColor = true;
            // 
            // NRotaryCheckbox
            // 
            this.NRotaryCheckbox.AutoSize = true;
            this.NRotaryCheckbox.Location = new System.Drawing.Point(15, 196);
            this.NRotaryCheckbox.Name = "NRotaryCheckbox";
            this.NRotaryCheckbox.Size = new System.Drawing.Size(65, 17);
            this.NRotaryCheckbox.TabIndex = 10;
            this.NRotaryCheckbox.Text = "NRotary";
            this.NRotaryCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NRotaryCheckbox.UseVisualStyleBackColor = true;
            // 
            // NSerialComCheckbox
            // 
            this.NSerialComCheckbox.AutoSize = true;
            this.NSerialComCheckbox.Location = new System.Drawing.Point(15, 219);
            this.NSerialComCheckbox.Name = "NSerialComCheckbox";
            this.NSerialComCheckbox.Size = new System.Drawing.Size(81, 17);
            this.NSerialComCheckbox.TabIndex = 11;
            this.NSerialComCheckbox.Text = "NSerialCom";
            this.NSerialComCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NSerialComCheckbox.UseVisualStyleBackColor = true;
            // 
            // NTimerCheckbox
            // 
            this.NTimerCheckbox.AutoSize = true;
            this.NTimerCheckbox.Location = new System.Drawing.Point(15, 242);
            this.NTimerCheckbox.Name = "NTimerCheckbox";
            this.NTimerCheckbox.Size = new System.Drawing.Size(60, 17);
            this.NTimerCheckbox.TabIndex = 12;
            this.NTimerCheckbox.Text = "NTimer";
            this.NTimerCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NTimerCheckbox.UseVisualStyleBackColor = true;
            // 
            // NWireCheckbox
            // 
            this.NWireCheckbox.AutoSize = true;
            this.NWireCheckbox.Location = new System.Drawing.Point(15, 265);
            this.NWireCheckbox.Name = "NWireCheckbox";
            this.NWireCheckbox.Size = new System.Drawing.Size(56, 17);
            this.NWireCheckbox.TabIndex = 13;
            this.NWireCheckbox.Text = "NWire";
            this.NWireCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NWireCheckbox.UseVisualStyleBackColor = true;
            // 
            // CopySelectedButton
            // 
            this.CopySelectedButton.Location = new System.Drawing.Point(281, 58);
            this.CopySelectedButton.Name = "CopySelectedButton";
            this.CopySelectedButton.Size = new System.Drawing.Size(150, 109);
            this.CopySelectedButton.TabIndex = 14;
            this.CopySelectedButton.Text = "Copy Selected";
            this.CopySelectedButton.UseVisualStyleBackColor = true;
            this.CopySelectedButton.Click += new System.EventHandler(this.CopySelectedButton_Click);
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Location = new System.Drawing.Point(281, 173);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(150, 109);
            this.DeleteSelectedButton.TabIndex = 15;
            this.DeleteSelectedButton.Text = "Delete Selected";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(125, 58);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(150, 109);
            this.SelectAllButton.TabIndex = 16;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.Location = new System.Drawing.Point(125, 172);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(150, 109);
            this.DeselectAllButton.TabIndex = 17;
            this.DeselectAllButton.Text = "Deselect All";
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 293);
            this.Controls.Add(this.DeselectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.DeleteSelectedButton);
            this.Controls.Add(this.CopySelectedButton);
            this.Controls.Add(this.NWireCheckbox);
            this.Controls.Add(this.NTimerCheckbox);
            this.Controls.Add(this.NSerialComCheckbox);
            this.Controls.Add(this.NRotaryCheckbox);
            this.Controls.Add(this.NPushCheckbox);
            this.Controls.Add(this.NHCSR04Checkbox);
            this.Controls.Add(this.NEventsCheckbox);
            this.Controls.Add(this.NFuncsCheckbox);
            this.Controls.Add(this.NDefsCheckbox);
            this.Controls.Add(this.NColorCheckbox);
            this.Controls.Add(this.DestinationTextBox);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.LibrariesLabel);
            this.Controls.Add(this.SourceLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstallerForm";
            this.Text = "Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label LibrariesLabel;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.CheckBox NColorCheckbox;
        private System.Windows.Forms.CheckBox NDefsCheckbox;
        private System.Windows.Forms.CheckBox NFuncsCheckbox;
        private System.Windows.Forms.CheckBox NEventsCheckbox;
        private System.Windows.Forms.CheckBox NHCSR04Checkbox;
        private System.Windows.Forms.CheckBox NPushCheckbox;
        private System.Windows.Forms.CheckBox NRotaryCheckbox;
        private System.Windows.Forms.CheckBox NSerialComCheckbox;
        private System.Windows.Forms.CheckBox NTimerCheckbox;
        private System.Windows.Forms.CheckBox NWireCheckbox;
        private System.Windows.Forms.Button CopySelectedButton;
        private System.Windows.Forms.Button DeleteSelectedButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button DeselectAllButton;
    }
}

