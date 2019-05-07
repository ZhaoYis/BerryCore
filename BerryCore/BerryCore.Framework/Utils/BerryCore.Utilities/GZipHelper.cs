#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：GZipHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:41:02
* 更新时间 ：2019/5/7 23:41:02
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：GZip压缩帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:41:02 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:41:02 
    /// </summary>
    public static class GZipHelper
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string GZipCompress(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            byte[] buffer = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(GZipCompress(buffer));
        }

        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] GZipCompress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                return null;
            }

            return GZipCompress(StreamToBytes(stream));
        }

        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] GZipCompress(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deflate压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] DeflateCompress(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                using (var deflate = new DeflateStream(ms, CompressionMode.Compress, true))
                {
                    deflate.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string Decompress(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            byte[] buffer = Convert.FromBase64String(text);
            using (var ms = new MemoryStream(buffer))
            {
                using (var zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(zip))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] Decompress(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }

            return Decompress(new MemoryStream(buffer));
        }

        #region 私有方法

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="stream">流</param>
        private static byte[] Decompress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                return null;
            }

            using (var zip = new GZipStream(stream, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(zip))
                {
                    return Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
        }
        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        private static byte[] StreamToBytes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        #endregion
    }
}
