using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public enum TablerAvatarSize
    {
        Default,
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public enum TablerAvatarRounded
    {
        Default,
        Rounded,
        RoundedSmall,
        RoundedLarge,
        Circle,
        None
    }

    public class TablerAvatar : TablerBaseComponent
    {
        public TablerAvatar()
        {
            _elementType = "span";
        }

        [Parameter] public string Url { get; set; } = "";
        [Parameter] public TablerAvatarSize Size { get; set; } = TablerAvatarSize.Default;
        [Parameter] public TablerAvatarRounded Rounded { get; set; } = TablerAvatarRounded.Default;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("avatar")
                .Add(BackgroundColor.GetColorClass("bg", suffix: "lt"))
                .Add(TextColor.GetColorClass("text"))
                .AddCompare(Size, new Dictionary<TablerAvatarSize, string>
                {
                    { TablerAvatarSize.Small, "avatar-sm" },
                    { TablerAvatarSize.Medium, "avatar-md" },
                    { TablerAvatarSize.Large, "avatar-lg" },
                    { TablerAvatarSize.ExtraLarge, "avatar-xl" }
                })
                .AddCompare(Rounded, new Dictionary<TablerAvatarRounded, string>
                {
                    { TablerAvatarRounded.RoundedSmall, "rounded-sm" },
                    { TablerAvatarRounded.Rounded, "rounded" },
                    { TablerAvatarRounded.RoundedLarge, "rounded-lg" },
                    { TablerAvatarRounded.Circle, "rounded-circle" },
                    { TablerAvatarRounded.None, "rounded-0" }
                });

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());

            if (string.IsNullOrWhiteSpace(Url))
            {
                builder.AddContent(seq++, ChildContent);
            }
            else
            {
                builder.AddAttribute(seq++, "style", $"background-image: url('{Url}')");
            }

            builder.CloseElement();
        }
    }
}