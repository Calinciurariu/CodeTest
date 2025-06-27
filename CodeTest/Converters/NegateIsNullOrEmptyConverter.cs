using System.Globalization;

namespace CodeTest.Converters
{
    public class NegateIsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture)
        {
            return !(pValue == null || (pValue is string str && string.IsNullOrWhiteSpace(str)));
        }

        public object ConvertBack(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture)
                => throw new NotImplementedException();
    }
}
