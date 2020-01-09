using CinemaBookingSystem.Models;
using CinemaUnitTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CinemaUnitTest
{
    public class JsonReadTest
    {
        private string _filepath;
        public JsonReadTest(string filepath)
        {
            _filepath = filepath;
        }
        /// <summary>
        /// Method to parse Json TestCasesData from Json file & return its testCaseDataModel
        /// </summary>
        public CustomermodelList ParseJson2Model()
        {
            string jsonData;
            CustomermodelList testCaseDM = new CustomermodelList();
            try
            {
                //Json Data read
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    jsonData = reader.ReadToEnd();
                }
                testCaseDM = JsonConvert.DeserializeObject<CustomermodelList>(jsonData);
            }
            catch (System.Exception exe)
            {
                //handle & log exception
            }
            return testCaseDM;
        }

        /// <summary>
        /// Method to parse Json TestCasesData from Json file & return its testCaseDataModel
        /// </summary>
        public ModelTest ParseSecretJson2Model()
        {
            string jsonData;
            ModelTest secretCodeTest = new ModelTest();
            try
            {
                //Json Data read
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    jsonData = reader.ReadToEnd();
                }
                secretCodeTest = JsonConvert.DeserializeObject<ModelTest>(jsonData);
            }
            catch (System.Exception exe)
            {
                //handle & log exception
            }
            return secretCodeTest;
        }

        /// <summary>
        /// Method to parse Json TestCasesData from Json file & return its testCaseDataModel
        /// </summary>
        public UnBookTest ParseJsonUnBookModel()
        {
            string jsonData;
            UnBookTest unBookCodeTest = new UnBookTest();
            try
            {
                //Json Data read
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    jsonData = reader.ReadToEnd();
                }
                unBookCodeTest = JsonConvert.DeserializeObject<UnBookTest>(jsonData);
            }
            catch (System.Exception exe)
            {
                //handle & log exception
            }
            return unBookCodeTest;
        }

        
    }
}
