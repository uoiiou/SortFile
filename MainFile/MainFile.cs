using System;

namespace MainFileDLL
{
    public class MainFile
    {
        private String path = "";
        private long size = 0;
        private int ssize = 0;
        private int onefilesize = 0;

        public String Path
        {
            get { return path; }

            set { path = value; }
        }

        public long Size
        {
            get { return size; }

            set { size = value; }
        }

        public int Ssize
        {
            get { return ssize; }

            set { ssize = value; }
        }

        public int Onefilesize
        {
            get { return onefilesize; }

            set { onefilesize = value; }
        }
    }
}