using MyFarm.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFarm.Core.Specifications
{
    public class UsersFarmSpecification : BaseSpecification<Farm>
    {

        public UsersFarmSpecification(string name) : base(f =>  f.Name != "dsf")
        {
        }   
    }
}
