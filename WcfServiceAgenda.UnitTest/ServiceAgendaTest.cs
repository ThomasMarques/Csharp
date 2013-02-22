using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceAgenda;
using System.Collections.Generic;

namespace WcfServiceAgenda.UnitTest
{
    [TestClass]
    public class ServiceAgendaTest
    {

        [TestMethod]
        public void GetDataTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient();
            string result = service.GetData(5);
            Assert.AreEqual("You entered: 5", result);
        }

        [TestMethod]
        public void GetAllArtistesTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient();
            var tmp = service.GetAllArtistes("toto", "12299170891009567410982971131211871132061153230");
            Assert.AreNotEqual(tmp.Count(),0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllEvents("toto", "12299170891009567410982971131211871132061153230").Count(), 0);
        }

        [TestMethod]
        public void GetAllLieuxTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllLieux("toto", "12299170891009567410982971131211871132061153230").Count(), 0);
        }

        [TestMethod]
        public void GetAllPlanningElementsTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllPlanningElements("toto", "12299170891009567410982971131211871132061153230").Count(), 0);
        }


        [TestMethod]
        public void GetAllUsersTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllUsers("toto", "12299170891009567410982971131211871132061153230").Count(), 0);
        }


    }
}