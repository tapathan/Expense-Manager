using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExMon
{
    class EncryptDecrypt
    {
        int StEncryptBy = 0, StDecryptBy = 0;
        int EncryptBy;
        char[] EncryptDecryptStr = new char[50];
        Random RandomNoTemp = new Random(100);

        public EncryptDecrypt(char[] EDS, int I)
        {
            this.EncryptDecryptStr = EDS;
            this.EncryptBy = I;
        }

        public EncryptDecrypt(char[] EDS)
        {
            this.EncryptDecryptStr = EDS;
            this.EncryptBy = StEncryptBy;
        }

        public string Encrypt()
        {
            char[] Alpha = new char[26];
            Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int Counter = EncryptDecryptStr.Length - 1, RandomNo;
            string Encrypted = "";
            char EncryptedChar = '\0';
            StEncryptBy = 5;
            Encrypted = Encrypted + EncryptChar(EncryptDecryptStr[Counter - Counter + 2]);
            RandomNo = RandomNoTemp.Next(1, 25);
            Encrypted = Encrypted + EncryptChar(Alpha[RandomNo]);
            while (Counter >= 0)
            {
                EncryptedChar = EncryptChar(EncryptDecryptStr[Counter], EncryptBy);
                Encrypted = Encrypted + EncryptedChar;
                RandomNo = RandomNoTemp.Next(1, 25);
                Encrypted = Encrypted + EncryptChar(Alpha[RandomNo]);
                Counter--;
            }
            RandomNo = RandomNoTemp.Next(1, 25);
            Encrypted = Encrypted + EncryptChar(Alpha[RandomNo]);
            return (Encrypted);
        }

        public string Decrypt()
        {
            char[] Alpha = new char[26];
            Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int Counter = EncryptDecryptStr.Length - 1;
            string Decrypted = "";
            char DecryptedChar = '\0';
            Counter = Counter - 2;
            while (Counter >= 2)
            {
                DecryptedChar = DecryptChar(EncryptDecryptStr[Counter], 3);
                Decrypted = Decrypted + DecryptedChar;
                Counter--;
                Counter--;
            }
            return (Decrypted);
        }

        private char EncryptChar(char A, int EncryptBy)
        {
            char[] AlphaNum = new char[62];
            AlphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int AlphaCounter = 0;
            while (AlphaCounter < AlphaNum.Length)
            {
                if (A == AlphaNum[AlphaCounter])
                {
                    StEncryptBy = AlphaCounter;
                    AlphaCounter = (AlphaCounter + EncryptBy) % 62;
                    break;
                }
                AlphaCounter++;
            }
            return (AlphaNum[AlphaCounter]);
        }

        private char EncryptChar(char A)
        {
            char[] AlphaNum = new char[62];
            AlphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int AlphaCounter = 0;
            while (AlphaCounter < AlphaNum.Length)
            {
                if (A == AlphaNum[AlphaCounter])
                {
                    AlphaCounter = (AlphaCounter + StEncryptBy) % 62;
                    StEncryptBy = AlphaCounter;
                    break;
                }
                AlphaCounter++;
            }
            return (AlphaNum[AlphaCounter]);
        }

        private char DecryptChar(char A, int DecryptBy)
        {
            char[] AlphaNum = new char[62];
            AlphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int AlphaCounter = 0;
            while (AlphaCounter < AlphaNum.Length)
            {
                if (A == AlphaNum[AlphaCounter])
                {
                    AlphaCounter = AlphaCounter - DecryptBy;
                    if (AlphaCounter < 0)
                        AlphaCounter = AlphaCounter + 62;
                    break;
                }
                AlphaCounter++;
            }
            return (AlphaNum[AlphaCounter]);
        }
    }
}
