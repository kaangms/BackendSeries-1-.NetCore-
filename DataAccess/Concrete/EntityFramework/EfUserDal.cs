﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            
                using (var context = new DbContext())                                               //*****sql query****///
                {
                var result = from operationClaim in context.OperationClaims                                 //from OperationClaims as operationClaim

                             join userOperationClaim in context.UserOperationClaims                        //inner join UserOperationClaims as userOperationClaim

                               on operationClaim.Id equals userOperationClaim.OperationClaimId            //on operationClaim.Id = userOperationClaim.OperationClaimId 

                             where userOperationClaim.UserId == user.Id                                  //where userOperationClaim.UserId == user.Id 




                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };


                return result.ToList();
                }
           
        }
    }
}
