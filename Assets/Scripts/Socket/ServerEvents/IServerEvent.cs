using System;
using System.Collections.Generic;

namespace Socket
{
  public interface IServerEvent
  {
    public void SetOptions(Dictionary<string, Object> options);
    public void Call();
  }
}