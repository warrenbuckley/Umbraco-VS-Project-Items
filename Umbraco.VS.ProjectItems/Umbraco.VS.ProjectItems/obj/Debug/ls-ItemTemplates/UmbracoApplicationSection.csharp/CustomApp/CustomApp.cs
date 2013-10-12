using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.businesslogic;
using umbraco.interfaces;

namespace $rootnamespace$
{
    /// <summary>
    /// Registers our custom Application Section in Umbraco.
    /// This is intentionally an empty class, as just used for registering the section
    /// 
    /// Documentation
    /// http://www.theoutfield.net/blog/2012/07/creating-custom-applications-and-trees-in-umbraco-48plus
    /// http://this.isfluent.com/2013/3/how-to-add-a-custom-application-to-umbraco-48/
    /// </summary>
    [Application("Custom App", "myCustomAppAlias", "my-icon.png")]
    public class $safeitemrootname$ : IApplication
    {

    }
}
