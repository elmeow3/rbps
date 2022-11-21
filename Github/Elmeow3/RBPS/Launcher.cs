using System;
using CommandLine;

namespace Github.Elmeow3.RBPS
{
  class Launcher
  {
    static public void Main(string[] args)
    {
      
    }

    private class Options
    {
      private readonly bool _verbose;

      public Options(bool verbose)
      {
        _verbose = verbose;
      }

      [Option]
      public bool Verbose {get {return _verbose;}}
    }
  }
}