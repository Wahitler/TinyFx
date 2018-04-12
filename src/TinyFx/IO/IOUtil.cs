using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TinyFx.IO
{
    /// <summary>
    /// IO辅助类
    /// file    => string   : File.ReadAllText
    /// file    => stream   : IOUtil.ReadFileToStream
    /// file    => bytes    : File.ReadAllBytes
    /// string  => file     : File.WriteAllText
    /// string  => stream   : IOUtil.ReadStreamToString
    /// string  => bytes    : Encoding.UTF8.GetBytes
    /// stream  => string   : IOUtil.ReadStreamToString
    /// stream  => file     : IOUtil.WriteStreamToFile
    /// stream  => bytes    : IOUtil.ReadStreamToBytes
    /// bytes   => stream   : new MemoryStream(bytes)
    /// bytes   => string   : Encoding.UTF8.GetString
    /// bytes   => file     : File.WriteAllBytes
    /// </summary>
    public static class IOUtil
    {
        /// <summary>
        /// 读取 Stream 到 byte[]
        /// </summary>
        /// <param name="stream">需要读取的Stream</param>
        /// <param name="isClose">读取完是否关闭Stream</param>
        /// <returns></returns>
        public static byte[] ReadStreamToBytes(Stream stream, bool isClose = false)
        {
            byte[] ret = new byte[stream.Length];
            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(ret, 0, (int)stream.Length);
            }
            finally
            {
                if (isClose) stream.Close();
                else stream.Seek(0, SeekOrigin.Begin);
            }
            return ret;
        }

        /// <summary>
        /// 将 Stream 写入文件 
        /// </summary>
        /// <param name="stream">流对象</param>
        /// <param name="path">文件名</param>
        /// <param name="encoding">Stream的字符集</param>
        public static void WriteStreamToFile(Stream stream, string path, Encoding encoding = null)
        {
            byte[] buffer = new byte[2048];
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryReader reader = new BinaryReader(stream, encoding ?? Encoding.UTF8);
                int readLength = 0;
                while ((readLength = reader.Read(buffer, 0, buffer.Length)) > 0)
                    fs.Write(buffer, 0, readLength);
            }
        }

        /// <summary>
        /// 从文件中读取到MemoryStream
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream ReadFileToStream(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                return new MemoryStream(buffer);
            }
        }

        /// <summary>
        /// 读取流到字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadStreamToString(Stream stream, Encoding encoding = null)
        {
            using (StreamReader reader = new StreamReader(stream, encoding ?? Encoding.UTF8))
            {
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 替换文本文件内容
        /// </summary>
        /// <param name="file"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public static void ReplaceTextFileContent(string file, string oldValue, string newValue)
        {
            var content = File.ReadAllText(file);
            content.Replace(oldValue, newValue);
            File.WriteAllText(file, content);
        }

        /// <summary>
        /// 移除指定文件夹的只读属性(包含这个文件夹下的所有文件)
        /// </summary>
        /// <param name="destDirectoryPath">目标文件夹</param>
        public static void RemoveReadOnlyAttr(string destDirectoryPath)
        {
            Queue<FileSystemInfo> filefolders = new Queue<FileSystemInfo>(new DirectoryInfo(destDirectoryPath).GetFileSystemInfos());
            while (filefolders.Count > 0)
            {
                FileSystemInfo atom = filefolders.Dequeue();
                FileInfo file = atom as FileInfo;
                if (file == null)
                {
                    DirectoryInfo directory = atom as DirectoryInfo;
                    foreach (FileSystemInfo fi in directory.GetFileSystemInfos())
                        filefolders.Enqueue(fi);
                }
                else
                    file.Attributes &= ~FileAttributes.ReadOnly;
            }
        }

        /// <summary>
        /// 判断路径是否是目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDir(string path)
            => (new FileInfo(path).Attributes & FileAttributes.Directory) != 0;

        /// <summary>
        /// 获取绝对路径。可以将相对路径转成绝对路径（可以使用SetCurrentDirectory设置相对的当前目录）
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentDirectory"></param>
        /// <returns></returns>
        public static string GetAbsolutePath(string path, string currentDirectory = null)
        {
            string ret = path;
            if (Path.IsPathRooted(path))
            {
                if (!string.IsNullOrEmpty(currentDirectory))
                    Directory.SetCurrentDirectory(currentDirectory);
                ret = Path.GetFullPath(path);
            }
            return ret;
        }

        /// <summary>
        /// 获取相对路径。可将绝对路径转换成相对路径
        /// </summary>
        /// <param name="absolutePath">绝对路径</param>
        /// <param name="relativeTo">相对的目录</param>
        /// <returns></returns>
        public static string GetRelativePath(string absolutePath, string relativeTo = null)
        {
            if (Path.IsPathRooted(absolutePath)) return absolutePath;
            string[] absoluteDirectories = absolutePath.Split('\\');
            string[] relativeDirectories = relativeTo.Split('\\');

            int length = absoluteDirectories.Length < relativeDirectories.Length ? absoluteDirectories.Length : relativeDirectories.Length;
            int lastCommonRoot = -1;
            int index;

            for (index = 0; index < length; index++)
                if (absoluteDirectories[index] == relativeDirectories[index])
                    lastCommonRoot = index;
                else
                    break;

            if (lastCommonRoot == -1)
                throw new ArgumentException("路径没有共同点");

            StringBuilder relativePath = new StringBuilder();
            for (index = lastCommonRoot + 1; index < absoluteDirectories.Length; index++)
                if (absoluteDirectories[index].Length > 0)
                    relativePath.Append("..\\");

            for (index = lastCommonRoot + 1; index < relativeDirectories.Length - 1; index++)
                relativePath.Append(relativeDirectories[index] + "\\");
            relativePath.Append(relativeDirectories[relativeDirectories.Length - 1]);

            return relativePath.ToString();
        }

        /// <summary>
        /// 删除目录中的所有
        /// </summary>
        /// <param name="targetDirectory"></param>
        public static void DeleteAll(string targetDirectory)
        {
            var dirInfo = new DirectoryInfo(targetDirectory);
            RecursiveDelete(dirInfo);
            // 递归
            void RecursiveDelete(DirectoryInfo baseDir)
            {
                if (!baseDir.Exists) return;
                foreach (var dir in baseDir.EnumerateDirectories())
                    RecursiveDelete(dir);
                if (baseDir.Exists)
                    baseDir.Delete(true);
            }
        }
    }
}
