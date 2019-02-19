using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Api.Subscribe.Observers;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Subscribe
{
    [TestFixture]
    public class Observers
    {
        [Test]
        public void TestSubscribeFirst()
        {
            var observer = new TestObserver<string, string>();
            var a = observer.NextAsync();
            var b = observer.NextAsync();
            observer.Notify("a");
            observer.Notify("b");
            observer.Notify("c");
            Assert.AreNotEqual(a, b);
            Assert.AreEqual(a.Result, "a");
            Assert.AreEqual(b.Result, "b");
        }

        [Test]
        public void TestNotifyFirst()
        {
            var observer = new TestObserver<string, string>();
            observer.Notify("a");
            observer.Notify("b");
            observer.Notify("c");
            var a = observer.NextAsync();
            var b = observer.NextAsync();
            Assert.AreNotEqual(a, b);
            Assert.AreEqual(a.Result, "a");
            Assert.AreEqual(b.Result, "b");
        }

        [Test]
        public void TestInterleaved()
        {
            var observer = new TestObserver<string, string>();
            observer.Notify("a");
            var a = observer.NextAsync();
            var b = observer.NextAsync();
            var c = observer.NextAsync();
            observer.Notify("b");
            var d = observer.NextAsync();
            observer.Notify("c");
            observer.Notify("d");
            observer.Notify("e");
            var e = observer.NextAsync();
            Assert.AreEqual(a.Result, "a");
            Assert.AreEqual(b.Result, "b");
            Assert.AreEqual(c.Result, "c");
            Assert.AreEqual(d.Result, "d");
            Assert.AreEqual(e.Result, "e");
        }

        [Test]
        public void TestCallback()
        {
            var x = 1;
            var observer = new TestObserver<int, string>();
            observer.OnNotify += res => x += res;
            observer.OnNotify += res => x += res * 2;
            observer.Notify(3);
            Assert.AreEqual(x, 10);
        }

        // [Test]
        // public void TestCollection()
        // {
        //     var observer = new TestObserver<int, string>();
        //     for (int i = 0; i < 10; i++)
        //     {
        //         observer.Notify(i);
        //     }
        //     var items = new List<int>();
        //     foreach (var item in observer.NotificationQueue.GetConsumingEnumerable())
        //     {
        //         items.Add(item);
        //     }

        //     Assert.AreEqual(Enumerable.Range(0, 10).ToList(), items);
        // }
    }

    public class TestObserver<T, F> : Observer<T, F>
    {
    }
}