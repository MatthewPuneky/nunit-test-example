using Moq;
using UnitTestingExample.Common;

namespace UnitTestExample.Tests.Common.Mocks
{
    public static class LoggerMocks
    {
        public static Mock<ILogger> GenerateBaseMock()
        {
            return new Mock<ILogger>();
        }

        public static Mock<ILogger> SetupLog(this Mock<ILogger> mock)
        {
            mock.Setup(x => x.Log(It.IsAny<object[]>()));
            return mock;
        }

        public static void VerifyLog(
            this Mock<ILogger> mock,
            object[] expectedToBeCalledWith)
        {
            foreach (var item in expectedToBeCalledWith)
            {
                mock.Verify(x => x.Log(It.Is<object>(o => o == item)), Times.Once);
            }
        }
    }
}
