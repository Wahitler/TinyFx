using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Extensions.SevenZipSharp
{
    /// <summary>
    /// 7-Z 压缩辅助类
    /// </summary>
    public static class SevenZipUtil
    {
        static SevenZipUtil()
        {
            string name = Environment.Is64BitProcess ? "7z64.dll" : "7z.dll";
            var file = Path.Combine(AppContext.BaseDirectory, name);
            if (!File.Exists(file))
                file = Path.Combine(AppContext.BaseDirectory, "Extensions\\SevenZipSharp", name);
            if (!File.Exists(file))
                throw new Exception("7zip所需的7z64.dll或7z.dll不存在。");
            SevenZipCompressor.SetLibraryPath(file);
        }
        #region 压缩
        /// <summary>
        /// 压缩目录到文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="archiveName"></param>
        /// <param name="format"></param>
        public static void ZipDirectory(string directory, string archiveName, OutArchiveFormat format = OutArchiveFormat.SevenZip)
        {
            var zip = new SevenZipCompressor();
            zip.ArchiveFormat = format;
            zip.CompressDirectory(directory, archiveName);
        }
        /// <summary>
        /// 压缩目录到Stream
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="archiveStream"></param>
        /// <param name="format"></param>
        public static void ZipDirectory(string directory, Stream archiveStream, OutArchiveFormat format = OutArchiveFormat.SevenZip)
        {
            var zip = new SevenZipCompressor();
            zip.ArchiveFormat = format;
            zip.CompressDirectory(directory, archiveStream);
        }
        /// <summary>
        /// 压缩文件到文件
        /// </summary>
        /// <param name="archiveName"></param>
        /// <param name="fileFullNames"></param>
        /// <param name="format"></param>
        public static void ZipFiles(string archiveName, List<string> fileFullNames, OutArchiveFormat format = OutArchiveFormat.SevenZip)
        {
            var zip = new SevenZipCompressor();
            zip.ArchiveFormat = format;
            zip.CompressFiles(archiveName, fileFullNames.ToArray());
        }
        /// <summary>
        /// 压缩文件到Stream
        /// </summary>
        /// <param name="archiveStream"></param>
        /// <param name="fileFullNames"></param>
        /// <param name="format"></param>
        public static void ZipFiles(Stream archiveStream, List<string> fileFullNames, OutArchiveFormat format = OutArchiveFormat.SevenZip)
        {
            var zip = new SevenZipCompressor();
            zip.ArchiveFormat = format;
            zip.CompressFiles(archiveStream, fileFullNames.ToArray());
        }
        /// <summary>
        /// 压缩Stream到Stream
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outStream"></param>
        /// <param name="format"></param>
        public static void ZipStream(Stream inStream, Stream outStream, OutArchiveFormat format = OutArchiveFormat.SevenZip)
        {
            var zip = new SevenZipCompressor();
            zip.ArchiveFormat = format;
            zip.CompressStream(inStream, outStream);
        }
        #endregion

        #region 解压缩
        /// <summary>
        /// 解压缩到目录
        /// </summary>
        /// <param name="archiveFullName"></param>
        /// <param name="outDirectory"></param>
        /// <param name="format"></param>
        public static void UnzipArchive(string archiveFullName, string outDirectory, InArchiveFormat format = InArchiveFormat.SevenZip)
        {
            using (SevenZipExtractor extractor = new SevenZipExtractor(archiveFullName, format))
            {
                extractor.ExtractArchive(outDirectory);
            }
        }
        /// <summary>
        /// 解压缩具体文件到Stream
        /// </summary>
        /// <param name="archiveFullName"></param>
        /// <param name="fileName"></param>
        /// <param name="stream"></param>
        /// <param name="format"></param>
        public static void UnzipFile(string archiveFullName, string fileName, Stream stream, InArchiveFormat format = InArchiveFormat.SevenZip)
        {
            using (SevenZipExtractor extractor = new SevenZipExtractor(archiveFullName, format))
            {
                extractor.ExtractFile(fileName, stream);
            }
        }
        /// <summary>
        /// 解压缩Stream到Stream
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outStream"></param>
        public static void UnzipStream(Stream inStream, Stream outStream)
        {
            using (SevenZipExtractor extractor = new SevenZipExtractor(inStream))
            {
                extractor.ExtractFile(0, outStream);
            }
        }
        #endregion
    }
}
