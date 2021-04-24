using System.Threading.Tasks;
using Start;
using Utility;
using Zenject;

namespace Main
{
  public class MainButtonController : ButtonController
  {
    [Inject]
    private ISceneManagerEx sm;
    public override async Task OnClick(string objectName)
    {
      switch (objectName)
      {
        case "Button1":
          await sm.UnloadSceneAsync<MainScene>();
          await sm.LoadSceneAsync<StartScene>();
          break;
      }
    }
  }
}