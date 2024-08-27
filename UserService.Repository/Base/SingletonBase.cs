namespace UserService.Repository;

public class SingletonBase<T> where T : class, new()
{
    private static T? _instance;
    private static readonly object _instanceLock = new();
    public static T Instance
    {
        get
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }
}
