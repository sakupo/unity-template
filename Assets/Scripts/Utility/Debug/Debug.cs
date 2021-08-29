using System.Diagnostics;

namespace Utility
{
  public static class Debug
  {
    [Conditional("UNITY_EDITOR")]
    public static void Log(object o)
    {
      UnityEngine.Debug.Log(o);
    }
  }
}