using JuliePro_Core;
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JuliePro_DataAcess_Tests
{
    public class TrainerAddTest
    {
        private Trainer trainer_first;
        private Trainer trainer_Second;
        private DbContextOptions<JulieProDbContext> options;


        public TrainerAddTest()
        {
            trainer_first = new Trainer()
            {
                Id = 8,
                FirstName = "Michel",
                LastName = "Lachancette",
                Email = "Michel.Lachance@juliepro.ca",
                Speciality_Id = 2,
                Photo = "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png",
                Active = true

            };
            trainer_Second = new Trainer()
            {
                Id = 9,
                FirstName = "Micheline",
                LastName = "MalChance",
                Email = "Micheline.MalChance@juliepro.ca",
                Speciality_Id = 3,
                Photo = "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png",
                Active = false

            };
            options = new DbContextOptionsBuilder<JulieProDbContext>().UseInMemoryDatabase(databaseName: "JulieProDB").Options;
        }


        [Fact]
        public void SaveTrainer_Trainer_CheckTheValuesFromDatabase()
        {

            //act
            using (var context = new JulieProDbContext(options))
            {
                var Service = new TrainersService(context);
                Service.AddAsync(trainer_first);
            }

            //assert
            using (var context = new JulieProDbContext(options))
            {
                var Trainer = context.Trainers.FirstOrDefault(c => c.Id == 8);
                Assert.Equal(trainer_first.Id, Trainer.Id);
                Assert.Equal(trainer_first.FirstName, Trainer.FirstName);
                Assert.Equal(trainer_first.LastName, Trainer.LastName);
                Assert.Equal(trainer_first.Email, Trainer.Email);
                Assert.Equal(trainer_first.Speciality_Id, Trainer.Speciality_Id);
                Assert.Equal(trainer_first.Photo, Trainer.Photo);
                Assert.Equal(trainer_first.Active, Trainer.Active);

            }
        }


            [Fact]
            public void GetAllTrainersTest()
            {

                // Arrange
                var ResultAttendue = new List<Trainer> { trainer_first };
                var ResultAttendue2 = new List<Trainer> { trainer_Second };
            using (var context = new JulieProDbContext(options))
                {
                    context.Database.EnsureDeleted();
                    var service = new TrainersService(context);
                    service.AddAsync(trainer_first);
                    service.AddAsync(trainer_Second);

                }
                //Act 
                List<Trainer> trainers;
                using(var context = new JulieProDbContext(options))
                {
                    var services = new TrainersService(context);
                    trainers = services.GetAllActive();
                }

            }
        

        
    }
}
