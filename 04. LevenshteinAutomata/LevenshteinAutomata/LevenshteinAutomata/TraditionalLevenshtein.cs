namespace LevenshteinAutomata
{
    public static class TraditionalLevenshtein
    {
        public static IEnumerable<string> Search(string word, int distance, IEnumerator<string> iterator)
        {
            List<string> results = new List<string>();
            while (iterator.MoveNext())
            {
                if (iterator.Current.Length > 0 && calculateDistance(word, iterator.Current) <= distance)
                {
                    results.Add(iterator.Current);
                }
            }
            return results;
        }

        public static int calculateDistance(string source1, string source2) //O(n*m)
        {
            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            if (source1Length == 0)
                return source2Length;

            if (source2Length == 0)
                return source1Length;

            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }

            return matrix[source1Length, source2Length];
        }

        //private static int calculateDistance(string s, string t)
        //{
        //    int n = s.Length;
        //    int m = t.Length;

        //    int[,] d = new int[n + 1, m + 1];

        //    int cost;

        //    if (n == 0) return m;
        //    if (m == 0) return n;

        //    for (int i = 0; i <= n; d[i, 0] = i++) ;
        //    for (int j = 0; j <= m; d[0, j] = j++) ;
        //    for (int i = 1; i <= n; i++)
        //    {
        //        for (int j = 1; j <= m; j++)
        //        {
        //            cost = (t[j - 1] == s[i - 1] ? 0 : 1);
        //            d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
        //                      d[i - 1, j - 1] + cost);
        //        }
        //    }
        //    return d[n, m];
        //}
    }
}
