using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace FogOptions
{

    [Flags]
    public enum ModOption : long
    {
        None = 0,
        DisableClouds = 1,
        DisableDistanceFog =2,
        DisableIndustrialSmog = 4,
        DisableEdgeFog = 8
    }

    public struct OptionsDTO
    {
        public bool disableClouds;
        public bool disableDistanceFog;
        public bool disableIndustrialSmog;
        public bool disableEdgeFog;
    }

    public static class OptionsHolder
    {
        public static ModOption Options = ModOption.None;
    }

    public static class OptionsLoader
    {
        public const string CONFIG_NAME = "CSL-FogOptions.xml";

        public static void LoadOptions()
        {
            OptionsHolder.Options = ModOption.None;
            OptionsDTO options;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(OptionsDTO));
                using (var streamReader = new StreamReader(CONFIG_NAME))
                {
                    options = (OptionsDTO)xmlSerializer.Deserialize(streamReader);
                }
            }
            catch (FileNotFoundException)
            {
                options = new OptionsDTO
                {
                   disableClouds = true,
                   disableDistanceFog = false,
                   disableIndustrialSmog = true,
                   disableEdgeFog = false
                };
                SaveOptions(options);
                // No options file yet
            }
            catch (Exception e)
            {
                Debug.LogError("Unexpected " + e.GetType().Name + " loading options: " + e.Message + "\n" + e.StackTrace);
                return;
            }
            if (options.disableClouds)
                OptionsHolder.Options |= ModOption.DisableClouds;
            if (options.disableDistanceFog)
                OptionsHolder.Options |= ModOption.DisableDistanceFog;
            if (options.disableIndustrialSmog)
                OptionsHolder.Options |= ModOption.DisableIndustrialSmog;
            if (options.disableEdgeFog)
                OptionsHolder.Options |= ModOption.DisableEdgeFog;
        }

        public static void SaveOptions()
        {
            OptionsDTO options = new OptionsDTO();
            if ((OptionsHolder.Options & ModOption.DisableClouds) != 0)
            {
                options.disableClouds = true;
            }
            if ((OptionsHolder.Options & ModOption.DisableDistanceFog) != 0)
            {
                options.disableDistanceFog = true;
            }
            if ((OptionsHolder.Options & ModOption.DisableIndustrialSmog) != 0)
            {
                options.disableIndustrialSmog = true;
            }
            if ((OptionsHolder.Options & ModOption.DisableEdgeFog) != 0)
            {
                options.disableEdgeFog = true;
            }
            SaveOptions(options);
        }

        public static void SaveOptions(OptionsDTO options)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(OptionsDTO));
                using (var streamWriter = new StreamWriter(CONFIG_NAME))
                {
                    xmlSerializer.Serialize(streamWriter, options);
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Unexpected " + e.GetType().Name + " saving options: " + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}