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
            var observer = new TestObserver<string>();
            var a = observer.Take();
            var b = observer.Take();
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
            var observer = new TestObserver<string>();
            observer.Notify("a");
            observer.Notify("b");
            observer.Notify("c");
            var a = observer.Take();
            var b = observer.Take();
            Assert.AreNotEqual(a, b);
            Assert.AreEqual(a.Result, "a");
            Assert.AreEqual(b.Result, "b");
        }

        [Test]
        public void TestInterleaved()
        {
            var observer = new TestObserver<string>();
            observer.Notify("a");
            var a = observer.Take();
            var b = observer.Take();
            var c = observer.Take();
            observer.Notify("b");
            var d = observer.Take();
            observer.Notify("c");
            observer.Notify("d");
            observer.Notify("e");
            var e = observer.Take();
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
            var observer = new TestObserver<int>();
            observer.AddCallback((res) => x += res);
            observer.AddCallback((res) => x += (res * 2));
            observer.Notify(3);
            Assert.AreEqual(x, 10);
        }

        [Test]
        public void TestAddRemoveCallbacks()
        {
            var observer = new TestObserver<string>();
            Action<string> f = (res) => { };
            Action<string> g = (res) => { };
            observer.AddCallback(f);
            observer.AddCallback(g);

            Assert.AreEqual(observer.Callbacks, new List<Action<string>>() { f, g });

            observer.RemoveCallback(f);

            Assert.AreEqual(observer.Callbacks, new List<Action<string>>() { g });

            observer.RemoveCallback();

            Assert.AreEqual(observer.Callbacks, new List<Action<string>>());
        }

        [Test]
        public void TestCollection()
        {
            var observer = new TestObserver<int>();
            for (int i = 0; i < 10; i++)
            {
                observer.Notify(i);
            }
            var items = new List<int>();
            foreach (var item in observer.Collection)
            {
                items.Add(item);
            }

            Assert.AreEqual(Enumerable.Range(0, 10).ToList(), items);
        }
    }

    public class TestObserver<T> : Observer<T>
    {
    }
}