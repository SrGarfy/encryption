using System.Collections;

namespace Encryption {
	public static class PairBitArraysExtensions {
		public static BitArray MergeSplitedBlocks(this PairBitArrays pairBitArrays, bool swapBlocks = false) {
			return swapBlocks 
				? new[] { pairBitArrays.RightBitArray, pairBitArrays.LeftBitArray }.MergeSplitedBlocks() 
				: new[] { pairBitArrays.LeftBitArray, pairBitArrays.RightBitArray }.MergeSplitedBlocks();
		}

		public static PairBitArrays CyclicShiftToLeft(this PairBitArrays pairBitArrays, int countShifts) {
			return new PairBitArrays(
				pairBitArrays.LeftBitArray.CyclicShiftToLeft(countShifts),
				pairBitArrays.RightBitArray.CyclicShiftToLeft(countShifts));
		}

		public static PairBitArrays CyclicShiftToRight(this PairBitArrays pairBitArrays, int countShifts) {
			return new PairBitArrays(
				pairBitArrays.LeftBitArray.CyclicShiftToRight(countShifts),
				pairBitArrays.RightBitArray.CyclicShiftToRight(countShifts));
		}
	}
}