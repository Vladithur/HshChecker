using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HshCheckerWindow
{
    public partial class Form1 : Form
    {
        bool onlyExe = false;
        public Form1()
        {
            InitializeComponent();
            try
            {
                textBox.Text = File.ReadAllText("dir.txt");
            }
            catch { }
            try
            {
                string[] temp = File.ReadAllText("start.txt").Split(' ');
                if (temp[0] == "True")
                {
                    checkBoxExe.Checked = Convert.ToBoolean(temp[1]);
                    checkBoxService.Checked = Convert.ToBoolean(temp[0]);
                    check(textBox.Text, Convert.ToBoolean(temp[1]));
                }
            }
            catch { }
        }

        private void checkBoxExe_CheckedChanged(object sender, EventArgs e)
        {
            onlyExe = checkBoxExe.Checked;
        }

        private void go_Click(object sender, EventArgs e)
        {
            check(textBox.Text, onlyExe);
        }

        private void del_Click(object sender, EventArgs e)
        {
            List<String> files = DirSearch(textBox.Text, false, "md5hc");
            foreach (string f in files)
            {
                File.SetAttributes(f, FileAttributes.Normal);
                File.Delete(f);
            }
        }

        public static void check(string folder, bool OnlyExe)
        {
            List<String> files = DirSearch(folder, OnlyExe, "");
            foreach (string f in files)
            {
                Console.WriteLine(f);
                if (!File.Exists(f + ".md5hc"))
                {
                    File.WriteAllText(f + ".md5hc", CalculateMD5(f));
                    File.SetAttributes(f + ".md5hc", FileAttributes.Hidden | FileAttributes.ReadOnly);
                }
                else
                {
                    File.SetAttributes(f + ".md5hc", FileAttributes.Normal);
                    string temp0 = File.ReadAllText(f + ".md5hc");
                    string temp1 = CalculateMD5(f);
                    if (!temp0.Equals(temp1))
                    {

                        if (MessageBox.Show("File Change! Did you change the file  " + f + "  ?", "File Chnage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Please review this file", "Danger", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    File.WriteAllText(f + ".md5hc", temp1);
                    File.SetAttributes(f + ".md5hc", FileAttributes.Hidden | FileAttributes.ReadOnly);
                }

            }
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox.Text = fbd.SelectedPath;
                    File.WriteAllText("dir.txt", fbd.SelectedPath);
                }
            }
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private static List<String> DirSearch(string sDir, bool onlyExe, string fType)
        {
            List<String> files = new List<String>();
            try
            {
                var filesInDir = Directory.GetFiles(sDir);
                foreach (string f in filesInDir)
                {
                    bool canAdd = true;
                    if (fType == "")
                    {
                        if (onlyExe)
                        {
                            string subs = f.Substring(f.Length - 3);
                            if (subs == "exe" || subs == "msi")
                            {
                                canAdd = false;
                            }
                        }
                        else if (canAdd)
                        {
                            string subs = f.Substring(f.Length - 5);
                            if (subs != "md5hc")
                                files.Add(f);
                        }
                    }
                    else
                    {
                        string subs = f.Substring(f.Length - fType.Length);
                        if (subs == fType)
                            files.Add(f);
                    }
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d, onlyExe, fType));
                }
            }
            catch (System.Exception excpt)
            {
                //MessageBox.Show(excpt.Message);
            }

            return files;
        }

        private void checkBoxService_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText("dir.txt", textBox.Text);
            File.WriteAllText("start.txt", checkBoxService.Checked.ToString() + " " + onlyExe.ToString());
        }
    }
}
