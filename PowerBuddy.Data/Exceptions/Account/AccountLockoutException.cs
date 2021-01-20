using System;

namespace PowerBuddy.Data.Exceptions.Account
{
	public class AccountLockoutException : Exception
	{
		public AccountLockoutException() : base("Your account is currently locked. Please try again in 10 minutes")
		{

		}

		public AccountLockoutException(string message) : base(message)
		{

		}
	}
}
