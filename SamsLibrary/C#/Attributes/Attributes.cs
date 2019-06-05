using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.Attributes
{

    public class Security
    {

        [AttributeUsage(AttributeTargets.Method)]
        public class AuthTestAttribute : Attribute
        {
            // could look up user for auth/permissions

        }


        //[AcceptVerbs(HttpVerbs.Post)]
        //[AuthorizeAction(EntityType = EntityTypeCode.PERSON, Function = AuthorizeAction.SAVE), ValidateAntiForgeryToken]
        [AuthTestAttribute]
        public void TestFunction()
        {
            // lets pretend this is a controller method.
        }
    }
}
