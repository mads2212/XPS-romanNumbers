namespace XPS_RomanNumbers.Logic;

public class RomanNumeralConverter : IRomanNumeralConverter
{
    //A dictionary with all the roman numeral units plus numerals that used for the subtractions  
    //From the biggest to the smaller cause Roman Numerals are written like that 
    private static readonly Dictionary<int, string> NumbersDictionary = new()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public string ConvertToRomanNumeral(int numberToBeConverted)
    {
        if (numberToBeConverted is <= 0 or > 2000)
            throw new ArgumentOutOfRangeException(nameof(numberToBeConverted),
                "The number provided must be between 1 and 2000.");

        /* When a number to be converted is bigger or the same as the key
        I calculate what's left from the number and repeat the process
        And add to the final roman numeral
        Example:
        46 -> Loop once until 46 > 40 (XL) -> add XL to the numeral, 6 left
        6 -> Loop again until 6 > 5 (V) -> add V to the numeral, 1 left
        1 -> Loop again until 1 >= 1 (I) -> add I to the numeral
        0 -> Loop again until 0 > 1 (I) -> add I to the numeral */

        var romanNumeral = string.Empty;
        foreach (var numeral in NumbersDictionary)
        {
            while (numberToBeConverted >= numeral.Key)
            {
                numberToBeConverted -= numeral.Key;
                romanNumeral += numeral.Value;
            }
        }

        return romanNumeral;
    }
}