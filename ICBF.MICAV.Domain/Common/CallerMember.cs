using System.Runtime.CompilerServices;

namespace ICBF.MICAV.Domain.Common
{
    public class CallerMember
    {
        public static string GetNameMethod([CallerMemberName] string caller = null)
        {
            return caller;
        }
        
        public static string GetClassName(dynamic model)
        {
            return model.GetType().ToString();
        }
    }
}