﻿using NightingaleCityClockCode.Integrations;
using StardewModdingAPI;

namespace NightingaleCityClockCode;

public class ConfigScreen {

    public static void Setup(IModHelper h, IManifest m) {
        var c = h.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

        if (c is null) return;

        c.Register(m, () => ModEntry.Config = new ModConfig(), () => h.WriteConfig(ModEntry.Config));

        c.AddBoolOption(m, () => ModEntry.Config.ShowConsoleLogs, v => ModEntry.Config.ShowConsoleLogs = v,
            I18n.Logs_Name);
    }

}