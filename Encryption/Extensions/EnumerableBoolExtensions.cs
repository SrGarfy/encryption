using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Encryption {
	public static class EnumerableBoolExtensions {
		public static BitArray ToBitArray(this IEnumerable<bool> bools) {
			return new BitArray(bools.ToArray());
		}
	}
}