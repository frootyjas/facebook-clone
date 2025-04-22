
using System.Drawing.Text;


namespace facebook_clone
{
    public static class FontHelper
    {
        private static readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();
        private static FontFamily _fontFamily;

        static FontHelper()
        {
            LoadFont(Path.Combine(Application.StartupPath, "Fonts", "font.ttf"));
        }

        public static void LoadFont(string fontPath)
        {
            _fontCollection.AddFontFile(fontPath);
            _fontFamily = _fontCollection.Families[0];
        }

        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(_fontFamily, size, style);
        }
    }
}