# -*- encoding=utf8 -*-
from poco.drivers.unity3d import UnityPoco                  # Unity用のインポート.

# Windows用の初期化処理.
from poco.drivers.unity3d.device import UnityEditorWindow   # UnityEditor用のインポート.
dev = UnityEditorWindow()                                   # デバイスにUnityEditorを指定.
addr = ('', 5001)                                           # 接続先のIPアドレスを指定.
poco = UnityPoco(addr, device=dev) 
import time
# Unity用のPocoを生成
poco("Button1").click()
time.sleep(1.0)
