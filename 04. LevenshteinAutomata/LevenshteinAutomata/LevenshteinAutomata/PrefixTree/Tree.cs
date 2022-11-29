namespace LevenshteinAutomata.PrefixTree
{
    public class Tree
    {
        private Node _root;
        private IEnumerator<string> _iterator;
        public Tree(IEnumerator<string> iterator)
        {
            _root = new Node("");
            _iterator = iterator;

            BuildTree();
        }
        public Node Root => _root;
        private void BuildTree()
        {
            //Tree tree = new Tree();

            while (_iterator.MoveNext())
            {
                AddNode(_iterator.Current);
            }

            //return this;
        }
        private void AddNode(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            Node current = _root;

            for (int i = 0; i < word.Length; ++i)
            {
                if (!current.Children.ContainsKey(word[i]))
                {
                    current.Children.Add(word[i], new Node(word.Substring(0, i + 1)));
                }

                current = current.Children[word[i]];

                if (i == word.Length - 1)
                {
                    current.End = true;
                }
            }
        }
    }
}
