using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Main;
using NUnit.Framework;
using Root;
using Start;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utility;
using Zenject;
using Assert = NUnit.Framework.Assert;
using Debug = Utility.Debug;

public class PlayModeTestScript: ZenjectIntegrationTestFixture
{
    [Inject]
    private ISceneManagerEx sm;

    [SetUp]
    public async void SetUp()
    {
        // SceneContextの生成
        PreInstall();
        /*
         * ここでBind
         */
        // Inject実行
        PostInstall();
        
        // 初期シーンの生成
        await sm.LoadSceneAsync<RootScene>(null, LoadSceneMode.Single);
        await sm.LoadSceneAsync<StartScene>();
    }

    // A Test behaves as an ordinary method
    [Test]
    public void PlayModeTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayModeTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(1f);
        Assert.IsNotNull(sm.GetScene<StartScene>());
        Assert.IsNull(sm.GetScene<MainScene>());
    }
}
