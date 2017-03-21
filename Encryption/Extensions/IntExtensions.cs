using System.Collections.Generic;
using System.Linq;

namespace Encryption {
	public static class IntExtensions {
		public static IEnumerable<bool> ToBoolArray(this int value, int lengthBitArray) {
			return Enumerable.Range(0, lengthBitArray).Reverse().Select(x => ((value >> x) & 1) == 1);
		}
	}
}