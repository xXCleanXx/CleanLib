using CleanLib.Common.Enumerations.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanLib.Common.Streams {
    public static class StreamsCore {
        [Flags]
        public enum LineEndings {
            CarriageReturn = 1,
            LineBreak = 2
        }

        public static void TrimStartTextFileToLength(Stream stream, long length = 1024 * 1024) {
            using StreamReader sr = new(stream);
            Stack stack = new();

            while (!sr.EndOfStream) {
                stack.Push(sr.ReadLine());
            }

            long bytesWritten = 0;
            stream = new MemoryStream();
            using StreamWriter sw = new(stream);

            do {
                string str = stack.Pop().ToString();

                sw.WriteLine(str);

                bytesWritten += str.Length;
            } while (bytesWritten < length);
        }

        public static void TrimStartTextFileToLength(string path, long length = 1024 * 1024) {
            using FileStream fs = File.Open(path, FileMode.OpenOrCreate);

            TrimStartTextFileToLength(fs, length);
        }

        /// <summary>
        /// Trims a textfile down to the designated filesize.<br/>
        /// The last lines will be leftover, trimming the start
        /// </summary>
        /// <param name="filepath">The file to trim</param>
        /// <param name="size">Measured in bytes, 1MB default</param>
        /// <param name="linebreak">Set the linebreak style, note, cr & lf will add more bytes to the file causing less data to be</param>
        /// <param name="buffersize">Depending on the filesystem and the OS, the default 4096 byte buffer is proven to be the best choice</param>
        public static void TextFileToSize(string filepath, long size = 1024 * 1024, LineEndings linebreak = LineEndings.CarriageReturn | LineEndings.LineBreak, int buffersize = 4096, string seperateFile = null) {
            Stack<string> stack = new();
            long bytesWritten = 0;
            Stack<byte[]> lines = new();

            using FileStream f = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader reader = new(f, Encoding.UTF8, true, bufferSize: buffersize);

            while (!reader.EndOfStream) {
                stack.Push(reader.ReadLine());
            }

            while (bytesWritten < size) {
                lines.Push(Encoding.UTF8.GetBytes(stack.Pop()));
                bytesWritten += lines.Peek().LongLength + linebreak.CountFlags();
            }

            if (seperateFile == null) {
                WriteTrimmedFile(filepath, lines, linebreak);
            } else {
                WriteTrimmedFile(seperateFile, lines, linebreak);
            }
        }

        private static void WriteTrimmedFile(string filepath, IEnumerable<byte[]> lines, LineEndings linebreak) {
            using FileStream f = File.Open(filepath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            using StreamWriter writer = new(f);
            string lineending = null;

            if (linebreak.HasFlag(LineEndings.CarriageReturn)) {
                lineending += "\r";
            }

            if (linebreak.HasFlag(LineEndings.LineBreak)) {
                lineending += "\n";
            }

            writer.NewLine = lineending;
            writer.BaseStream.SetLength(0);

            foreach (byte[] bline in lines) {
                writer.WriteLine(Encoding.UTF8.GetString(bline));
            }
        }
    }
}