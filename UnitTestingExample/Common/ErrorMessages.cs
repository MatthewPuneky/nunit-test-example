namespace UnitTestExample.Common
{
    public class ErrorMessages
    {
        public static string CannotConvertFahrenheitToKelvin(double fahrenheit)
        {
            return $"The value of {fahrenheit} Fahrenheit cannot be converted into Kelvin.";
        }
    }
}
