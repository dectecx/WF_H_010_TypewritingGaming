using System.Drawing;
using System.IO;
using WF_H_010_TypewritingGaming.Enums;
using WF_H_010_TypewritingGaming.Properties;

namespace WF_H_010_TypewritingGaming.Helper
{
    /// <summary>
    /// Resources Helper
    /// </summary>
    public static class ResourcesHelper
    {
        /// <summary>
        /// 取得指定音效資料流
        /// </summary>
        /// <param name="soundEnum">音效種類</param>
        public static Stream GetSoundStream(SoundEnum soundEnum)
        {
            switch (soundEnum)
            {
                case SoundEnum.BackgroundMusic: return Resources.BackgroundMusic;
                case SoundEnum.Correct: return Resources.Correct;
                case SoundEnum.Error: return Resources.Error;
                case SoundEnum.Bounce: return Resources.Bounce;
                case SoundEnum.Congratulations: return Resources.Congratulations;
                default: return null;
            }
        }

        /// <summary>
        /// 取得ASCII Code對應圖片(限定範圍33-126,超過return null)
        /// </summary>
        /// <param name="asciiCode">ASCII Code(限定範圍33-126,超過return null)</param>
        /// <returns></returns>
        public static Bitmap GetAsciiBitmap(int asciiCode)
        {
            switch (asciiCode)
            {
                case 33: return Resources._33;
                case 34: return Resources._34;
                case 35: return Resources._35;
                case 36: return Resources._36;
                case 37: return Resources._37;
                case 38: return Resources._38;
                case 39: return Resources._39;
                case 40: return Resources._40;
                case 41: return Resources._41;
                case 42: return Resources._42;
                case 43: return Resources._43;
                case 44: return Resources._44;
                case 45: return Resources._45;
                case 46: return Resources._46;
                case 47: return Resources._47;
                case 48: return Resources._48;
                case 49: return Resources._49;
                case 50: return Resources._50;
                case 51: return Resources._51;
                case 52: return Resources._52;
                case 53: return Resources._53;
                case 54: return Resources._54;
                case 55: return Resources._55;
                case 56: return Resources._56;
                case 57: return Resources._57;
                case 58: return Resources._58;
                case 59: return Resources._59;
                case 60: return Resources._60;
                case 61: return Resources._61;
                case 62: return Resources._62;
                case 63: return Resources._63;
                case 64: return Resources._64;
                case 65: return Resources._65;
                case 66: return Resources._66;
                case 67: return Resources._67;
                case 68: return Resources._68;
                case 69: return Resources._69;
                case 70: return Resources._70;
                case 71: return Resources._71;
                case 72: return Resources._72;
                case 73: return Resources._73;
                case 74: return Resources._74;
                case 75: return Resources._75;
                case 76: return Resources._76;
                case 77: return Resources._77;
                case 78: return Resources._78;
                case 79: return Resources._79;
                case 80: return Resources._80;
                case 81: return Resources._81;
                case 82: return Resources._82;
                case 83: return Resources._83;
                case 84: return Resources._84;
                case 85: return Resources._85;
                case 86: return Resources._86;
                case 87: return Resources._87;
                case 88: return Resources._88;
                case 89: return Resources._89;
                case 90: return Resources._90;
                case 91: return Resources._91;
                case 92: return Resources._92;
                case 93: return Resources._93;
                case 94: return Resources._94;
                case 95: return Resources._95;
                case 96: return Resources._96;
                case 97: return Resources._97;
                case 98: return Resources._98;
                case 99: return Resources._99;
                case 100: return Resources._100;
                case 101: return Resources._101;
                case 102: return Resources._102;
                case 103: return Resources._103;
                case 104: return Resources._104;
                case 105: return Resources._105;
                case 106: return Resources._106;
                case 107: return Resources._107;
                case 108: return Resources._108;
                case 109: return Resources._109;
                case 110: return Resources._110;
                case 111: return Resources._111;
                case 112: return Resources._112;
                case 113: return Resources._113;
                case 114: return Resources._114;
                case 115: return Resources._115;
                case 116: return Resources._116;
                case 117: return Resources._117;
                case 118: return Resources._118;
                case 119: return Resources._119;
                case 120: return Resources._120;
                case 121: return Resources._121;
                case 122: return Resources._122;
                case 123: return Resources._123;
                case 124: return Resources._124;
                case 125: return Resources._125;
                case 126: return Resources._126;
                default: return null;   // 不該發生
            }
        }
    }
}
