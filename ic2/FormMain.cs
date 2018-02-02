using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ic2
{
    public partial class FormMain : Form
    {
        
        
        private bool allowshowdisplay = true;


        //during init of your application bind to this event  
        
        public FormMessage formMessage = new FormMessage();

        public IMessageFilter messageFilter { get; private set; }

        public FormMain()
        {
            
            InitializeComponent();
            Visible = true;
        }

       

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.BalloonTipText = "Для активации программы нажмите правой клавишей мыши на иконке";
                //notifyIcon1.ShowBalloonTip(300);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.allowshowdisplay = true;
                this.Visible = !this.Visible;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                //notifyIcon1.BalloonTipText = "Для активации программы нажмите правой клавишей мыши на иконке";
                //notifyIcon1.ShowBalloonTip(300);
                this.Hide();
            }
        }

        private void mnuCloseProgramm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, Control.MousePosition); // or any other overload
            }
            if(e.Button == MouseButtons.Left)
            {
                formMessage.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           web.IsWebBrowserContextMenuEnabled = false;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }

        private static void RunOurPeople()
        {
            FormOP formOP = new FormOP();
            formOP.Show();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunOurPeople();
        }
    }

    
}
