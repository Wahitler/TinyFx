using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.IO;

namespace TinyFx.Drawing
{
    /// <summary>
    /// 缩略图处理类（包括水印）
    /// </summary>
    public class ThumbHandler
    {
        #region Properties
        /// <summary>
        /// 获取或设置需处理的图片
        /// </summary>
        public Image SourceImage { get; set; }

        /// <summary>
        /// 获取一个值，该值指定如何将合成图像绘制到此 System.Drawing.Graphics。
        /// </summary>
        public CompositingQuality CompositingQuality { get; set; }

        /// <summary>
        /// 获取或设置与此 System.Drawing.Graphics 关联的插补模式。
        /// </summary>
        public InterpolationMode InterpolationMode { get; set; }

        /// <summary>
        /// 获取或设置此 System.Drawing.Graphics 的呈现质量。
        /// </summary>
        public SmoothingMode SmoothingMode { get; set; }

        /// <summary>
        /// 获取或设置与此 System.Drawing.Graphics 关联的文本的呈现模式。
        /// </summary>
        public TextRenderingHint TextRenderingHint { get; set; }

        private Image _processingImage;

        /// <summary>
        /// 当前正在处理的图片
        /// </summary>
        public Image ProcessingImage
        {
            get
            {
                if (_processingImage == null)
                {
                    _processingImage = new Bitmap(SourceImage);
                }
                return _processingImage;
            }
            set
            {
                _processingImage = value;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">要处理的图片</param>
        public ThumbHandler(Image source)
        {
            SourceImage = source;
            CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        }

        #region Utils
        /// <summary>
        /// 获取一个图片按等比例缩小后的大小
        /// </summary>
        /// <param name="toWidth">缩小到的宽度</param>
        /// <param name="toHeight">缩小到的高度</param>
        /// <param name="imgWidth">图片的原始宽度</param>
        /// <param name="imgHeight">图片的原始高度</param>
        /// <returns>返回图片按等比例缩小后的实际大小</returns>
        private static Size GetZoomSize(int toWidth, int toHeight, int imgWidth, int imgHeight)
        {
            Size ret = new Size();
            if (toWidth >= imgWidth && toHeight >= imgHeight)
            {
                ret.Width = imgWidth;
                ret.Height = imgHeight;
            }
            else if ((double)imgWidth / imgHeight > (double)toWidth / toHeight)
            {
                ret.Width = toWidth;
                ret.Height = toWidth * imgHeight / imgWidth;
            }
            else
            {
                ret.Height = toHeight;
                ret.Width = toHeight * imgWidth / imgHeight;
            }
            return ret;
        }
        //指定高宽裁减
        private static Rectangle GetCutRectangle(int toWidth, int toHeight, int imgWidth, int imgHeight)
        {
            Rectangle ret = new Rectangle();
            if (toWidth >= imgWidth && toHeight >= imgHeight)
            {
                ret.Width = imgWidth;
                ret.Height = imgHeight;
                ret.X = 0;
                ret.Y = 0;
            }
            else if ((double)imgWidth / imgHeight > (double)toWidth / toHeight)
            {
                ret.Height = imgHeight;
                ret.Width = imgHeight * toWidth / toHeight;
                ret.Y = 0;
                ret.X = (imgWidth - ret.Width) / 2;
            }
            else
            {
                ret.Width = imgWidth;
                ret.Height = imgWidth * toHeight / toWidth;
                ret.X = 0;
                ret.Y = (imgHeight - ret.Height) / 2;
            }
            return ret;
        }
        //质量设置
        private void Quality(Graphics g)
        {
            g.CompositingQuality = CompositingQuality;
            g.InterpolationMode = InterpolationMode;
            g.SmoothingMode = SmoothingMode;
            g.TextRenderingHint = TextRenderingHint;
            //g.Clear(Color.Transparent);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 调整图片大小，按比例缩放或指定高宽裁减
        /// </summary>
        /// <param name="width">指定的宽</param>
        /// <param name="height">指定的高</param>
        /// <param name="isZoom">是否等比缩放。true:按等比进行缩放，false:指定高宽裁减</param>
        public void Resize(int width, int height, bool isZoom = false)
        {
            Bitmap newImg = null;
            Graphics g = null;
            if (isZoom)
            {
                Size newSize = GetZoomSize(width, height, ProcessingImage.Width, ProcessingImage.Height);
                newImg = new Bitmap(newSize.Width, newSize.Height);
                using (g = Graphics.FromImage(newImg))
                {
                    Quality(g);
                    g.DrawImage(ProcessingImage, new Rectangle(0, 0, newSize.Width, newSize.Height), new Rectangle(0, 0, ProcessingImage.Width, ProcessingImage.Height), GraphicsUnit.Pixel);
                }
            }
            else
            {
                Rectangle rect = GetCutRectangle(width, height, ProcessingImage.Width, ProcessingImage.Height);
                Bitmap tmpImg = new Bitmap(rect.Width, rect.Height);

                using (g = Graphics.FromImage(tmpImg))
                {
                    Quality(g);
                    g.DrawImage(ProcessingImage, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
                }
                newImg = new Bitmap(width, height);
                using (g = Graphics.FromImage(newImg))
                {
                    Quality(g);
                    g.DrawImage(tmpImg, new Rectangle(0, 0, width, height), new Rectangle(0, 0, tmpImg.Width, tmpImg.Height), GraphicsUnit.Pixel);
                }
            }
            ProcessingImage = newImg;
        }

        /// <summary>
        /// 绘制文字水印
        /// </summary>
        /// <param name="text">水印文字</param>
        public void DrawTextWaterMark(string text)
        {
            using (Graphics g = Graphics.FromImage(ProcessingImage))
            {
                Quality(g);
                SolidBrush brush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
                Font font = new Font("Arial", 16, FontStyle.Regular);
                SizeF size = g.MeasureString(text, font);

                float x = (float)ProcessingImage.Width - size.Width - 10F;
                float y = (float)ProcessingImage.Height - size.Height - 10F;
                g.DrawString(text, font, brush, x, y);
                brush.Dispose();
            }
        }

        /// <summary>
        /// 绘制图片水印
        /// </summary>
        /// <param name="image">水印图片</param>
        public void DrawImageWaterMark(Image image)
        {
            using (Graphics g = Graphics.FromImage(ProcessingImage))
            {
                Quality(g);
                int x = ProcessingImage.Width - image.Width - 10;
                int y = ProcessingImage.Height - image.Height - 10;
                int width = image.Width;
                int height = image.Height;

                g.DrawImage(image, new Rectangle(x, y, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// 将此 System.Drawing.Image 以指定格式保存到指定文件。
        /// </summary>
        /// <param name="filename">字符串，包含要将此 System.Drawing.Image 保存到的文件的名称。</param>
        /// <param name="format">此 System.Drawing.Image 的 System.Drawing.Imaging.ImageFormat。</param>
        public void Save(string filename, ImageFormat format = null)
        {
            ProcessingImage.Save(filename, format ?? SourceImage.RawFormat);
        }

        /// <summary>
        /// 将此图像以指定的格式保存到指定的流中。
        /// </summary>
        /// <param name="stream">将在其中保存图像的 System.IO.Stream。</param>
        /// <param name="format">System.Drawing.Imaging.ImageFormat，指定保存的图像的格式。</param>
        public void Save(Stream stream, ImageFormat format = null)
        {
            ProcessingImage.Save(stream, format ?? SourceImage.RawFormat);
        }

        /// <summary>
        /// 使用指定的编码器和图像编码器参数，将该图像保存到指定的流。
        /// </summary>
        /// <param name="stream">将在其中保存图像的 System.IO.Stream。</param>
        /// <param name="encoder">此 System.Drawing.Image 的 System.Drawing.Imaging.ImageCodecInfo。</param>
        /// <param name="encoderParams">一个 System.Drawing.Imaging.EncoderParameters，它指定图像编码器使用的参数。</param>
        public void Save(Stream stream, ImageCodecInfo encoder, EncoderParameters encoderParams)
        {
            ProcessingImage.Save(stream, encoder, encoderParams);
        }

        /// <summary>
        /// 使用指定的编码器和图像编码器参数，将该 System.Drawing.Image 保存到指定的文件。
        /// </summary>
        /// <param name="filename">字符串，包含要将此 System.Drawing.Image 保存到的文件的名称。</param>
        /// <param name="encoder">此 System.Drawing.Image 的 System.Drawing.Imaging.ImageCodecInfo。</param>
        /// <param name="encoderParams">用于该 System.Drawing.Image 的 System.Drawing.Imaging.EncoderParameters。</param>
        public void Save(string filename, ImageCodecInfo encoder, EncoderParameters encoderParams)
        {
            ProcessingImage.Save(filename, encoder, encoderParams);
        }
        #endregion
    }

}
