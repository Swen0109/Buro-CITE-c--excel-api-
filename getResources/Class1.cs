using System.Text.RegularExpressions;
using System.Text;

namespace getResources
{
    public class BasePage : Page
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hWriter = new HtmlTextWriter(sw);
            base.Render(hWriter);
            writer.Write(this.Localize(sb.ToString()));
        }

        private const string ResourceFileName = "Resource";
        private string Localize(string html)
        {
            MatchCollection matches = new Regex(@"Localize\(([^\))]*)\)", RegexOptions.Singleline | RegexOptions.Compiled).Matches(html);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                html = html.Replace(match.Value, GetGlobalResourceObject(ResourceFileName, match.Groups[1].Value).ToString());
            }
            return html;
        }
    }
}