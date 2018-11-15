using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloud.SDK.Entities;
using MbedCloud.SDK.Enums;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CrudTests
    {
        [Test]
        public async Task CrudAccount()
        {
            var myAccount = await new Account().Me();

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "PhoneNumber", "118118" }
            };

            var crudTest = new CrudTest<Account>(
                objectInstance: myAccount,
                propsToUpdate: propsToUpdate,
                update: true
            );
            await crudTest.Test();
        }

        [Test]
        public async Task CrudApiKey()
        {
            var newApiKey = new ApiKey
            {
                Name = "alex new api keyyy",
            };

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "Name", "UpdatedApiKeyyy" },
            };

            var crudTest = new CrudTest<ApiKey>(
                objectInstance: newApiKey,
                propsToUpdate: propsToUpdate,
                create: true,
                update: true
            );
            await crudTest.Test();

            var myApiKey = await new ApiKey().Me();
            Assert.IsInstanceOf(typeof(ApiKey), myApiKey);
        }

        [Test]
        public async Task CrudUser()
        {
            var newUser = new User
            {
                Username = "alexnewuser",
                FullName = "Dan Dan",
                Email = "dan@dan.com",
                PhoneNumber = "0800001066",
            };

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "PhoneNumber", "118118" },
            };

            var crudTest = new CrudTest<User>(
                objectInstance: newUser,
                propsToUpdate: propsToUpdate,
                create: true,
                update: true
            );

            await crudTest.Test();
        }

        [Test]
        public async Task CrudUserInvitation()
        {
            var crudTest = new CrudTest<UserInvitation>();
            await crudTest.Test();
        }

        [Test]
        public async Task CrudSubUser()
        {
            var myAccount = await new Account().Me();
            var firstSubUser = myAccount.Users().First();
            var newSubUser = new SubtenantUser
            {
                AccountId = myAccount.Id,
                Username = "alexnewusersub",
                FullName = "Dan Dan Dan",
                Email = "dandan@dan.com",
                PhoneNumber = "0800001066",
            };

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "PhoneNumber", "118118" },
            };

            Func<SubtenantUser, SubtenantUser> preFunc = (SubtenantUser entity) =>
            {
                entity.AccountId = myAccount.Id;
                return entity;
            };

            var crudTest = new CrudTest<SubtenantUser>(
                list: false,
                preGetFunc: preFunc,
                firstObj: firstSubUser,
                idToGet: firstSubUser.Id,
                objectInstance: newSubUser,
                propsToUpdate: propsToUpdate,
                create: true,
                update: true
            );

            await crudTest.Test();
        }

        [Test]
        public async Task CrudDevice()
        {
            var device = new Device().List().First();

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "Name", "Alex Updated Device Name" },
            };

            var crudTest = new CrudTest<Device>(
                objectInstance: device,
                propsToUpdate: propsToUpdate
            );

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
            var trustedCert = new TrustedCertificate().List().FirstOrDefault(t => t.IsDeveloperCertificate == false);

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "Description", "updated description" },
            };

            var crudTest = new CrudTest<TrustedCertificate>(
                objectInstance: trustedCert,
                propsToUpdate: propsToUpdate,
                update: true
            );
            await crudTest.Test();
        }

        [Test]
        public async Task CrudSubTrustedCertificate()
        {
            var myAccount = await new Account().Me();
            var trustedCert = myAccount.TrustedCertificates().FirstOrDefault(t => t.IsDeveloperCertificate == false);

            var propsToUpdate = new Dictionary<string, object>()
            {
                { "Description", "updated description" },
            };

            Func<SubtenantTrustedCertificate, SubtenantTrustedCertificate> preFunc = (SubtenantTrustedCertificate entity) =>
            {
                entity.AccountId = myAccount.Id;
                return entity;
            };

            var crudTest = new CrudTest<SubtenantTrustedCertificate>(
                list: false,
                firstObj: trustedCert,
                preGetFunc: preFunc,
                idToGet: trustedCert.Id,
                objectInstance: trustedCert,
                propsToUpdate: propsToUpdate,
                update: true
            );
            await crudTest.Test();
        }

        [Test]
        public async Task CrudDeveloperCertificate()
        {
            var firstDevCert = await new TrustedCertificate().List().FirstOrDefault(d => d.IsDeveloperCertificate == true).DeveloperCertificateInfo();

            var devCert = new DeveloperCertificate
            {
                Name = "Alex new dev cert",
                Description = "this is a new developer certificate",
            };

            var crudTest = new CrudTest<DeveloperCertificate>(
                list: false,
                objectInstance: devCert,
                firstObj: firstDevCert,
                idToGet: firstDevCert.Id,
                create: true
            );
            await crudTest.Test();
        }
    }
}