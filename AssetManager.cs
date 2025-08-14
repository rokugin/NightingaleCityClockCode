using NightingaleCityClockCode.Models;
using StardewModdingAPI.Events;
using StardewValley;

namespace NightingaleCityClockCode {
    internal static class AssetManager {

        static Dictionary<string, ClockTowerModel>? clockTowerData = null;
        public static Dictionary<string, ClockTowerModel> ClockTowerData {
            get {
                if (clockTowerData == null) {
                    clockTowerData = Game1.content.Load<Dictionary<string, ClockTowerModel>>("suzukiPC.NightingaleCity/ClockTowerData");
                }
                return clockTowerData!;
            }
        }

        internal static void OnAssetRequested(AssetRequestedEventArgs e) {
            if (e.NameWithoutLocale.IsEquivalentTo("suzukiPC.NightingaleCity/ClockTowerData")) {
                e.LoadFrom(() => new Dictionary<string, ClockTowerModel>(), AssetLoadPriority.Exclusive);
            }
        }

        internal static void OnAssetInvalidated(AssetsInvalidatedEventArgs e) {
            foreach (var name in e.NamesWithoutLocale) {
                if (name.IsEquivalentTo("suzukiPC.NightingaleCity/ClockTowerData")) {
                    clockTowerData = null;
                }
            }
        }

    }
}
