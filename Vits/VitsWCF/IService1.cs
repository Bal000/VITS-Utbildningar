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

        // Save operations for single objects.
        [OperationContract]
        void SaveReport(CompositeReport report);

        [OperationContract]
        void SaveOffice(CompositeOffice office);

        [OperationContract]
        void SaveMission(CompositeMission mission);

        [OperationContract]
        void SaveTrip(CompositeTrip trip);
        
        [OperationContract]
        void SaveTravelAdvances(CompositeTravelAdvances travelAdvances);

        [OperationContract]
        void SaveEmployee(CompositeEmployee employee);

        [OperationContract]
        void SaveExpense(CompositeExpense expense);

        [OperationContract]
        void SaveDeviation(CompositeDeviation deviation);

        [OperationContract]
        void SaveCountry(CompositeCountry country);

        [OperationContract]
        void SaveCostCenter(CompositeCostCenter costcenter);

        [OperationContract]
        void SaveSubsistence(CompositeSubsistence subsistence);

       
        //Get Single objects.

        [OperationContract]
        int GetCountryIdByName(string name);

        [OperationContract]
        CompositeEmployee GetEmployee(int eid);

        [OperationContract]
        CompositeMission GetMission(int mid);

        [OperationContract]
        int GetEmployeeByIdNumber(string idNumber);

        [OperationContract]
        CompositeOffice GetOffice(int oid);

        //Get methods for lists.
        [OperationContract]
        List<CompositeEmployee> GetEmployees();

        [OperationContract]
        List<CompositeExpense> GetExpenses();

        [OperationContract]
        List<CompositeCostCenter> GetCostCenter();

        [OperationContract]
        List<CompositeMission> GetMissionsByEid(int eid);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeOffice : Office
    {

    }

    [DataContract]
    public class CompositeEmployee : Employee
    {
        //string firstName = "";
        //string lastName = "";
        //string idNumber = "";
        //string adress = "";
        //string city = "";
        //string email = "";
        //string zipCode = "";
        //bool manager;
        //[DataMember]
        //public string FIRSTNAME
        //{
        // get { return firstName; }
        // set { firstName = value; }
        //}
        //[DataMember]
        //public string LASTNAME
        //{
        // get { return lastName; }
        // set { lastName = value; }
        //}
        //[DataMember]
        //public string EMAIL
        //{
        // get { return email; }
        // set { email = value; }
        //}
        // [DataMember]
        //public string ZIPCODE
        //{
        // get { return zipCode; }
        // set { zipCode = value; }
        //}
        // [DataMember]
        //public string CITY
        //{
        // get { return city; }
        // set { city = value; }
        //}
        // [DataMember]
        //public string IDNUMBER
        //{
        // get { return idNumber; }
        // set { idNumber = value; }
        //}
        // [DataMember]
        // public string ADRESS
        // {
        // get { return adress; }
        // set { adress = value; }
        // }
        // [DataMember]
        // public bool MANAGER
        // {
        // get { return manager; }
        // set { manager = value; }
        // }
    }

    [DataContract]
    public class CompositeCountry : Country
    {

    }

    [DataContract]
    public class CompositeSubsistence : Subsistence
    {

    }

    [DataContract]
    public class CompositeMission : Mission
    {

    }

    [DataContract]
    public class CompositeReport : Report
    {

    }

    [DataContract]
    public class CompositeTravelAdvances : TravelAdvances
    {

    }

    [DataContract]
    public class CompositeExpense : Expense
    {

    }

    [DataContract]
    public class CompositeCostCenter : CostCenter
    {

    }

    [DataContract]
    public class CompositeDeviation : Deviation
    {

    }
    [DataContract]
    public class CompositeTravelOrder : TravelOrder
    {

    }
    [DataContract]
    public class CompositeTravelMethod : TravelMethod
    {

    }
    [DataContract]
    public class CompositeTrip : Trip
    {

    }

}
