using System;
using System.Web.Mvc;
using Unity;
using System.Web.Routing;

using LoggingLibrary;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Concrete;
using SportsStoreMVCWenApp.Infrastructure;

namespace SportsStoreMVCWenApp.Infrastructure
{
  public class SportsUnityControllerFactory:DefaultControllerFactory
  {
    private UnityContainer _container;
    public SportsUnityControllerFactory()
    {
      _container = new UnityContainer();
      AddBindings();
    }

    protected override IController GetControllerInstance(RequestContext requestContext,
      Type controllerType)
    {
      //Default
      // return base.GetControllerInstance(requestContext, controllerType);
      return controllerType == null ? null : _container.Resolve(controllerType) as IController;
    }

    void AddBindings()
    {
      //Map the Interface with the class to be initiliazed in the controller
      _container.RegisterType<ILogger, Logger>();
      //_container.RegisterType<IProductRepository, MockProduct>();
      _container.RegisterType<IProductRepository, EProductRepository>();

    }
  }
}