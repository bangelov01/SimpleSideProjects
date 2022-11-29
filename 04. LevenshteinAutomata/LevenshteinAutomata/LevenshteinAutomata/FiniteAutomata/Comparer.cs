using state = System.Int32;
using input = System.Char;

namespace LevenshteinAutomata.FiniteAutomata
{
    public class Comparer : IComparer<KeyValuePair<state, input>>
    {
        public int Compare(KeyValuePair<state, input> transition1, KeyValuePair<state, input> transition2)
        {
            if (transition1.Key == transition2.Key)
            {
                return transition1.Value.CompareTo(transition2.Value);
            }

            return transition1.Key.CompareTo(transition2.Key);
        }
    }
}
