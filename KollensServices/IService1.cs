using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment5
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string findNearestStore(string zipcode, string storeName);

        [OperationContract]
        string[] Weather5day(string zipcode);
    }
}
