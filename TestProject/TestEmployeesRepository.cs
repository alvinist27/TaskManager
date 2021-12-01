using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TaskManager.Domain;


namespace TestProject
{
    public class TestEmployeesRepository
    {

        Guid guid_value1 = new Guid("0DD62430-80CA-44A5-B16D-5FBF0432406B");

        Mission mission1 = new Mission { MissionID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324071"), MName = "Создать БД",
            MDescription = "Создания БД с использованием SQLServer", DateStart = new DateTime(2021, 11, 20),
            DateEnd = new DateTime(), Employee = new Employee(), Project = new Project(), EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324081"),
            ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324091"), MStatus = "В процессе", MType = "Технологический отдел"};
        Mission mission2 = new Mission {MissionID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324072"), MName = "Написать программу",
            MDescription = "Написать программу на C##", DateStart = new DateTime(2021, 11, 25), DateEnd = new DateTime(2021, 11, 28), 
            Employee = new Employee(), Project = new Project(), EmployeeID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324082"),
            ProjectID = new Guid("0DD62430-80CA-44A5-B16D-5FBF04324091"), MStatus = "Завершено", MType = "Технологический отдел"
        };
        List<Mission> missions_list = new List<Mission>();
       

        [Fact]
        public void TestAdd()
        {
            missions_list.Add(mission1);
            missions_list.Add(mission2);
            var testHelper = new TestHelper();
            var employeesRepository = testHelper.EmployeesRepository;

            Employee person = new Employee { EmployeeID = guid_value1, EName = "Nic", EWork = "Строитель", Missions = missions_list };
            employeesRepository.AddAsync(person).Wait();

            Assert.Equal(guid_value1, employeesRepository.GetByIdAsync(guid_value1).Result.EmployeeID);
            Assert.Equal("Nic", employeesRepository.GetByIdAsync(guid_value1).Result.EName);
        }

        [Theory]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324061", "0DD62430-80CA-44A5-B16D-5FBF04324061")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324062", "0DD62430-80CA-44A5-B16D-5FBF04324062")]
        [InlineData("0DD62430-80CA-44A5-B16D-5FBF04324063", "0DD62430-80CA-44A5-B16D-5FBF04324063")]
        public void TestMultipleAdd(string id, string expected)
        {
            var testHelper = new TestHelper();
            var employeesRepository = testHelper.EmployeesRepository;

            var id_1 = new Guid(id);
            var expected_id = new Guid(expected);

            Employee person = new Employee { EmployeeID = id_1, EName = "Nic", EWork = "Строитель", Missions = missions_list };
            employeesRepository.AddAsync(person).Wait();

            Assert.Equal(expected_id, employeesRepository.GetByIdAsync(id_1).Result.EmployeeID);
        }
    }
}
