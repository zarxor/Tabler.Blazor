using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public enum TablerButtonShape
    {
        Default,
        Square,
        Pill
    }

    public enum TablerButtonSize
    {
        Default,
        Large,
        Small
    }

    public class TablerButton : TablerBaseComponent
    {
        public TablerButton()
        {
            _elementType = "button";
        }

        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Block { get; set; }
        [Parameter] public bool IsIcon { get; set; }
        [Parameter] public bool IsLoading { get; set; }
        [Parameter] public bool BackgroundColorOutlined { get; set; }
        [Parameter] public TablerButtonShape Shape { get; set; } = TablerButtonShape.Default;
        [Parameter] public TablerButtonSize Size { get; set; } = TablerButtonSize.Default;
        [Parameter] public string Href { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var buttonClassBuilder = new ClassBuilder(Class)
                .Add("btn")
                .Add(BackgroundColor.GetColorClass("btn", BackgroundColorOutlined))
                .Add(TextColor.GetColorClass("text"))
                .AddIf("disabled", Disabled)
                .AddIf("btn-block", Block)
                .AddIf("btn-icon", IsIcon)
                .AddIf("btn-loading", IsLoading)
                .AddCompare("btn-pill", Shape, TablerButtonShape.Pill)
                .AddCompare("btn-square", Shape, TablerButtonShape.Square)
                .AddCompare("btn-lg", Size, TablerButtonSize.Large)
                .AddCompare("btn-sm", Size, TablerButtonSize.Small);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", buttonClassBuilder.ToString());
            if (ElementType.Equals("a", StringComparison.InvariantCultureIgnoreCase))
            {
                builder.AddAttribute(seq++, "role", "button");
                builder.AddAttribute(seq++, "href", Href);
            }

            seq = AfterOpenElement(builder, seq);
            //else if (ElementType.Equals("input", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    builder.AddAttribute(seq++, "value", InputValue);
            //    builder.AddAttribute(seq++, "type", InputType);
            //}

            builder.AddAttribute(seq++, "onclick", OnClick);
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}