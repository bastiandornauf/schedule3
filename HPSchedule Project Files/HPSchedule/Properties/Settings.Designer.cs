﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HPSchedule.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("23")]
        public int KalendarZeilenhöhe {
            get {
                return ((int)(this["KalendarZeilenhöhe"]));
            }
            set {
                this["KalendarZeilenhöhe"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string dbLocalServer {
            get {
                return ((string)(this["dbLocalServer"]));
            }
            set {
                this["dbLocalServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bdornauf")]
        public string dbLocalUser {
            get {
                return ((string)(this["dbLocalUser"]));
            }
            set {
                this["dbLocalUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("poly2312")]
        public string dbLocalPassword {
            get {
                return ((string)(this["dbLocalPassword"]));
            }
            set {
                this["dbLocalPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("schedule")]
        public string dbLocalDatabase {
            get {
                return ((string)(this["dbLocalDatabase"]));
            }
            set {
                this["dbLocalDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mysql.bastian-dornauf.de")]
        public string dbRemoteServer {
            get {
                return ((string)(this["dbRemoteServer"]));
            }
            set {
                this["dbRemoteServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("db38884_6")]
        public string dbRemoteUser {
            get {
                return ((string)(this["dbRemoteUser"]));
            }
            set {
                this["dbRemoteUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("YoojsS&&Hqf1")]
        public string dbRemotePassword {
            get {
                return ((string)(this["dbRemotePassword"]));
            }
            set {
                this["dbRemotePassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("db38886_6")]
        public string dbRemoteDatabase {
            get {
                return ((string)(this["dbRemoteDatabase"]));
            }
            set {
                this["dbRemoteDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool useRemoteDatabase {
            get {
                return ((bool)(this["useRemoteDatabase"]));
            }
            set {
                this["useRemoteDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int showDaysInDayview {
            get {
                return ((int)(this["showDaysInDayview"]));
            }
            set {
                this["showDaysInDayview"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\bdornauf\\Desktop\\invoices")]
        public string pathToInvoiceFiles {
            get {
                return ((string)(this["pathToInvoiceFiles"]));
            }
            set {
                this["pathToInvoiceFiles"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("server=localhost;User Id=bdornauf;password=poly2312;Persist Security Info=True;da" +
            "tabase=schedule")]
        public string scheduleConnectionString {
            get {
                return ((string)(this["scheduleConnectionString"]));
            }
        }
    }
}