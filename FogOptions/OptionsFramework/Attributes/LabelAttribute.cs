using System;

namespace FogOptions.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LabelAttribute : AbstractOptionsAttribute
    {
        public LabelAttribute(string description, string group) :
            base(description, group, null, null)
        {
        }
    }
}