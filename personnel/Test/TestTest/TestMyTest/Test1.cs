using TestTest;

namespace TestMyTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestThatSumOfTenAndTenIsTwenty()
        {
            //Arrange
            int x = 10;
            int y = 10;
            int z = -15;

            //Act
            int res = MyMath.Ss(x, y);
            int res2 = MyMath.Ss(x, z);

            //Assert
            Assert.AreEqual(20, res);
            Assert.AreEqual(-5, res2);
        }
    }
}
