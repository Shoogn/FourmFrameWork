using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Ninject;
using MvcDemo.AbstractLayer;
using MvcDemo.Repository;

namespace MvcDemo.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddDefaultBingings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);

            //if (controllerType == null)
            //{
            //    return null;
            //}
            //else
            //{
            //   return (IController)ninjectKernel.Get(controllerType);
            //}
        }

        private void AddDefaultBingings() 
        {
            ninjectKernel.Bind<IFourmRepository>().To<ForumRepository>();
            ninjectKernel.Bind<IJobRepository>().To<JobRepository>();
        }
    }
}