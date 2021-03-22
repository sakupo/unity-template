using System.Threading.Tasks;
using Main;
using Utility;

namespace Start
{
  public class StartButtonController : ButtonController
  {
    public override async Task OnClick(string objectName)
    {
      switch (objectName)
      {
        case "Button1":
          await SceneManagerEx.Instance.UnloadSceneAsync<StartScene>();
          await SceneManagerEx.Instance.LoadSceneAsync<MainScene>();
          break;
      }
    }
  }
}