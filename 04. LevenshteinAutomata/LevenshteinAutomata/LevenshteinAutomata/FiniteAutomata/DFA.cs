using LevenshteinAutomata;
using state = System.Int32;
using input = System.Char;

namespace LevenshteinAutomata.FiniteAutomata
{
    public class DFA
    {
        private state _start;
        private Set<state> _final;
        private SortedList<KeyValuePair<state, input>, state> _transitionTable;
        private Dictionary<state, state> _defaultTransition;

        public DFA()
        {
            _final = new Set<state>();
            _defaultTransition = new Dictionary<state, state>();
            _transitionTable = new SortedList<KeyValuePair<state, input>, state>(new Comparer());
        }

        public state Start 
        { 
            get => _start;
            set => _start = value; 
        }

        public Set<state> Final => _final;

        public SortedList<KeyValuePair<state, input>, state> TransitionTable => _transitionTable;

        public Dictionary<state, state> DefaultTransition => _defaultTransition;

    }
}
