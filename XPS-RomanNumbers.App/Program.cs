// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using XPS_RomanNumbers.Logic;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IRomanNumeralConverter, RomanNumeralConverter>() // Register the converter
    .BuildServiceProvider();
var converter = serviceProvider.GetRequiredService<IRomanNumeralConverter>();

while (true)
{
    Console.Write("Enter a integer number to convert to Roman numerals, enter q to exit: ");
    var input = Console.ReadLine();

    if (input?.ToLower() == "q")
        break;

    if (int.TryParse(input, out var number))
    {
        try
        {
            var romanNumeral = converter.ConvertToRomanNumeral(number);
            Console.WriteLine("The Roman numeral is: {0}", romanNumeral);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Invalid entry: {0}", ex.Message);
        }
    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid integer.");
    }
}