namespace LevenshteinAutomata.PrefixTree
{
    public class Node
    {
        private Dictionary<char, Node> _children;
        private string _key;
        private bool _end;

        public Node(string key)
        {
            _children = new Dictionary<char, Node>();
            _key = key;
            _end = false;
        }
        public Dictionary<char, Node> Children => _children;
        public string Key => _key;
        public bool End { 
            get => _end; 
            set => _end = value; 
        }
    }
}
