using System.Collections;

namespace Encryption {
	public class SimpleDes : ITripleDes {
		private readonly IDesEncryption desEncryption;

		public SimpleDes() {
			desEncryption = new DesEncryption();
		}
		public BitArray Encrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey = null, BitArray thirdInputKey = null) {
			return desEncryption.Encrypt(inputData, firstInputKey);
		}
		public BitArray Decrypt(BitArray inputData, BitArray firstInputKey, BitArray secondInputKey = null, BitArray thirdInputKey = null) {
			return desEncryption.Decrypt(inputData, firstInputKey);
		}
	}
}