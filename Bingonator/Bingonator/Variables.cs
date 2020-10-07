using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoWortGeber
{
    class Variables
    {
        public static List<Content> sections = new List<Content>();
        public static List<string> words = new List<string>();
        public static List<string> duplicates = new List<string>();

        public static string titleSection = "";

        public static Color blue = Color.FromArgb(12, 58, 120);

        public static List<Button> playButtons = new List<Button>();
        public static List<Button> createButtons = new List<Button>();
        public static List<Button> menuButtons = new List<Button>();
        public static List<Button> noListButtons = new List<Button>();
        public static List<Label> cornerLabels = new List<Label>();
    }
}
