using IMatchConstructor;

namespace IPatternConstructor
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
