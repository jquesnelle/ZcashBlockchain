using Base58Check;
using System;
using System.Security.Cryptography;


namespace ZcashBlockchain.Parser
{
    public class AddressParser
    {
        private static byte[] BASE58PREFIX_PUBKEY_ADDRESS = { 0x1c, 0xb8 };
        private static byte[] BASE58PREFIX_SCRIPT_ADDRESS = { 0x1c, 0xbd };

        private static String GetAddressFromHash160(byte[] scriptBytes, int publicKeyHashIndex, byte[] type)
        {
            // build up an address

            byte[] pubKeyHashWithVersion = new byte[2 + 20];
            pubKeyHashWithVersion[0] = type[0];
            pubKeyHashWithVersion[1] = type[1];
            Array.Copy(scriptBytes, publicKeyHashIndex, pubKeyHashWithVersion, 2, 20);

            return Base58CheckEncoding.Encode(pubKeyHashWithVersion);
        }

        private static String GetAddressFromPublicKey(byte[] scriptBytes, int publicKeyIndex, int keyLength, byte[] type)
        {
            var sha = SHA256.Create().ComputeHash(scriptBytes, publicKeyIndex, keyLength);
            var ripe = RIPEMD160.Create().ComputeHash(sha);
            return GetAddressFromHash160(ripe, 0, BASE58PREFIX_PUBKEY_ADDRESS);
        }

        public static string GetAddressFromOutputScript(byte[] scriptBytes)
        {
            if (scriptBytes == null)
                return null;

            if (scriptBytes.Length == 25 && scriptBytes[0] == 0x76 && scriptBytes[1] == 0xa9 && scriptBytes[2] == 0x14
                && scriptBytes[23] == 0x88 && scriptBytes[24] == 0xac) // P2PKH
            {
                // OP_DUP OP_HASH160 PUSH20 <HASH> OP_EQUALVERIFY OP_CHECKSIG
                return GetAddressFromHash160(scriptBytes, 3, BASE58PREFIX_PUBKEY_ADDRESS);
            }
            else if (scriptBytes.Length == 23 && scriptBytes[0] == 0xa9 && scriptBytes[1] == 0x14 && scriptBytes[22] == 0x87) // P2SH
            {
                // OP_HASH160 PUSH20 <HASH> OP_EQUAL
                return GetAddressFromHash160(scriptBytes, 2, BASE58PREFIX_SCRIPT_ADDRESS); 
            }
            else if (scriptBytes.Length == 67 && scriptBytes[0] == 0x41 && scriptBytes[1] == 0x04 && scriptBytes[66] == 0xac) // P2PK uncompressed
            {
                // PUSH65 <PUBKEY> OP_CHECKSIG
                return GetAddressFromPublicKey(scriptBytes, 1, 65, BASE58PREFIX_PUBKEY_ADDRESS);
            }
            else if (scriptBytes.Length == 35 && scriptBytes[0] == 0x21 && (scriptBytes[1] == 0x02 || scriptBytes[1] == 0x03)
                && scriptBytes[34] == 0xac) // P2PK compressed
            {
                // PUSH33 <PUBKEY> OP_CHECKSIG
                return GetAddressFromPublicKey(scriptBytes, 1, 33, BASE58PREFIX_PUBKEY_ADDRESS);
            }

            return null;
        }
    }
}
