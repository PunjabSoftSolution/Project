using NumberToWords.Core.Interfaces;
using NumberToWords.Core.Utility;

namespace NumberToWords.Core.Repository
{
    public class ManageNumberRepository : IManageNumberRepository
    {
        public string ConvertToWords(int number)
        {
            return ConvertNumberToText(number);
        }

        private static string ConvertNumberToText(int num)
        {
            string tempString = "";
            int thousands;
            int temp;
            string result = "";
            if (num < 0 || num > 100000)
            {
                return result;
            }
            if (num == 0)
            {
                return result;
            }

            if (num < 1000)

            {
                HelperConvertNumberToText(num, out tempString);

                result += tempString;
            }
            else

            {
                thousands = num / 1000;

                temp = num - thousands * 1000;

                HelperConvertNumberToText(thousands, out tempString);

                result += tempString;

                result += Constants.THOUSAND + " ";

                HelperConvertNumberToText(temp, out tempString);

                result += tempString;
            }

            return result;
        }

        private static bool HelperConvertNumberToText(int num, out string buf)

        {
            string result = "";
            buf = "";
            int single, tens, hundreds;
            if (num > 1000)
                return false;
            hundreds = num / 100;
            num = num - hundreds * 100;
            if (num < 20)
            {
                tens = 0; // special case
                single = num;
            }
            else
            {
                tens = num / 10;
                num = num - tens * 10;
                single = num;
            }

            result = "";
            if (hundreds > 0)
            {
                result += (EBasicCounting)hundreds;
                result += " " + Constants.HUNDRED + " ";
            }

            if (tens > 0)
            {
                result += (ETens)tens;
                result += " ";
            }
            if (single > 0)
            {
                result += (EBasicCounting)single;
                result += " ";
            }
            buf = result;
            return true;
        }
    }
}