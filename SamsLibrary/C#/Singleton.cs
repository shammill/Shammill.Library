// Thread Safe Singleton without using locks and no lazy instantiation
// Useful pattern for an in memory cache

namespace SamsLibrary
{
    public class Cache
    {
        static Cache _instance = new Cache();

        static Cache()
        {
        }

        Cache()
        {
        }

        public static Cache Instance
        {
            get { return _instance; }
        }

        private List<string> cachedItem = new List<string>();
        public string Secrets
        {
            get { return cachedItem; }
        }
    }

    public class Usage
    {
        var listOfSecrets = Cache.Instance.Secrets;
    }

}