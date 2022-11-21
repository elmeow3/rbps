using System;
using CommandLine;
using CommandLine.Text;

namespace Github.Elmeow3.RBPS
{
  class Launcher
  {
    static public void Main(string[] args)
    {
      Parser parser = new Parser(with => with.EnableDashDash = true);
      parser.ParseArguments<Options>(args).WithParsed(options => new Launcher(options));
    }

    public Launcher(Options options)
    {
      
    }

    private class Options
    {
      private readonly bool _verbose;
      private readonly bool _merge;
      private readonly IEnumerable<string> _output;
      private readonly IEnumerable<string> _patchFiles;

      public Options(bool verbose, bool merge, IEnumerable<string> patchFiles, IEnumerable<string> output)
      {
        _verbose = verbose;
        _merge = merge;
        _patchFiles = patchFiles;
        _output = output;
      }

      [Option(ShortName = 'v', LongName = "verbose", Required = false, HelpText = "Verbose output")]
      public bool Verbose {get {return _verbose;}}

      [Option(ShortName = 'm', LongName = "merge", HelpText = "Merge patch files into one")]
      public bool Merge {get {return _merge;}}

      [Value(1, Required = true, Min = 1, HelpText = "Patch files")]
      public IEnumerable<string> PatchFiles {get {return _patchFiles;}}

      [Option(ShortName = 'o', LongName = "output", Required = false, Min = 1, Max = 1, HelpText = "Change output file name")]

      [Usage(ApplicationAlias = "rpbs")]
      public static IEnumerable<Example> Examples
      {
        get
        {
          return new List<Example>()
          {
            new Example("Merge patches into one file", new Options(false, true, new List<string>() {"foo.rbps", "bar.rbps", "baz.rbps"}, null)),
            new Example("Apply patches to file", new Options(false, false, new List<string>() {"target.bin", "foo.rbps", "bar.rbps", "baz.rbps"}, null)),
            new Example("Choose output file name", new Options(false, false, new List<string>() {"target.bin", "foobarbaz.rbps"}, new List<string>() {"firmware.bin"}))
          };
        }
      }
    }
  }
}