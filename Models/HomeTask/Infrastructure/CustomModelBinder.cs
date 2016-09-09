using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Infrastructure
{
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = (Person)bindingContext.Model ?? new Person();

            model.FirstName = GetValue(bindingContext, "FirstName");
            model.LastName = GetValue(bindingContext, "LastName");

            model.Role = (Role)bindingContext.ValueProvider.GetValue("Role").ConvertTo(typeof(Role));
            return model;
        }

        private string GetValue(ModelBindingContext bindingContext, string name)
        {
            name = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + name;

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue == "")
            {
                return "<Not Specified>";
            }

            return result.AttemptedValue;
        }

        private Role GetRole()
        {
            return 0;
        }
    }
}