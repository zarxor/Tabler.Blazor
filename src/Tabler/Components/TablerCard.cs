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
    public class TablerCard : ComponentBase
    {
        [Parameter] public string ElementType { get; set; } = "div";
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public TablerColor Color { get; set; } = TablerColor.Primary;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter] public bool IsAside { get; set; }
        [Parameter] public TablerCardSize Size { get; set; } = TablerCardSize.Default;


        //[Parameter] public ICommand Command { get; set; }

        ///// <summary>
        /////     Command parameter.
        ///// </summary>
        //[Parameter]
        //public object CommandParameter { get; set; }

        //protected void OnClickHandler(MouseEventArgs ev)
        //{
        //    OnClick.InvokeAsync(ev);
        //    if (Command?.CanExecute(CommandParameter) ?? false) Command.Execute(CommandParameter);
        //}

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("card")
                .AddCompare("card-sm", Size, TablerCardSize.Small)
                .AddCompare("card-md", Size, TablerCardSize.Medium)
                .AddCompare("card-lg", Size, TablerCardSize.Large);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}