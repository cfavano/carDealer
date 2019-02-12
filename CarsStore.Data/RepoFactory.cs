using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Data
{
    public static class RepoFactory
    {
        public static ICarStoreRepo GetRepo()
        {
            switch (Settings.GetRepoMode())
            {
                case "ADO":
                    return new ADOCarRepo();

                case "PROD":
                    return new EFCarRepo() ;

                case "QA":
                    return new InMemoryCarRepo();

              
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}