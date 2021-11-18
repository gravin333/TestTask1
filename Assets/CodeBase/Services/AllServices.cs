namespace CodeBase.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public void Register<TService>(TService service)
        {
            Implementation<TService>.ServiceInstance = service;
        }

        public TService Single<TService>()
        {
            return Implementation<TService>.ServiceInstance;
        }

        private static class Implementation<TService>
        {
            public static TService ServiceInstance;
        }
    }
}