namespace Xamarin.Forms
{
    public interface IValidableObject
    {
        bool IsValid { get; set; }
        bool Validate();
    }
}
