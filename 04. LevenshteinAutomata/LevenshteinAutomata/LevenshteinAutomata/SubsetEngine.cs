using state = System.Int32;
using input = System.Char;

using LevenshteinAutomata;
using LevenshteinAutomata.FiniteAutomata;

namespace LevenshteinAutomata
{
    public class SubsetEngine
    {
        private static int num = 0;

        public static DFA SubsetConstruct(NFA nfa)
        {
            ResetState();
            DFA dfa = new DFA();

            Set<Set<state>> markedStates = new Set<Set<state>>();
            Set<Set<state>> unmarkedStates = new Set<Set<state>>();

            Dictionary<Set<state>, state> dfaStateNumber = new Dictionary<Set<state>, state>();

            Set<state> nfaInitial = new Set<state>();
            nfaInitial.Add(nfa.Initial);

            Set<state> first = EpsilonClosure(nfa, nfaInitial);
            unmarkedStates.Add(first);

            state dfaInitial = GenNewState();
            dfaStateNumber[first] = dfaInitial;
            dfa.Start = dfaInitial;

            while (unmarkedStates.Count != 0)
            {
                Set<state> markedState = unmarkedStates.Choose();

                unmarkedStates.Remove(markedState);

                markedStates.Add(markedState);

                if (markedState.Where(state => nfa.Final.Contains(state)).Count() > 0)
                    dfa.Final.Add(dfaStateNumber[markedState]);

                IEnumerator<input> inputEnumerator = nfa.Inputs.GetEnumerator();

                while (inputEnumerator.MoveNext())
                {
                    Set<state> next = EpsilonClosure(nfa, nfa.Move(markedState, inputEnumerator.Current));
                    if (next.IsEmpty) continue;

                    if (!unmarkedStates.Contains(next) && !markedStates.Contains(next))
                    {
                        unmarkedStates.Add(next);
                        dfaStateNumber.Add(next, GenNewState());
                    }

                    if (inputEnumerator.Current != (char)NFA.Constants.Any && inputEnumerator.Current != (char)NFA.Constants.EpsilonAny)
                    {
                        KeyValuePair<state, input> transition = new KeyValuePair<state, input>(dfaStateNumber[markedState], inputEnumerator.Current);
                        dfa.TransitionTable[transition] = dfaStateNumber[next];
                    }
                    else
                    {
                        if (!dfa.DefaultTransition.ContainsKey(dfaStateNumber[markedState]))
                        {
                            dfa.DefaultTransition.Add(dfaStateNumber[markedState], dfaStateNumber[next]);
                        }
                    }
                }
            }

            return dfa;
        }

        private static Set<state> EpsilonClosure(NFA nfa, Set<state> states)
        {
            if (states.IsEmpty) return states;

            Stack<state> uncheckedStack = new Stack<state>(states);

            Set<state> epsilonClosure = states;

            while (uncheckedStack.Count != 0)
            {
                state t = uncheckedStack.Pop();

                int i = 0;

                foreach (input input in nfa.TransitionTable[t])
                {
                    if (input == (char)NFA.Constants.EpsilonAny)
                    {
                        state u = Array.IndexOf(nfa.TransitionTable[t], input, i);

                        if (!epsilonClosure.Contains(u))
                        {
                            epsilonClosure.Add(u);
                            uncheckedStack.Push(u);
                        }
                    }

                    i = i + 1;
                }
            }

            return epsilonClosure;
        }

        private static state GenNewState()
        {
            return num++;
        }

        private static void ResetState()
        {
            num = 0;
        }
    }
}
