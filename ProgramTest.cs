#if DEBUG
using System.Collections.Generic;
using NUnit.Framework;

//TODO: переделать тесты под BDD

namespace RefCheck
{
  [TestFixture]
  public class ProgramTest
  {
    [Test]
    public void TestGetUnreferenced()
    {
      Assert.AreEqual(new List<string> {"l:unrefd"},
        Program.GetUnreferenced("\\label{l:refd}\\label{l:unrefd}\\ref{l:refd}",
          "\\\\label\\{([A-Za-z0-9:_]*)\\}"));
      Assert.AreEqual(new List<string> { "l:unrefd1", "l:unrefd2", "l:unrefd3" },
        Program.GetUnreferenced("\\begin{lstlisting}[float,caption=XML-ляля,label=lst:hilbert_xml,escapechar=\\%]\n\\ref{lst:hilbert_xml}\n[label=l:unrefd1,label=l:refd1,label=l:refd2,label=l:unrefd2,label=l:unrefd3]\\ref{l:refd1}\\ref{l:refd2}",
          "label=([A-Za-z0-9:_]*)(,|\\])"));
    }
  }
}
#endif