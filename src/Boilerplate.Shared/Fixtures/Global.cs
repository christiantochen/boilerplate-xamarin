namespace Boilerplate.Shared
{
    public static partial class Fixtures
    {
        /**/
        public const string SECURE_STORAGE_TOKEN_KEY = "token";
        /**/
        public const string REGEX_EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        /**/
        public const string MESSAGE_INVALID_FORMAT_EMAIL = "The Email address provided is not valid";
        public const string MESSAGE_INVALID_FORMAT_URL = "The Url provided is not valid";
        public const string MESSAGE_INVALID_OBJECT_EMPTY = "Object cannot be empty or null";
        /**/
        public const string LOCALHOST_IP = "http://10.0.2.2:8000/api";

    }
}
