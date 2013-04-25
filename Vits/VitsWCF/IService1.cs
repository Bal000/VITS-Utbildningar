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
        void SaveEmployee(CompositeEmployee employee);

        [OperationContract]
        void SaveExpense(Expense expense);

        [OperationContract]
        void SaveDeviation(Deviation deviation);

        [OperationContract]
        void SaveCountry(Country country);

        [OperationContract]
        void SaveCostCenter(CostCenter costcenter);



        [OperationContract]
        List<CompositeEmployee> GetEmployees();




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
    
}
