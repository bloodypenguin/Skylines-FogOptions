using FogOptions.OptionsFramework;

namespace FogOptions
{
    public class OptionsDTO : IModOptions
    {
        [Checkbox("Disable clouds", "FogController", "ApplyChanges")]
        public bool disableClouds { get; private set; }
        [Checkbox("Disable industrial smog", "FogController", "ApplyChanges")]
        public bool disableIndustrialSmog { get; private set; }
        [Checkbox("Disable distance fog", "FogController", "ApplyChanges")]
        public bool disableDistanceFog { get; private set; }
        [Checkbox("Disable edge fog", "FogController", "ApplyChanges")]
        public bool disableEdgeFog { get; private set; }

        public OptionsDTO()
        {
            disableClouds = true;
            disableDistanceFog = false;
            disableIndustrialSmog = true;
            disableEdgeFog = false;
        }

        public string FileName => "CSL-FogOptions.xml";
    }
}