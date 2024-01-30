using Microsoft.Extensions.DependencyInjection;
using XPS_RomanNumbers.Logic;

namespace XPS_RomanNumbers.Tests;

public class RomanNumeralConverterTests
{

    private readonly IRomanNumeralConverter _romanNumeralConverter;
    
    public RomanNumeralConverterTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IRomanNumeralConverter>(_ => new RomanNumeralConverter());
        var serviceProvider = serviceCollection.BuildServiceProvider();
        _romanNumeralConverter = serviceProvider.GetRequiredService<IRomanNumeralConverter>();
    }

    [Test]
    public void ConvertToRomanNumeral_Returns_One()
    {
        Assert.AreEqual("I", _romanNumeralConverter.ConvertToRomanNumeral(1), "1 should be I");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Returns_Two()
    {
        Assert.AreEqual("II", _romanNumeralConverter.ConvertToRomanNumeral(2), "2 should be II");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Returns_Three()
    {
        Assert.AreEqual("III", _romanNumeralConverter.ConvertToRomanNumeral(3), "3 should be III");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Returns_Forty()
    {
        Assert.AreEqual("XL", _romanNumeralConverter.ConvertToRomanNumeral(40), "40 should be XL");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Returns_Forty_Seven()
    {
        Assert.AreEqual("XLVII", _romanNumeralConverter.ConvertToRomanNumeral(47), "47 should be XLVII");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Returns_One_Hundred_Sixty_Eight()
    {
        Assert.AreEqual("CLXVIII", _romanNumeralConverter.ConvertToRomanNumeral(168), "168 should be CLXVIII");
    }
    
    [Test]
    public void ConvertToRomanNumeral_Throws_Exception_For_Bigger_Than_200_Value()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _romanNumeralConverter.ConvertToRomanNumeral(2001));
    }
    
    [Test]
    public void ConvertToRomanNumeral_Throws_Exception_For_Zero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _romanNumeralConverter.ConvertToRomanNumeral(0));
    }
    
    [Test]
    public void ConvertToRomanNumeral_Throws_Exception_For_Negative_Number()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _romanNumeralConverter.ConvertToRomanNumeral(-1));
    }

}