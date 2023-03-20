using Data;
using Entities.Entities;
using Logic.Ilogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class RolLogic : BaseContextLogic, IRolLogic
    {
        public RolLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public void InsertUserRol(UserRol userRol)
        {
            _serviceContext.Rols.Add(userRol);
            _serviceContext.SaveChanges();
        }
    

    }
}
