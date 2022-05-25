using CleanLib.Common.Streams;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CleanLibTests.Streams {

    [TestFixture]
    public class StreamsTests {
        private readonly string sourcefile = @"C:\Users\xxcle\Desktop\console - Copy.log";
        private readonly string targetfile = @"C:\Users\xxcle\Desktop\console - Copy2.log";

        [SetUp]
        public void SetUp() {
            if (File.Exists(targetfile)) {
                File.Delete(targetfile);
            }
            File.Copy(sourcefile, targetfile);
        }

        [Test]
        public void SendPerPipe() {
            using NamedPipeClientStream pipe = new("", "", PipeDirection.Out);
            pipe.Connect();

            using StreamWriter sw = new(pipe);
            sw.WriteLine("Hello World");
        }

        [Test]
        public void TrimStartTextFileToLengthTest() {
            StreamsCore.TrimStartTextFileToLength(this.targetfile);
        }

        [Test]
        [Ignore("This is a benchmark")]
#pragma warning disable S2699 // Tests should include assertions
        public void Benchmark() {
            Stopwatch sw = new();

            List<TimeSpan> ts128 = new();
            List<TimeSpan> ts512 = new();
            List<TimeSpan> ts4096 = new();

            for (int i = 0; i < 1024; i++) {
                File.Copy(this.sourcefile, this.targetfile, true);

                sw.Restart();
                StreamsCore.TrimStartTextFileToLength(this.targetfile, 128);
                sw.Stop();
                ts128.Add(sw.Elapsed);

                File.Copy(this.sourcefile, this.targetfile, true);

                sw.Restart();
                StreamsCore.TrimStartTextFileToLength(this.targetfile, 512);
                sw.Stop();
                ts512.Add(sw.Elapsed);

                File.Copy(this.sourcefile, this.targetfile, true);

                sw.Restart();
                StreamsCore.TrimStartTextFileToLength(this.targetfile, 4096);
                sw.Stop();
                ts4096.Add(sw.Elapsed);
            }

            Debug.Print($"Avg 128: {TimeSpan.FromMilliseconds(ts128.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
            Debug.Print($"Avg 512: {TimeSpan.FromMilliseconds(ts512.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
            Debug.Print($"Avg 4096: {TimeSpan.FromMilliseconds(ts4096.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
            
            sw = new();

            ts128 = new();
            ts512 = new();
            ts4096 = new();

            for (int i = 0; i < 1024; i++) {
                File.Copy(sourcefile, targetfile, true);

                sw.Restart();
                StreamsCore.TextFileToSize(this.targetfile, linebreak: StreamsCore.LineEndings.LineBreak, buffersize: 128);
                sw.Stop();
                ts128.Add(sw.Elapsed);

                File.Copy(sourcefile, targetfile, true);

                sw.Restart();
                StreamsCore.TextFileToSize(this.targetfile, linebreak: StreamsCore.LineEndings.LineBreak, buffersize: 512);
                sw.Stop();
                ts512.Add(sw.Elapsed);

                File.Copy(sourcefile, targetfile, true);

                sw.Restart();
                StreamsCore.TextFileToSize(this.targetfile, linebreak: StreamsCore.LineEndings.LineBreak, buffersize: 4096);
                sw.Stop();
                ts4096.Add(sw.Elapsed);
            }

            Debug.Print($"Avg 128: {TimeSpan.FromMilliseconds(ts128.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
            Debug.Print($"Avg 512: {TimeSpan.FromMilliseconds(ts512.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
            Debug.Print($"Avg 4096: {TimeSpan.FromMilliseconds(ts4096.Average(x => x.TotalMilliseconds)):ss\\:ffffff}");
        }
#pragma warning restore S2699 // Tests should include assertions

        [Test]
        public void SizeTest() {
            int[] testLengths = new int[]
            {
                1024 * 1024, // 1MB
                1024 * 1024 * 2, // 2MB
                4096 * 1024, // 4MB
                4096 * 1024 * 2, // 8MB
            };

            FileInfo fi;

            foreach (int s in testLengths) {
                File.Copy(this.sourcefile, this.targetfile, true);
                StreamsCore.TrimStartTextFileToLength(this.targetfile, s);
                fi = new(this.targetfile);
                Assert.GreaterOrEqual(fi.Length, s);
            }
        }

        [Test]
        public void LineEndingLNTests() {
            StreamsCore.TrimStartTextFileToLength(this.targetfile);

            string text = null;

            using (FileStream f = File.Open(this.targetfile, FileMode.Open, FileAccess.Read)) {
                char[] buffer = new char[512];

                using (StreamReader r = new(f)) {
                    r.Read(buffer, 0, 511);
                }

                text = new string(buffer);
            }

            Assert.IsTrue(text.Contains('\n'));
            Assert.IsFalse(text.Contains('\r'));
        }

        [Test]
        public void LineEndingCRLNTests() {
            StreamsCore.TrimStartTextFileToLength(this.targetfile);

            string text = null;

            using (FileStream f = File.Open(this.targetfile, FileMode.Open, FileAccess.Read)) {
                char[] buffer = new char[512];

                using (StreamReader r = new(f)) {
                    r.Read(buffer, 0, 511);
                }

                text = new string(buffer);
            }

            Assert.IsTrue(text.Contains('\n'));
            Assert.IsTrue(text.Contains('\r'));
        }

        [Test]
        public void LineEndingCRTests() {
            StreamsCore.TrimStartTextFileToLength(this.targetfile);

            string text = null;

            using (FileStream f = File.Open(this.targetfile, FileMode.Open, FileAccess.Read)) {
                char[] buffer = new char[512];

                using (StreamReader r = new(f)) {
                    r.Read(buffer, 0, 511);
                }

                text = new string(buffer);
            }

            Assert.IsFalse(text.Contains('\n'));
            Assert.IsTrue(text.Contains('\r'));
        }

        [TearDown]
        public void TearDown() {
            //if (File.Exists(targetfile)) {
            //    File.Delete(targetfile);
            //}
        }

    }
}
