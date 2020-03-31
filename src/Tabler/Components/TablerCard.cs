using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Tabler.Components
{
    public enum TablerCardSize
    {
        Default,
        Small,
        Medium,
        Large
    }

    public enum TablerCardStatusPosition
    {
        Left,
        Top,
        Bottom
    }

    public class TablerCard : TablerBaseComponent
    {
        //[Parameter] public bool IsAside { get; set; }
        [Parameter] public TablerCardSize Size { get; set; } = TablerCardSize.Default;
        [Parameter] public bool Stacked { get; set; }
        [Parameter] public TablerColor StatusTop { get; set; } = TablerColor.Default;
        [Parameter] public TablerColor StatusLeft { get; set; } = TablerColor.Default;
        [Parameter] public TablerColor StatusBottom { get; set; } = TablerColor.Default;
        [Parameter] public string Link { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public EventCallbackFactory EventCallbackFactory { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            EventCallbackFactory = new EventCallbackFactory();

            if (!string.IsNullOrWhiteSpace(Link))
                _elementType = "a";

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("card")
                .AddIf("card-stacked", Stacked)
                .Add(BackgroundColor.GetColorClass("bg"))
                .Add(TextColor.GetColorClass("text"))
                .AddCompare("card-sm", Size, TablerCardSize.Small)
                .AddCompare("card-md", Size, TablerCardSize.Medium)
                .AddCompare("card-lg", Size, TablerCardSize.Large);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());

            if (!string.IsNullOrWhiteSpace(Link))
            {
                builder.AddAttribute(seq++, "href", Link);
                OnClick = EventCallbackFactory.Create<MouseEventArgs>(this, args => NavigationManager.NavigateTo(Link));
            }

            builder.AddAttribute(seq++, "onclick", OnClick);

            AddStatus(builder, "top", StatusTop, ref seq);
            AddStatus(builder, "left", StatusLeft, ref seq);
            AddStatus(builder, "bottom", StatusBottom, ref seq);

            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }

        private void AddStatus(RenderTreeBuilder builder, string position, TablerColor color, ref int seq)
        {
            if (color != TablerColor.Default)
            {
                var cardClassBuilder = new ClassBuilder()
                    .Add($"card-status-{position}")
                    .Add(color.GetColorClass("bg"));

                builder.OpenElement(seq++, "div");
                builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
                builder.CloseElement();
            }
        }
    }
}