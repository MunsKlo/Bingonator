using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoWortGeber
{
    class Content
    {
        public string Title { get; set; }
        public string ShortTItle { get; set; }
        public List<string> WordList { get; set; }

        public Content(string title, List<string> wordList)
        {
            Title = title;
            WordList = wordList;
        }

        public Content()
        {

        }
    }
}
