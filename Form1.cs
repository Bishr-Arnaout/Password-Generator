using System;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private bool[] CheckedTypes = new bool[4];
        public Form1()
        {
            InitializeComponent();
        }
        private void trbNumber_Of_Letters_Scroll(object sender, ScrollEventArgs e)
        {
            lblNumber_Of_Letters.Text = trbNumber_Of_Letters.Value.ToString() + " Letters";
        }
        bool IsAnyTypeChecked()
        {
            if (chkCapital_Letters.Checked || chkSmall_Letters.Checked
                || chkNumbers.Checked || chkSpecial_Letters.Checked)
                return true;
            return false;
        }
        char GetRandomCharacter(byte From, byte To)
        {
            return Convert.ToChar(random.Next(From, To));
        }
        byte GetRandomType()
        {
            return Convert.ToByte(random.Next(0, 4));
        }
        void GeneratePassword()
        {
            for (byte i = 1; i <= trbNumber_Of_Letters.Value; i++)
            {
                byte type = GetRandomType();

                 while (CheckedTypes[type] != true)
                {
                    type = GetRandomType();
                }

                 switch(type)
                {
                    case 0:
                        {
                            txtPassword.Text += GetRandomCharacter(65, 90);
                            break;
                        }
                    case 1:
                        {
                            txtPassword.Text += GetRandomCharacter(97, 122);
                            break;
                        }
                    case 2:
                        {
                            txtPassword.Text += GetRandomCharacter(48, 57);
                            break;
                        }
                    case 3:
                        {
                            byte SpecialGroub = GetRandomType();
                            switch (SpecialGroub)
                            {
                                case 0:
                                    txtPassword.Text += GetRandomCharacter(33, 47);
                                    break;
                                case 1:
                                    txtPassword.Text += GetRandomCharacter(58, 64);
                                    break;
                                case 2:
                                    txtPassword.Text += GetRandomCharacter(91, 96);
                                    break;
                                case 3:
                                    txtPassword.Text += GetRandomCharacter(123, 126);
                                    break;
                            }
                            break;
                        }
                }
            }
        }
        void CheckeCheckedTypes()
        {
            if (chkCapital_Letters.Checked) CheckedTypes[0] = true;
            else CheckedTypes[0] = false;
            if (chkSmall_Letters.Checked) CheckedTypes[1] = true;
            else CheckedTypes[1] = false;
            if (chkNumbers.Checked) CheckedTypes[2] = true;
            else CheckedTypes[2] = false;
            if (chkSpecial_Letters.Checked) CheckedTypes[3] = true;
            else CheckedTypes[3] = false;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            if (IsAnyTypeChecked())
            {
                CheckeCheckedTypes();
                GeneratePassword();
            }
            else
                MessageBox.Show("Choose any type!", "No selected type", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text)) Clipboard.SetText(txtPassword.Text);
            else
                MessageBox.Show("There is no password to be copied!", "No password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text)) Clipboard.SetText(txtPassword.Text);
            else
                MessageBox.Show("There is no password to be copied!", "No password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}