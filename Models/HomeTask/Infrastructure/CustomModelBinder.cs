using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Infrastructure
{
    public class CustomModelBinder : IModelBinder
    {
        private static readonly string notDefined = "<not-defined>";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person model = (Person)bindingContext.Model ?? new Person();
            model.Address = new Address();

            model.FirstName = GetValue(bindingContext, "FirstName");
            model.LastName = GetValue(bindingContext, "LastName");

            model.Role = GetRole(controllerContext, bindingContext);

            model.DateOfBirth = GetDate(bindingContext);

            model.Address.City = GetValue(bindingContext, "Address.City");
            model.Address.Country = GetValue(bindingContext, "Address.Country");

            model.Address.Line1 = GetLine(bindingContext, "Address.Line1");
            model.Address.Line2 = GetLine(bindingContext, "Address.Line2");

            model.Address.PostalCode = GetPostalCode(bindingContext);

            model.AddressSummary = GetAddressSummary(model);

            return model;
        }

        private string GetValue(ModelBindingContext bindingContext, string name)
        {
            name = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + name;

            ValueProviderResult result = bindingContext.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue == "")
            {
                return notDefined;
            }

            return result.AttemptedValue;
        }

        private Role GetRole(ControllerContext controllerContext, ModelBindingContext context)
        {
            Role role;
            var roleStr = (string)context.ValueProvider.GetValue("Role").ConvertTo(typeof(string));
            if (!Enum.IsDefined(typeof(Role), roleStr))
            {
                role = Role.Guest;
            }
            else
            {
                role = (Role)Enum.Parse(typeof(Role), roleStr);
                if (role != Role.Admin) return role;

                if (!controllerContext.RequestContext.HttpContext.Request.IsLocal)
                {
                    role = Role.User;
                }
            }

            return role;
        }

        private string GetLine(ModelBindingContext bindingContext, string name)
        {
            var val = GetValue(bindingContext, name);
            if (val.IndexOf("PO BOX", StringComparison.Ordinal) > -1)
            {
                return notDefined;
            }
            return val;
        }

        private string GetPostalCode(ModelBindingContext bindingContext)
        {
            var val = GetValue(bindingContext, "Address.PostalCode");
            return val.Length >= 6 ? val : "<not-defined>";
        }

        private string GetAddressSummary(Person model)
        {
            if (model.Address.PostalCode == notDefined || 
                model.Address.City == notDefined ||
                model.Address.Line1 == notDefined)
            {
                return "No personal address";
            }
            
            return $"{model.Address.PostalCode} {model.Address.City}, " +
                                   $"{model.Address.Line1}";
        }

        private DateTime GetDate(ModelBindingContext bindingContext)
        {
            DateTime date;

            var val = GetValue(bindingContext, "DateOfBirth");

            if (!DateTime.TryParseExact(val, "MMM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date))
            {
                return DateTime.Now;
            }

            return date;
        }
    }
}