using COMP2084_MusicStore.Controllers;
using COMP2084_MusicStore.Models;
using System;
using Xunit;

namespace MusicStoreUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Throws<InvalidOperationException>(
            () =>
            {
                Song s = new Song();
                s.Price = -1;
            }
            );
        }

        [Fact]
        public void Test2()
        {

        }

        [Fact]
        public void Test3()
        {

        }
    }
}
