using System;
using System.IO;
using System.Linq;
using System.Text;
using MainFileDLL;

namespace FillFileDLL
{
    public class FillFile
    {
        private long file_size = 0;
        private int str_size = 0;
        private static Random random = new Random();

        public void fill(MainFile mainFile)
        {
            this.file_size = mainFile.Size;
            this.str_size = mainFile.Ssize;

            using (StreamWriter sw = new StreamWriter(File.Open(mainFile.Path, FileMode.Create), Encoding.Unicode))
            {
                int size = 2, step = 1;
                String str = "";

                while (size < file_size)
                {
                    str = getString(str_size);

                    if (!(step++ == 1))
                        str = "\r\n" + str;


                    if ((size + Encoding.Unicode.GetByteCount(str)) > file_size)
                    {
                        str = deleteSymbols(str, size, file_size);

                        if (str == "\r")
                            break;
                    }

                    size += Encoding.Unicode.GetByteCount(str);
                    sw.Write(str);
                }
            }
        }

        private String getString(int ssize)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, random.Next(1, ssize + 1)).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private String deleteSymbols(String str, int size, long fsize)
        {
            String copy = str;
            char[] array;

            while ((Encoding.Unicode.GetByteCount(copy) + size) > fsize)
            {
                array = new char[copy.Length - 1];
                copy.CopyTo(0, array, 0, copy.Length - 1);
                copy = new String(array);

                if (copy == "")
                    return "\r";
            }

            return copy;
        }
    }
}