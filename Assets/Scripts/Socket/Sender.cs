using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Utility;
using Utility.Binary;
using static Utility.Binary.BinUtil;

namespace Socket
{
  public class Sender
  {
    private HashAlgorithm hashAlgorithm = new Crc32();
    private byte[] magicNumber = {0x50, 0x1e};
    byte[] CreateHeader(string dataStr, int bodyLen)
    {
      byte[] data = new byte[12];
      magicNumber.CopyTo(data, 0);
      BinUtil.StringToBytes(dataStr).CopyTo(data, 2);
      var bodyLenByte = BitConverter.GetBytes(bodyLen);
      if (! BitConverter.IsLittleEndian)
        Array.Reverse(bodyLenByte);
      bodyLenByte.CopyTo(data, 8);
      return data;
    }
    
    public byte[] CreateBinary(IClientEvent ev)
    {
      var body =  ev.GetBytes();
      List<byte> header = CreateHeader(ev.EventName, body.Count).ToList();
      var checksum = hashAlgorithm.ComputeHash(body.Concat(header).ToArray());
      return header.Concat(checksum.Reverse()).Concat(body).ToArray();
    }
  }
}