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
            var tmp=service.GetAllArtistes();
            Assert.AreNotEqual(tmp.Count(),0);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllEvents().Count(), 0);
        }

        [TestMethod]
        public void GetAllLieuxTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllLieux().Count(), 0);
        }

        [TestMethod]
        public void GetAllPlanningElementsTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllPlanningElements().Count(), 0);
        }


        [TestMethod]
        public void GetAllUsersTest()
        {
            ServiceAgenda.ServiceAgendaClient service = new ServiceAgenda.ServiceAgendaClient(); ;
            Assert.AreNotEqual(service.GetAllUsers().Count(), 0);
        }


    }
}