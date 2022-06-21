using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WF_H_010_TypewritingGaming.Enums;
using WF_H_010_TypewritingGaming.Helper;

// 音效同時播放需使用「WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer);」
// - 參考文章:https://stackoverflow.com/questions/4740262/playing-2-sounds-together-at-same-time
// 若要使用「WMPLib.WindowsMediaPlayer」,專案需要加入參考Windows Media Player
// - 參考文章:https://olivermode.pixnet.net/blog/post/305842398

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
        /// 建構子
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // 亂數產生器
            _rand = new Random();
            // 循環播放背景音效
            _backgroundSound = new SoundPlayer(ResourcesHelper.GetSoundStream(SoundEnum.BackgroundMusic));
            _backgroundSound.PlayLooping();

            // 初始化
            tmCountdown.Stop();
            tmFall.Stop();
            _lastTime = 60;
            lblLastTime.Text = "倒數：" + _lastTime + "秒";
            CalScore();
        }

        /// <summary>
        /// 計算分數
        /// </summary>
        private void CalScore()
        {
            lblScore.Text = "得分：" + _score;
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
            // 紀錄是否有找到至少一個符合的
            bool isFound = false;

            // 找出遊戲區塊內所有圖片物件
            foreach (Control item in plGameRegion.Controls)
            {
                if (item is PictureBox picture)
                {
                    if ((string)item.Tag == input)
                    {
                        // 移除泡泡
                        item.Dispose();
                        // 得分
                        _score += 5;

                        // 播放音效
                        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                        wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Correct);
                        wplayer.controls.play();

                        // 若畫面有多個,只取最早出現的那個(一次只消除一個)
                        isFound = true;
                        break;
                    }
                }
            }

            // 沒有任何一個泡泡答案吻合
            if (!isFound)
            {
                // TODO: 切換圖片
                // 播放音效
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Error);
                wplayer.controls.play();
            }
            // 計算分數
            CalScore();
        }

        /// <summary>
        /// 開始遊戲按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // TODO: 待補齊按鈕邏輯
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
            lblLastTime.Text = "倒數：" + _lastTime + "秒";
            if (_lastTime <= 0)
            {
                tmCountdown.Stop();
                tmFall.Stop();
                btnStart.Text = "重新挑戰";

                // 播放音效
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Congratulations);
                wplayer.controls.play();
                MessageBox.Show("時間到！", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 亂數決定ASCII Code (範圍33-123)
            int asciiCode = _rand.Next(33, 126);

            // 產生一個ASCII圖片物件
            PictureBox picture = new PictureBox();
            picture.BackgroundImage = ResourcesHelper.GetAsciiBitmap(asciiCode);
            // 設定圖片形式為延展
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.Height = 50;
            picture.Width = 50;
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

                        // 播放音效
                        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                        wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Bounce);
                        wplayer.controls.play();
                    }
                }
            }

            // 計算分數
            CalScore();
        }
    }
}