using Microsoft.AspNetCore.Components;

namespace Tabler.Components
{
    public abstract class TablerBaseComponent : ComponentBase
    {
        [Parameter] public TablerColor TextColor { get; set; } = TablerColor.Default;

        [Parameter] public TablerColor BackgroundColor { get; set; } = TablerColor.Default;
    }
}