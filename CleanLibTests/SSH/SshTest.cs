using CleanLib.Common.SSH;
using NUnit.Framework;
using Renci.SshNet;
using System;
using System.Diagnostics;
using System.IO;

namespace CleanLibTests.SSH {
    public class SshTest {
        [Test]
        public void RunCommand0() => Assert.DoesNotThrow(() =>
        {
            new Ssh()
            .Credentials("178.254.37.60", "sebastian", "test1234")
            .Connect()
            .RunCommand("cat /etc/motd", out string result)
            .Dispose();

            Debug.Print(result);
            Console.WriteLine(result);
        });

        [Test]
        public void RunCommand1() => Assert.DoesNotThrow(() =>
        {
            new Ssh()
            .Credentials("178.254.37.60", "sebastian", "test1234")
            .Connect()
            .GetCommandOutput("cat /etc/motdd", out SshCommandResult result)
            .Dispose();

            Debug.Print(result.Result);
            Debug.Print(result.ExitCode.ToString());
            Debug.Print(result.HasError.ToString());
            Debug.Print(result.ErrorMessage);
        });

        [Test]
        public void RunCommand2() {
            using FileStream stream = File.OpenRead(@"C:\Users\xxcle\Desktop\privateKeyFile.txt");

            Assert.DoesNotThrow(() =>
            {
                new Ssh()
                .Credentials("178.254.37.60", "sebastian", new PrivateKeyFile(stream))
                .Connect()
                .RunCommand("cat /etc/motd", out string result)
                .Dispose();

                Debug.Print(result);
            });

            stream.Close();
        }
    }
}