namespace Assignment1.Tests;

public class IteratorsTests
{
  [Fact]
  public void Flatten_given_List_1_2_and_List_3_4_returns_List_1_2_3_4()
  {
    var collection = new List<List<int>>();
    collection.Add(new List<int> { 1, 2 });
    collection.Add(new List<int> { 3, 4 });

    var result = Iterators.Flatten(collection);

    result.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 4 });
  }


  [Fact]
  public void Flatten_given_List_1_2_and_List_3_4_2returns_List_1_2_3_4_2()
  {
    var collection = new List<List<int>>();
    collection.Add(new List<int> { 1, 2 });
    collection.Add(new List<int> { 3, 4, 2 });

    var result = Iterators.Flatten(collection);

    result.Should().BeEquivalentTo(new List<int> { 1, 2, 3, 4, 2 });
  }

  [Fact]
  public void Flatten_given_Empty_List_and_List_3_4_2returns_List_2_3_4()
  {
    var collection = new List<List<int>>();
    collection.Add(new List<int> { });
    collection.Add(new List<int> { 3, 4, 2 });

    var result = Iterators.Flatten(collection);

    result.Should().BeEquivalentTo(new List<int> { 2, 3, 4 });
  }

  [Fact]
  public void Filter_given_List_3_4_2_5_returns_List_2_4()
  {
    Predicate<int> even = Even;
    bool Even(int i) => i % 2 == 0;

    var list = new List<int> { 3, 4, 2, 5 };

    var result = Iterators.Filter<int>(list, even);

    result.Should().BeEquivalentTo(new List<int> { 2, 4 });
  }
}
