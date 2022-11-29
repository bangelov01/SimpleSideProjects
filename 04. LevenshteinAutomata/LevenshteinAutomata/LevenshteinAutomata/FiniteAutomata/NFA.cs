using C5;
using LevenshteinAutomata;

using state = System.Int32;
using input = System.Char;

namespace LevenshteinAutomata.FiniteAutomata
{
    public class NFA
    {
        private state _initial;
        private Set<state> _final;
        private SortedArray<input> _inputs;
        private input[][] _transitionTable;

        private int _size;
        public enum Constants
        {
            EpsilonAny = 'ε',   //In Levenshtein NFA, the Epsilon edge is always also an Any edge.
            None = '\0',
            Any = 'θ'
        }

        public state Initial => _initial;

        public Set<state> Final => _final;

        public SortedArray<input> Inputs => _inputs;

        public input[][] TransitionTable => _transitionTable;

        private NFA()
        {

        }

        private NFA(int size, state initial, Set<state> final)
        {
            _initial= initial;
            _final= final;
            _size = size;

            _inputs = new SortedArray<input>();
            _transitionTable = new input[_size][];

            for (int i = 0; i < _size; ++i)
            {
                _transitionTable[i] = new input[_size];
            }
        }

        public static NFA CreateNFA(string str, int maxDistance)
        {
            int width = str.Length + 1;
            int height = maxDistance + 1;
            int size = width * height;

            Set<state> final = new Set<state>();

            for (int i = 1; i <= height; ++i)
            {
                final.Add(i * width - 1);
            }

            NFA nfa = new NFA(size, 0, final);

            for (int e = 0; e < height; ++e)
            {
                for (int i = 0; i < width - 1; ++i)
                {
                    nfa.AddTransition(e * width + i, e * width + i + 1, str[i]);
                    if (e < (height - 1))
                    {
                        nfa.AddTransition(e * width + i, (e + 1) * width + i, (char)Constants.Any);
                        nfa.AddTransition(e * width + i, (e + 1) * width + i + 1, (char)Constants.EpsilonAny);
                    }
                }
            }

            for (int k = 1; k < height; ++k)
            {
                nfa.AddTransition(k * width - 1, (k + 1) * width - 1, (char)Constants.Any);
            }
            return nfa;
        }

        public Set<state> Move(Set<state> states, input inp)
        {
            Set<state> result = new Set<state>();

            bool needNormalLetter = false;
            bool findNormalLetter = false;

            if (inp != (char)NFA.Constants.Any && inp != (char)NFA.Constants.EpsilonAny)
            {
                needNormalLetter = true;
            }

            foreach (state state in states)
            {
                for (int j = 0; j < _size; ++j)
                {
                    if (_transitionTable[state][j] == inp || _transitionTable[state][j] == (char)NFA.Constants.Any || _transitionTable[state][j] == (char)NFA.Constants.EpsilonAny)
                    {
                        if (needNormalLetter && _transitionTable[state][j] == inp) findNormalLetter = true;
                        result.Add(j);
                    }
                }
            }

            if (needNormalLetter && !findNormalLetter) result.Clear();
            return result;
        }

        private void AddTransition(state from, state to, input inp)
        {
            _transitionTable[from][to] = inp;
            _inputs.Add(inp);
        }
    }
}
