using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sheduler
{
    public class CustomPasswordBox : TextBox
    {
        private Visibility _passVisible = Visibility.Hidden;
        public string Password { get; set; }

        public bool ChangingSetSettings = false;

        public Visibility PasswordVisible
        {
            get { return _passVisible; }
            set
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    if (value == Visibility.Visible)
                        this.Text = Password;
                    if (value == Visibility.Hidden)
                        this.Text = new string('●', Password.Length);
                }
                _passVisible = value;
            }
        }

        public CustomPasswordBox()
        {

        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            int cursorPosition = this.CaretIndex;
            if (_passVisible == Visibility.Hidden)
                this.Text += '●';
            else this.Text += e.Text;
            this.SelectionStart = cursorPosition + 1;
            this.SelectionLength = 0;
            //if(cursorPosition == )
            Password += e.Text;//.Insert(cursorPosition, e.Text);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                int cursorPosition = this.CaretIndex;
                if (this.SelectedText.Length > 0)
                {
                    cursorPosition = this.SelectionStart;
                    Password = Password.Remove(cursorPosition, this.SelectedText.Length);
                    return;
                }
                if (cursorPosition == 0)
                    return;
                Password = Password.Remove(cursorPosition - 1, 1);
            }
            else if (e.Key == Key.Delete)
            {
                int cursorPosition = this.CaretIndex;
                if (this.SelectedText.Length > 0)
                {
                    cursorPosition = this.SelectionStart;
                    Password = Password.Remove(cursorPosition, this.SelectedText.Length);
                    return;
                }
                if (Password.Length == 0)
                    return;
                Password = Password.Remove(cursorPosition, 1);
            }
        }
    }

}
