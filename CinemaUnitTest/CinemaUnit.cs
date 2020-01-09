using Cinema.DAL.Models;
using Cinema.Repositories.Repository;
using CinemaBookingSystem.Controllers;
using CinemaBookingSystem.Models;
using CinemaUnitTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaUnitTest
{
    [TestClass]
    public class CinemaUnit
    {

        private IGenericRepository<TblBookingSeat> repository = null;
        private IGenericRepository<TblCustomer> repositoryCustomer = null;
        private IGenericRepository<TblErrorLog> repositoryErrorLog = null;
        static string _testCasesBookSeatFilePath = @".\TestJsonData\DataJson.json";
        static string _testCasesSecretFilePath = @".\TestJsonData\SecretCodeJson.json";
        static string _testCaseUnBookFilePath = @".\TestJsonData\UnBookData.json";

        //******************Test Case For Cinema Index Method******************//
        [TestMethod]
        public void CinemaControllerIndex()
        {
            this.repository = new GenericRepository<TblBookingSeat>();
            this.repositoryCustomer = new GenericRepository<TblCustomer>();
            this.repositoryErrorLog = new GenericRepository<TblErrorLog>();

            CinemaController cinemaController = new CinemaController(repository, repositoryCustomer, repositoryErrorLog);
            ViewResult result = cinemaController.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        //******************Test Case For Match Secret Code Method******************//
        [DataTestMethod]
        [DataRow(1, "48575")]
        [DataRow(2, "9546")]
        [DataRow(3, "45921")]
        public void CinemaControllerMatchSecretCode(int TicketId, string SecretCode)
        {
            this.repository = new GenericRepository<TblBookingSeat>();
            this.repositoryCustomer = new GenericRepository<TblCustomer>();
            this.repositoryErrorLog = new GenericRepository<TblErrorLog>();


            CinemaController cinemaController = new CinemaController(repository, repositoryCustomer, repositoryErrorLog);
            JsonResult result = cinemaController.CheckSecretCode(SecretCode, TicketId) as JsonResult;
            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// This Method is For Getting UnBookingSeat Data From Json File & Return Parsed Data To TestMethod.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetUnBookSeatData()
        {
            var unBookDataList = new JsonReadTest(_testCaseUnBookFilePath).ParseJsonUnBookModel().UnBookModel;
            //yield return testDataList;
            foreach (var testData in unBookDataList)
            {
                yield return new object[] {
                       testData
                };
            }
        }

        /// <summary>
        /// This Method Is For Getting Booking Data From Json File & Return Parsed Data To TestMethod.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetData()
        {
            var testDataList = new JsonReadTest(_testCasesBookSeatFilePath).ParseJson2Model().CustomerModel;
            //yield return testDataList;
            foreach (var testData in testDataList)
            {
                yield return new object[] {
                       testData
                };
            }
        }


        /// <summary>
        /// This Method Is For Getting SecretCode Data From Json File & Return Parsed Data To TestMethod.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetSecretData()
        {
            var testDataList = new JsonReadTest(_testCasesSecretFilePath).ParseSecretJson2Model().SecretModel;
            //yield return testDataList;
            foreach (var testData in testDataList)
            {
                yield return new object[] {
                       testData
                };
            }
        }

        //******************Test Case For Book Now Code Method******************//
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CinemaControllerBookNow(CustomerModel customermodel)
        {
            this.repository = new GenericRepository<TblBookingSeat>();
            this.repositoryCustomer = new GenericRepository<TblCustomer>();
            this.repositoryErrorLog = new GenericRepository<TblErrorLog>();
            CinemaController cinemaController = new CinemaController(repository, repositoryCustomer, repositoryErrorLog);
            JsonResult result = cinemaController.BookTicket(customermodel) as JsonResult;
            // Assert
            Assert.IsNotNull(result);
        }


        //******************Test Case For Check Secret Code Method******************//
        [TestMethod]
        [DynamicData(nameof(GetSecretData), DynamicDataSourceType.Method)]
        public void CinemaControllerCheckSecretCode(SecretModel modelTest)
        {
            this.repository = new GenericRepository<TblBookingSeat>();
            this.repositoryCustomer = new GenericRepository<TblCustomer>();
            this.repositoryErrorLog = new GenericRepository<TblErrorLog>();
            int SeatNum = modelTest.SeatNumber;
            string SecretCode = modelTest.SecretCode;

            CinemaController cinemaController = new CinemaController(repository, repositoryCustomer, repositoryErrorLog);
            JsonResult result = cinemaController.CheckSecretCode(SecretCode, SeatNum) as JsonResult;
            // Assert
            Assert.IsNotNull(result.Value);
        }


        //******************Test Case For UnBookSeat Method******************//
        [TestMethod]
        [DynamicData(nameof(GetUnBookSeatData), DynamicDataSourceType.Method)]
        public void CinemaControllerUnBookSeat(UnBookModel unBook)
        {
            this.repository = new GenericRepository<TblBookingSeat>();
            this.repositoryCustomer = new GenericRepository<TblCustomer>();
            this.repositoryErrorLog = new GenericRepository<TblErrorLog>();
            int SeatNum = unBook.SeatNumber;

            CinemaController cinemaController = new CinemaController(repository, repositoryCustomer, repositoryErrorLog);
            JsonResult result = cinemaController.UnBookTicket(SeatNum) as JsonResult;
            // Assert
            Assert.IsNotNull(result.Value);
        }

    }
}
