using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloud.SDK.Entities;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CrudTests
    {
        [Test]
        public async Task CrudAccount()
        {
            var crudTest = new CrudTest<Account>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudApiKey()
        {
            var crudTest = new CrudTest<ApiKey>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudUser()
        {
            var crudTest = new CrudTest<User>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudUserInvitation()
        {
            var crudTest = new CrudTest<UserInvitation>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudDevice()
        {
            var crudTest = new CrudTest<Device>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudDeviceEnrollment()
        {
            var crudTest = new CrudTest<DeviceEnrollment>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudDeviceEvents()
        {
            var crudTest = new CrudTest<DeviceEvents>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudCertificateEnrollment()
        {
            var crudTest = new CrudTest<CertificateEnrollment>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudCertificateIssuer()
        {
            var expectedFails = new List<int>() { 403 };
            var crudTest = new CrudTest<CertificateIssuer>(expectedFails: expectedFails);
            await crudTest.Test();
        }

        [Test]
        public async Task CrudCertificateIssuerConfig()
        {
            var crudTest = new CrudTest<CertificateIssuerConfig>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudTrustedCertificate()
        {
            var crudTest = new CrudTest<TrustedCertificate>();
            await crudTest.Test();
        }
    }
}