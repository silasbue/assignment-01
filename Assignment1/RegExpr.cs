namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
  public static IEnumerable<string> SplitLine(IEnumerable<string> lines) => throw new NotImplementedException();

  public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

  public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();

  public static IEnumerable<(Uri url, string title)> Urls(string html)
  {
    var pattern = @"<a href=""(?<url>https?://[^\s""]+)""\s*(title=""(?<title>[^""]+)"")?>\s*(?<innerText>[^<]+)\s*</a>";

    var matches = Regex.Matches(html, pattern);

    foreach (Match match in matches)
    {
      var url = new Uri(match.Groups["url"].Value);
      var title = match.Groups["title"].Success ? match.Groups["title"].Value : match.Groups["innerText"].Value;

      yield return (url, title);
    }
  }
}
