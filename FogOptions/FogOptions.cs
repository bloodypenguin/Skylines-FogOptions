using ColossalFramework;
using ICities;

namespace FogOptions
{
    public class FogOptions : IUserMod
    {
        public string Name
        {
            get
            {
                OptionsLoader.LoadOptions();
                return "Clouds & Fog Toggler";
            }
        }

        public string Description => "Disable clouds and distance fog that blocks your view when zooming out. Also allows to disable industrial smog and edge fog. (configurable)";

        public void OnSettingsUI(UIHelperBase helper)
        {
            OptionsLoader.LoadOptions();
            var group = helper.AddGroup("Fog Options");
            AddCheckbox("Disable clouds", ModOption.DisableClouds, group);
            AddCheckbox("Disable industrial smog", ModOption.DisableIndustrialSmog, group);
            AddCheckbox("Disable distance fog", ModOption.DisableDistanceFog, group);
            AddCheckbox("Disable edge fog", ModOption.DisableEdgeFog, group);
        }

        private static void AddCheckbox(string text, ModOption flag, UIHelperBase group)
        {
            group.AddCheckbox(text, OptionsHolder.Options.IsFlagSet(flag),
                b =>
                {
                    if (b)
                    {
                        OptionsHolder.Options |= flag;
                    }
                    else
                    {
                        OptionsHolder.Options &= ~flag;
                    }
                    FogController.ApplyChanges();
                    OptionsLoader.SaveOptions();
                });
        }
    }
}
