namespace Dungeon.Rendering
{
    public enum SortingLayer
    {
        UI,
        Foreground,
        Player,
        World,
        Background
    }

    public static class SortingLayerUtilities
    {
        /// <summary>
        /// The Default SortingLayer's Value
        /// </summary>
        /// <returns>Default SortingLayer's float value</returns>
        public static float DefaultValue()
        {
            return 0.0f;
        }

        /// <summary>
        /// The default SortingLayer
        /// </summary>
        /// <returns>Default Sorting Layer</returns>
        public static SortingLayer DefaultLayer()
        {
            return SortingLayer.Background;
        }

        /// <summary>
        /// Get the value of the Sorting Layer as a float
        /// </summary>
        /// <param name="layer">The layer to convert from</param>
        /// <returns>The float value of the Sorting layer</returns>
        public static float GetValue(SortingLayer layer)
        {
            switch (layer)
            {
                case SortingLayer.UI:
                    return 1.0f;
                case SortingLayer.Foreground:
                    return 0.75f;
                case SortingLayer.Player:
                    return 0.5f;
                case SortingLayer.World:
                    return 0.25f;
                case SortingLayer.Background:
                    return 0.0f;
                default:
                    return DefaultValue();
            }
        }

        /// <summary>
        /// Get the Sorting Layer corresponding to the given float value
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>The Sorting Layer that corresponds to the float value</returns>
        public static SortingLayer GetLayer(float value)
        {
            switch (value)
            {
                case 1.0f:
                    return SortingLayer.UI;
                case 0.75f:
                    return SortingLayer.Foreground;
                case 0.5f:
                    return SortingLayer.Player;
                case 0.25f:
                    return SortingLayer.World;
                case 0.0f:
                    return SortingLayer.Background;
                default:
                    return DefaultLayer();
            }
        }
    }
}