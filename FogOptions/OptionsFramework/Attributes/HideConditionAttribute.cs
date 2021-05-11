using System;

namespace FogOptions.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class HideConditionAttribute : Attribute
    {
        public abstract bool IsHidden();
    }
}