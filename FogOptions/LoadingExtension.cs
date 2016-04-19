using ICities;

namespace FogOptions
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            FogController.Initialize();
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            FogController.Dispose();
        }
    }
}