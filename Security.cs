//-----------------------------------------------------------------------
// 
//      Author: Abdelhalim EL HADI (elhadi.abdelhalim@gmail.com)
//      OrgAE Tools
//      Copyright (c) Abdelhalim EL HADI. All rights reserved.
//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License v3.0 as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU General Public License for more details.
//      You should have received a copy of the GNU General Public License
//      along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrgAE.Tools
{
    /// <summary>
    /// A set of Security methods to facilitate development and don't repeat your self.
    /// </summary>
    public static class Security
    {
        
        /// <summary>
        /// 
        /// </summary>
        public const string strPermutation = "93Fo33u5ive6825yxaqtdAdsJHGsdieobceYTREDVhs,jHVJGGhkl";
        /// <summary>
        /// 
        /// </summary>
        public const Int32 bytePermutation1 = 0x19;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 bytePermutation2 = 0x59;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 bytePermutation3 = 0x17;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 bytePermutation4 = 0x41;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        internal static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation, new byte[] { bytePermutation1, bytePermutation2, bytePermutation3, bytePermutation4});

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        internal static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes = new PasswordDeriveBytes(strPermutation, new byte[] { bytePermutation1, bytePermutation2, bytePermutation3, bytePermutation4});

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string Encrypt(string strData)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
            
        }
    }
}
