using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Utility.Binary;
using Zenject;

public class EditModeTestScript : ZenjectUnitTestFixture
{
  // A Test behaves as an ordinary method
  [Test]
  public void crc32Test()
  {
    // Use the Assert class to test conditions
    Crc32 crc32 = new Crc32();
    string hash = "";
    var str = BinUtil.StringToBytes("The quick brown fox jumps over the lazy dog");
    var b = crc32.ComputeHash(str);

    Console.WriteLine("CRC-32 is {0}", hash);
    Assert.AreEqual("414FA339", BinUtil.BytesToHexString(b));
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