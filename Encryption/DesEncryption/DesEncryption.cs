using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Encryption
{
    public class DesEncryption : IDesEncryption
    {

        public DesEncryption()
        {
        }

        public BitArray Encrypt(BitArray inputData, BitArray inputKey)
        {
            return EncryptOrDecryptAllData(inputData, inputKey, GenerateNextEncryptKey);
        }
        public BitArray Decrypt(BitArray inputData, BitArray inputKey)
        {
            return EncryptOrDecryptAllData(inputData, inputKey, GenerateNextDecryptKey);
        }
        private BitArray EncryptOrDecryptAllData(BitArray inputData, BitArray inputKey, Func<BitArray, int, BitArray> nextKeyGenerator)
        {
            CheckInputValueForAllData(inputData, inputKey);
            var inputDataBlocks = inputData.SplitIntoBlocks(inputData.Length / 64).ToArray();
            var encryptedOrDecryptedBlocks = inputDataBlocks.Select(data => EncryptOrDecryptOneBlock(data, inputKey, nextKeyGenerator)).ToArray();
            return encryptedOrDecryptedBlocks.MergeSplitedBlocks();
        }
        private BitArray EncryptOrDecryptOneBlock(BitArray inputData, BitArray inputKey, Func<BitArray, int, BitArray> nextKeyGenerator)
        {
            CheckInputValuesForOneBlock(inputData, inputKey);
            var reorderedInputData = inputData.Reorder(Tables.BeginOrderData);
            var key = inputKey.Reorder(Tables.BeginOrderKey);
            var data = reorderedInputData.Dimidiate();

            for (var i = 0; i < 16; i++)
            {
                key = nextKeyGenerator(key, i);
                data = FeistelFunction(data, key);
            }

            var mergeData = data.MergeSplitedBlocks(true);
            var outputData = mergeData.Reorder(Tables.EndOrderData);

            return outputData;
        }

        private void CheckInputValueForAllData(BitArray inputData, BitArray inputKey)
        {
            if (inputData.Length % 64 != 0)
                throw new ArgumentException("Array length must be divisible by 64 bit");
            CheckInputKey(inputKey, 2);
        }
        private void CheckInputValuesForOneBlock(BitArray inputData, BitArray inputKey)
        {
            if (inputData.Length != 64)
                throw new ArgumentException("Array length must be equal to 64 bit");
            CheckInputKey(inputKey, 4);
        }
        private void CheckInputKey(BitArray inputKey, int offsetForLogger)
        {
            if (inputKey.Length != 64)
                throw new ArgumentException("Key length must be divisible by 64 bit");
            if (inputKey.SplitIntoBlocks(8).Any(bitArray => bitArray.Take(7).Count(x => x) % 2 == 1 != bitArray[7]))
                throw new ArgumentException("Each byte must have odd number of 'ones'");
        }

        private BitArray GenerateNextEncryptKey(BitArray key, int iterationNumber)
        {
            return GenerateNextEncryptOrDecryptKey(key, iterationNumber, (pairBitArrays, x) => pairBitArrays.CyclicShiftToLeft(x), Tables.NumbersCyclicShiftToLeft);
        }
        private BitArray GenerateNextDecryptKey(BitArray key, int iterationNumber)
        {
            return GenerateNextEncryptOrDecryptKey(key, iterationNumber, (pairBitArrays, x) => pairBitArrays.CyclicShiftToRight(x), Tables.NumbersCyclicShiftToRight);
        }
        private BitArray GenerateNextEncryptOrDecryptKey(BitArray key, int iterationNumber, Func<PairBitArrays, int, PairBitArrays> cyclicShift, int[] tableForCyclicShift)
        {
            var keyAfterSplit = key.Dimidiate();
            var keyAfterCyclicShiftToRight = cyclicShift(keyAfterSplit, tableForCyclicShift[iterationNumber]);
            var keyAfterMerge = keyAfterCyclicShiftToRight.MergeSplitedBlocks();
            return keyAfterMerge;
        }

        private PairBitArrays FeistelFunction(PairBitArrays data, BitArray key)
        {
            return new PairBitArrays(data.RightBitArray, data.LeftBitArray.Xor(DesFunction(data.RightBitArray, key)));
        }
        private BitArray DesFunction(BitArray data, BitArray key)
        {
            key = key.Reorder(Tables.CompressionOrderKey);
            data = data.Reorder(Tables.ExtensionOrderData);
            data.Xor(key);
            data = data.SplitIntoBlocks(8).SelectMany(CreateBlock).ToBitArray();
            return data.Reorder(Tables.PBoxOrderData);
        }
        private IEnumerable<bool> CreateBlock(BitArray bitArray, int indexMatrix)
        {
            return Tables.SMatrixs[indexMatrix, bitArray.ToIntFromBytes(0, 5), bitArray.ToIntFromBytes(1, 2, 3, 4)].ToBoolArray(4);
        }
    }
}