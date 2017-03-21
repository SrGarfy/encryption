using System.Collections;
using System.Linq;

namespace Encryption {
	public class TripleDesEde3 : ITripleDes {
		private readonly IDesEncryption desEncryption;

		public TripleDesEde3() {
			desEncryption = new DesEncryption();
		}
		public BitArray Encrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey, BitArray thirdInputKey = null) {
            return desEncryption.Encrypt(desEncryption.Decrypt(desEncryption.Encrypt(inputData, firstInputKey), secondInputKey), firstInputKey);
		}
		public BitArray Decrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey, BitArray thirdInputKey = null) {
            return desEncryption.Decrypt(desEncryption.Encrypt(desEncryption.Decrypt(inputData, firstInputKey), secondInputKey), firstInputKey);
		}
	}
}