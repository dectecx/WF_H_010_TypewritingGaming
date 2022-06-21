using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WF_H_010_TypewritingGaming.Enums;
using WF_H_010_TypewritingGaming.Helper;
using WF_H_010_TypewritingGaming.Models;

namespace WF_H_010_TypewritingGaming
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 亂數產生器
        /// </summary>
        private Random _rand;

        /// <summary>
        /// 背景音效
        /// </summary>
        private SoundPlayer _backgroundSound;

        /// <summary>
        /// 剩餘時間
        /// </summary>
        private int _lastTime;

        /// <summary>
        /// 分數
        /// </summary>
        private int _score;

        /// <summary>
        /// 當前泡泡清單
        /// </summary>
        private List<BubbleModel> _currentBubbles;

        public MainForm()
        {
            InitializeComponent();

            // 亂數產生器
            _rand = new Random();
            // 循環播放背景音效
            //_backgroundSound = new SoundPlayer(new MemoryStream(ResourcesHelper.GetSoundStream(SoundEnum.BackgroundMusic)));
            //_backgroundSound.PlayLooping();

            // 初始化
            _lastTime = 60;
        }

        /// <summary>
        /// 表單鍵盤鍵入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 按下的按鈕
            string input = e.KeyChar.ToString();
            // 若畫面有多個,只取最早出現的那個(一次只消除一個)
            BubbleModel bubble = _currentBubbles.Where(x => x.Answer == input).FirstOrDefault();
            if (bubble != null)
            {
                // TODO: 播放音效
                _currentBubbles.Remove(bubble);
                _score += 5;
            }
            // 沒有任何一個泡泡答案吻合
            else
            {
                // TODO: 播放音效
                // TODO: 切換圖片
            }
        }

        /// <summary>
        /// 開始遊戲按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text != "暫停")
            {
                tmCountdown.Start(); // 圖片生成timer啟動
                tmFall.Start(); // 圖片掉落timer啟動
                btnStart.Text = "暫停";
                btnStart.BackColor = Color.LightPink;
            }
            else
            {
                tmCountdown.Stop(); // 圖片生成timer暫停
                tmFall.Stop(); // 圖片掉落timer暫停
                btnStart.Text = "重新挑戰";
                btnStart.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// 排行榜按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRank_Click(object sender, EventArgs e)
        {
            // 開啟排行榜畫面
            RankForm rankForm = new RankForm();
            rankForm.ShowDialog();
        }

        /// <summary>
        /// 遊戲倒數計時器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmCountdown_Tick(object sender, EventArgs e)
        {
            _lastTime--;

            // 亂數決定ASCII Code (範圍33-123)
            int asciiCode = _rand.Next(33, 126);

            // 產生一個ASCII圖片物件
            PictureBox picture = new PictureBox();
            picture.Image = ResourcesHelper.GetAsciiBitmap(asciiCode);
            //picture.Height = 20;
            //picture.Width = 20;
            // 答案存在tag內
            picture.Tag = asciiCode;
            picture.Top = 0;
            picture.Left = _rand.Next(0, plGameRegion.Width - picture.Width);
            plGameRegion.Controls.Add(picture);
        }

        /// <summary>
        /// 掉落計時器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmFall_Tick(object sender, EventArgs e)
        {
            // 找出遊戲區塊內所有圖片物件
            foreach (Control item in plGameRegion.Controls)
            {
                if (item is PictureBox picture)
                {
                    // 向下掉落
                    picture.Top += 5;

                    // 如果超過遊戲區塊,就刪除圖片+扣分+播放音效
                    if (item.Top > plGameRegion.Height)
                    {
                        item.Dispose();
                        // 每次扣3分,最低0分
                        _score -= 3;
                        if (_score < 0)
                        {
                            _score = 0;
                        }
                    }
                }
            }
        }
    }
}