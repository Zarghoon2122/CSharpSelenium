namespace SeleniumTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Set Up Method Execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test 1");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test 2");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Close window");
        }
    }
}