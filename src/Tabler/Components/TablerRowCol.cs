using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerRowCol : TablerBaseComponent
    {
        [Parameter] public int Columns { get; set; } = 0;
        [Parameter] public int Xs { get; set; } = 0;
        [Parameter] public int Sm { get; set; } = 0;
        [Parameter] public int Md { get; set; } = 0;
        [Parameter] public int Lg { get; set; } = 0;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("col")
                .Add(BackgroundColor.GetColorClass("bg"))
                .Add(TextColor.GetColorClass("text"))
                .AddIf($"col-{Columns}", Columns > 0)
                .AddIf($"col-xs-{Xs}", Xs > 0)
                .AddIf($"col-sm-{Sm}", Sm > 0)
                .AddIf($"col-md-{Md}", Md > 0)
                .AddIf($"col-lg-{Lg}", Lg > 0);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}