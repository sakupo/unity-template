using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Binary
{
  public static class BinUtil
  {
    public static byte[] StringToBytes(string str)
    {
      return Encoding.ASCII.GetBytes(str);
    }

    public static string BytesToString(byte[] bytes)
    {
      return Encoding.ASCII.GetString(bytes);
    }

    public static string BytesToHexString(byte[] bytes)
    {
      var str = BitConverter.ToString(bytes);
      str = str.Replace("-", string.Empty);
      return str;
    }

    public static void AddBytes(List<byte> list, string str)
    {
      AddBytes(list, StringToBytes(str));
    }

    public static void AddBytes(List<byte> list, int num)
    {
      int mask = 0x000000FF;
      for (int i = 0; i < 4; i++)
      {
        list.Add(Convert.ToByte((num >> 8 * i) & mask));
      }
    }

    public static void AddBytes(List<byte> list, byte[] bytes)
    {
      foreach (var b in bytes)
      {
        list.Add(b);
      }
    }

    public static byte[] HexStringToBytes(string str)
    {
      return Enumerable
        .Range(0, str.Length / 2)
        .Select(x => Convert.ToByte(str.Substring(x * 2, 2), 16))
        .ToArray();
    }

    public static string BytesToString(byte[] bytes, int startPos, byte len)
    {
      var targetBytes = new byte[len];
      Array.Copy(bytes, startPos, targetBytes, 0, len);
      return BytesToString(targetBytes);
    }
  }
}