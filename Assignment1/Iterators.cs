namespace Assignment1;

public static class Iterators
{
  public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
  {
    var output = new List<T>();

    foreach (var list in items)
    {
      foreach (var item in list)
      {
        yield return item;
      }
    }
  }

  public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
  {
    var output = new List<T>();

    foreach (var item in items)
    {
      var predicateResult = predicate(item);
      if (predicateResult)
      {
        yield return item;
      }
    }
  }
}
