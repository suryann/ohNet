using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using Zapp.Core;

namespace Zapp.Device.Providers
{
    public interface IDvProviderUpnpOrgRenderingControl2 : IDisposable
    {

        /// <summary>
        /// Set the value of the LastChange property
        /// </summary>
        /// <param name="aValue">New value for the property</param>
        /// <returns>true if the value has been updated; false if aValue was the same as the previous value</returns>
        bool SetPropertyLastChange(string aValue);

        /// <summary>
        /// Get a copy of the value of the LastChange property
        /// </summary>
        /// <param name="aValue">Property's value will be copied here</param>
        string PropertyLastChange();
        
    }
    /// <summary>
    /// Provider for the upnp.org:RenderingControl:2 UPnP service
    /// </summary>
    public class DvProviderUpnpOrgRenderingControl2 : DvProvider, IDisposable, IDvProviderUpnpOrgRenderingControl2
    {
        private GCHandle iGch;
        private ActionDelegate iDelegateListPresets;
        private ActionDelegate iDelegateSelectPreset;
        private ActionDelegate iDelegateGetBrightness;
        private ActionDelegate iDelegateSetBrightness;
        private ActionDelegate iDelegateGetContrast;
        private ActionDelegate iDelegateSetContrast;
        private ActionDelegate iDelegateGetSharpness;
        private ActionDelegate iDelegateSetSharpness;
        private ActionDelegate iDelegateGetRedVideoGain;
        private ActionDelegate iDelegateSetRedVideoGain;
        private ActionDelegate iDelegateGetGreenVideoGain;
        private ActionDelegate iDelegateSetGreenVideoGain;
        private ActionDelegate iDelegateGetBlueVideoGain;
        private ActionDelegate iDelegateSetBlueVideoGain;
        private ActionDelegate iDelegateGetRedVideoBlackLevel;
        private ActionDelegate iDelegateSetRedVideoBlackLevel;
        private ActionDelegate iDelegateGetGreenVideoBlackLevel;
        private ActionDelegate iDelegateSetGreenVideoBlackLevel;
        private ActionDelegate iDelegateGetBlueVideoBlackLevel;
        private ActionDelegate iDelegateSetBlueVideoBlackLevel;
        private ActionDelegate iDelegateGetColorTemperature;
        private ActionDelegate iDelegateSetColorTemperature;
        private ActionDelegate iDelegateGetHorizontalKeystone;
        private ActionDelegate iDelegateSetHorizontalKeystone;
        private ActionDelegate iDelegateGetVerticalKeystone;
        private ActionDelegate iDelegateSetVerticalKeystone;
        private ActionDelegate iDelegateGetMute;
        private ActionDelegate iDelegateSetMute;
        private ActionDelegate iDelegateGetVolume;
        private ActionDelegate iDelegateSetVolume;
        private ActionDelegate iDelegateGetVolumeDB;
        private ActionDelegate iDelegateSetVolumeDB;
        private ActionDelegate iDelegateGetVolumeDBRange;
        private ActionDelegate iDelegateGetLoudness;
        private ActionDelegate iDelegateSetLoudness;
        private ActionDelegate iDelegateGetStateVariables;
        private ActionDelegate iDelegateSetStateVariables;
        private PropertyString iPropertyLastChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="aDevice">Device which owns this provider</param>
        protected DvProviderUpnpOrgRenderingControl2(DvDevice aDevice)
            : base(aDevice, "upnp.org", "RenderingControl", 2)
        {
            iGch = GCHandle.Alloc(this);
            List<String> allowedValues = new List<String>();
            iPropertyLastChange = new PropertyString(new ParameterString("LastChange", allowedValues));
            AddProperty(iPropertyLastChange);
        }

        /// <summary>
        /// Set the value of the LastChange property
        /// </summary>
        /// <param name="aValue">New value for the property</param>
        /// <returns>true if the value has been updated; false if aValue was the same as the previous value</returns>
        public bool SetPropertyLastChange(string aValue)
        {
            return SetPropertyString(iPropertyLastChange, aValue);
        }

        /// <summary>
        /// Get a copy of the value of the LastChange property
        /// </summary>
        /// <returns>The value of the property</returns>
        public string PropertyLastChange()
        {
            return iPropertyLastChange.Value();
        }

