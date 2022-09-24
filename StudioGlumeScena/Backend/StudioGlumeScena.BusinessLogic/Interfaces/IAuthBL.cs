using StudioGlumeScena.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IAuthBL
    {
        public AuthenticatedResponse Login(LoginCredentialsVM loginCredentials);
    }
}
