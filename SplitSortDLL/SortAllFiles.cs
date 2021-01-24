using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MainFileDLL;

namespace SplitSortDLL
{
    public class SortAllFiles
    {
        public void sortAll(List<String> tmpfiles, MainFile mainFile)
        {
            int pointer = 0, step = 1;
            String mainfilename = Path.GetFileNameWithoutExtension(mainFile.Path);
            String filepath = Path.GetDirectoryName(mainFile.Path) + "\\" + mainfilename;
            StreamReader sr1 = null, sr2 = null;

            while (tmpfiles.Count != 1)
            {
                String tmpname = filepath + "tmp" + step++.ToString() + ".txt";
                StreamWriter sw = new StreamWriter(File.Open(tmpname, FileMode.Create), Encoding.Unicode);
                sr1 = new StreamReader(File.Open(tmpfiles[pointer], FileMode.Open), Encoding.Unicode);
                sr2 = new StreamReader(File.Open(tmpfiles[pointer + 1], FileMode.Open), Encoding.Unicode);

                fill(sr1, sr2, sw);

                sr1.Close();
                sr2.Close();
                sw.Close();

                File.Delete(tmpfiles[0]);
                File.Delete(tmpfiles[1]);
                tmpfiles.RemoveRange(0, 2);
                tmpfiles.Add(tmpname);
            }

            String directory = Path.GetDirectoryName(mainFile.Path);
            String file = Path.GetFileNameWithoutExtension(mainFile.Path);
            File.Move(tmpfiles[0], directory + file + "_result.txt");
        }

        private void fill(StreamReader sr1, StreamReader sr2, StreamWriter sw)
        {
            int step = 1;
            String str1, str2;

            str1 = sr1.ReadLine();
            str2 = sr2.ReadLine();

            while (true)
            {
                if (str1 == null)
                {
                    while (str2 != null)
                        str2 = getNextLine(step++, sw, str2, sr2);
                    break;
                }

                if (str2 == null)
                {
                    while (str1 != null)
                        str1 = getNextLine(step++, sw, str1, sr1);
                    break;
                }

                int res = String.Compare(str1, str2);

                if (res == -1 || res == 0)
                    str1 = getNextLine(step++, sw, str1, sr1);
                else
                    str2 = getNextLine(step++, sw, str2, sr2);
            }
        }

        private String getNextLine(int step, StreamWriter sw, String str, StreamReader sr)
        {
            if (step == 1)
                sw.Write(str);
            else
                sw.Write("\r\n" + str);

            return sr.ReadLine();
        }
    }
}