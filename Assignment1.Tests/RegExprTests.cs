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
}
