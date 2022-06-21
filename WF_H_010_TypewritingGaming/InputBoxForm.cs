using System;
using System.Windows.Forms;

namespace WF_H_010_TypewritingGaming
{
    public partial class InputBoxForm : Form
    {
        /// <summary>
        /// 是否按下確定
        /// </summary>
        private bool IsOk;

        /// <summary>
        /// 輸入的訊息
        /// </summary>
        private string Msg;

        /// <summary>
        /// 建構子
        /// </summary>
        public InputBoxForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得輸入的訊息
        /// </summary>
        /// <returns></returns>
        public string GetMsg()
        {
            return Msg;
        }

        /// <summary>
        /// 取得是否按下確定
        /// </summary>
        /// <returns></returns>
        public bool GetIsOk()
        {
            return IsOk;
        }

        /// <summary>
        /// 輸入框按下按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下Enter
            if (e.KeyCode == Keys.Return)
            {
                // 觸發確定按鈕Click事件
                btnOK.PerformClick();
            }
        }

        /// <summary>
        /// 確定按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            IsOk = true;
            Msg = txtInput.Text;
            this.Close();
        }

        /// <summary>
        /// 取消按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }
    }
}
