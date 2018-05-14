using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class Other
    {
        public void Other()
        {

        }


    }

    // How to add a function to another class seemlessly.
    partial class Convert
    {
        partial void ToLower(string val)
        {
            return val.ToLower();
        }

    }

}

