using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace Tabler.Components
{
    public abstract class TablerBaseComponent : ComponentBase
    {
        protected string _elementType = "div";
        protected Func<RenderTreeBuilder, int, int> AfterOpenElement = (builder, seq) => seq;

        [Parameter]
        public string ElementType
        {
            get => _elementType;
            set => _elementType = value;
        }

        [Parameter] public TablerColor TextColor { get; set; } = TablerColor.Default;
        [Parameter] public TablerColor BackgroundColor { get; set; } = TablerColor.Default;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Class { get; set; } = "";
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}