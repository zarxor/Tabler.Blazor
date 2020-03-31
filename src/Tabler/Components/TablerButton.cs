using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Tabler.Components
{
    public enum TablerButtonType
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
        [Parameter] public string ElementType { get; set; } = "button";
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Block { get; set; }
        [Parameter] public bool IsIcon { get; set; }
        [Parameter] public bool IsLoading { get; set; }
        [Parameter] public TablerButtonType Type { get; set; } = TablerButtonType.Default;
        [Parameter] public TablerButtonSize Size { get; set; } = TablerButtonSize.Default;



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
            var buttonClassBuilder = new ClassBuilder(Class)
                .Add("btn")
                .Add(BackgroundColor.GetColorClass("btn"))
                .AddIf("disabled", Disabled)
                .AddIf("btn-block", Block)
                .AddIf("btn-icon", IsIcon)
                .AddIf("btn-loading", IsLoading)
                .AddCompare("btn-pill", Type, TablerButtonType.Pill)
                .AddCompare("btn-square", Type, TablerButtonType.Square)
                .AddCompare("btn-lg", Size, TablerButtonSize.Large)
                .AddCompare("btn-sm", Size, TablerButtonSize.Small);

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", buttonClassBuilder.ToString());
            builder.AddAttribute(seq++, "onclick", OnClick);
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}