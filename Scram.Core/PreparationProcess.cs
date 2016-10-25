using StringPrep;
using SaslPrep = StringPrep.Profile.SaslPrep;

namespace Scram
{
  internal static class PreparationProcess
  {
    private static readonly IPreparationProcess SaslPreparationProcess = SaslPrep.PreparationProcess.Create();

    public static string Run(string input)
    {
      return SaslPreparationProcess.Run(input);
    }
  }
}
