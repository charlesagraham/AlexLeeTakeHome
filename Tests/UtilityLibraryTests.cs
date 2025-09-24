using AlexLeeTakeHomeConsole;

namespace Tests;

public class UtilityLibraryTests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void InterleaveStrings_abc_123_returns_a1b2c3()
	{
		var result = UtilityLibrary.InterleaveStrings("abc", "123");

		Assert.That(result, Is.EqualTo("a1b2c3"));
	}

	[Test]
	public void InterleaveStrings_abcd_123_returns_a1b2c3d()
	{
		var result = UtilityLibrary.InterleaveStrings("abcd", "123");

		Assert.That(result, Is.EqualTo("a1b2c3d"));
	}

	[Test]
	public void InterleaveStrings_abc_1234_returns_a1b2c34()
	{
		var result = UtilityLibrary.InterleaveStrings("abc", "1234");

		Assert.That(result, Is.EqualTo("a1b2c34"));
	}

	[Test]
	public void GetIsPalendromeDisplayName_madam_Returns_Palindrome()
	{
		var result = UtilityLibrary.GetIsPalendromeDisplayName("madam");

		Assert.That(result, Is.EqualTo("Palindrome"));
	}

	[Test]
	public void GetIsPalendromeDisplayName_step_on_no_pets_Returns_Palindrome()
	{
		var result = UtilityLibrary.GetIsPalendromeDisplayName("step on no pets");

		Assert.That(result, Is.EqualTo("Palindrome"));
	}

	[Test]
	public void GetIsPalendromeDisplayName_book_Returns_Not_Palindrome()
	{
		var result = UtilityLibrary.GetIsPalendromeDisplayName("book");

		Assert.That(result, Is.EqualTo("Not Palindrome"));
	}

	[Test]
	public void GetIsPalendromeDisplayName_1221_Returns_Palindrome()
	{
		var result = UtilityLibrary.GetIsPalendromeDisplayName("1221");

		Assert.That(result, Is.EqualTo("Palindrome"));
	}

	[Test]
	public void GetIsPalendromeDisplayName_12345_Returns_Not_Palindrome()
	{
		var result = UtilityLibrary.GetIsPalendromeDisplayName("12345");

		Assert.That(result, Is.EqualTo("Not Palindrome"));
	}
}
