namespace NightingaleCityClockCode.Models {
    public sealed class ClockTowerModel {

        public string? LocationName { get; set; }
        public NubTilePosition? TilePosition { get; set; }
        public HourHandTextureSourceLocation? HourHandTextureSourceLocation { get; set; }
        public MinuteHandTextureSourceLocation? MinuteHandTextureSourceLocation { get; set; }
        public NubTextureSourceLocation? NubTextureSourceLocation { get; set; }
        public HourHandRotationOrigin? HourHandRotationOrigin { get; set; }
        public MinuteHandRotationOrigin? MinuteHandRotationOrigin { get; set; }
        public NubOrigin? NubOrigin { get; set; }
        public float HourHandScale { get; set; }
        public float MinuteHandScale { get; set; }
        public float NubScale { get; set; }

    }

    public class HourHandTilePosition {
        public float x;
        public float y;
    }

    public class MinuteHandTilePosition {
        public float x;
        public float y;
    }

    public class NubTilePosition {
        public float x;
        public float y;
    }

    public class HourHandTextureSourceLocation {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    public class MinuteHandTextureSourceLocation {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    public class NubTextureSourceLocation {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    public class HourHandRotationOrigin {
        public float x;
        public float y;
    }

    public class MinuteHandRotationOrigin {
        public float x;
        public float y;
    }

    public class NubOrigin {
        public float x;
        public float y;
    }

}
