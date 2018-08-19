namespace NDice
{
    /// <summary>Interface all dice are derived from.</sumary>
    public interface IDie
    {
        int Sides { get; }
        int Current { get; }
        string CurrentLabel { get; }
        string[] Labels { get; }

        int Roll();
        string RollLabel();
    }
}