using System;
using Xunit;
using MyDiary.Controllers;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var home = new HomeController();
            var output = home.Index();
            Assert.NotNull(output);
        }
        [Fact]
        public void Test2()
        {
            var home = new HomeController();
            var output = home.About();
            Assert.NotNull(output);
        }
        [Fact]
        public void Test3()
        {
            var home = new HomeController();
            var output = home.Contact();
            Assert.NotNull(output);
        }
        [Fact]
        public void Test4()
        {
            var home = new HomeController();
            var output = home.Privacy();
            Assert.NotNull(output);
        }
    }
}
