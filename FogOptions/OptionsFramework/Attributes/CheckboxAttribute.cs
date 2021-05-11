﻿using System;

namespace FogOptions.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckboxAttribute : AbstractOptionsAttribute
    {

        public CheckboxAttribute(string description, string group = null, string actionClass = null, string actionMethod = null) : 
            base(description, group, actionClass, actionMethod)
        {
        }
    }
}