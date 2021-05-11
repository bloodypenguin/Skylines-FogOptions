﻿using System;

namespace FogOptions.OptionsFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextfieldAttribute : AbstractOptionsAttribute
    {
        public TextfieldAttribute(string description, string group = null, string actionClass = null,
            string actionMethod = null) : base(description, group, actionClass, actionMethod)
        {
        }
    }
}