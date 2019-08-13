using System;
using System.Web.Mvc;

namespace WebApi.DependencyInjectionContainer
{
    public class SpringControllerFactory : DefaultControllerFactory, IControllerFactory
    {

        #region IControllerFactory Memebers  
        IController IControllerFactory.CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IController controller = null;
            string controllerClassName = string.Format("{0}Controller", controllerName);

            if (SpringApplicationContext.Contains(controllerClassName))
            {
                controller = SpringApplicationContext.Resolve<IController>(controllerClassName);
            }
            else
            {
                try
                {
                    controller = base.CreateController(requestContext, controllerName);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return controller;
        }
        #endregion

        void IControllerFactory.ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}