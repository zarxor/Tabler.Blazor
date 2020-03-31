﻿using Microsoft.AspNetCore.Components.Rendering;

namespace Tabler.Components
{
    public class TablerButtonList : TablerBaseComponent
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var seq = 0;
            var cardClassBuilder = new ClassBuilder(Class)
                .Add("btn-list");

            builder.OpenElement(seq++, ElementType);
            builder.AddAttribute(seq++, "class", cardClassBuilder.ToString());
            builder.AddAttribute(seq++, "onclick", OnClick);
            builder.AddContent(seq++, ChildContent);
            builder.CloseElement();
        }
    }
}