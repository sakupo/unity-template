using System.Threading.Tasks;
using Start;
using Utility;

namespace Main
{
    public class MainButtonController : ButtonController
    {
        public override async Task OnClick(string objectName)
        {
            switch (objectName)
            {
                case "Button1":
                    await SceneManagerEx.Instance.LoadSceneAsync<StartScene>();
                    break;
            }
        }
    }
}