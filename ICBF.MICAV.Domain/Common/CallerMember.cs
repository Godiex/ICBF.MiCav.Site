using System.Runtime.CompilerServices;

namespace ICBF.MICAV.Domain.Common
{
    public class CallerMember
    {
        public static string GetName([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}