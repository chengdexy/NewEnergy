using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// clsMD5 的摘要说明
/// </summary>
public static class clsMD5
{
    public static string getMd5Str(string pwd)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(pwd));
        string str2 = "";
        for (int i = 0; i < result.Length; i++)
        {
            str2 += string.Format("{0:x}", result[i]);
        }
        return str2;
    }
}