using Zenject;
using Utility;


namespace DiInstaller
{
    public class SceneManagerExInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISceneManagerEx>() // ISceneManagerExが要求されたら
                .To<SceneManagerExWithZenject>() // SceneManagerExWithZenjectを生成して注入する
                .FromComponentInNewPrefabResource("PermanentObjects/SceneManagerExWithZenject") // SceneManagerExWithZenject.csを持つゲームオブジェクトを生成
                .AsSingle()　// インスタンスを再利用する(一度しかBindできない)
                .NonLazy(); // 実行の一番最初に生成する

        }
    }
}