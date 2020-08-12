//Code for Caesar Cipher Substitution Algorithm
//Method: Replace each letter in plaintext with a Shifted letter in the alphabet used.
//USage: From Main program, user selects encryption method, enters file to encrypt

namespace EncryptionAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;

    public class Caesar
    {
        readonly int eKey;
        Char[] alphabet;


        #region Constructor
        public Caesar(int eKey)
        {
            this.eKey = eKey;
        }
        #endregion

        #region Private Methods

        private Char[] encrypt(Char[] buff)
        {
            //instantiate our alphabet
            alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            //for each character in buffer
            foreach (char c in buff)
            {
                c = Char.ToUpper(c);
                //shift the # of places set by Key
                c = Array.GetValue(26 % (Array.IndexOf(alphabet, c) + eKey));
            }
            //return updated buffer
            return buff;
        }

        private Char[] decrypt(Char[] buff)
        {
                        //instantiate our alphabet
            alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            //for each character in buffer
            foreach (char c in buff)
            {
                c = Char.ToUpper(c);
                //shift in reverse the # of places set by key
                index = Array.getValue(alphabet, c);
                index = (index + 26 - eKey) % 26;
                c = Array.GetValue(index);
            }
            //process with decryption algorithm
            //return new buffer
            return buff;
        }


        /*
        *@params
        *readFile - StreamReader used to read from the user entered file / path
        * writeFile - StreamReader used to read from same file / path
        * mode - used to designate whether to encrypt or decrypt (0 = encrypt, 1 = decrypt)
        */
        public Char[] process(StreamReader readFile, StreamWriter writeFile, int mode)
        {
            //char Buffers to handle both read and write data
            Char[] readBuff = new Char[];
            Char[] writeBuff = new Char[];
            //instantiate our alphabet
            alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            //repeat reading / encryption / writing process until complete
            while(!readFile.EndOfStream)
            {
                //read into the char buffer
                readBuff = readFile.ReadLine();
                //encrypt or decrypt read buffer into write buffer
                if (mode = 0)
                {
                    writeBuff = this.encrypt(readBuff);
                }                
                else
                {
                    writeBuff = this.decrypt(readBuff);
                }
                //write buffer out to file
                writeFile.WriteLine(writeBuff);
                  //when 32 chars have not been read, we have reached end of file
            }
            //close StreamReader and StreamWriter
            readFile.Close();
            writeFile.Close();
        }

        public StreamReader openReadFile(string filePath)
        {
            return new StreamReader(filePath);
        }
        
        public StreamWriter openWriteFile(string filePath)
        {
            return new StreamWriter(filePath);
        }

        
    }
}