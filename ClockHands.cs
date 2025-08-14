using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework;
using NightingaleCityClockCode.Models;

namespace NightingaleCityClockCode;

public class ClockHands {

    public static Texture2D? ClockTexture;
    public static bool ShouldRender = false;

    static float hourRotation;
    static float minuteRotation;

    static Vector2 hourHandPosition;
    static Vector2 minuteHandPosition;
    static Vector2 nubPosition;

    static Rectangle hourHandTextureSource;
    static Rectangle minuteHandTextureSource;
    static Rectangle nubTextureSource;

    static Color hourColor = Color.White;
    static Color minuteColor = Color.White;
    static Color nubColor = Color.White;

    static Vector2 hourOrigin;
    static Vector2 minuteOrigin;
    static Vector2 nubOrigin;

    static float hourScale = 4f;
    static float minuteScale = 4f;
    static float nubScale = 4f;

    static int towerTileHeight = 10;

    static float hourDepth;
    static float minuteDepth;
    static float nubDepth;

    public static void SetupClockVariables() {
        ClockTowerModel data = AssetManager.ClockTowerData.First().Value;

        hourHandPosition = new Vector2(data.HourHandTilePosition!.x, data.HourHandTilePosition.y) * 64;
        minuteHandPosition = new Vector2(data.MinuteHandTilePosition!.x, data.MinuteHandTilePosition.y) * 64;
        nubPosition = new Vector2(data.NubTilePosition!.x, data.NubTilePosition.y) * 64;

        hourHandTextureSource = new Rectangle(data.HourHandTextureSourceLocation!.x, data.HourHandTextureSourceLocation.y,
            data.HourHandTextureSourceLocation.width, data.HourHandTextureSourceLocation.height);
        minuteHandTextureSource = new Rectangle(data.MinuteHandTextureSourceLocation!.x, data.MinuteHandTextureSourceLocation.y,
            data.MinuteHandTextureSourceLocation.width, data.MinuteHandTextureSourceLocation.height);
        nubTextureSource = new Rectangle(data.NubTextureSourceLocation!.x, data.NubTextureSourceLocation.y,
            data.NubTextureSourceLocation.width, data.NubTextureSourceLocation.height);

        hourOrigin = new Vector2(data.HourHandRotationOrigin!.x, data.HourHandRotationOrigin.y);
        minuteOrigin = new Vector2(data.MinuteHandRotationOrigin!.x, data.MinuteHandRotationOrigin.y);
        nubOrigin = new Vector2(data.NubOrigin!.x, data.NubOrigin.y);

        hourDepth = (float)((hourHandPosition.Y + towerTileHeight) * 64) / 10000f + 0.0001f;
        minuteDepth = (float)((minuteHandPosition.Y + towerTileHeight) * 64) / 10000f + 0.00011f;
        nubDepth = (float)((nubPosition.Y + towerTileHeight) * 64) / 10000f + 0.00012f;
    }

    public static void RenderClockHands(RenderedWorldEventArgs e) {
        if (!ShouldRender) return;

        SpriteBatch b = e.SpriteBatch;

        var adjustedHours = Game1.timeOfDay / 100;
        var adjustedMinutes = Game1.timeOfDay % 100 / 60f;

        hourRotation =
            (float)Math.Tau * ((adjustedHours + adjustedMinutes) % 12 / 12 + Game1.gameTimeInterval / (float)Game1.realMilliSecondsPerGameTenMinutes / 72);
        minuteRotation = (float)Math.Tau * (adjustedMinutes + Game1.gameTimeInterval / (float)Game1.realMilliSecondsPerGameTenMinutes / 6);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, hourHandPosition),
            hourHandTextureSource,
            hourColor,
            hourRotation,
            hourOrigin,
            hourScale,
            SpriteEffects.None,
            hourDepth);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, minuteHandPosition),
            minuteHandTextureSource,
            minuteColor,
            minuteRotation,
            minuteOrigin,
            minuteScale,
            SpriteEffects.None,
            minuteDepth);

        b.Draw(ClockTexture,
            Game1.GlobalToLocal(Game1.viewport, nubPosition),
            nubTextureSource,
            nubColor,
            0f,
            nubOrigin,
            nubScale,
            SpriteEffects.None,
            nubDepth);
    }

}