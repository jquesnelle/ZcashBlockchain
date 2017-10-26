//-----------------------------------------------------------------------
// <copyright file="ZCProof.cs">
// Copyright © Jeffrey Quesnelle. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZcashBlockchain.Data
{
    /// <summary>
    /// A compressed zk-SNARK guaranteeing the correctness of a JoinSplit
    /// </summary>
    public class ZCProof
    {

        public CompressedElement G_A { get; set; }

        public CompressedElement G_A_Prime { get; set; }

        public CompressedElement G_B { get; set; }

        public CompressedElement G_B_Prime { get; set; }

        public CompressedElement G_C { get; set; }

        public CompressedElement G_C_Prime { get; set; }

        public CompressedElement G_K { get; set; }

        public CompressedElement G_H { get; set; }
    }
}
