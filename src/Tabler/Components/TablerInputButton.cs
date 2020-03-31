using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerInputButton : TablerButton
    {
        public TablerInputButton()
        {
            _elementType = "input";
        }

        [Parameter] public string Type { get; set; } = "button";
        [Parameter] public string Value { get; set; } = "";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            AfterOpenElement = (baseBuilder, baseSeq) =>
            {
                builder.AddAttribute(baseSeq++, "type", Type);
                builder.AddAttribute(baseSeq++, "value", Value);

                return baseSeq;
            };

            base.BuildRenderTree(builder);
        }
    }
}