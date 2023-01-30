using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;

namespace ReSharperPlugin.OptionPages;

[SettingsKey(
    Parent: typeof(EnvironmentSettings),
    Description: "Settings")]
public class Settings
{
    [SettingsEntry(DefaultValue: "// Copyright, All Rights Reserved.", Description: "Copyright notice")]
    public string CopyrightNotice;

    //todo: temporary solution to avoid duplication while it is still not quite clear how to access settings` page properties
    public const string TempCopyright = "// Copyright, All Rights Reserved.";
}
