namespace NDice
{
    /// <summary>Interface for algorithm used to generate random number for rolling the die.static</summary>
    public interface IRandomizable
    {
        /// <summary>Gets a random int. The return value should not exceed maxValue</summary>
        /// <param name="maxValue">The maximum (exclusive value to be returned.</returns>
        /// <returns>A random integer.</returns>
        int Get(int maxValue);
    }
}