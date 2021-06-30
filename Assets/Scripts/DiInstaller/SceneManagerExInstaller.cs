using UnityEngine;
using Zenject;
using Utility;


namespace DiInstaller
{
    public class SceneManagerExInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var sceneManagerObj = FindObjectOfType<SceneManagerExWithZenject>().gameObject;
            Container
                .Bind<ISceneManagerEx>() // ISceneManagerExが要求されたら
                .To<SceneManagerExWithZenject>() // SceneManagerExWithZenjectを生成して注入する
                .FromComponentOn(sceneManagerObj) // SceneManagerExWithZenject.csを持つゲームオブジェクトを生成
                .AsSingle()　// インスタンスを再利用する(一度しかBindできない)
                .NonLazy(); // 実行の一番最初に生成する

        }
    }
}