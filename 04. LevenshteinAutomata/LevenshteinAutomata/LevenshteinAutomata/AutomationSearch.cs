using LevenshteinAutomata;
using LevenshteinAutomata.FiniteAutomata;
using LevenshteinAutomata.PrefixTree;

namespace LevenshteinAutomata
{
    public static class AutomationSearch
    {
        public static IEnumerable<string> Search(string oriWord, int maxDist, Tree dict)
        {
            NFA nfa = NFA.CreateNFA(oriWord, maxDist);
            DFA dfa = SubsetEngine.SubsetConstruct(nfa);
            List<string> output = new List<string>();
            DFSserach(dfa, dfa.Start, dict.Root, output);
            return output;
        }

        private static void DFSserach(DFA dfa, int start, Node dictNode, List<string> output)
        {
            if (dfa.Final.Contains(start) && dictNode.End)
                output.Add(dictNode.Key);

            Set<char> inputs = new Set<char>();
            for (char ch = 'a'; ch <= 'z'; ++ch)
            {
                KeyValuePair<int, char> pair = new KeyValuePair<int, char>(start, ch);
                if (dfa.TransitionTable.ContainsKey(pair))
                {
                    inputs.Add(ch);
                    if (dictNode.Children.ContainsKey(ch))
                    {
                        DFSserach(dfa, dfa.TransitionTable[pair], dictNode.Children[ch], output);
                    }
                }
            }

            if (dfa.DefaultTransition.ContainsKey(start))
            {
                foreach (char input in dictNode.Children.Keys)
                {
                    if (!inputs.Contains(input))
                    {
                        DFSserach(dfa, dfa.DefaultTransition[start], dictNode.Children[input], output);
                    }
                }
            }
        }
    }
}
