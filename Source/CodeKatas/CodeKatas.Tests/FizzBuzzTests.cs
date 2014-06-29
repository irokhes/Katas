using System;
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
    }

    public class FizzBuzz
    {
        public string Answer(int number)
        {
            return number % 3 == 0 ? "Fizz" : number.ToString();
        }
    }
}
