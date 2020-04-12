namespace Tabler.Components
{
    public partial class TablerAlert : TablerBaseComponent
    {
        protected override string ClassNames => ClassBuilder
            .Add("alert")
            .Add(BackgroundColor.GetColorClass("alert"))
            .Add(TextColor.GetColorClass("text"))
            .ToString();
    }
}