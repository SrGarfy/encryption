using System.Collections;

namespace Encryption {
	public interface IDesEncryption {
		BitArray Encrypt(BitArray inputData, BitArray inputKey);
		BitArray Decrypt(BitArray text, BitArray key);
	}
}