using System.Collections.Generic;

namespace Utility
{
  public class NavigationCanvas : UICanvas
  {
    public CanvasEx CurrentCanvas { get; private set; }
    public Stack<CanvasEx> CanvasHistory { get; private set; } = new Stack<CanvasEx>();

    void Awake()
    {
      HideCanvas();
    }

    protected override void Init()
    {
      gameObject.SetActive(true);
    }

    public void ShowCanvas(CanvasEx prevCanvas, CanvasEx currentCanvas)
    {
      Init();
      Debug.Log(CanvasHistory.Count);
      prevCanvas.HideCanvas();
      CanvasHistory.Push(prevCanvas);
      CurrentCanvas = currentCanvas;
      CurrentCanvas.ShowCanvas();
    }

    public void ResetHistory()
    {
      CanvasHistory.Clear();
    }

    public void ShowPrevCanvas()
    {
      if (CanvasHistory.Count < 1)
      {
        return;
      }

      if (CurrentCanvas != null)
      {
        CurrentCanvas.HideCanvas();
      }

      CurrentCanvas = CanvasHistory.Pop();
      CurrentCanvas.ShowCanvas();
    }
  }
}