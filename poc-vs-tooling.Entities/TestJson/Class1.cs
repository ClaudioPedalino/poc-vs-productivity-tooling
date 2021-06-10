using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Entities.TestJson
{

    public class Widget
    {
        public string Debug { get; set; }
        public Window Window { get; set; }
        public Image Image { get; set; }
        public Text Text { get; set; }
    }

    public class Window
    {
        public string title { get; set; }
        public string name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Image
    {
        public string src { get; set; }
        public string name { get; set; }
        public int hOffset { get; set; }
        public int vOffset { get; set; }
        public string alignment { get; set; }
    }

    public class Text
    {
        public string data { get; set; }
        public int size { get; set; }
        public string style { get; set; }
        public string name { get; set; }
        public int hOffset { get; set; }
        public int vOffset { get; set; }
        public string alignment { get; set; }
        public string onMouseUp { get; set; }
    }

}
