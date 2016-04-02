using ColossalFramework;
using FogOptions.OptionsFramework;
using ICities;

namespace FogOptions
{
    public class FogOptions : IUserMod
    {
        public string Name => "Clouds & Fog Toggler";

        public string Description => "Disable clouds and distance fog that blocks your view when zooming out. Also allows to disable industrial smog and edge fog. (configurable)";

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<OptionsDTO>();
        }
    }
}
