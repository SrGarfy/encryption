using System.Collections;

namespace Encryption {
	public class PairBitArrays {
		public readonly BitArray LeftBitArray;
		public readonly BitArray RightBitArray;

		public PairBitArrays(BitArray leftBitArray, BitArray rightBitArray) {
			LeftBitArray = leftBitArray;
			RightBitArray = rightBitArray;
		}
	}
}