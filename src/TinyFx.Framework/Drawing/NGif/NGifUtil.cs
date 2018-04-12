using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TinyFx.Drawing.NGif
{
    /// <summary>
    /// GIF动画处理辅助类
    /// </summary>
    public static class NGifUtil
    {
        /// <summary>
        /// 生成GIF图片返回byte[]
        /// </summary>
        /// <param name="imgs">GIF Frames图片</param>
        /// <param name="delay">动画间隔时间：ms</param>
        /// <param name="repeat">是否重复播放</param>
        /// <returns></returns>
        public static byte[] EncodeToBytes(IEnumerable<string> imgs, int delay = 500, bool repeat = true)
        {
            AnimatedGifEncoder encoder = new AnimatedGifEncoder();
            encoder.Start();
            encoder.SetDelay(delay);
            encoder.SetRepeat(repeat ? 0 : -1);
            foreach (var img in imgs)
                encoder.AddFrame(Image.FromFile(img));
            encoder.Finish();
            return encoder.CurrentGifBytes;
        }
        /// <summary>
        /// 生成GIF图片保存文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="imgs"></param>
        /// <param name="delay"></param>
        /// <param name="repeat"></param>
        public static void EncodeToFile(string file, IEnumerable<string> imgs, int delay = 500, bool repeat = true)
            => File.WriteAllBytes(file, EncodeToBytes(imgs, delay, repeat));

        /// <summary>
        /// 解码GIF返回MemoryStream集合
        /// </summary>
        /// <param name="file">GIF图片</param>
        /// <param name="format">解析Frame图片格式</param>
        /// <returns></returns>
        public static IEnumerable<MemoryStream> DecodeToStreams(string file, ImageFormat format)
        {
            var ret = new List<MemoryStream>();
            GifDecoder decoder = new GifDecoder();
            decoder.Read(file);
            for (int i = 0; i < decoder.GetFrameCount(); i++)
            {
                var frame = decoder.GetFrame(i);
                var item = new MemoryStream();
                frame.Save(item, format);
                ret.Add(item);
            }
            return ret;
        }

        /// <summary>
        /// 解码GIF保存Frames图片文件
        /// </summary>
        /// <param name="file">GIF图片</param>
        /// <param name="format">解析Frame图片格式</param>
        /// <param name="path">保存路径</param>
        public static void DecodeToFiles(string file, ImageFormat format, string path)
        {
            GifDecoder decoder = new GifDecoder();
            decoder.Read(file);
            for (int i = 0; i < decoder.GetFrameCount(); i++)
            {
                var frame = decoder.GetFrame(i);
                var saveFile = Path.Combine(path, $"{Path.GetFileNameWithoutExtension(file)}_{i}.{format.ToString()}");
                frame.Save(saveFile, format);
            }
        }
    }
}
