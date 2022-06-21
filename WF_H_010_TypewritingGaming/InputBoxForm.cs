using System;
using System.Windows.Forms;

namespace WF_H_010_TypewritingGaming
{
    public partial class InputBoxForm : Form
    {
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
        /// 確定按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
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
            this.Close();
        }
    }
}
