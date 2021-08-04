using System;
using CommandLine;

namespace ScreenRuler
{
    public class Options
    {
        [Option('x', SetName = "basic", HelpText = "Set X coordinate of ruler.")]
        public int? X { get; set; }
        [Option('y', SetName = "basic", HelpText = "Set Y coordinate of ruler.")]
        public int? Y { get; set; }
        [Option("width", SetName = "basic", HelpText = "Set width of ruler.")]
        public int? Width { get; set; }
        [Option("height", SetName = "basic", HelpText = "Set height of ruler.")]
        public int? Height { get; set; }

        [Option("hwnd", SetName = "hwnd", HelpText = "Specify the handle to a window to be measured.")]
        public int? WindowHandle { get; set; }

        [Option('t', "title", SetName = "title", HelpText = "Specify the title of the window to be measured.")]
        public string WindowTitle { get; set; }
    }
}
