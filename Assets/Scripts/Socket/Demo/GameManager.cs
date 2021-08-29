using System.Collections;
using System.Linq;
using Cysharp.Threading.Tasks;
using Socket.ClientEvents;
using UnityEngine;

namespace Socket.Demo
{
  public class GameManager: MonoBehaviour
  {
    private volatile bool isRunning;
    public readonly int totalNoOfPlayer = 2;
    public readonly int bufferSize = 16;
    public byte PlayerNum = 0;
    public byte[,] ActionBuffers { get; private set; }
    private byte[] ownActionBuffer;
    private int ownActionBufferIndex = 0;
    [SerializeField] private TcpClient tcpClient;

    [SerializeField] private SampleGame _game;

    private ISyncGame game
    {
      get
      {
        return _game;
      }
      set
      {
        _game = value as SampleGame;
      }
    }

    private int startFrame = 0;
    public volatile int latestFrame = 0;
    public int[] latestFrames;
    private bool isStartGame = false;
    public bool[] IsOk { get; private set; }
    public long RandomNum { get; set; }

    public volatile int phase = 0;
    [SerializeField] private ServerEventManager serverEventManager;

    private void Start()
    {
      IsOk = new bool[totalNoOfPlayer];
    }

    public void StartGame()
    {
      ActionBuffers = new byte[totalNoOfPlayer, bufferSize];
      ownActionBuffer = new byte[bufferSize];
      startFrame = Time.frameCount;
      latestFrame = 0;
      latestFrames = new int[totalNoOfPlayer];
      IsOk = new bool[totalNoOfPlayer];
      phase = 0;
      isStartGame = true;
      isRunning = false;
    }

    public void EndGame()
    {
      isStartGame = false;
    }

    private async void Update()
    {
      if (!isStartGame)
      {
        // ゲーム開始前
        switch (phase)
        {
          case 0: case 1:
            if (IsOk.All(b => b))
            {
              var ev = new ReadyEvent(PlayerNum);
              tcpClient.Send(ev);
              for (var i = 0; i < IsOk.Length; i++)
              {
                IsOk[i] = false;
              }
            }
            break;
          case 2:
            StartGame();
            Debug.Log(PlayerNum.ToString());
            break;
        }
        return;
      }
      await MoveToNextFrame();
    }

    public void OnAnyKeyPressed(byte key)
    {
      lock (ownActionBuffer)
      {
        if (ownActionBufferIndex < bufferSize)
        {
          ownActionBuffer[ownActionBufferIndex++] = key;
          if (ownActionBufferIndex < bufferSize)
          {
            ownActionBuffer[ownActionBufferIndex] = 0;
          }
        }
      }
    }

    private IEnumerator MoveToNextFrame()
    {
      // 自分のactionの送信
      int currentFrame = Time.frameCount - startFrame;
      IClientEvent ev = CreateActionEvent(currentFrame);
      tcpClient.Send(ev);
      yield return null;
      // 他プレイヤーの行動待機
      int lagCounter = 0;
      while (currentFrame > latestFrame)
      {
        if (lagCounter++ % 60 != 0) break;
        serverEventManager.CallEvents();
      }
      game.UpdateGame(this, ActionBuffers);
    }

    private IClientEvent CreateActionEvent(int currentFrame)
    {
      IClientEvent ev;
      var sentActionBuffer = new byte[bufferSize];
      lock (ownActionBuffer)
      {
        ownActionBuffer.CopyTo(sentActionBuffer, 0);
        ev = new ActionEvent(sentActionBuffer, bufferSize, currentFrame);
        ownActionBufferIndex = 0;
        ownActionBuffer[0] = 0;
      }
      return ev;
    }
  }
}