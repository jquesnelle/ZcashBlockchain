//-----------------------------------------------------------------------
// <copyright file="ZcashConstants.cs">
// Copyright © Jeffrey Quesnelle. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZcashBlockchain.Data
{
    /// <summary>
    /// Various constants used in Zcash
    /// </summary>
    class ZcashConstants
    {
        public const int ZC_NUM_JS_INPUTS = 2;
        public const int ZC_NUM_JS_OUTPUTS = 2;
        public const int INCREMENTAL_MERKLE_TREE_DEPTH = 29;
        public const int INCREMENTAL_MERKLE_TREE_DEPTH_TESTING = 4;

        public const int ZC_NOTEPLAINTEXT_LEADING = 1;
        public const int ZC_V_SIZE = 8;
        public const int ZC_RHO_SIZE = 32;
        public const int ZC_R_SIZE = 32;
        public const int ZC_MEMO_SIZE = 512;

        public const int ZC_NOTEPLAINTEXT_SIZE = (ZC_NOTEPLAINTEXT_LEADING + ZC_V_SIZE + ZC_RHO_SIZE + ZC_R_SIZE + ZC_MEMO_SIZE);
        public const int NOTEENCRYPTION_AUTH_BYTES = 16;
        public const int ZC_NOTECIPHERTEXT_SIZE = ZC_NOTEPLAINTEXT_SIZE + NOTEENCRYPTION_AUTH_BYTES;

        public const byte G1_PREFIX_MASK = 0x02;
        public const byte G2_PREFIX_MASK = 0x0a;
    }
}
