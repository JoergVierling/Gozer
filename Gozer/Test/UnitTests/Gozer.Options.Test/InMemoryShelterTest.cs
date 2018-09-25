using System;
using System.Collections.Generic;
using FluentAssertions;
using Gozer.Contract;
using Gozer.Core;
using Gozer.Services;
using Gozer.Shelter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace Gozer.Options.Test
{
    [TestClass]
    public class InMemoryShelterTest
    {
        private Service testInstance;

        public InMemoryShelterTest()
        {
            testInstance = new Service("TestQualifiedName", ServicesBinding.WebApi, "localhost")
            {
                Guid = Guid.Parse("005a723a-dbb7-436e-a525-e7d9fbd733ee"),
                LastCall = new DateTime(2018, 09, 04, 22, 07, 00)
            };
        }

        [TestMethod]
        public void TestMethod1_InitalEmpty()
        {
            var shelter = new InMemoryShelter();
            IEnumerator<IService> inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeFalse();

            inner.Dispose();
        }


        [TestMethod]
        public void TestMethod1_Add()
        {
            var shelter = new InMemoryShelter();
            shelter.Add(testInstance);

            IEnumerator<IService> inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeTrue();
            inner.Current.Should().Be(testInstance);

            inner.Dispose();
        }

        [TestMethod]
        public void TestMethod1_Update()
        {
            var shelter = new InMemoryShelter();
            shelter.Add(testInstance);

            IEnumerator<IService> inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeTrue();
            inner.Current.LastCall.Should().Be(new DateTime(2018, 09, 04, 22, 07, 00));

            testInstance.LastCall = new DateTime(2018, 09, 04, 22, 10, 00);

            shelter.Update(testInstance);
            
            inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeTrue();
            inner.Current.LastCall.Should().Be(new DateTime(2018, 09, 04, 22, 10, 00));
            inner.MoveNext().Should().BeFalse();

            inner.Dispose();
            
            testInstance.LastCall = new DateTime(2018, 09, 04, 22, 07, 00);
        }

        [TestMethod]
        public void TestMethod1_Remove()
        {
            
            var shelter = new InMemoryShelter();
            shelter.Add(testInstance);

            IEnumerator<IService> inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeTrue();
            inner.Current.LastCall.Should().Be(new DateTime(2018, 09, 04, 22, 07, 00));
            
            shelter.Remove(testInstance);
            inner = shelter.GetEnumerator();
            inner.MoveNext().Should().BeFalse();
        }
    }
}