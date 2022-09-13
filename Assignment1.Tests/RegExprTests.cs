namespace Assignment1.Tests;

public class RegExprTests
{
  [Fact]
  public void TestName()
  {
    var list = new List<string> { "This-is.the best/string.you will  see" };

    var result = RegExpr.SplitLine(list);

    result.Should().BeEquivalentTo(new List<string> { "This", "is", "the", "best", "string", "you", "will", "see" });
  }
}
