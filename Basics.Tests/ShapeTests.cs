using InterfaceExample;

namespace Basics.Tests
{
    [TestClass]
    public sealed class ShapeTests
    {
        [TestMethod]
        public void Test_CircleArea_CorrectCalculation()
        {
            // Arrange
            double radius = 10;
            //double expectedArea = Math.PI * 100;
            double expectedArea = 3.14 * 100;
            IShape circle = new Circle(radius);

            // Act
            double actualArea = circle.CalculateArea();

            // Assert
            // The last parameter (0.001) is the allowed delta/precision
            Assert.AreEqual(expectedArea, actualArea, 0.001, "Circle area calculation is incorrect.");
        }

        [TestMethod]
        public void Test_RectangleArea_CorrectCalculation()
        {
            // Arrange
            double length = 5;
            double width = 4;
            double expectedArea = 20;
            IShape rectangle = new Rectangle(length, width);

            // Act
            double actualArea = rectangle.CalculateArea();

            // Assert
            Assert.AreEqual(expectedArea, actualArea, 0.001, "Rectangle area calculation is incorrect.");
        }
    }
}
