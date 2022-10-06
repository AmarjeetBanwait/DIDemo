using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DIDemo.Web
{
    public partial class Contact : Page
    {
        public IConfiguration Configuration { get; set; }
        public Contact(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Name { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Name = Configuration["Name"];
        }
    }
}