using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Encryption {
	public static class BitArrayExtensions {
		public static BitArray Reorder(this BitArray bitArray, IEnumerable<int> order) {
			return new BitArray(order.Select(x => bitArray[x - 1]).ToArray());
		}

		public static IEnumerable<bool> Take(this BitArray bitArray, int count) {
			return Enumerable.Range(0, count).Select(x => bitArray[x]);
		}

		public static IEnumerable<bool> Skip(this BitArray bitArray, int count) {
			return Enumerable.Range(count, bitArray.Length - count).Select(x => bitArray[x]);
		}

		public static IEnumerable<bool> ToBools(this BitArray bitArray) {
			return Enumerable.Range(0, bitArray.Length).Select(x => bitArray[x]);
		}

		public static PairBitArrays Dimidiate(this BitArray bitArray) {
			return new PairBitArrays(bitArray.Take(bitArray.Length / 2).ToBitArray(), bitArray.Skip(bitArray.Length / 2).ToBitArray());
		}

		public static IEnumerable<BitArray> SplitIntoBlocks(this BitArray bitArray, int countBlocks) {
			if (countBlocks < 1 || (bitArray.Length % countBlocks != 0))
				throw new ArgumentException($"Byte array isn't divisible by {countBlocks} blocks");
			var lengthBlock = bitArray.Length / countBlocks;
			return Enumerable.Range(0, countBlocks).Select(x => bitArray.Skip(x * lengthBlock).Take(lengthBlock).ToBitArray());
		}

		public static BitArray CyclicShiftToLeft(this BitArray bitArray, int countShifts) {
			return bitArray.Skip(countShifts).Concat(bitArray.Take(countShifts)).ToBitArray();
		}

		public static BitArray CyclicShiftToRight(this BitArray bitArray, int countShifts) {
			return bitArray.Skip(bitArray.Length - countShifts).Concat(bitArray.Take(bitArray.Length - countShifts)).ToBitArray();
		}

		public static int ToIntFromBytes(this BitArray bitArray, params int[] byteIndexs) {
			return byteIndexs.OrderBy(x => x).Select(x => bitArray[x]).ToBitArray().ToInt();
		}

		public static int ToInt(this BitArray bitArray) {
			var tempArray = new int[1];
			bitArray.ToBools().Reverse().ToBitArray().CopyTo(tempArray, 0);
			return tempArray[0];
		}

		public static string ToStringInHex(this BitArray bitArray) {
			if (bitArray == null || bitArray.Length == 0)
				return "empty";

			var bools = bitArray.ToBools().ToArray();
			if (bools.Length % 4 != 0)
				bools = new bool[4 - bools.Length % 4].Concat(bools).ToArray();

			return new string(Enumerable.Range(0, bools.Length / 4)
				.Select(x => bools.Skip(x * 4).Take(4).ToBitArray().ToInt())
				.Select(x => (char)(x < 10 ? '0' + x : 'A' + x - 10))
				.ToArray());
		}
	}
}