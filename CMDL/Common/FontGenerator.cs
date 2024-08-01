using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CMDL.Common
{
    public static class FontGenerator
    {
        public static Font Regular(float fontSize,string fontFamily = Constants.FontFamily)
        {
            return new Font(fontFamily, fontSize);
        }

        public static Font Bold(float fontSize,string fontFamily = Constants.FontFamily)
        {
            return new Font(fontFamily, fontSize, FontStyle.Bold);
        }

        public static Font Underline(float fontSize,string fontFamily = Constants.FontFamily)
        {
            return new Font(fontFamily, fontSize, FontStyle.Underline);
        }
    }
}
