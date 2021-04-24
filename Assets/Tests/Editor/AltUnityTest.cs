using System.Threading;
using NUnit.Framework;
using Altom.AltUnityDriver;
using Altom.AltUnityDriver.Commands;
using Start;
using UnityEngine.SceneManagement;
using Utility;

public class AltUnityTest
{
    public AltUnityDriver AltUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        AltUnityDriver =new AltUnityDriver();
    }

    [SetUp]
    public void LoadLevel()
    {
        AltUnityDriver.LoadScene("StartScene", false);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        AltUnityDriver.Stop();
    }

    [Test]
    public void Test()
    {
        Thread.Sleep(3000);
        //Here you can write the test
        AltUnityDriver.FindObject(By.NAME, "Button1").ClickEvent();
        Thread.Sleep(3000);
        
        Assert.AreEqual("", string.Empty);
    }

}