using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Win7Pack;

namespace ControlExplorer.Win7Pack
{
    public partial class Win7PackMainForm : C1DemoForm
    {
        public Win7PackMainForm()
        {
            InitializeComponent();
        }

        private void btnJumpTaskDemo_Click(object sender, EventArgs e)
        {
            if (C1TaskbarButton.IsPlatformSupported)
            {
                JumpTaskDemo demo = new JumpTaskDemo();
                demo.StartPosition = FormStartPosition.CenterScreen;
                demo.Show();
            }
            else
            {
                MessageBox.Show("C1任务栏按钮只支持Vista以及更新的操作系统。");
            }
        }

        private void btnProgressDemo_Click(object sender, EventArgs e)
        {
            if (C1TaskbarButton.IsPlatformSupported)
            {
                ProgressIndicatorDemo demo = new ProgressIndicatorDemo();
                demo.StartPosition = FormStartPosition.CenterScreen;
                demo.Show();
            }
            else
            {
                MessageBox.Show("C1任务栏按钮只支持Vista以及更新的操作系统。");
            }
        }

        private void btnThumbnailButtons_Click(object sender, EventArgs e)
        {
            if (C1TaskbarButton.IsPlatformSupported)
            {
                ThumbnailButtonDemo demo = new ThumbnailButtonDemo();
                demo.StartPosition = FormStartPosition.CenterScreen;
                demo.Show();
            }
            else
            {
                MessageBox.Show("C1任务栏按钮只支持Vista以及更新的操作系统。");
            }
        }

        private void btnDialogDemo_Click(object sender, EventArgs e)
        {
            if (C1TaskDialog.IsPlatformSupported)
            {
                // show custom error dialog
                dialogError.Show();
            }
            else
            {
                MessageBox.Show("抱歉, C1任务对话框只支持Vista以及更新的操作系统。");
            }
        }

        private void dialogError_ButtonClick(object sender, TaskDialogButtonClickEventArgs e)
        {
            if (e.DialogResult == TaskDialogResult.Custom &&
                e.CustomButton.Name == "sendButton")
            {
                C1TaskDialog sendDialog = new C1TaskDialog();
                sendDialog.WindowTitle = "发送反馈对话框";
                sendDialog.Content = "正在发送您的反馈.....";
                sendDialog.ProgressBar.Maximum = 5000;
                sendDialog.ProgressBar.Visible = true;
                sendDialog.EnableTimer = true;
                sendDialog.TimerTick += new TaskDialogTimerTickEventHandler(sendDialog_TimerTick);

                sendDialog.Show();
                sendDialog.Dispose();
            }
        }

        private void sendDialog_TimerTick(object sender, TaskDialogTimerTickEventArgs e)
        {
            C1TaskDialog dialog = (C1TaskDialog)sender;
            if (e.Ticks <= 5000)
            {
                dialog.MainInstruction = string.Format("发送中 ....{0}", e.Ticks);
                dialog.ProgressBar.Value = e.Ticks;
            }
            else
            {
                dialog.MainInstruction = "感谢您的反馈!";
                dialog.Content = "我们的开发者将得到正确的...";
                dialog.ProgressBar.Value = 5000;
            }
        }
    }
}
