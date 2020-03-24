using System;
using Org.BouncyCastle;
using System.Security.Cryptography;
using System.Text;

namespace PowerLifting.Cypto
{
    public sealed class PasswordHandler
    {
        private static readonly Lazy<PasswordHandler> lazy = new Lazy<PasswordHandler>(() => new PasswordHandler());

        public static PasswordHandler Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private PasswordHandler()
        {

        }
        /// <summary>
        /// Used to create a SHA512 + Salt Password.
        /// Always uses a salt byte length of 24
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <returns>The encrypted newly created password</returns>
        public string ComputeHash(string password)
        {
            Byte[] saltBytes = new byte[24];
            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Initialize appropriate hashing algorithm class.:
            HashAlgorithm sha521 = new SHA512Managed();

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = sha521.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public bool VerifyHash(string plainText, string hashValue)
        {
            //Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            //We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            //Make sure that hashing algorithm name is specified.

            HashAlgorithm sha521 = new SHA512Managed();
            hashSizeInBits = 512;

            //Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            //Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            //Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
}
