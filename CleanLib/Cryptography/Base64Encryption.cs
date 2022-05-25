﻿using System;
using System.Text;

namespace CleanLib.Common.Cryptography {
    public class Base64Encryption {
        public static string Encode(string plainText) {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string base64EncodedData) {
            byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}