using System;
using System.Collections.Generic;
using System.IO;

namespace WF_H_010_TypewritingGaming.Helper
{
    /// <summary>
    /// 排行榜Helper
    /// </summary>
    public static class RankHelper
    {
        /// <summary>
        /// 排行榜檔案名稱
        /// </summary>
        private const string _recordsFileName = "rankRecords.txt";

        /// <summary>
        /// 將排行榜資訊寫入檔案
        /// </summary>
        /// <param name="newRank">排行榜模型</param>
        public static void WriteRankFile(List<RankModel> newRank)
        {
            using (StreamWriter sw = new StreamWriter(_recordsFileName))
            {
                foreach (var item in newRank)
                {
                    sw.WriteLine($"{item.Id},{item.Name},{item.Score}");
                }
            }
        }

        /// <summary>
        /// 取得排行榜資料
        /// </summary>
        /// <returns></returns>
        public static List<RankModel> GetRankModels()
        {
            // 讀檔
            StreamReader sr = new StreamReader(_recordsFileName);
            string recordStr = sr.ReadToEnd();
            sr.Close();

            // 解析
            List<RankModel> rankModels = new List<RankModel>();
            foreach (string oneLine in recordStr.Split('\n'))
            {
                string[] datas = oneLine.Split(',');
                // 只處理符合格式的資料
                if (datas.Length == 3)
                {
                    rankModels.Add(new RankModel
                    {
                        Id = datas[0],
                        Name = datas[1],
                        Score = Convert.ToInt32(datas[2])
                    });
                }
            }
            return rankModels;
        }
    }
}
