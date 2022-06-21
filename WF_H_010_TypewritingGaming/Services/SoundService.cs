using System.IO;
using WF_H_010_TypewritingGaming.Enums;
using WF_H_010_TypewritingGaming.Properties;

namespace WF_H_010_TypewritingGaming.Services
{
    /// <summary>
    /// 音效服務
    /// </summary>
    public class SoundService
    {
        /// <summary>
        /// 取得指定音效資料流
        /// </summary>
        /// <param name="soundEnum">音效種類</param>
        public Stream GetSoundStream(SoundEnum soundEnum)
        {
            if (soundEnum == SoundEnum.BackgroundMusic)
            {
                return new MemoryStream(Resources.BackgroundMusic);
            }
            else if (soundEnum == SoundEnum.Correct)
            {
                return new MemoryStream(Resources.Correct);
            }
            else if (soundEnum == SoundEnum.Error)
            {
                return new MemoryStream(Resources.Error);
            }
            else if (soundEnum == SoundEnum.Bounce)
            {
                return new MemoryStream(Resources.Bounce);
            }
            else if (soundEnum == SoundEnum.Congratulations)
            {
                return new MemoryStream(Resources.Congratulations);
            }
            else
            {
                return null;
            }
        }
    }
}
