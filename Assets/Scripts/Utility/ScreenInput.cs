using UnityEngine;

namespace Utility
{
  public class ScreenInput : MonoBehaviour
  {
    // フリック最小移動距離
    [SerializeField] private Vector2 flickMinRange = new Vector2(30.0f, 30.0f);

    // スワイプ最小移動距離
    [SerializeField] private Vector2 swipeMinRange = new Vector2(50.0f, 50.0f);

    // スワイプ入力距離
    private Vector2 _swipeRange;

    // 入力方向記録用
    private Vector2 _inputStart;
    private Vector2 _inputMove;
    private Vector2 _inputEnd;

    // フリックの方向
    public enum FlickDirection
    {
      None,
      Tap,
      Up,
      Right,
      Down,
      Left,
    }

    public FlickDirection NowFlick { get; private set; } = FlickDirection.None;

    // スワイプの方向
    public enum SwipeDirection
    {
      None,
      Tap,
      Up,
      Right,
      Down,
      Left,
    }

    public SwipeDirection NowSwipe { get; private set; } = SwipeDirection.None;
    public bool IsSwipeEnd { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
      GetInputVector();
    }

    // 入力の取得
    private void GetInputVector()
    {
      // Unity上での操作取得
      if (Application.isEditor)
      {
        if (Input.GetMouseButtonDown(0))
        {
          _inputStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
          _inputMove = Input.mousePosition;
          CalcSwipeDirection();
        }
        else if (Input.GetMouseButtonUp(0))
        {
          _inputEnd = Input.mousePosition;
          if (NowSwipe != SwipeDirection.None && NowSwipe != SwipeDirection.Tap)
          {
            IsSwipeEnd = true;
          }

          CalcFlickDirection();
        }
        else if (NowFlick != FlickDirection.None || NowSwipe != SwipeDirection.None)
        {
          ResetParameter();
        }
      }
      // 端末上での操作取得
      else
      {
        if (Input.touchCount > 0)
        {
          Touch touch = Input.touches[0];
          if (touch.phase == TouchPhase.Began)
          {
            _inputStart = touch.position;
          }
          else if (touch.phase == TouchPhase.Moved)
          {
            _inputMove = Input.mousePosition;
            CalcSwipeDirection();
          }
          else if (touch.phase == TouchPhase.Ended)
          {
            _inputEnd = touch.position;
            if (NowSwipe != SwipeDirection.None && NowSwipe != SwipeDirection.Tap)
            {
              IsSwipeEnd = true;
            }

            CalcFlickDirection();
          }
        }
        else if (NowFlick != FlickDirection.None || NowSwipe != SwipeDirection.None)
        {
          ResetParameter();
        }
      }
    }

    // 入力内容からフリック方向を計算
    private void CalcFlickDirection()
    {
      Vector2 _work = new Vector2((new Vector3(_inputEnd.x, 0, 0) - new Vector3(_inputStart.x, 0, 0)).magnitude,
        (new Vector3(0, _inputEnd.y, 0) - new Vector3(0, _inputStart.y, 0)).magnitude);

      if (_work.x <= flickMinRange.x && _work.y <= flickMinRange.y)
      {
        NowFlick = FlickDirection.Tap;
      }
      else if (_work.x > _work.y)
      {
        float _x = Mathf.Sign(_inputEnd.x - _inputStart.x);
        if (_x > 0) NowFlick = FlickDirection.Right;
        else if (_x < 0) NowFlick = FlickDirection.Left;
      }
      else
      {
        float _y = Mathf.Sign(_inputEnd.y - _inputStart.y);
        if (_y > 0) NowFlick = FlickDirection.Up;
        else if (_y < 0) NowFlick = FlickDirection.Down;
      }
    }

    // 入力内容からスワイプ方向を計算
    private void CalcSwipeDirection()
    {
      _swipeRange = new Vector2((new Vector3(_inputMove.x, 0, 0) - new Vector3(_inputStart.x, 0, 0)).magnitude,
        (new Vector3(0, _inputMove.y, 0) - new Vector3(0, _inputStart.y, 0)).magnitude);

      if (_swipeRange.x <= swipeMinRange.x && _swipeRange.y <= swipeMinRange.y)
      {
        NowSwipe = SwipeDirection.Tap;
      }
      else if (_swipeRange.x > _swipeRange.y)
      {
        float _x = Mathf.Sign(_inputMove.x - _inputStart.x);
        if (_x > 0) NowSwipe = SwipeDirection.Right;
        else if (_x < 0) NowSwipe = SwipeDirection.Left;
      }
      else
      {
        float _y = Mathf.Sign(_inputMove.y - _inputStart.y);
        if (_y > 0) NowSwipe = SwipeDirection.Up;
        else if (_y < 0) NowSwipe = SwipeDirection.Down;
      }
    }

    // NONEにリセット
    private void ResetParameter()
    {
      NowFlick = FlickDirection.None;
      NowSwipe = SwipeDirection.None;
      IsSwipeEnd = false;
      _swipeRange = new Vector2(0, 0);
    }

    // スワイプ量の取得
    public float GetSwipeRange()
    {
      if (_swipeRange.x > _swipeRange.y)
      {
        return _swipeRange.x;
      }
      else
      {
        return _swipeRange.y;
      }
    }

    // スワイプ量の取得
    public Vector2 GetSwipeRangeVec()
    {
      if (NowSwipe != SwipeDirection.None)
      {
        return new Vector2(_inputMove.x - _inputStart.x, _inputMove.y - _inputStart.y);
      }
      else
      {
        return new Vector2(0, 0);
      }
    }
  }
}