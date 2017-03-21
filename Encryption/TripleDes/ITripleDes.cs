using System.Collections;

namespace Encryption {
	public interface ITripleDes {
		BitArray Encrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey, BitArray thirdInputKey);
		BitArray Decrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey, BitArray thirdInputKey);
	}
}