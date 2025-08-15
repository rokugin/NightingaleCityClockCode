using Microsoft.Xna.Framework.Graphics;
using NightingaleCityClockCode.Models;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace NightingaleCityClockCode;

internal class ModEntry : Mod {

    ClockTowerModel data => AssetManager.ClockTowerData.First().Value;

    public static ModConfig Config = new();

    public override void Entry(IModHelper helper) {
        Log.Init(Monitor);
        I18n.Init(helper.Translation);

        Config = helper.ReadConfig<ModConfig>();

        helper.Events.Content.AssetRequested += static (_, e) => AssetManager.OnAssetRequested(e);
        helper.Events.Content.AssetsInvalidated += static (_, e) => AssetManager.OnAssetInvalidated(e);
        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        helper.Events.Display.RenderedWorld += OnRenderedWorld;
        helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        helper.Events.Player.Warped += OnWarped;
    }

    private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e) {
        if (ClockHands.ClockTexture == null) {
            ClockHands.ClockTexture = Game1.content.Load<Texture2D>("Maps/suzukiPCClockTowerTilesheet");
            ClockHands.SetupClockVariables();
        }

        ClockHands.ShouldRender = Game1.player.currentLocation == Game1.getLocationFromName(data.LocationName);
    }

    private void OnWarped(object? sender, WarpedEventArgs e) {
        ClockHands.ShouldRender = e.NewLocation == Game1.getLocationFromName(data.LocationName);
    }

    private void OnRenderedWorld(object? sender, RenderedWorldEventArgs e) {
        ClockHands.RenderClockHands(e);
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e) {
        ConfigScreen.Setup(Helper, ModManifest);
    }

}