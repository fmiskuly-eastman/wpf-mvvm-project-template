using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTemplate.ViewModels
{
    public class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region INotifyDataErrorInfo implementation
        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors[propertyName];
        }

        #endregion

        #region Helpers

        public bool ValidateTextboxDouble(object value, out double result, [CallerMemberName] string propertyName = null)
        {
            this._errors.Remove(propertyName);

            if (!Double.TryParse((string)value, out double parseResult))
            {
                if (!this._errors.ContainsKey(propertyName))
                    this._errors[propertyName] = new List<string>();

                _errors[propertyName].Add("Value could not be cast to a double");

                result = 0;
                return false;
            }
            result = parseResult;
            return true;
        }

        public bool ValidateTextboxInt(object value, out int result, [CallerMemberName] string propertyName = null)
        {
            this._errors.Remove(propertyName);

            if (!Int32.TryParse((string)value, out int parseResult))
            {
                if (!this._errors.ContainsKey(propertyName))
                    this._errors[propertyName] = new List<string>();

                _errors[propertyName].Add("Value could not be cast to an int");

                result = 0;
                return false;
            }
            result = parseResult;
            return true;
        }

        #endregion
    }
}
