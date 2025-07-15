using EcoleDeLaPerformance.Ui.Models;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class StateContainerService
    {
        private User? _userInfo = default!;
        public User? UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                UserNotifyStateChanged();
            }
        }

        public event Action? OnUserStateChange;

        private void UserNotifyStateChanged() => OnUserStateChange?.Invoke();
    }
}
