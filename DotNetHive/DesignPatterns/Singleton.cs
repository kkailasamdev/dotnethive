namespace DotNetHive.DesignPatterns
{
    public sealed class Singleton
    {
        private static readonly object _syncLock = new object();
        private static Singleton _instance = null;
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
