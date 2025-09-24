using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexLeeTakeHomeConsole;

public class UtilityLibrary
{
	/// <summary>
	/// Question 1: Write a function that takes two strings as input and returns a new string that interleaves the characters of the two input strings.
	/// </summary>
	public static string InterleaveStrings(string s1, string s2)
	{
		//We are assuming that the inputs are not the same size and will just interleave the rest of the strings
		//If that were not the case, we would uncomment the following code
		/*
		if (s1.Length != s2.Length)
		{
			throw new ArgumentException("Strings must be the same length");
		}
		*/


		//Never build string using regular strings because they are immutable
		//We set the initial capacity if the string builder to the sum of the lengths of both strings to avoid resizing
		var stringBuilder = new StringBuilder(s1.Length + s2.Length);
		int index = 0;
		for (; index < s1.Length; index++)
		{
			stringBuilder.Append(s1[index]);
			if (index < s2.Length)
			{
				stringBuilder.Append(s2[index]);
			}
		}

		for(; index < s2.Length; index++)
		{
			stringBuilder.Append(s2[index]);
		}

		return stringBuilder.ToString();
	}

	/// <summary>
	/// Question 2: Write a function that takes a string as input and returns whether the string is a palindrome
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public static string GetIsPalendromeDisplayName(string input)
	{
		return IsPalendrome(input) ? "Palindrome" : "Not Palindrome";
	}

	public static bool IsPalendrome(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return true;
		}

		int left = 0;
		int right = input.Length - 1;
		while (left < right)
		{
			if (input[left] != input[right])
			{
				return false;
			}
			left++;
			right--;
		}

		return true;
	}
}