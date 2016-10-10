using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace UITest1
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .ApkFile("C:/Users/gusta/AppData/Local/Xamarin/Mono for Android/Archives/2016-10-10/MimAcher.Mobile 10-10-16 2.42 AM.apkarchive/MimAcher.MimAcher.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");

        }
    }
}
