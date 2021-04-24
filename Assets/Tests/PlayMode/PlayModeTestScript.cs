using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Start;
using UnityEngine;
using UnityEngine.TestTools;
using Utility;

public class PlayModeTestScript
{
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
        Assert.AreEqual("StartScene", SceneManagerEx.Instance.GetScene<StartScene>().name);
    }
}
