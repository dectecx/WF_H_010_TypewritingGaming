﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using WF_H_010_TypewritingGaming.Enums;
using WF_H_010_TypewritingGaming.Helper;
using WF_H_010_TypewritingGaming.Properties;

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
        /// 遊戲狀態
        /// </summary>
        private GameStatus _gameStatus;

        /// <summary>
        /// 是否開啟圖片淡出效果(注意:很吃效能,畫面若太多圖片很容易卡當)
        /// </summary>
        private bool _isUseFadeOut;

        /// <summary>
        /// 遊戲最大時間
        /// </summary>
        private int _maxGameTime;

        /// <summary>
        /// 剩餘時間
        /// </summary>
        private int _lastTime;

        /// <summary>
        /// 分數
        /// </summary>
        private int _score;

        /// <summary>
        /// 圖片尺寸
        /// </summary>
        private int _asciiImgSize;

        /// <summary>
        /// 建構子
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // 設定遊戲狀態
            _gameStatus = GameStatus.GameInitial;

            // 亂數產生器
            _rand = new Random();
            // 循環播放背景音效
            _backgroundSound = new SoundPlayer(ResourcesHelper.GetSoundStream(SoundEnum.BackgroundMusic));
            _backgroundSound.PlayLooping();
            // 設定是否開啟圖片淡出效果(注意:很吃效能,畫面若太多圖片很容易卡當)
            _isUseFadeOut = true;
            // 設定遊戲最大時間
            _maxGameTime = 60;
            // 設定圖片生成速度
            tmBubbleGenerate.Interval = 1000;
            // 設定降落速度
            tmFall.Interval = 1000;
            // 設定圖片尺寸
            _asciiImgSize = 45;

            // 初始化
            tmCountdown.Stop();
            tmBubbleGenerate.Stop();
            tmFall.Stop();
            _lastTime = _maxGameTime;
            lblLastTime.Text = "倒數：" + _lastTime + "秒";
            _score = 0;
            lblScore.Text = "得分：" + _score;
        }

        /// <summary>
        /// 表單鍵盤鍵入事件
        /// 要預先在表單設計那邊將KeyPreview這個屬性改成true,鍵盤相關事件才會有效
        /// 參考文章:https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/input-keyboard/how-to-handle-forms?view=netdesktop-6.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只有在遊戲中才監聽
            if (_gameStatus != GameStatus.Gaming)
            {
                return;
            }

            // 按下的按鈕
            int input = e.KeyChar;
            // 紀錄是否有找到至少一個符合的
            bool isFound = false;

            // 找出遊戲區塊內所有圖片物件
            foreach (Control item in plGameRegion.Controls)
            {
                if (item is PictureBox picture)
                {
                    if ((int)picture.Tag == input)
                    {
                        // 判斷是否開啟淡出圖片效果
                        if (_isUseFadeOut)
                        {
                            // 答對先將Tag改為0
                            picture.Tag = 0;
                            // 圖片換成泡泡破裂
                            picture.BackgroundImage = Resources.burst_bubble;
                            picture.Width = (int)(picture.Height * 1.33);

                            // 參考文章:https://stackoverflow.com/questions/960738/fading-out-an-image-with-transparency-in-winforms-ui-net3-5
                            #region 圖片淡出處理
                            // 透明度
                            int alpha = 0;
                            Timer fadeOutTimer = new Timer();
                            fadeOutTimer.Interval = 30;
                            fadeOutTimer.Tick += tmFadeOut;
                            fadeOutTimer.Start();

                            // 淡出計時器
                            void tmFadeOut(object s, EventArgs eve)
                            {
                                // 若透明度尚未到完全透明,就持續增加透明度
                                if (alpha++ < 255)
                                {
                                    Image image = picture.BackgroundImage;
                                    using (Graphics g = Graphics.FromImage(image))
                                    {
                                        Pen pen = new Pen(Color.FromArgb(alpha, 255, 255, 255), image.Width);
                                        g.DrawLine(pen, -1, -1, image.Width, image.Height);
                                        g.Save();
                                    }
                                    picture.Image = image;
                                }
                                // 完全透明就關閉計時器並移除泡泡
                                else
                                {
                                    fadeOutTimer.Stop();
                                    // 移除泡泡
                                    picture.Dispose();
                                    fadeOutTimer.Dispose();
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            // 移除泡泡
                            picture.Dispose();
                        }

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
                // 播放音效
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Error);
                wplayer.controls.play();
            }
            // 計算分數
            lblScore.Text = "得分：" + _score;
        }

        /// <summary>
        /// 開始遊戲按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // 當前狀態為剛啟動 or 遊戲暫停
            if (_gameStatus == GameStatus.GameInitial ||
                _gameStatus == GameStatus.Stop)
            {
                // 狀態改為遊戲暫停
                _gameStatus = GameStatus.Gaming;
                // 啟動倒數計時timer
                tmCountdown.Start();
                // 啟動圖片生成timer
                tmBubbleGenerate.Start();
                // 啟動圖片掉落timer
                tmFall.Start();
                btnStart.Text = "暫停遊戲";
                btnStart.BackColor = Color.LightPink;
            }
            // 當前狀態為遊戲中
            else if (_gameStatus == GameStatus.Gaming)
            {
                // 狀態改為遊戲中
                _gameStatus = GameStatus.Stop;
                // 暫停倒數計時timer
                tmCountdown.Stop();
                // 暫停圖片生成timer
                tmBubbleGenerate.Stop();
                // 暫停圖片掉落timer
                tmFall.Stop();
                btnStart.Text = "繼續遊戲";
                btnStart.BackColor = Color.LightGreen;
            }
            // 當前狀態為遊戲結束
            else if (_gameStatus == GameStatus.GameOver)
            {
                // 清除所有泡泡,移除遊戲區塊內所有物件
                plGameRegion.Controls.Clear();

                // 初始化
                _lastTime = _maxGameTime;
                lblLastTime.Text = "倒數：" + _lastTime + "秒";
                _score = 0;
                lblScore.Text = "得分：" + _score;

                // 狀態改為遊戲暫停
                _gameStatus = GameStatus.Gaming;
                // 啟動倒數計時timer
                tmCountdown.Start();
                // 啟動圖片生成timer
                tmBubbleGenerate.Start();
                // 啟動圖片掉落timer
                tmFall.Start();
                btnStart.Text = "暫停遊戲";
                btnStart.BackColor = Color.LightPink;
            }
            else
            {
                MessageBox.Show("發生錯誤，出現未知的遊戲狀態:" + _gameStatus, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _gameStatus = GameStatus.GameOver;
                tmCountdown.Stop();
                tmBubbleGenerate.Stop();
                tmFall.Stop();
                btnStart.Text = "重新挑戰";
                btnStart.BackColor = Color.LightGreen;

                // 播放音效
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = ResourcesHelper.GetSoundFilePath(SoundEnum.Congratulations);
                wplayer.controls.play();
                MessageBox.Show("時間到！", "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 取得排行榜資料
                List<RankModel> rankModels = RankHelper.GetRankModels();
                // 判斷是否能進排行榜
                if (rankModels.Count < 10 || rankModels.Where(x => x.Score < _score).Any())
                {
                    InputBoxForm inputBox = new InputBoxForm();
                    DialogResult result = inputBox.ShowDialog();
                    // 要按確定才寫入,若使用者按取消,則不寫入
                    if (inputBox.GetIsOk())
                    {
                        // 將逗點移除,避免字串分析時會有bug
                        var intputMsg = inputBox.GetMsg().Replace(",", "");
                        RankModel model = new RankModel
                        {
                            Name = intputMsg,
                            Score = _score
                        };

                        rankModels.Add(model);
                        // 排序
                        rankModels = rankModels.OrderByDescending(x => x.Score).ToList();
                        // 取前10個
                        List<RankModel> newRank = new List<RankModel>();
                        for (int i = 0; i < 10 && i < rankModels.Count(); i++)
                        {
                            rankModels[i].Id = (i + 1).ToString();
                            newRank.Add(rankModels[i]);
                        }
                        // 將排行榜資訊寫入檔案
                        RankHelper.WriteRankFile(newRank);
                    }
                }
                return;
            }
        }

        /// <summary>
        /// 泡泡生成計時器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmBubbleGenerate_Tick(object sender, EventArgs e)
        {
            // 亂數決定ASCII Code (範圍33-123)
            int asciiCode = _rand.Next(33, 126);

            // 產生一個ASCII圖片物件
            PictureBox picture = new PictureBox();
            picture.BackgroundImage = ResourcesHelper.GetAsciiBitmap(asciiCode);
            // 設定圖片形式為延展
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.Height = _asciiImgSize;
            picture.Width = _asciiImgSize;
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
                    // 向下掉落1張圖片高度
                    picture.Top += _asciiImgSize;

                    // 如果圖片底部超過遊戲區塊,就刪除圖片 and 扣分 and 播放音效
                    // 且答案不等於0 (0代表已經被答對了)
                    if ((int)picture.Tag != 0 && picture.Bottom > plGameRegion.Height)
                    {
                        picture.Dispose();
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
            lblScore.Text = "得分：" + _score;
        }
    }
}