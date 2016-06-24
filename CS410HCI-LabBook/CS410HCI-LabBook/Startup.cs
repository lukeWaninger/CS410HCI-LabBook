using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS410HCI_LabBook.Startup))]
namespace CS410HCI_LabBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
