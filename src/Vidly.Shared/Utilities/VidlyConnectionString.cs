using System.Configuration;

namespace Vidly.Shared.Utilities
{
    public class VidlyConnectionString
    {
        /**********************************************************************************************************************************************************
         * The following shows an exmaple of coverting to an expression bodied member.
         * You can use an expression body definition whenever the logic for any supported member, such as a method or property, consists of a single expression.
         **********************************************************************************************************************************************************/
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["Vidly_OLTP"].ConnectionString;
    }
}
