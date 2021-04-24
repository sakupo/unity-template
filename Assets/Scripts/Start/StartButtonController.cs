using System.Threading.Tasks;
using Main;
using UnityEngine;
using Utility;
using Zenject;

namespace Start
{
  public class StartButtonController : ButtonController
  {
    [Inject]
    private ISceneManagerEx sm;
    public override async Task OnClick(string objectName)
    {
      switch (objectName)
      {
        case "Button1":
          await sm.UnloadSceneAsync<StartScene>();
          await sm.LoadSceneAsync<MainScene>();
          break;
      }
    }
  }
}