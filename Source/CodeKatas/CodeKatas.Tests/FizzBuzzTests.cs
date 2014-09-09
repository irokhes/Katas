using NUnit.Framework;


namespace CodeKatas.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void When_getting_divisible_by_3()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(3);

            //Assert
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_getting_divisible_by_5()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(5);

            //Assert
            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void When_getting_number_divisible_by_3_and_5()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(15);

            //Assert
            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void When_getting_a_number_containing_a_3()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(13);

            //Assert
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_getting_a_number_containing_a_3_and_5()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz();

            //Act
            var result = fizzBuzz.Answer(53);

            //Assert
            Assert.AreEqual("FizzBuzz", result);
        }
    }
}
