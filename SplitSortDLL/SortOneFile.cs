using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SplitSortDLL
{
    public class SortOneFile
    {
        public void sortOne(List<String> files)
        {
            for (int i = 0; i < files.Count; i++)
                sort(files[i]);
        }

        private void sort(String filename)
        {
            String[] lines = File.ReadAllLines(filename, Encoding.Unicode);
            Array.Sort(lines, StringComparer.Ordinal);
            File.WriteAllLines(filename, lines, Encoding.Unicode);
        }
    }
}