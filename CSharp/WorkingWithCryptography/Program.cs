using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Security.Permissions;
using System.Security;
using System.Runtime.InteropServices;
namespace WorkingWithCryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crypthography is the study of techniques for secure information
            //CyptAnalysis studies the hidden aspects of information systems.
            //Encryption is the process to hidde a message or make it unreadable.
            //Decrypt is the process to get a original message from a encrypted message.

            //Encryption Types
            //  1. Symmetric Encryption. A key (like a password) is shared between the sender and receiver 
            //      1.1 AES AES (Advanced Encryption Standard) It has support for 128 - bit data and 128, 192, 256 - bit key.
            //      1.2 DES DES(Data Encryption Standard) published by National Institute Of Standard and Technology(NIST).
            //      1.3 RC2 RC2(Ron’s Code or Rivest Cipher) also known as ARC2 designed by Ron Rivest.
            //      1.4 Rijndael chosen by NSA as a Advanced Encryption Standard(AES).
            //      1.5 TripleDes also known as 3DES(Triple Data Encryption Standard) applies DES algorithm three times to each data block.
            //  2. Asymmetric Encryption. There are 2 keys (public key and private key). Only one has the private key. When a sender sends a message encrypted with the public key, only the private key can decrypt the message. When a message is encrypted with the private key everythig who has public key can decrypt the message, and when private key encrypt message the reciever knows who comes from the message (Authentication).
            //      2.1 RSA commonly used by modern computers.
            //      2.2 DSA (Digital Signature Algorithm), produced by NIST, is a standard to create digital signatures for data integrity.
            //      2.3 ECDsa (Elliptic Curve Digital Signature) offers variant of the DSA.
            //      2.4 ECDiffieHellman Provides a basic set of operations that ECDH implementations must support.

            // The Digital certificate associate a public key with a identity. A public key infrastructure (PKI) is a system of digital certificates, certificate authorities, and other registration authorities to verify and authenticate the validity of each involved party.
            // Some of the information that a certificate contains is: validity time of certification, public key, issuer of certification, subject which the certificate is issued. 
            // there are many types of certificates some of them are: 
            // 1. Secure Socket Layer. It can be a server that hosts a WebSite, a mail server, or any other type of server that needs to be authenticated, or that wants to send and receive encrypted data. 
            // 2. Code Signing Certificate. It is used to sign software that is downloaded over the Internet. 
            // 3. Client Certificate. It is used to identify one person to another


            //Hash code. it is an encryption fixed length code. The properties of hash code are:
            // 1.- you Can Not decrypt a hash code.
            // 2.- each stream has a unique hash code.
            // 3.- The length size of hash code is fixed, no matter the size length of stream


            // It is used to encrypt passwords that lay in a database, and because the hash code has a fixed length is also used to check the integrity of data
            // Hash code can be implemented with severals algorithms
            //  1.  SHA1  160 - bit length size.
            //  2.  SHA256 256 - bit length size.
            //  3.  SHA512 512 - bit length size.
            //  4.  SHA384 384 - bit length size.
            //  5.  RIPEMD(RACE Integrity Primitives Evaluation Message Digest) 160 similar in performance to SHA1.

            //Each time that you make a hash code from a message, the same hash code is returned.
            //Salt Hashing. It is a random Data that is added to the hash code to make it unique every time is generated

            //Choosing an appropriate Algorithm

            //1.When there is a scenario to deal with more sensitive data, you should use Asymmetric encryption instead of symmetric encryption.
            //2.When there is a scenario for data privacy, use Aes(Symmetric algorithm).
            //3.When there is a scenario for Data Integrity, use HMACSHA256 and HMACSHA512 hashing algorithms.
            //4.When there is a scenario for digital signing (Digital Signature), use ECDsa and RSA.
            //5.When there is a scenario to generate a random number, use RNGCryptoServiceProvider



            //SymmetricEncryptionMethod();
            //RSACryptoServiceProviderMethod();
            //ImplementKeyManagementMethod();

            //ReadingPrivateKeyFromContainer();
            //EncryptStreamMethod();
            //EncryptStreamMethod1();
            //ProtectedDataClassMethod();
            //Hashing();
            //SaltHashing();
            WorkingwithSecureStringClass();
            Console.ReadLine();

        }

        public static void SymmetricEncryptionMethod()
        {
            //using System.Security.Cryptography;

            //encrypting
            //1.- you need a message
            string message = "this is my secret message";
            //2.- make the message as a byte array
            byte[] streamMessage = Encoding.UTF8.GetBytes(message);
            //3.- create an algorithm, by default uses RijndaelManaged algorithm
            SymmetricAlgorithm symmetricAlgorithm = SymmetricAlgorithm.Create();
            //4.- create an encryptor with a key and a  Initial Vector (IV, it is optional) 
            ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            //5.- Get the encrypted message as byte array
            byte[] encryptedMessage = encryptor.TransformFinalBlock(streamMessage, 0, streamMessage.Length);

            string stringEncryptedMessage = Encoding.UTF8.GetString(encryptedMessage);
            Console.WriteLine("The encrypted message is: {0}", stringEncryptedMessage);

            //Decrypting
            //The algorithm and key for decryption must be the same while decrypting

            //1.Creating an algorithm
            SymmetricAlgorithm sa = SymmetricAlgorithm.Create();

            //2.creating a Decryptor THE KEY AND THE ALGORITHM MUST BE THE SAME THAT USED IN THE ENCRYPTION
            ICryptoTransform decryptor = sa.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

            //3. decrypt message, it returns a byte array
            byte[] decryptedMessage = decryptor.TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);

            //converting to string the message
            string DecryptedStringMessage = Encoding.UTF8.GetString(decryptedMessage);

            Console.WriteLine("The decrypted Message is: {0}", DecryptedStringMessage);


        }

        public static void RSACryptoServiceProviderMethod()
        {
            //CREATING KEYS
            //Creating an asymmetric algorithm object
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();

            //Saving the key information to RSAParametrer structure
            RSAParameters RSAKeyInfo = provider.ExportParameters(false);

            //generating keys
            string PublicKey = provider.ToXmlString(false);
            string PrivateKey = provider.ToXmlString(true);

            //The next show how to encrypt with a public key and decrypt with a private key
            //ENCRYPT
            //1.- have the message
            string message = "this is a secret messsage";

            //2.- convert the message into a byte array
            byte[] messageInBytes = Encoding.UTF8.GetBytes(message);

            //3.- create a RSACryptoServiceProvider Object...to encrypt in RSA
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            //4.- set the public key to the rsa object
            rsa.FromXmlString(PublicKey);

            //5._ encrypt the message. the second parameter is for padding, true just in windows XP s.o. or later
            byte[] encryptedMessageInBytes = rsa.Encrypt(messageInBytes, true);

            string encryptedMessage = Encoding.UTF8.GetString(encryptedMessageInBytes);

            Console.WriteLine("the encrypted message is: {0}", encryptedMessage);

            //DECRYPT

            //1.-create a RSACryptoServiceProvider object
            RSACryptoServiceProvider rsa1 = new RSACryptoServiceProvider();

            //2.-set the private key
            rsa1.FromXmlString(PrivateKey);

            //3.-decrypt the message
            byte[] decryptedMessageInBytes = rsa1.Decrypt(encryptedMessageInBytes, true);

            //getting the message in a string
            string decryptedMessage = Encoding.UTF8.GetString(decryptedMessageInBytes);

            Console.WriteLine("The decrypted Message is: {0}", decryptedMessage);







        }

        public static void ImplementKeyManagementMethod()
        {

            //Symmetric encryption
            //key management for symmetricEncryption

            SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create();
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            //In general, there is no reason to use this method, because CreateEncryptor() or CreateEncryptor(null, null) automatically generates both an initialization vector and a key.

            //Assymetric Encryption
            //To store the private key in a secute way, you can use a container, since it you can store, delete or read the private key

            //1.-Create the container.
            CspParameters container = new CspParameters();
            container.KeyContainerName = "myContainer";

            //2.- Create the algorithm object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(container);
            RSAParameters RSAKeyInfo = rsa.ExportParameters(false);

            //3.- Create the private key, and automatically save the private key
            string PrivateKey = rsa.ToXmlString(true);

            Console.WriteLine("private key is stored in the container {0}", PrivateKey);


        }

        public static void ReadingPrivateKeyFromContainer()
        {

            //create CspParameters
            CspParameters container = new CspParameters();
            //set the same container name which stores the private key
            container.KeyContainerName = "myContainer";

            //create RSACryptServiceProvider, and enter as argument th CspParameters object
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(container);

            //get the key
            string PrivateKey = rsa.ToXmlString(true);

            Console.WriteLine("PrivateKey: {0}", PrivateKey);

        }

        public static void DeletingPrivateKeyFromContainer()
        {
            CspParameters container = new CspParameters();
            container.KeyContainerName = "myContainer";

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(container);
            RSAParameters rsakeyinfo = rsa.ExportParameters(false);

            rsa.PersistKeyInCsp = false;
            rsa.Clear();

            Console.WriteLine("The private key has been deleted from the container");


        }

        public static void EncryptStreamMethod()
        {
            string message = "this is a secret message";
            byte[] encryptedMessageInBytes;
            SymmetricAlgorithm symmetric = SymmetricAlgorithm.Create();
            ICryptoTransform encryptor = symmetric.CreateEncryptor(symmetric.Key, symmetric.IV);
            //encrypting stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                    }

                }
                encryptedMessageInBytes = memoryStream.ToArray();
                Console.WriteLine("the encrypted message is: {0}", Encoding.UTF8.GetString(encryptedMessageInBytes));
            }

            //decrypting stream
            SymmetricAlgorithm sa = SymmetricAlgorithm.Create();
            ICryptoTransform decryptor = symmetric.CreateDecryptor(symmetric.Key, symmetric.IV);
            byte[] bytesToRead;

            using (MemoryStream memoryStream = new MemoryStream(encryptedMessageInBytes))
            {
                using (CryptoStream cs = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        Console.WriteLine("The decrypted Message is {0}", sr.ReadToEnd());
                    }
                }

            }

        }

        public static void EncryptStreamMethod1()
        {
            string message = "this is my secret message";
            SymmetricAlgorithm sa = SymmetricAlgorithm.Create();
            ICryptoTransform encriptor = sa.CreateEncryptor(sa.Key, sa.IV);
            byte[] bytesToRead;
            //Encrypt an stream
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encriptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                    }
                    bytesToRead = ms.ToArray();
                    Console.WriteLine("the encrypted message is {0}", Encoding.UTF8.GetString(bytesToRead));
                }
            }

            //Decrypt a stream
            SymmetricAlgorithm sa1 = SymmetricAlgorithm.Create();
            ICryptoTransform decryptor = sa1.CreateDecryptor(sa.Key, sa.IV);
            string decryptedMessage;
            using (MemoryStream ms1 = new MemoryStream(bytesToRead))
            {
                using (CryptoStream cs1 = new CryptoStream(ms1, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs1))
                    {
                        decryptedMessage = sr.ReadToEnd();
                    }

                    Console.WriteLine(decryptedMessage);
                }
            }
        }

        public static void ProtectedDataClassMethod()
        {
            //A way to encrypt data without configure an algorithm and other configurations is with ProtectedData class
            //System.Security.Cryptography namespace
            //System.Security assembly

            //1. you need a data
            string message = "this is my secret message";

            //2. convert the data in a byte array
            byte[] messageInBytes = Encoding.UTF8.GetBytes(message);

            //3. Use the static method Protect of ProtectedData Class
            byte[] EncryptedMessageInBytes = ProtectedData.Protect(messageInBytes, null, DataProtectionScope.CurrentUser);

            Console.WriteLine("The encrypted message is {0}", Encoding.UTF8.GetString(EncryptedMessageInBytes));

            //DECRYPTING

            byte[] decryptedMessage = ProtectedData.Unprotect(EncryptedMessageInBytes, null, DataProtectionScope.CurrentUser);

            Console.WriteLine("the decrypted message is {0}", Encoding.UTF8.GetString(decryptedMessage));

        }

        public static void DigitalCertificates()
        {
            //A digital certification uses hashing and asymmetric encryption to authenticate the identity of the owner(signed object) to others.
            //Create and Install Certificate
            //this example use Makecert.exe to create a certificate

            //i)  Run Command Prompt as Administrator.
            //ii) To create a digital certificate, enter the following command: makecert {Certificate_Name}.cer
            //iii)makecert myCertificate.cer

            //the certificate has been created so far, in order to use it, it must be installed in your machine. 
            //the place where it is stored after installation is the Certificate Store.

            //Installing the certificate

            //i)  Run Command Prompt as Administrator.
            //ii) To create a digital certificate, enter the following command: makecert { Certificate_Name}.cer makecert - n "CN=myCert" - sr currentuser - ss myCertStore

            //the last command create and install the certificate

        }

        public static void CodeAccessSecurity()
        {
            //System.Security.Permissions provides Code Access Security(CAS), which protects your computer from malicious code.
            //The.NET Framework provides a mechanism for the enforcement of varying levels of trust on different code running in the same application called Code Access Security(CAS). Code Access Security in .NET Framework should NOT be used as a mechanism for enforcing security boundaries based on code origination or other identity aspects.
            //there are 2 ways to specify CAS

            //1. Declarative

            //    [FileIOPermission(SecurityAction.Demand,
            //    AllLocalFiles = FileIOPermissionAccess.Read)]
            //public static void DeclarativeMethod()
            //{

            //}

            //2. Imperative
            FileIOPermission fp = new FileIOPermission(PermissionState.None);
            fp.AllLocalFiles = FileIOPermissionAccess.Read;
            fp.Demand();

    }
        [FileIOPermission(SecurityAction.Demand,
            AllLocalFiles = FileIOPermissionAccess.Read)]
        public static void DeclarativeMethod()
        {

        }

        public static void Hashing()
        {
            //System.Security.Cryptography

            //1. you need a message to encrypt
            string message = "this is a password";

            //2. Convert the message in a byte array
            byte[] MessageInBytes = Encoding.UTF8.GetBytes(message);

            //3. create an algorithm
            HashAlgorithm hashAlgorithm = SHA512.Create();

            byte[] HashCode = hashAlgorithm.ComputeHash(MessageInBytes);



            StringBuilder stringHashCode = new StringBuilder();

            foreach(byte i in HashCode)
            {
                stringHashCode.Append(i);
            }

            Console.WriteLine("The hash code is {0}", stringHashCode.ToString());

        }

        public static void SaltHashing()
        {
            string password = "this is a password";

            Guid salt = Guid.NewGuid();

            string PassWithRandonSalt = password + salt;

            byte[] ranPassInBytes = Encoding.UTF8.GetBytes(PassWithRandonSalt);

            HashAlgorithm sha512 = SHA512.Create();

            byte[] PasswordHashed = sha512.ComputeHash(ranPassInBytes);

            StringBuilder PasswordHashedString = new StringBuilder();

            foreach(var b in PasswordHashed)
            {
                PasswordHashedString.Append(b);

            }
            Console.WriteLine("the password hashed is {0}",PasswordHashedString.ToString());
            //to return the original hashcode use GetHashCode()
            Console.WriteLine("the hashcode is {0}", PasswordHashedString.GetHashCode());
        }

        public static void WorkingwithSecureStringClass()
        {
            //System.Security namespace.
            //when you work with sensitive data, like passwords.. and you use string type to store them
            //you are in risk because is a inmutable data in plain text
            //you can use SecureString Class to make more secure data, due to this class encrypt data automatically, is stored is a especific location, is mutable and is a disposable class
            SecureString secureString = new SecureString();
            Console.WriteLine("Write the password: ");
            while (true)
            {
                var keyEntered = Console.ReadKey(true);
                if (keyEntered.Key == ConsoleKey.Enter)
                    break;
                secureString.AppendChar(keyEntered.KeyChar);
                Console.Write("*");
            }
            secureString.MakeReadOnly();


            //Reading the SecureString
            //System.Runtime.InteropServices namespace

            IntPtr plainTextAsIntPtr = IntPtr.Zero;

            //use try catch to control in case secureString has been disposed.
            try
            {
                //decrypt data as IntPtr
                plainTextAsIntPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                //convert pointer to string
                Marshal.PtrToStringUni(plainTextAsIntPtr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //clear the decrypted string from memory
                Marshal.ZeroFreeGlobalAllocUnicode(plainTextAsIntPtr);
            }


            secureString.Dispose();
            
        }

    }
}
