namespace Unistream.T2.Business.Exceptions
{
    public class StorageException : Exception
    {
        public StorageException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
