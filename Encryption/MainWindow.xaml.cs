using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Encryption;

namespace Encryption {
	public partial class MainWindow {
		private readonly Encoding usingEncoding = Encoding.Default;

		public MainWindow() {
			InitializeComponent();
		}
		private IEnumerable<string> GetErrorsFromFields() {
			if (TextBoxIsEmpty(TextBoxInputLine))
				yield return GenerateErrorEmptyField(LabelInputLine);
			else if (RadioButtonInputLineInHex.IsChecked == true && TextBoxIsNotHexCode(TextBoxInputLine))
				yield return GenerateErrorNotHexCode(LabelInputLine);

			if (TextBoxIsEnabledAndEmpty(TextBoxFirstKey))
				yield return GenerateErrorEmptyField(LabelFirstKey);
			else if (TextBoxIsNotHexCode(TextBoxFirstKey))
				yield return GenerateErrorNotHexCode(LabelFirstKey);

			if (TextBoxIsEnabledAndEmpty(TextBoxSecondKey))
				yield return GenerateErrorEmptyField(LabelSecondKey);
			else if (TextBoxIsNotHexCode(TextBoxSecondKey))
				yield return GenerateErrorNotHexCode(LabelSecondKey);

			if (TextBoxIsEnabledAndEmpty(TextBoxThirdKey))
				yield return GenerateErrorEmptyField(LabelThirdKey);
			else if (TextBoxIsNotHexCode(TextBoxThirdKey))
				yield return GenerateErrorNotHexCode(LabelThirdKey);

			if (RadioButtonsNotSelected(RadioButtonInputLineInText, RadioButtonInputLineInHex))
				yield return $"Select data type";
        }
		private bool TextBoxIsEmpty(TextBox textBox) {
			return string.IsNullOrEmpty(textBox.Text);
		}
		private bool TextBoxIsEnabledAndEmpty(TextBox textBox) {
			return textBox.IsEnabled && TextBoxIsEmpty(textBox);
		}
		private bool TextBoxIsNotHexCode(TextBox textBox) {
			return !Regex.IsMatch(textBox.Text, @"^[\dA-F]*$");
		}
		private bool RadioButtonsNotSelected(params RadioButton[] radioButtons) {
			return radioButtons.All(radioButton => radioButton.IsChecked != true);
		}
		private string GenerateErrorEmptyField(Label label) {
			return $"Enter '{(string)label.Content}'";
		}
		private string GenerateErrorNotHexCode(Label label) {
			return $"{(string)label.Content} isn't hex code";
		}

		private void ButtonEncrypt_OnClick(object sender, RoutedEventArgs e) {
			EncryptOrDecrypt((tripleDes, inputData, inputFirstKey, inputSecondKey, inputThirdKey) =>
				tripleDes.Encrypt(inputData, inputFirstKey, inputSecondKey, inputThirdKey));
		}
		private void ButtonDecrypt_OnClick(object sender, RoutedEventArgs e) {
			EncryptOrDecrypt((tripleDes, inputData, inputFirstKey, inputSecondKey, inputThirdKey) =>
				tripleDes.Decrypt(inputData, inputFirstKey, inputSecondKey, inputThirdKey));
		}
		private void EncryptOrDecrypt(Func<ITripleDes, BitArray, BitArray, BitArray, BitArray, BitArray> encryptOrDecrypt) {
			var errors = GetErrorsFromFields().ToArray();
			if (errors.Any()) {
				MessageBox.Show(string.Join("\n", errors));
				return;
			}

            var outputLine = string.Empty;
            try
            {
                var inputData = GetInputData();
                var inputFirstKey = TextBoxFirstKey.Text.ToBitArrayFromHex();
                var inputSecondKey = TextBoxSecondKey.Text.ToBitArrayFromHex();
                var inputThirdKey = TextBoxThirdKey.Text.ToBitArrayFromHex();

                outputLine = encryptOrDecrypt(GetTripleDes(), inputData, inputFirstKey, inputSecondKey, inputThirdKey).ToStringInHex();
            }
            catch (Exception exception) {
				outputLine = exception.Message;
            }
            TextBoxOutputLine.Text = outputLine;
        }
        private BitArray GetInputData() {
			if (RadioButtonInputLineInHex.IsChecked == true)
				return TextBoxInputLine.Text.ToBitArrayFromHex();
			if (RadioButtonInputLineInText.IsChecked == true)
				return new BitArray(usingEncoding.GetBytes(TextBoxInputLine.Text));
			throw new NotImplementedException();
		}
		private ITripleDes GetTripleDes() {
			return new TripleDesEde3();
		}
	}
}
