using UnityEngine;

namespace Utility
{
  public class MathEx
  {
    public static float GetAngle(Vector2 start,Vector2 target)
    {
      Vector2 dt = target - start;
      float rad = Mathf.Atan2 (dt.y, dt.x);
      float degree = rad * Mathf.Rad2Deg;
		
      return degree;
    }
  }
}