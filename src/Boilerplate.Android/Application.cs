using System;
using Android.Runtime;
using Boilerplate.Shared;
using Android.App;

namespace Boilerplate.Droid
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY", Value = Fixtures.GOOGLE_MAPS_ANDROID_API_KEY)]
    public class MyApplication : Application
    {
        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
