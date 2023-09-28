namespace CodeBase.Services
{
  /// <summary>
  /// The most simple realization of Service Locator class based on the mechanism of
  /// creating different implementations for generic classes
  /// </summary>
  public class AllServices
  {
    private static AllServices _instance;
    public static AllServices Container => _instance ?? (_instance = new AllServices());

    /// <summary>
    /// Register a service in the DI Container as Single
    /// </summary>
    /// <param name="implementation">Implementation of the service</param>
    /// <typeparam name="TService">Interface of the service</typeparam>
    public void RegisterSingle<TService>(TService implementation) where TService : IService =>
      Implementation<TService>.ServiceInstance = implementation;

    /// <summary>
    /// Get a service by it's interface
    /// </summary>
    /// <typeparam name="TService">Interface of the service</typeparam>
    /// <returns></returns>
    public TService Single<TService>() where TService : IService =>
      Implementation<TService>.ServiceInstance;

    private class Implementation<TService> where TService : IService
    {
      public static TService ServiceInstance;
    }
  }
}