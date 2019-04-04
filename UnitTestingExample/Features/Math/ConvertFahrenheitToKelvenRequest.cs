using UnitTestExample.Common;
using UnitTestingExample.Common;

namespace UnitTestingExample.Features.Math
{
    public class ConvertFahrenheitToKelvenRequest
    {
        public double Fahrenheit { get; set; }
    }

    public class ConvertFahrenheitToKelvenRequestHandler
    {
        private readonly ILogger _logger;

        public ConvertFahrenheitToKelvenRequestHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Response<double> Handle(ConvertFahrenheitToKelvenRequest request)
        {
            _logger.Log(request);

            var response = new Response<double>();

            if (request.Fahrenheit < Constants.LowestLegalKelvinValueInFahrenheit)
            {
                response.IsValid = false;
                response.ErrorMessages.Add(new ErrorMessage
                {
                    Property = nameof(request.Fahrenheit),
                    Message = ErrorMessages.CannotConvertFahrenheitToKelvin(request.Fahrenheit)
                });
            }

            var exactValue = (request.Fahrenheit - 32) * (5.0 / 9.0) + 273.15;
            var roundedValue = System.Math.Round(exactValue, 2);

            response.Data = roundedValue;

            return response;
        }
    }
}