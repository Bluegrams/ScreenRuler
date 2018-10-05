using System;
using System.ComponentModel;
using System.Resources;
using System.Linq;

namespace ScreenRuler.Units
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        ResourceManager resMan;
        string resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            resMan = new ResourceManager(resourceType);
            this.resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                var s = resMan.GetString(resourceKey);
                return String.IsNullOrWhiteSpace(s) ? resourceKey : s;
            }
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum en)
        {
            DescriptionAttribute attr = (DescriptionAttribute)en.GetType()
                .GetField(en.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault();
            if (attr != null)
            {
                return attr.Description;
            }
            else return en.ToString();
        }
    }
}
