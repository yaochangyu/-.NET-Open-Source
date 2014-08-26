//// ***********************************************************************
//// Assembly         : Tako.Component.Extension
//// Author           : 余小章
//// Created          : 08-19-2014
////
//// Last Modified By : 余小章
//// Last Modified On : 08-19-2014
//// ***********************************************************************
//// <copyright file="SaveAndLoad.cs" company="">
////     Copyright (c) . 余小章 . All rights reserved.
//// </copyright>
//// <summary></summary>
//// ***********************************************************************
//using System;
//using System.IO;
//using System.Text;

///// <summary>
///// The Extension namespace.
///// </summary>
//namespace Tako.Component.Extension
//{
//    /// <summary>
//    /// Class StringExtensions.
//    /// </summary>
//    public static partial class StringExtensions
//    {
//        //internal static Encoding DEFAULT_ENCODE = Encoding.GetEncoding(950);
//        /// <summary>
//        /// The defaul t_ encode
//        /// </summary>
//        internal static Encoding DEFAULT_ENCODE = Encoding.UTF8;

//        /// <summary>
//        /// 字串存檔
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="FileName">檔案位置名稱</param>
//        /// <param name="Append">是否附加檔案</param>
//        /// <param name="Encode">編碼</param>
//        /// <exception cref="System.ArgumentException">
//        /// An empty string value cannot be encrypted.
//        /// or
//        /// An empty string value cannot be encrypted.
//        /// </exception>
//        public static void SaveAs(this string Value, string FileName, bool Append, Encoding Encode)
//        {
//            if (string.IsNullOrEmpty(Value))
//            {
//                throw new ArgumentException("An empty string value cannot be encrypted.");
//            }
//            if (string.IsNullOrEmpty(FileName))
//            {
//                throw new ArgumentException("An empty string value cannot be encrypted.");
//            }

//            using (StreamWriter sw = new StreamWriter(FileName, Append, Encode))
//            {
//                sw.Write(Value);
//            }
//        }

//        /// <summary>
//        /// 字串存檔
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="FileName">檔案位置名稱</param>
//        public static void Save(this string Value, string FileName)
//        {
//            SaveAs(Value, FileName, false, DEFAULT_ENCODE);
//        }

//        /// <summary>
//        /// 字串附加存檔
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="FileName">檔案位置名稱</param>
//        public static void AppendSave(this string Value, string FileName)
//        {
//            SaveAs(Value, FileName, true, DEFAULT_ENCODE);
//        }

//        /// <summary>
//        /// 字串讀取檔案
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <returns>返回讀取的Byte陣列</returns>
//        /// <exception cref="System.ArgumentException">An empty string value cannot be encrypted.</exception>
//        /// <exception cref="System.IO.FileNotFoundException">Value</exception>
//        public static byte[] LoadAllBytes(this string Value)
//        {
//            if (string.IsNullOrEmpty(Value))
//            {
//                throw new ArgumentException("An empty string value cannot be encrypted.");
//            }
//            if (!File.Exists(Value))
//            {
//                throw new FileNotFoundException("Value");
//            }

//            //using (FileStream stream = File.Open(Value, FileMode.Open))
//            //using (MemoryStream memory = new MemoryStream())
//            //{
//            //    byte[] buffer = new byte[1024];
//            //    int bytesRead;
//            //    while (true)
//            //    {
//            //        bytesRead = stream.Read(buffer, 0, buffer.Length);
//            //        if (bytesRead == 0)
//            //            break;
//            //        memory.Write(buffer, 0, bytesRead);
//            //    }
//            //    return memory.ToArray();
//            //}

//            using (FileStream stream = new FileStream(Value, FileMode.Open, FileAccess.Read))
//            {
//                byte[] dataByteArray = new byte[stream.Length];
//                stream.Read(dataByteArray, 0, dataByteArray.Length);
//                return dataByteArray;
//            }
//        }

//        /// <summary>
//        /// 字串讀取檔案內容
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="Encode">編碼</param>
//        /// <returns>返回讀取內容</returns>
//        public static string Load(this string Value, Encoding Encode)
//        {
//            byte[] contentByte = LoadAllBytes(Value);
//            string content = Encode.GetString(contentByte);
//            return content;
//        }

//        /// <summary>
//        /// 字串讀取檔案內容
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <returns>返回讀取內容</returns>
//        public static string Load(this string Value)
//        {
//            return Load(Value, DEFAULT_ENCODE);
//        }

//        /// <summary>
//        /// 字串讀取檔案某一行
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="Line">指定特定行數</param>
//        /// <param name="Encode">編碼</param>
//        /// <returns>返回該行結果</returns>
//        public static string LoadLine(this string Value, int Line, Encoding Encode)
//        {
//            using (StreamReader reader = new StreamReader(Value, Encode))
//            {
//                int line = 0;
//                int offset = Line - 1;
//                string linedata = "";
//                while (!reader.EndOfStream)
//                {
//                    if (line != offset)
//                    {
//                        reader.ReadLine();
//                    }
//                    else if (line == offset)
//                    {
//                        linedata = reader.ReadLine();
//                        break;
//                    }
//                    line++;
//                }
//                return linedata;
//            }
//        }

//        /// <summary>
//        /// 字串讀取檔案某一行
//        /// </summary>
//        /// <param name="Value">擴充字串</param>
//        /// <param name="Line">指定特定行數</param>
//        /// <returns>返回該行結果</returns>
//        public static string LoadLine(this string Value, int Line)
//        {
//            return LoadLine(Value, Line, DEFAULT_ENCODE);
//        }
//    }
//}