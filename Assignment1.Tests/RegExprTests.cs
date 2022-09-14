namespace Assignment1.Tests;

public class RegExprTests
{
  [Fact]
  public void splitLine_given_list_of__string_returns_words()
  {
    var list = new List<string> { "This-is.the best/string.you will  see", "tselkjt.sdf" };

    var result = RegExpr.SplitLine(list);

    result.Should().BeEquivalentTo(new List<string> { "This", "is", "the", "best", "string", "you", "will", "see", "tselkjt", "sdf" });
  }


  [Fact]
  public void reusolutions_given__returns_()
  {
    var input = "1920x1080, 1024x780-987x650";

    var result = RegExpr.Resolution(input);

    result.Should().BeEquivalentTo(new List<(int, int)> { (1920, 1080), (1024, 780), (987, 650) });
  }

  [Fact]
  public void Urls_given_html_with_url_and_title_returns_url_and_title()
  {
    var input = "<a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a>";

    var result = RegExpr.Urls(input);

    result.Should().BeEquivalentTo(new List<(Uri, string)> { (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language") });
  }

  [Fact]
  public void Urls_given_html_with_url_returns_url_and_innerText()
  {
    var input = "<a href=\"https://en.wikipedia.org/wiki/Formal_language\">formal language</a>";

    var result = RegExpr.Urls(input);

    result.Should().BeEquivalentTo(new List<(Uri, string)> { (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "formal language") });
  }

  [Fact]
  public void Urls_given_html_with_multiple_urls_returns_all_urls_and_title_or_innerText()
  {
    var input = "<a href=\"https://en.wikipedia.org/wiki/Formal_language\">formal language</a> <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a>";

    var result = RegExpr.Urls(input);

    result.Should().BeEquivalentTo(new List<(Uri, string)> { (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "formal language"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language") });
  }
}
