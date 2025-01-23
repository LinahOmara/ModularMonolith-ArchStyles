using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.BusinessLogic;
using ModularMonolith_DotNetGirlsGrp.DoctorAvailability.Internal.Controller;

namespace ModularMonolith.MSTest
{
    [TestClass]
    public class DoctorAvailabilityTests
    {
        [TestMethod]
        public void AddValidSlot()
        {
            //arrange
            DoctorAvailabilityController controller = new DoctorAvailabilityController();

            DoctorAvailabilityDto request = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Valid",
                IsReserved = false,
                Time = DateTime.Now.AddDays(1)
            };



            //act 
            var result = controller.AddSlot(request);


            //assert 
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult, "Expected OkObjectResult but got a different result type.");
            Assert.AreEqual(200, okResult.StatusCode, "Expected HTTP status code 200.");
            var isAdded = okResult.Value;

            Assert.AreEqual(isAdded, true, "Not added successfully.");
        }


        [TestMethod]
        public void AddInValidSlot()
        {
            //arrange
            DoctorAvailabilityController controller = new DoctorAvailabilityController();

            DoctorAvailabilityDto orignialRequest = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Invalid",
                IsReserved = false,
                Time = new DateTime(2025, 10, 10)
            };

            DoctorAvailabilityDto duplicatedRequest = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Invalid",
                IsReserved = false,
                Time = new DateTime(2025, 10, 10)
            };



            //act 
            controller.AddSlot(orignialRequest);

            //assert 
            var exception = Assert.ThrowsException<ArgumentException>(() => controller.AddSlot(duplicatedRequest));

            Assert.AreEqual("Slot already exist", exception.Message);



        }


        [TestMethod]
        public void GetAvailabeSlots()
        {
            //arrange
            DoctorAvailabilityController controller = new DoctorAvailabilityController();

            //DoctorAvailabilityDto reservedRequest = new DoctorAvailabilityDto()
            //{
            //    Id = Guid.NewGuid(),
            //    DoctorId = Guid.NewGuid(),
            //    Cost = 10,
            //    DoctorName = "Test",
            //    IsReserved = true,
            //    Time =  DateTime.Now.AddDays(1)
            //};
            DoctorAvailabilityDto notReservedRequest = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Test",
                IsReserved = false,
                Time = DateTime.Now.AddDays(1)
            };
            //controller.AddSlot(reservedRequest);
            controller.AddSlot(notReservedRequest);


            //act 
            var result = controller.GetAvailabeSlot();


            //assert 
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult, "Expected OkObjectResult but got a different result type.");
            Assert.AreEqual(200, okResult.StatusCode, "Expected HTTP status code 200.");
            var slots = okResult.Value as IEnumerable<DoctorAvailabilityDto>;
            Assert.IsNotNull(slots, "Expected appointment object in the response.");
            Assert.IsTrue(slots.Any(), "The slots collection is empty.");

            Assert.IsTrue(!slots.Any(s => s.IsReserved == true), "Slots count doesn't match");
        }

        [TestMethod]
        public void GetAvailabeFutureSlots()
        {
            //arrange
            DoctorAvailabilityController controller = new DoctorAvailabilityController();

            //DoctorAvailabilityDto futureRequest = new DoctorAvailabilityDto()
            //{
            //    Id = Guid.NewGuid(),
            //    DoctorId = Guid.NewGuid(),
            //    Cost = 10,
            //    DoctorName = "Test",
            //    IsReserved = true,
            //    Time = DateTime.Now.AddDays(1)
            //};
            DoctorAvailabilityDto pastRequest = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Test",
                IsReserved = false,
                Time = DateTime.Now.AddDays(-1)
            };
            //controller.AddSlot(futureRequest);
            controller.AddSlot(pastRequest);


            //act 
            var result = controller.GetAvailabeSlot();


            //assert 
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult, "Expected OkObjectResult but got a different result type.");
            Assert.AreEqual(200, okResult.StatusCode, "Expected HTTP status code 200.");
            var slots = okResult.Value as IEnumerable<DoctorAvailabilityDto>;
            Assert.IsNotNull(slots, "Expected appointment object in the response.");
            Assert.IsTrue(slots.Any(), "The slots collection is empty.");


            Assert.IsTrue(!slots.Any(s => s.Time <= DateTime.Now), "Future Slots count doesn't match");
        }

        [TestMethod]
        public void GetAllSlots()
        {
            //arrange
            DoctorAvailabilityController controller = new DoctorAvailabilityController();

            DoctorAvailabilityDto request1 = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Test",
                IsReserved = true,
                Time = DateTime.Now.AddDays(1)
            };
            DoctorAvailabilityDto request2 = new DoctorAvailabilityDto()
            {
                Id = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Cost = 10,
                DoctorName = "Test",
                IsReserved = false,
                Time = DateTime.Now.AddDays(-1)
            };
            controller.AddSlot(request1);
            controller.AddSlot(request2);


            //act 
            var result = controller.GetSlots();


            //assert 
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult, "Expected OkObjectResult but got a different result type.");
            Assert.AreEqual(200, okResult.StatusCode, "Expected HTTP status code 200.");
            
            var slots = okResult.Value as IEnumerable<DoctorAvailabilityDto>;
            Assert.IsNotNull(slots, "Expected appointment object in the response.");
            Assert.IsTrue(slots.Any(), "The slots collection is empty.");
            Assert.IsTrue(slots.Count() >= 2, $"All Slots count doesn't match, Expected 2 or more, got {slots.Count()}");
        }
    }
}