        /// <summary>
        /// Signal that the action ListPresets is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// ListPresets must be overridden if this is called.</remarks>
        protected void EnableActionListPresets()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("ListPresets");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterString("CurrentPresetNameList", allowedValues));
            iDelegateListPresets = new ActionDelegate(DoListPresets);
            EnableAction(action, iDelegateListPresets, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SelectPreset is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SelectPreset must be overridden if this is called.</remarks>
        protected void EnableActionSelectPreset()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SelectPreset");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("FactoryDefaults");
            action.AddInputParameter(new ParameterString("PresetName", allowedValues));
            allowedValues.Clear();
            iDelegateSelectPreset = new ActionDelegate(DoSelectPreset);
            EnableAction(action, iDelegateSelectPreset, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetBrightness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetBrightness must be overridden if this is called.</remarks>
        protected void EnableActionGetBrightness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetBrightness");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentBrightness", 0, 0, 1));
            iDelegateGetBrightness = new ActionDelegate(DoGetBrightness);
            EnableAction(action, iDelegateGetBrightness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetBrightness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetBrightness must be overridden if this is called.</remarks>
        protected void EnableActionSetBrightness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetBrightness");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredBrightness", 0, 0, 1));
            iDelegateSetBrightness = new ActionDelegate(DoSetBrightness);
            EnableAction(action, iDelegateSetBrightness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetContrast is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetContrast must be overridden if this is called.</remarks>
        protected void EnableActionGetContrast()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetContrast");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentContrast", 0, 0, 1));
            iDelegateGetContrast = new ActionDelegate(DoGetContrast);
            EnableAction(action, iDelegateGetContrast, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetContrast is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetContrast must be overridden if this is called.</remarks>
        protected void EnableActionSetContrast()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetContrast");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredContrast", 0, 0, 1));
            iDelegateSetContrast = new ActionDelegate(DoSetContrast);
            EnableAction(action, iDelegateSetContrast, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetSharpness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetSharpness must be overridden if this is called.</remarks>
        protected void EnableActionGetSharpness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetSharpness");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentSharpness", 0, 0, 1));
            iDelegateGetSharpness = new ActionDelegate(DoGetSharpness);
            EnableAction(action, iDelegateGetSharpness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetSharpness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetSharpness must be overridden if this is called.</remarks>
        protected void EnableActionSetSharpness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetSharpness");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredSharpness", 0, 0, 1));
            iDelegateSetSharpness = new ActionDelegate(DoSetSharpness);
            EnableAction(action, iDelegateSetSharpness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetRedVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetRedVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionGetRedVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetRedVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentRedVideoGain", 0, 0, 1));
            iDelegateGetRedVideoGain = new ActionDelegate(DoGetRedVideoGain);
            EnableAction(action, iDelegateGetRedVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetRedVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetRedVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionSetRedVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetRedVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredRedVideoGain", 0, 0, 1));
            iDelegateSetRedVideoGain = new ActionDelegate(DoSetRedVideoGain);
            EnableAction(action, iDelegateSetRedVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetGreenVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetGreenVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionGetGreenVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetGreenVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentGreenVideoGain", 0, 0, 1));
            iDelegateGetGreenVideoGain = new ActionDelegate(DoGetGreenVideoGain);
            EnableAction(action, iDelegateGetGreenVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetGreenVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetGreenVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionSetGreenVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetGreenVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredGreenVideoGain", 0, 0, 1));
            iDelegateSetGreenVideoGain = new ActionDelegate(DoSetGreenVideoGain);
            EnableAction(action, iDelegateSetGreenVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetBlueVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetBlueVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionGetBlueVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetBlueVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentBlueVideoGain", 0, 0, 1));
            iDelegateGetBlueVideoGain = new ActionDelegate(DoGetBlueVideoGain);
            EnableAction(action, iDelegateGetBlueVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetBlueVideoGain is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetBlueVideoGain must be overridden if this is called.</remarks>
        protected void EnableActionSetBlueVideoGain()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetBlueVideoGain");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredBlueVideoGain", 0, 0, 1));
            iDelegateSetBlueVideoGain = new ActionDelegate(DoSetBlueVideoGain);
            EnableAction(action, iDelegateSetBlueVideoGain, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetRedVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetRedVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionGetRedVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetRedVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentRedVideoBlackLevel", 0, 0, 1));
            iDelegateGetRedVideoBlackLevel = new ActionDelegate(DoGetRedVideoBlackLevel);
            EnableAction(action, iDelegateGetRedVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetRedVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetRedVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionSetRedVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetRedVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredRedVideoBlackLevel", 0, 0, 1));
            iDelegateSetRedVideoBlackLevel = new ActionDelegate(DoSetRedVideoBlackLevel);
            EnableAction(action, iDelegateSetRedVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetGreenVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetGreenVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionGetGreenVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetGreenVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentGreenVideoBlackLevel", 0, 0, 1));
            iDelegateGetGreenVideoBlackLevel = new ActionDelegate(DoGetGreenVideoBlackLevel);
            EnableAction(action, iDelegateGetGreenVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetGreenVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetGreenVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionSetGreenVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetGreenVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredGreenVideoBlackLevel", 0, 0, 1));
            iDelegateSetGreenVideoBlackLevel = new ActionDelegate(DoSetGreenVideoBlackLevel);
            EnableAction(action, iDelegateSetGreenVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetBlueVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetBlueVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionGetBlueVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetBlueVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentBlueVideoBlackLevel", 0, 0, 1));
            iDelegateGetBlueVideoBlackLevel = new ActionDelegate(DoGetBlueVideoBlackLevel);
            EnableAction(action, iDelegateGetBlueVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetBlueVideoBlackLevel is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetBlueVideoBlackLevel must be overridden if this is called.</remarks>
        protected void EnableActionSetBlueVideoBlackLevel()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetBlueVideoBlackLevel");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredBlueVideoBlackLevel", 0, 0, 1));
            iDelegateSetBlueVideoBlackLevel = new ActionDelegate(DoSetBlueVideoBlackLevel);
            EnableAction(action, iDelegateSetBlueVideoBlackLevel, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetColorTemperature is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetColorTemperature must be overridden if this is called.</remarks>
        protected void EnableActionGetColorTemperature()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetColorTemperature");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterUint("CurrentColorTemperature", 0, 0, 1));
            iDelegateGetColorTemperature = new ActionDelegate(DoGetColorTemperature);
            EnableAction(action, iDelegateGetColorTemperature, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetColorTemperature is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetColorTemperature must be overridden if this is called.</remarks>
        protected void EnableActionSetColorTemperature()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetColorTemperature");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterUint("DesiredColorTemperature", 0, 0, 1));
            iDelegateSetColorTemperature = new ActionDelegate(DoSetColorTemperature);
            EnableAction(action, iDelegateSetColorTemperature, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetHorizontalKeystone is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetHorizontalKeystone must be overridden if this is called.</remarks>
        protected void EnableActionGetHorizontalKeystone()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetHorizontalKeystone");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterInt("CurrentHorizontalKeystone"));
            iDelegateGetHorizontalKeystone = new ActionDelegate(DoGetHorizontalKeystone);
            EnableAction(action, iDelegateGetHorizontalKeystone, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetHorizontalKeystone is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetHorizontalKeystone must be overridden if this is called.</remarks>
        protected void EnableActionSetHorizontalKeystone()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetHorizontalKeystone");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterInt("DesiredHorizontalKeystone"));
            iDelegateSetHorizontalKeystone = new ActionDelegate(DoSetHorizontalKeystone);
            EnableAction(action, iDelegateSetHorizontalKeystone, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetVerticalKeystone is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetVerticalKeystone must be overridden if this is called.</remarks>
        protected void EnableActionGetVerticalKeystone()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetVerticalKeystone");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddOutputParameter(new ParameterInt("CurrentVerticalKeystone"));
            iDelegateGetVerticalKeystone = new ActionDelegate(DoGetVerticalKeystone);
            EnableAction(action, iDelegateGetVerticalKeystone, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetVerticalKeystone is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetVerticalKeystone must be overridden if this is called.</remarks>
        protected void EnableActionSetVerticalKeystone()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetVerticalKeystone");
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterInt("DesiredVerticalKeystone"));
            iDelegateSetVerticalKeystone = new ActionDelegate(DoSetVerticalKeystone);
            EnableAction(action, iDelegateSetVerticalKeystone, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetMute is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetMute must be overridden if this is called.</remarks>
        protected void EnableActionGetMute()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetMute");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddOutputParameter(new ParameterBool("CurrentMute"));
            iDelegateGetMute = new ActionDelegate(DoGetMute);
            EnableAction(action, iDelegateGetMute, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetMute is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetMute must be overridden if this is called.</remarks>
        protected void EnableActionSetMute()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetMute");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddInputParameter(new ParameterBool("DesiredMute"));
            iDelegateSetMute = new ActionDelegate(DoSetMute);
            EnableAction(action, iDelegateSetMute, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetVolume is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetVolume must be overridden if this is called.</remarks>
        protected void EnableActionGetVolume()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetVolume");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddOutputParameter(new ParameterUint("CurrentVolume", 0, 0, 1));
            iDelegateGetVolume = new ActionDelegate(DoGetVolume);
            EnableAction(action, iDelegateGetVolume, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetVolume is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetVolume must be overridden if this is called.</remarks>
        protected void EnableActionSetVolume()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetVolume");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddInputParameter(new ParameterUint("DesiredVolume", 0, 0, 1));
            iDelegateSetVolume = new ActionDelegate(DoSetVolume);
            EnableAction(action, iDelegateSetVolume, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetVolumeDB is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetVolumeDB must be overridden if this is called.</remarks>
        protected void EnableActionGetVolumeDB()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetVolumeDB");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddOutputParameter(new ParameterInt("CurrentVolume"));
            iDelegateGetVolumeDB = new ActionDelegate(DoGetVolumeDB);
            EnableAction(action, iDelegateGetVolumeDB, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetVolumeDB is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetVolumeDB must be overridden if this is called.</remarks>
        protected void EnableActionSetVolumeDB()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetVolumeDB");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddInputParameter(new ParameterInt("DesiredVolume"));
            iDelegateSetVolumeDB = new ActionDelegate(DoSetVolumeDB);
            EnableAction(action, iDelegateSetVolumeDB, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetVolumeDBRange is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetVolumeDBRange must be overridden if this is called.</remarks>
        protected void EnableActionGetVolumeDBRange()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetVolumeDBRange");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddOutputParameter(new ParameterInt("MinValue"));
            action.AddOutputParameter(new ParameterInt("MaxValue"));
            iDelegateGetVolumeDBRange = new ActionDelegate(DoGetVolumeDBRange);
            EnableAction(action, iDelegateGetVolumeDBRange, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetLoudness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetLoudness must be overridden if this is called.</remarks>
        protected void EnableActionGetLoudness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetLoudness");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddOutputParameter(new ParameterBool("CurrentLoudness"));
            iDelegateGetLoudness = new ActionDelegate(DoGetLoudness);
            EnableAction(action, iDelegateGetLoudness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetLoudness is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetLoudness must be overridden if this is called.</remarks>
        protected void EnableActionSetLoudness()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetLoudness");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            allowedValues.Add("Master");
            action.AddInputParameter(new ParameterString("Channel", allowedValues));
            allowedValues.Clear();
            action.AddInputParameter(new ParameterBool("DesiredLoudness"));
            iDelegateSetLoudness = new ActionDelegate(DoSetLoudness);
            EnableAction(action, iDelegateSetLoudness, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action GetStateVariables is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// GetStateVariables must be overridden if this is called.</remarks>
        protected void EnableActionGetStateVariables()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("GetStateVariables");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterString("StateVariableList", allowedValues));
            action.AddOutputParameter(new ParameterString("StateVariableValuePairs", allowedValues));
            iDelegateGetStateVariables = new ActionDelegate(DoGetStateVariables);
            EnableAction(action, iDelegateGetStateVariables, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// Signal that the action SetStateVariables is supported.
        /// </summary>
        /// <remarks>The action's availability will be published in the device's service.xml.
        /// SetStateVariables must be overridden if this is called.</remarks>
        protected void EnableActionSetStateVariables()
        {
            Zapp.Core.Action action = new Zapp.Core.Action("SetStateVariables");
            List<String> allowedValues = new List<String>();
            action.AddInputParameter(new ParameterUint("InstanceID"));
            action.AddInputParameter(new ParameterString("RenderingControlUDN", allowedValues));
            action.AddInputParameter(new ParameterString("ServiceType", allowedValues));
            action.AddInputParameter(new ParameterString("ServiceId", allowedValues));
            action.AddInputParameter(new ParameterString("StateVariableValuePairs", allowedValues));
            action.AddOutputParameter(new ParameterString("StateVariableList", allowedValues));
            iDelegateSetStateVariables = new ActionDelegate(DoSetStateVariables);
            EnableAction(action, iDelegateSetStateVariables, GCHandle.ToIntPtr(iGch));
        }

        /// <summary>
        /// ListPresets action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// ListPresets action for the owning device.
        ///
        /// Must be implemented iff EnableActionListPresets was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentPresetNameList"></param>
        protected virtual void ListPresets(uint aVersion, uint aInstanceID, out string aCurrentPresetNameList)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SelectPreset action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SelectPreset action for the owning device.
        ///
        /// Must be implemented iff EnableActionSelectPreset was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aPresetName"></param>
        protected virtual void SelectPreset(uint aVersion, uint aInstanceID, string aPresetName)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetBrightness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetBrightness action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetBrightness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentBrightness"></param>
        protected virtual void GetBrightness(uint aVersion, uint aInstanceID, out uint aCurrentBrightness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetBrightness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetBrightness action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetBrightness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredBrightness"></param>
        protected virtual void SetBrightness(uint aVersion, uint aInstanceID, uint aDesiredBrightness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetContrast action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetContrast action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetContrast was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentContrast"></param>
        protected virtual void GetContrast(uint aVersion, uint aInstanceID, out uint aCurrentContrast)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetContrast action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetContrast action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetContrast was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredContrast"></param>
        protected virtual void SetContrast(uint aVersion, uint aInstanceID, uint aDesiredContrast)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetSharpness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetSharpness action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetSharpness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentSharpness"></param>
        protected virtual void GetSharpness(uint aVersion, uint aInstanceID, out uint aCurrentSharpness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetSharpness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetSharpness action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetSharpness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredSharpness"></param>
        protected virtual void SetSharpness(uint aVersion, uint aInstanceID, uint aDesiredSharpness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetRedVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetRedVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetRedVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentRedVideoGain"></param>
        protected virtual void GetRedVideoGain(uint aVersion, uint aInstanceID, out uint aCurrentRedVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetRedVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetRedVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetRedVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredRedVideoGain"></param>
        protected virtual void SetRedVideoGain(uint aVersion, uint aInstanceID, uint aDesiredRedVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetGreenVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetGreenVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetGreenVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentGreenVideoGain"></param>
        protected virtual void GetGreenVideoGain(uint aVersion, uint aInstanceID, out uint aCurrentGreenVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetGreenVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetGreenVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetGreenVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredGreenVideoGain"></param>
        protected virtual void SetGreenVideoGain(uint aVersion, uint aInstanceID, uint aDesiredGreenVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetBlueVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetBlueVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetBlueVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentBlueVideoGain"></param>
        protected virtual void GetBlueVideoGain(uint aVersion, uint aInstanceID, out uint aCurrentBlueVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetBlueVideoGain action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetBlueVideoGain action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetBlueVideoGain was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredBlueVideoGain"></param>
        protected virtual void SetBlueVideoGain(uint aVersion, uint aInstanceID, uint aDesiredBlueVideoGain)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetRedVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetRedVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetRedVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentRedVideoBlackLevel"></param>
        protected virtual void GetRedVideoBlackLevel(uint aVersion, uint aInstanceID, out uint aCurrentRedVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetRedVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetRedVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetRedVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredRedVideoBlackLevel"></param>
        protected virtual void SetRedVideoBlackLevel(uint aVersion, uint aInstanceID, uint aDesiredRedVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetGreenVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetGreenVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetGreenVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentGreenVideoBlackLevel"></param>
        protected virtual void GetGreenVideoBlackLevel(uint aVersion, uint aInstanceID, out uint aCurrentGreenVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetGreenVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetGreenVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetGreenVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredGreenVideoBlackLevel"></param>
        protected virtual void SetGreenVideoBlackLevel(uint aVersion, uint aInstanceID, uint aDesiredGreenVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetBlueVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetBlueVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetBlueVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentBlueVideoBlackLevel"></param>
        protected virtual void GetBlueVideoBlackLevel(uint aVersion, uint aInstanceID, out uint aCurrentBlueVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetBlueVideoBlackLevel action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetBlueVideoBlackLevel action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetBlueVideoBlackLevel was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredBlueVideoBlackLevel"></param>
        protected virtual void SetBlueVideoBlackLevel(uint aVersion, uint aInstanceID, uint aDesiredBlueVideoBlackLevel)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetColorTemperature action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetColorTemperature action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetColorTemperature was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentColorTemperature"></param>
        protected virtual void GetColorTemperature(uint aVersion, uint aInstanceID, out uint aCurrentColorTemperature)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetColorTemperature action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetColorTemperature action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetColorTemperature was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredColorTemperature"></param>
        protected virtual void SetColorTemperature(uint aVersion, uint aInstanceID, uint aDesiredColorTemperature)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetHorizontalKeystone action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetHorizontalKeystone action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetHorizontalKeystone was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentHorizontalKeystone"></param>
        protected virtual void GetHorizontalKeystone(uint aVersion, uint aInstanceID, out int aCurrentHorizontalKeystone)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetHorizontalKeystone action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetHorizontalKeystone action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetHorizontalKeystone was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredHorizontalKeystone"></param>
        protected virtual void SetHorizontalKeystone(uint aVersion, uint aInstanceID, int aDesiredHorizontalKeystone)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetVerticalKeystone action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetVerticalKeystone action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetVerticalKeystone was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aCurrentVerticalKeystone"></param>
        protected virtual void GetVerticalKeystone(uint aVersion, uint aInstanceID, out int aCurrentVerticalKeystone)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetVerticalKeystone action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetVerticalKeystone action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetVerticalKeystone was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aDesiredVerticalKeystone"></param>
        protected virtual void SetVerticalKeystone(uint aVersion, uint aInstanceID, int aDesiredVerticalKeystone)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetMute action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetMute action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetMute was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aCurrentMute"></param>
        protected virtual void GetMute(uint aVersion, uint aInstanceID, string aChannel, out bool aCurrentMute)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetMute action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetMute action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetMute was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aDesiredMute"></param>
        protected virtual void SetMute(uint aVersion, uint aInstanceID, string aChannel, bool aDesiredMute)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetVolume action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetVolume action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetVolume was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aCurrentVolume"></param>
        protected virtual void GetVolume(uint aVersion, uint aInstanceID, string aChannel, out uint aCurrentVolume)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetVolume action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetVolume action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetVolume was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aDesiredVolume"></param>
        protected virtual void SetVolume(uint aVersion, uint aInstanceID, string aChannel, uint aDesiredVolume)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetVolumeDB action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetVolumeDB action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetVolumeDB was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aCurrentVolume"></param>
        protected virtual void GetVolumeDB(uint aVersion, uint aInstanceID, string aChannel, out int aCurrentVolume)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetVolumeDB action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetVolumeDB action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetVolumeDB was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aDesiredVolume"></param>
        protected virtual void SetVolumeDB(uint aVersion, uint aInstanceID, string aChannel, int aDesiredVolume)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetVolumeDBRange action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetVolumeDBRange action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetVolumeDBRange was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aMinValue"></param>
        /// <param name="aMaxValue"></param>
        protected virtual void GetVolumeDBRange(uint aVersion, uint aInstanceID, string aChannel, out int aMinValue, out int aMaxValue)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetLoudness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetLoudness action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetLoudness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aCurrentLoudness"></param>
        protected virtual void GetLoudness(uint aVersion, uint aInstanceID, string aChannel, out bool aCurrentLoudness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetLoudness action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetLoudness action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetLoudness was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aChannel"></param>
        /// <param name="aDesiredLoudness"></param>
        protected virtual void SetLoudness(uint aVersion, uint aInstanceID, string aChannel, bool aDesiredLoudness)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// GetStateVariables action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// GetStateVariables action for the owning device.
        ///
        /// Must be implemented iff EnableActionGetStateVariables was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aStateVariableList"></param>
        /// <param name="aStateVariableValuePairs"></param>
        protected virtual void GetStateVariables(uint aVersion, uint aInstanceID, string aStateVariableList, out string aStateVariableValuePairs)
        {
            throw (new ActionDisabledError());
        }

        /// <summary>
        /// SetStateVariables action.
        /// </summary>
        /// <remarks>Will be called when the device stack receives an invocation of the
        /// SetStateVariables action for the owning device.
        ///
        /// Must be implemented iff EnableActionSetStateVariables was called.</remarks>
        /// <param name="aVersion">Version of the service being requested (will be <= the version advertised)</param>
        /// <param name="aInstanceID"></param>
        /// <param name="aRenderingControlUDN"></param>
        /// <param name="aServiceType"></param>
        /// <param name="aServiceId"></param>
        /// <param name="aStateVariableValuePairs"></param>
        /// <param name="aStateVariableList"></param>
        protected virtual void SetStateVariables(uint aVersion, uint aInstanceID, string aRenderingControlUDN, string aServiceType, string aServiceId, string aStateVariableValuePairs, out string aStateVariableList)
        {
            throw (new ActionDisabledError());
        }

        private static int DoListPresets(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string currentPresetNameList;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.ListPresets(aVersion, instanceID, out currentPresetNameList);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteString("CurrentPresetNameList", currentPresetNameList);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSelectPreset(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string presetName;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                presetName = invocation.ReadString("PresetName");
                invocation.ReadEnd();
                self.SelectPreset(aVersion, instanceID, presetName);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetBrightness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentBrightness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetBrightness(aVersion, instanceID, out currentBrightness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentBrightness", currentBrightness);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetBrightness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredBrightness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredBrightness = invocation.ReadUint("DesiredBrightness");
                invocation.ReadEnd();
                self.SetBrightness(aVersion, instanceID, desiredBrightness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetContrast(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentContrast;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetContrast(aVersion, instanceID, out currentContrast);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentContrast", currentContrast);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetContrast(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredContrast;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredContrast = invocation.ReadUint("DesiredContrast");
                invocation.ReadEnd();
                self.SetContrast(aVersion, instanceID, desiredContrast);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetSharpness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentSharpness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetSharpness(aVersion, instanceID, out currentSharpness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentSharpness", currentSharpness);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetSharpness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredSharpness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredSharpness = invocation.ReadUint("DesiredSharpness");
                invocation.ReadEnd();
                self.SetSharpness(aVersion, instanceID, desiredSharpness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetRedVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentRedVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetRedVideoGain(aVersion, instanceID, out currentRedVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentRedVideoGain", currentRedVideoGain);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetRedVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredRedVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredRedVideoGain = invocation.ReadUint("DesiredRedVideoGain");
                invocation.ReadEnd();
                self.SetRedVideoGain(aVersion, instanceID, desiredRedVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetGreenVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentGreenVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetGreenVideoGain(aVersion, instanceID, out currentGreenVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentGreenVideoGain", currentGreenVideoGain);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetGreenVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredGreenVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredGreenVideoGain = invocation.ReadUint("DesiredGreenVideoGain");
                invocation.ReadEnd();
                self.SetGreenVideoGain(aVersion, instanceID, desiredGreenVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetBlueVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentBlueVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetBlueVideoGain(aVersion, instanceID, out currentBlueVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentBlueVideoGain", currentBlueVideoGain);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetBlueVideoGain(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredBlueVideoGain;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredBlueVideoGain = invocation.ReadUint("DesiredBlueVideoGain");
                invocation.ReadEnd();
                self.SetBlueVideoGain(aVersion, instanceID, desiredBlueVideoGain);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetRedVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentRedVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetRedVideoBlackLevel(aVersion, instanceID, out currentRedVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentRedVideoBlackLevel", currentRedVideoBlackLevel);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetRedVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredRedVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredRedVideoBlackLevel = invocation.ReadUint("DesiredRedVideoBlackLevel");
                invocation.ReadEnd();
                self.SetRedVideoBlackLevel(aVersion, instanceID, desiredRedVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetGreenVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentGreenVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetGreenVideoBlackLevel(aVersion, instanceID, out currentGreenVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentGreenVideoBlackLevel", currentGreenVideoBlackLevel);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetGreenVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredGreenVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredGreenVideoBlackLevel = invocation.ReadUint("DesiredGreenVideoBlackLevel");
                invocation.ReadEnd();
                self.SetGreenVideoBlackLevel(aVersion, instanceID, desiredGreenVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetBlueVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentBlueVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetBlueVideoBlackLevel(aVersion, instanceID, out currentBlueVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentBlueVideoBlackLevel", currentBlueVideoBlackLevel);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetBlueVideoBlackLevel(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredBlueVideoBlackLevel;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredBlueVideoBlackLevel = invocation.ReadUint("DesiredBlueVideoBlackLevel");
                invocation.ReadEnd();
                self.SetBlueVideoBlackLevel(aVersion, instanceID, desiredBlueVideoBlackLevel);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetColorTemperature(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint currentColorTemperature;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetColorTemperature(aVersion, instanceID, out currentColorTemperature);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentColorTemperature", currentColorTemperature);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetColorTemperature(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            uint desiredColorTemperature;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredColorTemperature = invocation.ReadUint("DesiredColorTemperature");
                invocation.ReadEnd();
                self.SetColorTemperature(aVersion, instanceID, desiredColorTemperature);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetHorizontalKeystone(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            int currentHorizontalKeystone;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetHorizontalKeystone(aVersion, instanceID, out currentHorizontalKeystone);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteInt("CurrentHorizontalKeystone", currentHorizontalKeystone);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetHorizontalKeystone(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            int desiredHorizontalKeystone;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredHorizontalKeystone = invocation.ReadInt("DesiredHorizontalKeystone");
                invocation.ReadEnd();
                self.SetHorizontalKeystone(aVersion, instanceID, desiredHorizontalKeystone);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetVerticalKeystone(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            int currentVerticalKeystone;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                invocation.ReadEnd();
                self.GetVerticalKeystone(aVersion, instanceID, out currentVerticalKeystone);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteInt("CurrentVerticalKeystone", currentVerticalKeystone);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetVerticalKeystone(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            int desiredVerticalKeystone;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                desiredVerticalKeystone = invocation.ReadInt("DesiredVerticalKeystone");
                invocation.ReadEnd();
                self.SetVerticalKeystone(aVersion, instanceID, desiredVerticalKeystone);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetMute(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            bool currentMute;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                invocation.ReadEnd();
                self.GetMute(aVersion, instanceID, channel, out currentMute);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteBool("CurrentMute", currentMute);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetMute(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            bool desiredMute;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                desiredMute = invocation.ReadBool("DesiredMute");
                invocation.ReadEnd();
                self.SetMute(aVersion, instanceID, channel, desiredMute);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetVolume(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            uint currentVolume;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                invocation.ReadEnd();
                self.GetVolume(aVersion, instanceID, channel, out currentVolume);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteUint("CurrentVolume", currentVolume);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetVolume(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            uint desiredVolume;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                desiredVolume = invocation.ReadUint("DesiredVolume");
                invocation.ReadEnd();
                self.SetVolume(aVersion, instanceID, channel, desiredVolume);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetVolumeDB(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            int currentVolume;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                invocation.ReadEnd();
                self.GetVolumeDB(aVersion, instanceID, channel, out currentVolume);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteInt("CurrentVolume", currentVolume);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetVolumeDB(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            int desiredVolume;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                desiredVolume = invocation.ReadInt("DesiredVolume");
                invocation.ReadEnd();
                self.SetVolumeDB(aVersion, instanceID, channel, desiredVolume);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetVolumeDBRange(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            int minValue;
            int maxValue;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                invocation.ReadEnd();
                self.GetVolumeDBRange(aVersion, instanceID, channel, out minValue, out maxValue);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteInt("MinValue", minValue);
                invocation.WriteInt("MaxValue", maxValue);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetLoudness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            bool currentLoudness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                invocation.ReadEnd();
                self.GetLoudness(aVersion, instanceID, channel, out currentLoudness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteBool("CurrentLoudness", currentLoudness);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetLoudness(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string channel;
            bool desiredLoudness;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                channel = invocation.ReadString("Channel");
                desiredLoudness = invocation.ReadBool("DesiredLoudness");
                invocation.ReadEnd();
                self.SetLoudness(aVersion, instanceID, channel, desiredLoudness);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoGetStateVariables(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string stateVariableList;
            string stateVariableValuePairs;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                stateVariableList = invocation.ReadString("StateVariableList");
                invocation.ReadEnd();
                self.GetStateVariables(aVersion, instanceID, stateVariableList, out stateVariableValuePairs);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteString("StateVariableValuePairs", stateVariableValuePairs);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        private static int DoSetStateVariables(IntPtr aPtr, IntPtr aInvocation, uint aVersion)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            DvProviderUpnpOrgRenderingControl2 self = (DvProviderUpnpOrgRenderingControl2)gch.Target;
            DvInvocation invocation = new DvInvocation(aInvocation);
            uint instanceID;
            string renderingControlUDN;
            string serviceType;
            string serviceId;
            string stateVariableValuePairs;
            string stateVariableList;
            try
            {
                invocation.ReadStart();
                instanceID = invocation.ReadUint("InstanceID");
                renderingControlUDN = invocation.ReadString("RenderingControlUDN");
                serviceType = invocation.ReadString("ServiceType");
                serviceId = invocation.ReadString("ServiceId");
                stateVariableValuePairs = invocation.ReadString("StateVariableValuePairs");
                invocation.ReadEnd();
                self.SetStateVariables(aVersion, instanceID, renderingControlUDN, serviceType, serviceId, stateVariableValuePairs, out stateVariableList);
            }
            catch (ActionError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (PropertyUpdateError)
            {
                invocation.ReportError(501, "Invalid XML");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("         Only ActionError or PropertyUpdateError can be thrown by actions");
                return -1;
            }
            try
            {
                invocation.WriteStart();
                invocation.WriteString("StateVariableList", stateVariableList);
                invocation.WriteEnd();
            }
            catch (ActionError)
            {
                return -1;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("ERROR: unexpected exception {0}(\"{1}\") thrown by {2}", e.GetType(), e.Message, e.TargetSite.Name);
                Console.WriteLine("       Only ActionError can be thrown by action response writer");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            return 0;
        }

        /// <summary>
        /// Must be called for each class instance.  Must be called before Core.Library.Close().
        /// </summary>
        public virtual void Dispose()
        {
            DoDispose();
            GC.SuppressFinalize(this);
        }

        ~DvProviderUpnpOrgRenderingControl2()
        {
            DoDispose();
        }

        private void DoDispose()
        {
            lock (this)
            {
                if (iHandle == IntPtr.Zero)
                {
                    return;
                }
                DisposeProvider();
                iHandle = IntPtr.Zero;
            }
            iGch.Free();
        }
    }
}

