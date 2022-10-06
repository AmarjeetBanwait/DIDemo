using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DIDemo.Web.Extensions
{
    public static class EnvironmentExtension
    {
        public static bool IsDevelopment()
        {
            CompilationSection compilationSection = (CompilationSection)ConfigurationManager.GetSection(@"system.web/compilation");
            return compilationSection.Debug;
        }
    }
}