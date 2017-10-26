//-----------------------------------------------------------------------
// <copyright file="JoinSplit.cs">
// Copyright © Jeffrey Quesnelle. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZcashBlockchain.Data
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a JoinSplit, which is the operation that moves coins in and out
    /// of the anonymous pool
    /// </summary>
    public class JoinSplit
    {

        public UInt64 AmountIn { get; set; }

        public UInt64 AmountOut { get; set; }

        public ByteArray Anchor { get; set; }

        public readonly ByteArray[] Nullifiers;

        public readonly ByteArray[] Commitments;

        public ByteArray EphemeralKey { get; set; }

        public readonly ByteArray[] Ciphertexts;

        public ByteArray RandomSeed { get; set; }

        public readonly ByteArray[] MACs;

        public ZCProof Proof { get; set; }

        public JoinSplit()
        {
            Nullifiers = new ByteArray[ZcashConstants.ZC_NUM_JS_INPUTS];
            Commitments = new ByteArray[ZcashConstants.ZC_NUM_JS_OUTPUTS];

            Ciphertexts = new ByteArray[ZcashConstants.ZC_NUM_JS_OUTPUTS];

            MACs = new ByteArray[ZcashConstants.ZC_NUM_JS_INPUTS];
        }
    }
}
