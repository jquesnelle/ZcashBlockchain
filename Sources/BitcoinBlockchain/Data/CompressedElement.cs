//-----------------------------------------------------------------------
// <copyright file="CompressedElement.cs">
// Copyright © Jeffrey Quesnelle. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZcashBlockchain.Data
{
    /// <summary>
    /// Represents a compressed element in a field
    /// </summary>
    public class CompressedElement
    {
        public bool YIndicator;

        public ByteArray X;
    }
}
