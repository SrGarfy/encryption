using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Encryption {
	public static class EnumerableBitArrayExtensions {
		public static BitArray MergeSplitedBlocks(this IEnumerable<BitArray> bitArrays) {
			return bitArrays.SelectMany(bitArray => bitArray.ToBools()).ToBitArray();
		}
	}
}