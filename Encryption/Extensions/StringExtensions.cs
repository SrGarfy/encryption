using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Encryption {
	public static class StringExtensions {
		private static readonly Dictionary<char, bool[]> parseChars = new Dictionary<char, bool[]> {
			{ '0', new[] { false, false, false, false } },
			{ '1', new[] { false, false, false, true } },
			{ '2', new[] { false, false, true, false } },
			{ '3', new[] { false, false, true, true } },
			{ '4', new[] { false, true, false, false } },
			{ '5', new[] { false, true, false, true } },
			{ '6', new[] { false, true, true, false } },
			{ '7', new[] { false, true, true, true } },
			{ '8', new[] { true, false, false, false } },
			{ '9', new[] { true, false, false, true } },
			{ 'A', new[] { true, false, true, false } },
			{ 'B', new[] { true, false, true, true } },
			{ 'C', new[] { true, true, false, false } },
			{ 'D', new[] { true, true, false, true } },
			{ 'E', new[] { true, true, true, false } },
			{ 'F', new[] { true, true, true, true } }
		};

		public static BitArray ToBitArrayFromHex(this string text) {
			return new BitArray(text.SelectMany(c => parseChars[c]).ToArray());
		}
	}
}