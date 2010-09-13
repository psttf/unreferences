using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace RefCheck
{
  class Program
  {
    public static IEnumerable<string> GetUnreferenced(string content, string str)
    {
      return Regex.Matches(content, str).Cast<Match>().Select(match => match.Groups[1].Value).
        Where(val => Regex.Matches(content, val).Count <= 1).ToList();
    }

    static void Main(string[] args)
    {
      var reader = new StreamReader(args[0]);
      var content = reader.ReadToEnd();
      reader.Close();

      foreach (var lbl in GetUnreferenced(content, "\\\\label\\{(.*)\\}").Concat(GetUnreferenced(content, "label=(.*)(,|\\])")))
      {
        Console.WriteLine(lbl);
      }
    }
  }
}
