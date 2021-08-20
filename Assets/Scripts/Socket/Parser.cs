using System;
using System.Linq;
using System.Security.Cryptography;
using Cysharp.Threading.Tasks;
using Socket.ServerEvents;
using Utility;
using Utility.Binary;

namespace Socket
{
  public class Parser
  {
    private HashAlgorithm hashAlgorithm = new Crc32();
    private readonly byte[] magicNumber = {0x50, 0x1e};
    private readonly UInt32 hashMagic = 0x2144df1c;

    public ServerEvent ReadAndParse(TcpConnector connector)
    {
      byte[] header = new byte[16];
      int receiveSize = connector.Receive(header);
      if (receiveSize <= 0) return new ConnectionCloseEvent(connector);
      // magicの照合
      bool isMagicCorrect = header.Take(2).SequenceEqual(magicNumber);
      if (!isMagicCorrect) return new UnknownEvent("Invalid magic.");
      // bodyの取得
      var bodyLen = BitConverter.ToUInt32(header, 8);
      byte[] body = new byte[bodyLen];
      connector.Receive(body);
      // hash magicの照合
      var hashMagicBytes = hashAlgorithm.ComputeHash(body.Concat(header).ToArray());
      var hashMagic = BitConverter.ToUInt32(hashMagicBytes.Reverse().ToArray(), 0);
      var isHashMagicCorrect = hashMagic==this.hashMagic;
      if (!isHashMagicCorrect) return new UnknownEvent("Invalid hash algorithm magic.");
      // event名の取得
      var eventName = BinUtil.BytesToString(header.Skip(2).Take(6).ToArray());
      ServerEvent serverEvent;
      switch (eventName)
      {
        case "WELCOM":
          serverEvent = new WelcomeEvent();
          break;
        default:
          serverEvent = new UnknownEvent("Unknown event received");
          break;
      }
      return serverEvent;
    }
  }
}