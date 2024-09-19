using ApplicationUser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
     public  class UserService :IUserService
    {

        public UserService(IManagementApi managementApi)
        {
            
        }
    }
}
