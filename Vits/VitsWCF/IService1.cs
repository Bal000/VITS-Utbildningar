using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VitsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void SaveReport(Report report);

        [OperationContract]
        void SaveOffice(Office office);

        [OperationContract]
        void SaveMission(Mission mission);

        [OperationContract]
        void SaveTrip(Trip trip);
        
        [OperationContract]
        void SaveTravelAdvances(TravelAdvances travelAdvances);

        [OperationContract]
        void SaveEmployee(Employee employee);

        [OperationContract]
        void SaveExpense(Expense expense);

        [OperationContract]
        void SaveDeviation(Deviation deviation);

        [OperationContract]
        void SaveCountry(Country country);

        [OperationContract]
        void SaveCostCenter(CostCenter costcenter);



        [OperationContract]
        List<Employee> GetEmployees();




        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
