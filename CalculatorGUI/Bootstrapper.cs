using System;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using CalculatorGUI.ViewModels;
using CalculatorGUI.Input;

namespace CalculatorGUI
{
    public class Bootstrapper : BootstrapperBase
    {
		public Bootstrapper() {
			Initialize();
		}

		protected override void OnStartup(object sender, StartupEventArgs e) {
			DisplayRootViewFor<ShellViewModel>();
		}

		protected override void Configure() {
			var defaultCreateTrigger = Parser.CreateTrigger;

			Parser.CreateTrigger = (target, triggerText) => {
				if (triggerText == null) {
					return defaultCreateTrigger(target, null);
				}

				var triggerDetail = triggerText
					.Replace("[", string.Empty)
					.Replace("]", string.Empty);

				var splits = triggerDetail.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

				switch (splits[0]) {
					case "Key":
						var key = (Key)Enum.Parse(typeof(Key), splits[1], true);
						return new KeyTrigger { Key = key };

					case "Gesture":
						var mkg = (MultiKeyGesture)(new MultiKeyGestureConverter()).ConvertFrom(splits[1]);
						return new KeyTrigger { Modifiers = mkg.KeySequences[0].Modifiers, Key = mkg.KeySequences[0].Keys[0] };
				}

				return defaultCreateTrigger(target, triggerText);
			};
		}
	}
}
