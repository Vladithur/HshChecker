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
        }

        private void checkBoxExe_CheckedChanged(object sender, EventArgs e)
        {
            onlyExe = checkBoxExe.Checked;
        }

        private void go_Click(object sender, EventArgs e)
        {
            check(textBox.Text, onlyExe);
        }

        public static void check(string folder, bool OnlyExe)
        {
            List<String> files = DirSearch(folder, OnlyExe);
            foreach (string f in files)
            {
                Console.WriteLine(f);
                if (!File.Exists("." + f + ".md5"))
                    File.WriteAllText("." + f + ".md5", CalculateMD5(f));
                else
                {
                    string temp0 = File.ReadAllText("." + f + ".md5");
                    string temp1 = CalculateMD5(f);
                    if (!temp0.Equals(temp1))
                    {

                        if (MessageBox.Show("File Chnage! Did you change the file " + f + " ?", "File Chnage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            MessageBox.Show("Please review this file", "Danger", MessageBoxButtons.OK);
                        }
                    }
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

        private static List<String> DirSearch(string sDir, bool onlyExe)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (onlyExe)
                    {
                        string subs = f.Substring(f.Length - 3);
                        if (subs == "exe" || subs == "msi")
                            files.Add(f);
                    }
                    else files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d, onlyExe));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }
    }
}
