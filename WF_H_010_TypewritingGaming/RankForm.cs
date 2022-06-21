using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_H_010_TypewritingGaming
{
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表單載入時執行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RankForm_Load(object sender, EventArgs e)
        {
            // 載入排名資料
            LoadRankFile();
        }

        /// <summary>
        /// 取得排行榜資料
        /// </summary>
        /// <returns></returns>
        public List<RankModel> GetRankModels()
        {
            // 讀檔
            StreamReader sr = new StreamReader("rankRecords.txt");
            string recordStr = sr.ReadToEnd();
            sr.Close();

            // 解析
            List<RankModel> rankModels = new List<RankModel>();
            foreach (string oneLine in recordStr.Split('\n'))
            {
                string[] datas = oneLine.Split(',');
                rankModels.Add(new RankModel
                {
                    Id = datas[0],
                    Name = datas[1],
                    Score = Convert.ToInt32(datas[2])
                });
            }
            return rankModels;
        }

        private void LoadRankFile()
        {
            // 取得排行榜資料
            List<RankModel> rankModels = GetRankModels();

            // 依序動態生成在畫面上
            int currentHeight = 0;
            foreach (var item in rankModels)
            {
                Label idLabel = new Label();
                idLabel.Text = item.Id;
                idLabel.Left = lblAnchorId.Left;
                idLabel.Top = currentHeight;
                idLabel.Font = new Font("微軟正黑體", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
                idLabel.ForeColor = Color.White;
                plRecords.Controls.Add(idLabel);

                Label nameLabel = new Label();
                nameLabel.Text = item.Name;
                nameLabel.Left = lblAnchorName.Left;
                nameLabel.Top = currentHeight;
                nameLabel.Font = new Font("微軟正黑體", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
                nameLabel.ForeColor = Color.White;
                plRecords.Controls.Add(nameLabel);

                Label scoreLabel = new Label();
                scoreLabel.Text = item.Score.ToString();
                scoreLabel.Left = lblAnchorScore.Left;
                scoreLabel.Top = currentHeight;
                scoreLabel.Font = new Font("微軟正黑體", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
                scoreLabel.ForeColor = Color.White;
                plRecords.Controls.Add(scoreLabel);

                currentHeight += 30;
            }
        }

        public void WriteRankFile(List<RankModel> newRank)
        {
            using (StreamWriter sw = new StreamWriter("rankRecords.txt"))
            {
                foreach (var item in newRank)
                {
                    sw.WriteLine($"{item.Id},{item.Name},{item.Score}");
                }
            }
        }
    }
}
