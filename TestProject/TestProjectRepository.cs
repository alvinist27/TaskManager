using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TaskManager.Domain;


namespace TestProject
{
    public class TestProjectRepository
    {
        Guid guid_value2 = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324333");

        Mission mission1 = new Mission { MissionID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324341"),
            MName = "Создать БД", MDescription = "Создания БД с использованием SQLServer", 
            DateStart = new DateTime(2021, 11, 20), DateEnd = new DateTime(), Employee = new Employee(),
            Project = new Project(), EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324342"),
            ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324343"), MStatus = "В процессе",
            MType = "Технологический отдел"
        };
        Mission mission2 = new Mission { MissionID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324351"),
            MName = "Написать программу", MDescription = "Написать программу на C##",
            DateStart = new DateTime(2021, 11, 25), DateEnd = new DateTime(2021, 11, 28), Employee = new Employee(),
            Project = new Project(), EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324352"),
            ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324353"), MStatus = "Завершено",
            MType = "Технологический отдел"
        };
        List<Mission> missions_list = new List<Mission>();

        [Fact]
        public void TestAdd()
        {
            missions_list.Add(mission1);
            missions_list.Add(mission2);
            var testHelper = new TestHelper();
            var projectsRepository = testHelper.ProjectsRepository;

            Project project = new Project { ProjectID = guid_value2, Missions = missions_list, PName = "Заказ" };
            projectsRepository.AddAsync(project).Wait();

            Assert.Equal(guid_value2, projectsRepository.GetByIdAsync(guid_value2).Result.ProjectID);
            Assert.True(projectsRepository.GetAllAsync().Result.Count == 1);
            Assert.Equal("Заказ", projectsRepository.GetByIdAsync(guid_value2).Result.PName);
        }

        [Theory]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324371", "0DD62430-80CA-44A5-B16D-5FBF04324371")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324372", "0DD62430-80CA-44A5-B16D-5FBF04324372")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324373", "0DD62430-80CA-44A5-B16D-5FBF04324373")]
        public void TestMultipleAdd(string id, string expected)
        {
            var testHelper = new TestHelper();
            var projectsRepository = testHelper.ProjectsRepository;

            var id_1 = new Guid(id);
            var expected_id = new Guid(expected);

            Project project = new Project { ProjectID = id_1, PName = "Заказ", Missions = missions_list };
            projectsRepository.AddAsync(project).Wait();

            Assert.Equal(expected_id, projectsRepository.GetByIdAsync(id_1).Result.ProjectID);
        }
    }
}
