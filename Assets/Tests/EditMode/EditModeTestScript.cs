using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utility;
using Zenject;

public class EditModeTestScript: ZenjectUnitTestFixture
{
    // A Test behaves as an ordinary method
    [Test]
    public void EditModeTestScriptSimplePasses()
    {

        // Use the Assert class to test conditions
        Assert.AreEqual(1, 1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EditModeTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
