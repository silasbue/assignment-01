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
  public void splitLine_given_empty_list_returns_null()
  {
    var list = new List<string> { "" };

    var result = RegExpr.SplitLine(list);

    result.Should().BeEquivalentTo(new List<string> { });
  }


  [Fact]
  public void resolutions_given__returns_()
  {
    var input = "1920x1080, 1024x780-987x650";

    var result = RegExpr.Resolution(input);

    result.Should().BeEquivalentTo(new List<(int, int)> { (1920, 1080), (1024, 780), (987, 650) });
  }

  [Fact]
  public void resolutions_given__null__returns_null()
  {
    var input = "";

    var result = RegExpr.Resolution(input);

    result.Should().BeEquivalentTo(new List<(int, int)> { });
  }

  [Fact]
  public void resolutions_given__other_numbers__returns_resolution()
  {
    var input = "vi skal have et 1920x1080 for 500 kroner, men også 1024x780 til 300 kroner";

    var result = RegExpr.Resolution(input);

    result.Should().BeEquivalentTo(new List<(int, int)> { (1920, 1080), (1024, 780) });
  }

  [Fact]
  public void HTML_given_HTML_Return_inner_text_a()
  {
    var HTMLinput = "<div<p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
    var tag = "a";
    var result = RegExpr.InnerText(HTMLinput, tag);

    result.Should().BeEquivalentTo(new List<String> { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" });
  }

  [Fact]
  public void HTML_given_HTML_Return_inner_text_of_p()
  {
    var HTMLinput = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
    var tag = "p";
    var result = RegExpr.InnerText(HTMLinput, tag);

    result.Should().BeEquivalentTo(new List<String> { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." });
  }

  [Fact]
  public void innerText_given_HTML_and_tag_returns_only_inner_text()
  {
    var input = "<p>hello <i>world</i></p>";
    var tag = "p";
    var result = RegExpr.InnerText(input, tag);

    result.Should().BeEquivalentTo(new List<String> { "hello world" });
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
