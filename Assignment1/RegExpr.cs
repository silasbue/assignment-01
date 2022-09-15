namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
  public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
  {
    var pattern = @"\w+[a-z0-9A-Z]";
    var myRegex = new Regex(pattern);

    var input = new List<String>(lines);
    var ans = new List<String>();
    string combinedString = string.Join(" ", input);

    foreach (Match m in myRegex.Matches(combinedString))
    {
      yield return m.ToString();
    }
  }

  public static IEnumerable<(int width, int height)> Resolution(string resolutions)
  {
    var pattern = @"(?<width>\d+)x(?<height>\d+)";
    var myRegex = new Regex(pattern);

    var output = new List<(int, int)>();

    foreach (Match m in myRegex.Matches(resolutions))
    {
      var width = m.Groups["width"].Value;
      var height = m.Groups["height"].Value;
      yield return (Int32.Parse(width), Int32.Parse(height));
    }
  }

  public static IEnumerable<string> InnerText(string html, string tag)
  {
    var pattern = $@"<{tag}.*?>(?<text>.*?)</{tag}>";
    var myRegex = new Regex(pattern);

    var output = new List<String>();

    foreach (Match m in myRegex.Matches(html))
    {
      var text = m.Groups["text"].Value;
      yield return text;
    }
  }

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
