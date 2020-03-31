using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerRow : TablerBaseComponent
    {
        [Parameter] public bool Cards { get; set; }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("row")
                .Add(BackgroundColor.GetColorClass("bg"))
                .Add(TextColor.GetColorClass("text"))
                .AddIf("row-cards", Cards);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}