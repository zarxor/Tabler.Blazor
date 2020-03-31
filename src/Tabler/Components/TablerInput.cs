using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerInput : TablerBaseComponent
    {
        public TablerInput()
        {
            _elementType = "input";
        }

        [Parameter] public string Type { get; set; } = "";
        [Parameter] public string Value { get; set; } = "";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
        }
    }
}