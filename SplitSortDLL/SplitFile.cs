using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MainFileDLL;

namespace SplitSortDLL
{
    public class SplitFile
    {
        public List<String> split(MainFile mainFile)
        {
            List<String> list = new List<String>();
            String mainfilename = Path.GetFileNameWithoutExtension(mainFile.Path);
            String filepath = Path.GetDirectoryName(mainFile.Path) + "\\" + mainfilename + "t";

            using (StreamReader srmain = new StreamReader(File.Open(mainFile.Path, FileMode.Open), Encoding.Unicode))
            {
                int step = 1;
                bool check = true;
                while (check)
                {
                    String tmppath = filepath + step++.ToString() + ".txt";
                    list.Add(tmppath);
                    using (StreamWriter swtmp = new StreamWriter(File.Open(tmppath, FileMode.Create), Encoding.Unicode))
                    {
                        bool first = true;
                        int size = 0;
                        String str = "";

                        while ((size < mainFile.Onefilesize) && check)
                        {
                            if ((str = srmain.ReadLine()) != null)
                            {
                                if (first)
                                    first = false;
                                else
                                    str = "\r\n" + str;

                                size += Encoding.Unicode.GetByteCount(str);
                                swtmp.Write(str);
                            }
                            else
                            {
                                check = false;
                            }
                        }

                    }
                }
            }

            return list;
        }
    }
}