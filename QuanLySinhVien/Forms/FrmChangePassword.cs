using System;
using System.Windows.Forms;
using QuanLySinhVien.BLL;

namespace QuanLySinhVien.Forms
{
    public partial class FrmChangePassword : Form
    {
        private readonly AuthBLL _authBll = new AuthBLL();

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.CardBg;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblHeader.Font = UiHelper.HeaderFont;
            lblHeader.ForeColor = UiHelper.PrimaryDark;
            lblUser.Font = UiHelper.RegularFont;
            lblUser.ForeColor = UiHelper.TextSecondary;

            lblOldPass.Font = UiHelper.SmallBoldFont; lblOldPass.ForeColor = UiHelper.TextSecondary;
            lblNewPass.Font = UiHelper.SmallBoldFont; lblNewPass.ForeColor = UiHelper.TextSecondary;
            lblConfirmPass.Font = UiHelper.SmallBoldFont; lblConfirmPass.ForeColor = UiHelper.TextSecondary;

            UiHelper.StylePrimaryButton(btnSave);
            UiHelper.StyleSecondaryButton(btnCancel);

            if (AuthBLL.CurrentUser != null)
            {
                lblUser.Text = $"Tài khoản: {AuthBLL.CurrentUser.Username} ({AuthBLL.CurrentUser.FullName})";
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            char ch = chkShow.Checked ? '\0' : '●';
            txtOldPass.PasswordChar = ch;
            txtNewPass.PasswordChar = ch;
            txtConfirmPass.PasswordChar = ch;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AuthBLL.CurrentUser == null)
            {
                UiHelper.ShowError("Chưa đăng nhập.");
                return;
            }

            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(oldPass))
            {
                UiHelper.ShowWarning("Vui lòng nhập mật khẩu cũ.");
                txtOldPass.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 6)
            {
                UiHelper.ShowWarning("Mật khẩu mới phải có ít nhất 6 ký tự.");
                txtNewPass.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                UiHelper.ShowWarning("Xác nhận mật khẩu mới không khớp.");
                txtConfirmPass.Focus();
                return;
            }

            try
            {
                if (_authBll.ChangePassword(AuthBLL.CurrentUser.UserID, oldPass, newPass, AuthBLL.CurrentUser.Username))
                {
                    UiHelper.ShowSuccess("Đổi mật khẩu thành công! Vui lòng ghi nhớ mật khẩu mới của bạn.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ArgumentException ex)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi khi đổi mật khẩu: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
