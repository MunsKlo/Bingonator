using Bingonator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoWortGeber
{
    static class Variables
    {
        public static List<Content> sections = new List<Content>();
        public static List<string> words = new List<string>();
        public static List<string> duplicates = new List<string>();

        public static string titleSection = string.Empty;

        public static List<Button> playButtons = new List<Button>();
        public static List<Button> createButtons = new List<Button>();
        public static List<Button> menuButtons = new List<Button>();
        public static List<Button> noListButtons = new List<Button>();
        public static List<Label> dragLabels = new List<Label>();
        public static List<Label> cornerLabels = new List<Label>();
        public static List<Panel> borderPanels = new List<Panel>();

        public static List<Desktop> desktops = new List<Desktop>();

        public static Color disabledColor = Color.FromArgb(187, 194, 194);
        public static Color enabledColor = Color.White;
        public static Color blue = Color.FromArgb(12, 58, 120);
    }
}
