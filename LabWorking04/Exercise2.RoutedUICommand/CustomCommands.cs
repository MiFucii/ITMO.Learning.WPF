using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoutedUICommand
{
    class CustomCommands
    {

        public static System.Windows.Input.RoutedUICommand Launch { get; }

        static CustomCommands()
        {
            InputGestureCollection myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            Launch = new System.Windows.Input.RoutedUICommand("Запуск", "Launch", typeof(CustomCommands), myInputGestures);
        }
    }
}
