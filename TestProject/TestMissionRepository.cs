using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TaskManager.Domain;


namespace TestProject
{
    public class TestMissionRepository
    {
        Guid guid_value1 = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324222");

        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var missionsRepository = testHelper.MissionsRepository;

            Mission mission = new Mission{ MissionID = guid_value1, MName = "Создать БД", MDescription = "Создания БД с использованием SQLServer",
                DateStart = new DateTime(2021, 11, 20), DateEnd = new DateTime(), Employee = new Employee(), Project = new Project(),
                EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324223"), ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324224"),
                MStatus = "В процессе", MType = "Технологический отдел"
            };
            
            missionsRepository.AddAsync(mission).Wait();

            Assert.Equal(guid_value1, missionsRepository.GetByIdAsync(guid_value1).Result.MissionID);
            Assert.Equal("Создать БД", missionsRepository.GetByIdAsync(guid_value1).Result.MName);
        }

        [Theory]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324255", "0DD62430-80CA-44A5-B16D-5FBF04324255")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324256", "0DD62430-80CA-44A5-B16D-5FBF04324256")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324257", "0DD62430-80CA-44A5-B16D-5FBF04324257")]
        public void TestMultipleAdd(string id, string expected)
        {
            var testHelper = new TestHelper();
            var missionsRepository = testHelper.MissionsRepository;

            var id_1 = new Guid(id);
            var expected_id = new Guid(expected);

            Mission mission = new Mission { MissionID = id_1, MName = "Создать БД", MDescription = "Создания БД с использованием SQLServer",
                DateStart = new DateTime(2021, 11, 20), DateEnd = new DateTime(), Employee = new Employee(), Project = new Project(),
                EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324288"), ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324289"),
                MStatus = "В процессе", MType = "Технологический отдел"
            };
            missionsRepository.AddAsync(mission).Wait();

            Assert.Equal(expected_id, missionsRepository.GetByIdAsync(id_1).Result.MissionID);
        }
    }
}
