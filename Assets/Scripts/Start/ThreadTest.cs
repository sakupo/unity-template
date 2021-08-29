using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Debug = Utility.Debug;

namespace Start
{
  public class ThreadTest: MonoBehaviour
  {
    public string name;
    private bool isFirst = true;
    private Thread t;
    private volatile int cnt = 0;
    async void Update()
    {
      Debug.Log($"${name}: ${cnt}");
      if (cnt >= 1)
      {
        UnityEngine.Debug.Log("2");
        EditorApplication.isPlaying = false;
        return;
      }
      isFirst = false;
      Debug.Log($"${name} th start");
      await Task.Run(A);
      Debug.Log($"${name} th end");
      cnt=cnt+1;
    }

    private void A()
    {
      Thread.Sleep(1000);
    }
  }
}