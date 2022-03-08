using System;
using System.Windows.Forms;

namespace Beautiful_Dummy_SQLite.Forms
{
    public partial class fMain : Form
    {
        private fLogin fl = new fLogin();

        public bool isSidebarOpened;
        public DataBase.Models.User account;

        public fMain()
        {
            InitializeComponent();
            FormDock.SubscribeControlToDragEvents(lblTitle, true);

            if (fl.ShowDialog() == DialogResult.Yes)
                account = fl.account;
            else
                Environment.Exit(0);

            InitUser();

            if (pnlSidebar.Width >= 180)
            {
                isSidebarOpened = true;
                pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_32;
            }
            else if (pnlSidebar.Width <= 60)
            {
                isSidebarOpened = false;
                pctrSidebar.Image = Properties.Resources.Show_Sidepanel_32;
            }
        }

        #region Кнопка Закрытия
        private void btnImgTitleClose_Click(object sender, EventArgs e) =>
           Application.Exit();

        private void btnImgTitleClose_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleClose.BringToFront();
        #endregion

        #region Кнопка Увеличения Окна
        private void btnImgTitleMaximaze_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                FormDock.SubscribeControlToDragEvents(lblTitle, true);
                FormDock.SubscribeControlToDragEvents(pnlTitle, true);
            }
            else
            {
                FormDock.UnsubscribeControlToDragEvents(lblTitle, true);
                FormDock.UnsubscribeControlToDragEvents(pnlTitle, true);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnImgTitleMaximaze_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleMaximaze.BringToFront();
        #endregion

        #region Кнопка Сворачивания Окна
        private void btnImgTitleMinimaze_Click(object sender, EventArgs e) =>
            this.WindowState = FormWindowState.Minimized;

        private void btnImgTitleMinimaze_MouseEnter(object sender, EventArgs e) =>
            btnImgTitleMinimaze.BringToFront();
        #endregion

        #region Кнопка Бокового Меню и Таймер
        private void pctrSidebar_Click(object sender, EventArgs e) =>
            timerSidebar.Start();

        private void pctrSidebar_MouseMove(object sender, MouseEventArgs e) =>
            SetImageSidebar(true);

        private void pctrSidebar_MouseLeave(object sender, EventArgs e) =>
            SetImageSidebar(false);

        private void SetImageSidebar(bool isMoved)
        {
            switch (isMoved)
            {
                case true:
                    if (isSidebarOpened)
                        pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_Primary_32;
                    else
                        pctrSidebar.Image = Properties.Resources.Show_Sidepanel_Primary_32;
                    break;

                case false:
                    if (isSidebarOpened)
                        pctrSidebar.Image = Properties.Resources.Hide_Sidepanel_32;
                    else
                        pctrSidebar.Image = Properties.Resources.Show_Sidepanel_32;
                    break;
            }
        }

        private void timerSidebar_Tick(object sender, EventArgs e)
        {
            if (isSidebarOpened)
                pnlSidebar.Width -= 10;
            else
                pnlSidebar.Width += 10;

            if (pnlSidebar.Width == 180)
            {
                timerSidebar.Stop();
                isSidebarOpened = true;
                SetImageSidebar(false);
            }
            else if (pnlSidebar.Width == 50)
            {
                timerSidebar.Stop();
                isSidebarOpened = false;
                SetImageSidebar(false);
            }
        }
        #endregion

        #region Изображения и Кнопка выхода
        private void bnfUserPicture_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (fl.ShowDialog() == DialogResult.Yes)
            {
                account = fl.account;
                InitUser();
                this.Show();
            }
            else
                Environment.Exit(0);
        }

        private void bnfUserPicture_MouseMove(object sender, MouseEventArgs e) =>
            bnfUserPicture.Image = Properties.Resources.Logout_512;

        private void bnfUserPicture_MouseLeave(object sender, EventArgs e)
        {
            bnfUserPicture.Image = Properties.Resources.Contact_512;
        }
        #endregion

        #region Инициализация Пользователя
        private void InitUser()
        {
            lblUserName.Text = $"{account.Name.ToString()} {account.Surname.ToString()}";
            lblUserRole.Text = account.Role.ToString();

            if (account.Role.ToString() == "Support")
            {
                btnPageUsers.Visible = true;
                btnPageUsers.Enabled = true;
            }
            else
            {
                btnPageUsers.Visible = false;
                btnPageUsers.Enabled = false;
            }
        }
        #endregion
    }
}
