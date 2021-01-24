using System;
using System.Collections.Generic;
using FillFileDLL;
using MainFileDLL;
using SplitSortDLL;

namespace LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            while (i == 1)
            {
                MainFile mainfile = new MainFile();
                readInfoAboutFile(mainfile);

                Console.WriteLine("Start - " + DateTime.Now);

                FillFile fillFile = new FillFile();
                fillFile.fill(mainfile);

                SplitFile splitFile = new SplitFile();
                List<String> filesname = splitFile.split(mainfile);

                SortOneFile sortOneFile = new SortOneFile();
                sortOneFile.sortOne(filesname);

                SortAllFiles sortAllFiles = new SortAllFiles();
                sortAllFiles.sortAll(filesname, mainfile);

                Console.WriteLine("Stop - " + DateTime.Now + "\n");
                Console.Write("1 - One more time\n0 - Exit\nYour decision - ");
                i = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }

        private static void readInfoAboutFile(MainFile mf)
        {
            Console.Write("Enter absolute filepath - ");
            mf.Path = Console.ReadLine();

            Console.Write("Enter file size(bytes) - ");
            mf.Size = long.Parse(Console.ReadLine());

            Console.Write("Enter one file size(bytes) - ");
            mf.Onefilesize = int.Parse(Console.ReadLine());

            Console.Write("Enter max string size(letters count) - ");
            mf.Ssize = int.Parse(Console.ReadLine());
        }
    }
}