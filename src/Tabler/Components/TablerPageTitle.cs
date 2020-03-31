using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerPageTitle : TablerBaseComponent
    {
        public TablerPageTitle()
        {
            _elementType = "h1";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("page-title")
                .Add(BackgroundColor.GetColorClass("bg"))
                .Add(TextColor.GetColorClass("text"));

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}