using CoreBusiness;
using CoreCommon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWeb
{
    public abstract class BaseController<TModel, TViewModel> : Controller
        where TModel : class, IEntity, new()
        where TViewModel: class, new()
    {
        private IBusinessLogicRule<TModel> businessRule;

        public BaseController()
        {
            businessRule = DefineBusinessLogicRule();
        }

        protected abstract IBusinessLogicRule<TModel> DefineBusinessLogicRule();
    }
}
