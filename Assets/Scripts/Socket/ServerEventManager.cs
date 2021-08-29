using System.Collections.Generic;
using ModestTree;
using Socket.Demo;
using TMPro;
using UnityEngine;
using Object = System.Object;

namespace Socket
{
  public class ServerEventManager : MonoBehaviour
  {
    private Queue<IServerEvent> serverEvents = new Queue<IServerEvent>();
    [SerializeField] private TextMeshPro stateTmpro;
    [SerializeField] private GameObject roomsView;
    [SerializeField] private GameObject roomsViewItemPrefab;
    [SerializeField] private GameManager gameMgr;
    private Dictionary<string, Object> options = new Dictionary<string, object>();
    [SerializeField] private TcpClient tcpClient;

    private void Start()
    {
      options["state"] = stateTmpro;
      options["roomsView"] = roomsView;
      options["roomsViewItemPrefab"] = roomsViewItemPrefab;
      options["gameManager"] = gameMgr;
      options["client"] = tcpClient;
    }

    public void AddEvent(IServerEvent serverEvent)
    {
      lock (serverEvents)
      {
        serverEvents.Enqueue(serverEvent);
      }
    }

    public void CallEvents()
    {
      lock (serverEvents)
      {
        while (!serverEvents.IsEmpty())
        {
          IServerEvent serverEvent;
          serverEvent = serverEvents.Dequeue();
          serverEvent.SetOptions(options);
          serverEvent.Call();
        }
      }
    }
  }
}