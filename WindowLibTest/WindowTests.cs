using Windowlib;

namespace WindowLibTest
{
    [TestClass]
    public class WindowTests
    {
        [DataRow('A')]
        [DataRow('B')]
        [DataRow('C')]
        [TestMethod]
        public void EnergyClass_Should_Set_Value_To_A_B_or_C(char expectedEnergyClass)
        {
            // Arrange
            Window testWindow = new Window();

            // Act
            testWindow.EnergyClass = expectedEnergyClass;

            // Assert
            Assert.AreEqual(expectedEnergyClass, testWindow.EnergyClass);
        }
        [DataRow('D')]
        [DataRow('E')]
        [DataRow('F')]
        [DataRow('Z')]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnergyClass_Should_Throw_ArgumentException(char expectedEnergyClass)
        {
            // Arrange
            Window testWindow = new Window();

            // Act
            testWindow.EnergyClass = expectedEnergyClass;

            // Assert
            // Fanget af exception
        }

        [TestMethod]
        public void EnergyClass_Should_Return_Value()
        {
            // Arrange
            Window testWindow = new Window("Test Model", 'A', 0);

            // Act
            char resultEnergyClass = testWindow.EnergyClass;

            // Assert
            Assert.AreEqual(resultEnergyClass, testWindow.EnergyClass);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(3)]
        [TestMethod]
        public void Price_Should_Set_Positive_Value(int expectedPrice)
        {
            // Arrange
            Window testWindow = new Window();

            // Act
            testWindow.Price = expectedPrice;

            // Assert
            Assert.AreEqual(expectedPrice, testWindow.Price);
        }


        [DataRow(-1)]
        [DataRow(-2)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Price_Should_Throw_ArgumentException(int expectedPrice)
        {
            // Arrange
            Window testWindow = new Window();

            // Act
            testWindow.Price = expectedPrice;

            // Assert
            // Fanget af exception
        }

        [TestMethod]
        public void Price_Should_Return_Value()
        {
            // Arrange
            Window testWindow = new Window("Test Model", 'A', 100);

            // Act
            int resultPrice = testWindow.Price;

            // Assert
            Assert.AreEqual(resultPrice, testWindow.Price);
        }
    }
}
