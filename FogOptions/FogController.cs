using ColossalFramework;
using ICities;
using UnityEngine;

namespace FogOptions
{
    public class FogController : LoadingExtensionBase
    {
        private static FogProperties _fogProperties;
        private static RenderProperties _renderProperties;
        private static float _defaultFogDensity;
        private static float _defaultColorDecay;
        private static float _defaultPollutionAmount;
        private static float _defaultEdgeFogDistance;

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            _fogProperties = GameObject.FindObjectOfType<FogProperties>();
            _defaultFogDensity = _fogProperties.m_FogDensity;
            _defaultPollutionAmount = _fogProperties.m_PollutionAmount;
            _defaultColorDecay = _fogProperties.m_ColorDecay;

            _renderProperties = GameObject.FindObjectOfType<RenderProperties>();
            _defaultEdgeFogDistance = _renderProperties.m_edgeFogDistance;
            ApplyChanges();

        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            _fogProperties = null;
            _renderProperties = null;
        }

        public static void ApplyChanges()
        {
            if (_fogProperties != null)
            {
                _fogProperties.m_FogDensity = OptionsHolder.Options.IsFlagSet(ModOption.DisableClouds)
                    ? 0 : _defaultFogDensity;
                _fogProperties.m_ColorDecay = OptionsHolder.Options.IsFlagSet(ModOption.DisableDistanceFog)
                    ? 1 : _defaultColorDecay;
                _fogProperties.m_PollutionAmount = OptionsHolder.Options.IsFlagSet(ModOption.DisableIndustrialSmog)
                    ? 0 : _defaultPollutionAmount;
                _fogProperties.m_edgeFog = !OptionsHolder.Options.IsFlagSet(ModOption.DisableEdgeFog);
            }
            if (_renderProperties != null)
            {
                _renderProperties.m_useVolumeFog = !OptionsHolder.Options.IsFlagSet(ModOption.DisableClouds);
                var fogDistance = OptionsHolder.Options.IsFlagSet(ModOption.DisableEdgeFog) ? 3800.0f :
                    _defaultEdgeFogDistance;
                _renderProperties.m_edgeFogDistance = fogDistance;
                var fogEffect = (FogEffect)Util.GetCameraBehaviour("FogEffect");
                if (fogEffect != null)
                {
                    fogEffect.m_edgeFogDistance = fogDistance;
                    fogEffect.m_UseVolumeFog = !OptionsHolder.Options.IsFlagSet(ModOption.DisableClouds);
                    fogEffect.m_edgeFog = !OptionsHolder.Options.IsFlagSet(ModOption.DisableEdgeFog);
                }
            }
        }

    }
}