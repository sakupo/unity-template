using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Utility;

namespace Socket
{
    public class TcpConnector
    {
        /* 接続先サーバー情報 */
        private string addr;
        private int port;
        private int readTimeout;
        private int writeTimeout;
 
        /* 状態フラグ */
        public bool IsConnected { get; private set; }

        /* TCP通信ハンドル */
        private System.Net.Sockets.TcpClient tcpClient;
        private NetworkStream networkStream;
 
        /// <summary>
        /// サーバー情報初期化
        /// </summary>
        /// <param name="serverAddress">サーバーアドレス</param>
        /// <param name="serverPort">サーバーポート番号</param>
        /// <param name="readTimeout">受信タイムアウト[ms]</param>
        /// <param name="writeTimeout">送信タイムアウト[ms]</param>
        /// <returns></returns>
        public bool SetConnectInfo(string serverAddress, int serverPort, int readTimeout = Timeout.Infinite, int writeTimeout = Timeout.Infinite)
        {
            // サーバー情報を更新
            addr = serverAddress;
            port = serverPort;
            this.readTimeout = readTimeout;
            this.writeTimeout = writeTimeout;
 
            // 「切断」状態に初期化
            IsConnected = false;
            return true;
        }
 
        /// <summary>
        /// サーバー接続
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            bool result = false;
            try
            {
                // サーバーと接続
                // 接続完了するまでブロッキングする
                Debug.Log(MakeLogWithTime($"Connect() : [{addr}:{port}] ..."));
                tcpClient = new System.Net.Sockets.TcpClient(addr, port);
                Debug.Log(MakeLogWithTime("Connect() : connected."));
 
                // 接続完了
                result = true;
 
                // 「接続」状態に更新
                IsConnected = true;
 
                // ネットワークストリームを取得
                networkStream = tcpClient.GetStream();
 
                // 送受信タイムアウト時間を設定
                networkStream.ReadTimeout = readTimeout;
                networkStream.WriteTimeout = writeTimeout;
            }
            catch (Exception ex)
            {
                // 接続失敗
                Debug.Log(MakeLogWithTime($"Connect() : ERROR ! {ex.Message}"));
            }
            return result;
        }
 
        /// <summary>
        /// 切断処理
        /// </summary>
        public void Disconnect()
        {
            networkStream?.Close();
            tcpClient?.Close();
            IsConnected = false;
        }
 
        /// <summary>
        /// send data
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            try
            {
                // データ送信開始
                networkStream.Write(data, 0, data.Length);
 
                // 送信成功
               // Debug.Log(MakeLogWithTime($"Send() : [{MakeLog(data, data.Length)}]"));
            }
            catch (Exception ex)
            {
                // 送信失敗
                Debug.Log(MakeLogWithTime($"Send() : ERROR ! {ex.Message}"));
 
                // 「切断」状態に更新
                IsConnected = false;
 
                // クライアント初期化
                networkStream?.Close();
                tcpClient?.Close();
            }
        }
 
        /// <summary>
        /// 通信電文受信
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Receive(byte[] data)
        {
            int receiveSize = 0;
            try
            {
                // データ受信開始
                receiveSize = networkStream.Read(data, 0, data.Length);

                // 受信成功
                if (receiveSize > 0)
                {
                   // Debug.Log(MakeLogWithTime($"Receive() : [{MakeLog(data, receiveSize)}]"));
                }
            }
            catch (IOException)
            {
                // タイムアウト
                Debug.Log(MakeLogWithTime("Receive() : read timeout."));
            }
            catch(Exception ex)
            {
                Debug.Log(MakeLogWithTime($"Receive() : ERROR ! {ex.Message}"));
 
                // 「切断」状態に更新
                IsConnected = false;
 
                // クライアント初期化
                networkStream?.Close();
                tcpClient?.Close();
                throw;
            }
 
            return receiveSize;
        }
 
        /// <summary>
        /// 通信電文ログ取得
        /// </summary>
        /// <param name="data">通信電文</param>
        /// <param name="size">通信電文サイズ</param>
        /// <returns>通信電文ログ</returns>
        string MakeLog(byte[] data, int size)
        {
            string result = "";
            for (int i = 0; i < size; i++)
            {
                result += $"{data[i],2:X2}";
            }
            return result;
        }

        string MakeLogWithTime(string message = "")
        {
            return $"{DateTime.Now:[yyyy/MM/dd HH:mm:ss]} [TCPClient] " + message;
        }
    }
}