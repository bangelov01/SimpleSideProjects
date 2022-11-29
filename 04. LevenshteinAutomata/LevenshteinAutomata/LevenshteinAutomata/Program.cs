using LevenshteinAutomata;
using LevenshteinAutomata.PrefixTree;

using System.Diagnostics;
using System.Text.RegularExpressions;

/*When given a word to search, Levenshtein Automaton will first created a NFA (nondeterministic finite automata) based on given word
and Max levenshtein distance, then transform the NFA to DFA (deterministic finite automata). After getting DFA, do depth-first-search in this DFA 
and use TRIE node to validate the jump between states in DFA duing the DFS. 
When reaching final states in DFA, the word we reach in TRIE at the same time would be one of the fuzzy search results.*/

Regex rgx = new Regex("[^a-zA-Z]");
IEnumerable<string> wordList = File.ReadAllLines(@"..\..\..\Data\WordLib.txt").ToList().Select(word => rgx.Replace(word, "").ToLowerInvariant());

const int MaxDist = 1;

IEnumerable<string> testWords = File.ReadAllLines(@"..\..\..\Data\TestCase_2_WordsToSearch.txt").ToList().Select(word => rgx.Replace(word, "").ToLowerInvariant());

Console.WriteLine("----Automaton----");

Tree dict = new Tree(wordList.GetEnumerator());

Stopwatch stopWatch = new Stopwatch();

stopWatch.Start();

foreach (string word in testWords)
{
    IEnumerable<string> results = AutomationSearch.Search(word, MaxDist, dict).Distinct();
    if (results.Count() > 0)
    {
        Console.WriteLine($"Results for {word} with Count: {results.Count()}: \r\n{string.Join("\r\n", results)}");
    }
}

stopWatch.Stop();

Console.WriteLine($"Max distance : {MaxDist}; Total time consumed(milisec): {stopWatch.ElapsedMilliseconds}");

Console.Write("\n\n");

Console.ReadKey();

Console.WriteLine("----Traditional----");

stopWatch.Reset();

stopWatch.Start();
foreach (string word in testWords)
{
    IEnumerable<string> results2 = TraditionalLevenshtein.Search(word, MaxDist, wordList.GetEnumerator());
    if (results2.Count() > 0)
    {
        Console.WriteLine($"Results for {word} with Count: {results2.Count()}: \r\n{string.Join("\r\n", results2)}");
    }
}
stopWatch.Stop();
Console.WriteLine($"Max distance : {MaxDist}; Total time consumed (milisec): {stopWatch.ElapsedMilliseconds}");

Console.ReadKey();

