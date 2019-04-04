using Moq;
using NUnit.Framework;
using UnitTestExample.Common;
using UnitTestExample.Tests.Common.Mocks;
using UnitTestingExample.Common;
using UnitTestingExample.Features.Math;

namespace UnitTestExample.Tests.Features.Math
{
    [TestFixture]
    public class ConvertFahrenheitToKelvenRequestTests
    {
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = LoggerMocks.GenerateBaseMock();
        }

        public ConvertFahrenheitToKelvenRequestHandler GenerateHandler =>
            new ConvertFahrenheitToKelvenRequestHandler(_loggerMock.Object);

        [TestCase(-459.67, 0)]
        [TestCase(100, 310.93)]
        [TestCase(1000, 810.93)]
        public void Handle_GivenAFahrenheitValue_ReturnsCorrectKelvinValue(double fahrenheit, double kelvin)
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = fahrenheit};
            var result = GenerateHandler.Handle(request);

            Assert.AreEqual(kelvin, result.Data);
        }

        [Test]
        public void Handle_GivenLowestValidFahrenheitValue_IsValidIsTrue()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.67};
            var result = GenerateHandler.Handle(request);

            Assert.AreEqual(true, result.IsValid);
        }

        [Test]
        public void Handle_GivenValueLessThanLowestValidFahrenheitValue_IsValidIsFalse()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.68};
            var result = GenerateHandler.Handle(request);

            Assert.AreEqual(false, result.IsValid);
        }

        [Test]
        public void Handle_GivenValueLessThanLowestValidFahrenheitValue_HasOneErrorMessage()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.68};
            var result = GenerateHandler.Handle(request);

            Assert.AreEqual(1, result.ErrorMessages.Count);
        }

        [Test]
        public void Handle_GivenValueLessThanLowestValidFahrenheitValue_ErrorMessageHasPropertyOfFahrenheit()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.68};
            var result = GenerateHandler.Handle(request);

            Assert.AreEqual("Fahrenheit", result.ErrorMessages[0].Property);
        }

        [Test]
        public void Handle_GivenValueLessThanLowestValidFahrenheitValue_ErrorMessageHasCorrectErrorMessage()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.68};
            var result = GenerateHandler.Handle(request);

            var expectedErrorMessage = ErrorMessages.CannotConvertFahrenheitToKelvin(-459.68);

            Assert.AreEqual(expectedErrorMessage, result.ErrorMessages[0].Message);
        }

        [Test]
        public void Handle_LoggerIsCalledWithCorrectValues()
        {
            _loggerMock.SetupLog();

            var request = new ConvertFahrenheitToKelvenRequest {Fahrenheit = -459.68};
            GenerateHandler.Handle(request);

            _loggerMock.VerifyLog(new object[] {request});
        }
    }
}
