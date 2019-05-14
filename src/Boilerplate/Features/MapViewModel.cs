using System.Threading.Tasks;
using Boilerplate.Shared;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Boilerplate.Features
{
    public class MapViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        public MapViewModel()
        {
            Title = Fixtures.TITLE_MAP;
            Icon = Fixtures.ICON_MAP;
        }

        public async Task OnViewAppearingAsync(VisualElement view)
        {
            await CheckPermissionAsync();
            await CheckLastKnownLocationAsync();
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        async Task CheckPermissionAsync()
        {
            var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

            if (permissionStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Location))
                    permissionStatus = results[Permission.Location];
            }

            IsShowingUser = MyLocationEnabled = permissionStatus == PermissionStatus.Granted;
        }

        async Task CheckLastKnownLocationAsync()
        {
            if (InitialCameraPosition != null)
                return;

            var lastLocation = await Geolocation.GetLastKnownLocationAsync();

            if (lastLocation != default)
            {
                InitialCameraPosition = CameraUpdateFactory.NewCameraPosition(new CameraPosition(
                    new Position(lastLocation.Latitude, lastLocation.Longitude), 13, 30, 60));
            }
            else
            {
                initialCameraPosition = CameraUpdateFactory.NewCameraPosition(new CameraPosition(
                    new Position(-23.68, -46.87), 13, 30, 60));
            }
        }

        CameraUpdate initialCameraPosition;
        public CameraUpdate InitialCameraPosition
        {
            get => initialCameraPosition;
            set
            {
                initialCameraPosition = value;
                OnPropertyChanged();
            }
        }

        bool isShowingUser;
        public bool IsShowingUser
        {
            get => isShowingUser;
            set
            {
                isShowingUser = value;
                OnPropertyChanged();
            }
        }

        bool myLocationEnabled;
        public bool MyLocationEnabled
        {
            get => myLocationEnabled;
            set
            {
                myLocationEnabled = value;
                OnPropertyChanged();
            }
        }
    }
}