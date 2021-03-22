using UnityEngine;

namespace Utility
{
  class RuntimeInitializer
  {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
      var table = Resources.Load("PermanentObjects/InitializerTable") as InitializerTable;
      if (table != null)
      {
        foreach (var objData in table.Objects)
        {
          var obj = GameObject.Instantiate(objData);
        }
      }
    }
  }
}