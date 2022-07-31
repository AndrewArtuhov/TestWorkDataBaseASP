using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Test.Components
{
    [ViewComponent]
    public class DisplayName
    {
        public string Invoke(Type type, string nameProp)
        {
            return GetDisplayName(type, nameProp);
        }

        public string GetDisplayName(Type type, string nameProp)
        {
            var property = type.GetProperty(nameProp);
            var attribute = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            var displayName = attribute.Name;
            return displayName;
        }
    }
}
