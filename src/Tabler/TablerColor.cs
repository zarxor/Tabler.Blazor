﻿using System;

namespace Tabler
{
    public enum TablerColor
    {
        Default,
        Blue,
        Azure,
        Indigo,
        Purple,
        Pink,
        Red,
        Orange,
        Yellow,
        Lime,
        Green,
        Teal,
        Cyan,
        White,
        Gray,
        GrayDark,
        Primary,
        Secondary,
        Success,
        Info,
        Warning,
        Danger,
        Light,
        Dark
    }

    public static class TablerColorsExtensions
    {
        public static string GetColorClass(this TablerColor colors, string type, bool outlined = false, string suffix = "")
        {
            var colorClass = $"{type}";
            if (outlined)
                colorClass += "-outlined";

            switch (colors)
            {
                case TablerColor.Default:
                    colorClass = "";
                    break;
                case TablerColor.GrayDark:
                    colorClass += $"-gray-dark";
                    break;
                default:
                    colorClass += $"-{Enum.GetName(typeof(TablerColor), colors)?.ToLower()}";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(suffix) && !string.IsNullOrWhiteSpace(colorClass))
            {
                colorClass += $"-{suffix}";
            }

            return colorClass;
        }
    }
}