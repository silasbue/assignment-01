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
}
