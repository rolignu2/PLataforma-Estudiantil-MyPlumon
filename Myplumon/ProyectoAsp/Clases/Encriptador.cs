using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ProyectoAsp.Clases
{
    class Encriptador
    {

        private static string clave = "RSOF20111890WIN323590A";

        public static string encriptar(string cadena)
        {
            

            try
            {
                byte[] cadenaBytes = Encoding.UTF8.GetBytes(cadena);
                byte[] claveBytes = Encoding.UTF8.GetBytes(clave);

                RijndaelManaged rij = new RijndaelManaged();
                rij.Mode = CipherMode.ECB;
                rij.BlockSize = 256;
                rij.Padding = PaddingMode.Zeros;
                ICryptoTransform encriptador;
                encriptador = rij.CreateEncryptor(claveBytes, rij.IV);
                MemoryStream memStream = new MemoryStream();
                CryptoStream cifradoStream;
                cifradoStream = new CryptoStream(memStream, encriptador,
                CryptoStreamMode.Write);
                cifradoStream.Write(cadenaBytes, 0, cadenaBytes.Length);
                cifradoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memStream.ToArray();
                memStream.Close();
                cifradoStream.Close();
                return Convert.ToBase64String(cipherTextBytes);
            }
            catch
            {
                Console.WriteLine("longitud de la cadena es demaciado extensa par auna encriptacion de 256 bits");
                Console.ReadLine();
            }

            return "ERROR";
        }

        public static string desencriptar(string cadena)
        {
            
            byte[] cadenaBytes = Convert.FromBase64String(cadena);
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            RijndaelManaged rij = new RijndaelManaged();
            rij.Mode = CipherMode.ECB;
            rij.BlockSize = 256;
            rij.Padding = PaddingMode.Zeros;
            ICryptoTransform desencriptador;
            desencriptador = rij.CreateDecryptor(claveBytes, rij.IV);
            MemoryStream memStream = new MemoryStream(cadenaBytes);
            CryptoStream cifradoStream;
            cifradoStream = new CryptoStream(memStream, desencriptador,
            CryptoStreamMode.Read);
            StreamReader lectorStream = new StreamReader(cifradoStream);
            string resultado = lectorStream.ReadToEnd();
            memStream.Close();
            cifradoStream.Close();
            return resultado;
        }


        #region Encriptar
        /// <summary>
        /// Método para encriptar un texto plano usando el algoritmo (Rijndael).
        /// Este es el mas simple posible, muchos de los datos necesarios los
        /// definimos como constantes.
        /// </summary>
        /// <param name="textoQueEncriptaremos">texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public static string Encriptar_Md5(string textoQueEncriptaremos)
        {
            return Encriptar_Md5(textoQueEncriptaremos,
              "pass75dc@avz10", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }
        /// <summary>
        /// Método para encriptar un texto plano usando el algoritmo (Rijndael)
        /// </summary>
        /// <returns>Texto encriptado</returns>
        public static string Encriptar_Md5(string textoQueEncriptaremos,
          string passBase, string saltValue, string hashAlgorithm,
          int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
             CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
        #endregion
        #region Desencriptar
        /// <summary>
        /// Método para desencriptar un texto encriptado.
        /// </summary>
        /// <returns>Texto desencriptado</returns>
        public static string Desencriptar_Md5(string textoEncriptado)
        {
            return Desencriptar_Md5(textoEncriptado, "pass75dc@avz10", "s@lAvz", "MD5",
              1, "@1B2c3D4e5F6g7H8", 128);
        }
        /// <summary>
        /// Método para desencriptar un texto encriptado (Rijndael)
        /// </summary>
        /// <returns>Texto desencriptado</returns>
        public static string Desencriptar_Md5(string textoEncriptado, string passBase,
          string saltValue, string hashAlgorithm, int passwordIterations,
          string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
              CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
              plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
              decryptedByteCount);
            return plainText;
        }
        #endregion

    }
}
