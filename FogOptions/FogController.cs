using FogOptions.OptionsFramework;
using ICities;
using UnityEngine;

namespace FogOptions
{
    public class FogController
    {
        private static FogProperties _fogProperties;
        private static RenderProperties _renderProperties;
        private static float _defaultFogDensity;
        private static float _defaultFoggyFogDensity;
        private static float _defaultFoggyFogStart;
        private static float _defaultFoggyFogNoiseContrubution;
        private static float _defaultColorDecay;
        private static float _defaultPollutionAmount;
        private static float _defaultEdgeFogDistance;

        public static void Initialize()
        {
            _fogProperties = GameObject.FindObjectOfType<FogProperties>();
            _defaultFogDensity = _fogProperties.m_FogDensity;
            _defaultPollutionAmount = _fogProperties.m_PollutionAmount;
            _defaultColorDecay = _fogProperties.m_ColorDecay;
            _defaultFoggyFogNoiseContrubution = _fogProperties.m_FoggyNoiseContribution;
            _defaultFoggyFogDensity = _fogProperties.m_FoggyFogDensity;
            _defaultFoggyFogStart = _fogProperties.m_FoggyFogStart;

            _renderProperties = GameObject.FindObjectOfType<RenderProperties>();
            _defaultEdgeFogDistance = _renderProperties.m_edgeFogDistance;
            ApplyChangesImpl();

        }

        public static void Dispose()
        {
            _fogProperties = null;
            _renderProperties = null;
            _fogProperties.m_FogDensity = _defaultFogDensity;
            _fogProperties.m_PollutionAmount = _defaultPollutionAmount;
            _fogProperties.m_ColorDecay = _defaultColorDecay;
            _fogProperties.m_FoggyNoiseContribution = _defaultFoggyFogNoiseContrubution;
            _fogProperties.m_FoggyFogDensity = _defaultFoggyFogDensity;
            _fogProperties.m_FoggyFogStart = _defaultFoggyFogStart;
        }

        //this is for options framework
        public static void ApplyChanges(bool stubBool)
        {
            ApplyChangesImpl();
        }

        public static void ApplyChangesImpl()
        {

            if (_fogProperties != null)
            {
                _fogProperties.m_FogDensity = OptionsWrapper<OptionsDTO>.Options.disableClouds ? 0 : _defaultFogDensity;
                _fogProperties.m_FoggyFogDensity = OptionsWrapper<OptionsDTO>.Options.disableClouds ? 0 : _defaultFoggyFogDensity;

                _fogProperties.m_ColorDecay = OptionsWrapper<OptionsDTO>.Options.disableDistanceFog ? 1 : _defaultColorDecay;
                _fogProperties.m_FoggyFogStart = OptionsWrapper<OptionsDTO>.Options.disableDistanceFog ? _fogProperties.m_FogStart : _defaultFoggyFogStart;
                _fogProperties.m_FoggyNoiseContribution = OptionsWrapper<OptionsDTO>.Options.disableDistanceFog ? _fogProperties.m_NoiseContribution : _defaultFoggyFogNoiseContrubution;

                _fogProperties.m_PollutionAmount = OptionsWrapper<OptionsDTO>.Options.disableIndustrialSmog ? 0 : _defaultPollutionAmount;

                _fogProperties.m_edgeFog = !OptionsWrapper<OptionsDTO>.Options.disableEdgeFog;
            }
            if (_renderProperties != null)
            {
                _renderProperties.m_useVolumeFog = !OptionsWrapper<OptionsDTO>.Options.disableClouds;
                var fogDistance = OptionsWrapper<OptionsDTO>.Options.disableEdgeFog ? 3800.0f : _defaultEdgeFogDistance;
                _renderProperties.m_edgeFogDistance = fogDistance;
                var fogEffect = (FogEffect)Util.GetCameraBehaviour("FogEffect");
                if (fogEffect != null)
                {
                    fogEffect.m_edgeFogDistance = fogDistance;
                    fogEffect.m_UseVolumeFog = !OptionsWrapper<OptionsDTO>.Options.disableClouds;
                    fogEffect.m_edgeFog = !OptionsWrapper<OptionsDTO>.Options.disableEdgeFog;
                }
            }
        }

    }
}