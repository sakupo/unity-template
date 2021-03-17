using System.Threading.Tasks;
using UnityEngine;

namespace Utility
{
    public abstract class ButtonController: MonoBehaviour

    {
        public abstract Task OnClick(string objectName);
    }
}