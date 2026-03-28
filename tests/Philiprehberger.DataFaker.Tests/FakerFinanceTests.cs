using Xunit;
using Philiprehberger.DataFaker;

namespace Philiprehberger.DataFaker.Tests;

public class FakerFinanceTests
{
    [Fact]
    public void CreditCardNumber_Returns16Digits()
    {
        var cc = FakerFinance.CreditCardNumber();
        Assert.Equal(16, cc.Length);
        Assert.True(cc.All(char.IsDigit));
    }

    [Fact]
    public void CreditCardNumber_PassesLuhnCheck()
    {
        var cc = FakerFinance.CreditCardNumber();
        Assert.True(IsValidLuhn(cc), $"Credit card number {cc} failed Luhn check.");
    }

    [Fact]
    public void CreditCardNumber_StartsWithVisaOrMastercard()
    {
        var cc = FakerFinance.CreditCardNumber();
        Assert.True(cc[0] == '4' || cc[0] == '5',
            $"Expected Visa (4) or Mastercard (5) prefix, got '{cc[0]}'.");
    }

    [Fact]
    public void Iban_DefaultsToDeFormat()
    {
        var iban = FakerFinance.Iban();
        Assert.StartsWith("DE", iban);
        Assert.Equal(22, iban.Length); // DE + 2 check + 8 BLZ + 10 account
    }

    [Fact]
    public void Iban_GbFormatReturnsCorrectLength()
    {
        var iban = FakerFinance.Iban("GB");
        Assert.StartsWith("GB", iban);
        Assert.Equal(22, iban.Length); // GB + 2 check + 4 bank + 6 sort + 8 account
    }

    [Fact]
    public void BicSwift_Returns8Or11Characters()
    {
        var bic = FakerFinance.BicSwift();
        Assert.True(bic.Length == 8 || bic.Length == 11,
            $"BIC should be 8 or 11 chars, got {bic.Length}: {bic}");
    }

    [Fact]
    public void CurrencyCode_Returns3LetterCode()
    {
        var code = FakerFinance.CurrencyCode();
        Assert.Equal(3, code.Length);
        Assert.True(code.All(char.IsUpper));
    }

    [Fact]
    public void Amount_ReturnsValueInRange()
    {
        var amount = FakerFinance.Amount(10m, 100m);
        Assert.InRange(amount, 10m, 100m);
    }

    [Fact]
    public void Amount_RespectsDecimalPlaces()
    {
        var amount = FakerFinance.Amount(0m, 1000m, 3);
        var parts = amount.ToString().Split('.');
        if (parts.Length == 2)
        {
            Assert.True(parts[1].Length <= 3);
        }
    }

    private static bool IsValidLuhn(string number)
    {
        var sum = 0;
        var alternate = false;
        for (var i = number.Length - 1; i >= 0; i--)
        {
            var digit = number[i] - '0';
            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }
            sum += digit;
            alternate = !alternate;
        }
        return sum % 10 == 0;
    }
}
