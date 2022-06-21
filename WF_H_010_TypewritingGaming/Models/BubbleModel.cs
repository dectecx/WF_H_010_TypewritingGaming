using System;
using System.Windows.Forms;

namespace WF_H_010_TypewritingGaming.Models
{
    /// <summary>
    /// 泡泡模型
    /// </summary>
    public class BubbleModel
    {
        /// <summary>
        /// 識別碼
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// 圖片物件
        /// </summary>
        public PictureBox Picture { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
    }
}
