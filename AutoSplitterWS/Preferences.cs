using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoSplitterWS;
public class Preferences : INotifyPropertyChanged
{
    private bool _isShowScreenNumber = false;

    public bool IsShowScreenNumber
    {
        get => _isShowScreenNumber;
        set
        {
            _isShowScreenNumber = value;
            OnPropertyChanged();
        }
    }

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
