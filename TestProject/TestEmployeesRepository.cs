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
        Guid guid_value2 = new Guid("6A96F425-C325-4B35-89CF-C3AC2AFD8B15");
        Guid guid_value3 = new Guid("9DE3A2D8-94E6-440E-A57C-16F9AD9285B7");

        List<TaskManager.Domain.Task> list = new List<TaskManager.Domain.Task>();

        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var employeesRepository = testHelper.EmployeesRepository;

            Employee person = new Employee { EmployeeID = guid_value1, EName = "Nic", EWork = "Строитель", Tasks = list };
            employeesRepository.AddAsync(person).Wait();

            Assert.Equal(guid_value1, employeesRepository.GetByIdAsync(guid_value1).Result.EmployeeID);
            Assert.True(employeesRepository.GetAllAsync().Result.Count == 1);
            Assert.Equal("Nic", employeesRepository.GetByIdAsync(guid_value1).Result.EName);
        }

        /*[Theory]
        [InlineData(guid_value1, guid_value1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void TestMultipleAdd(Guid id, Guid expected)
        {
            var testHelper = new TestHelper();
            var employeesRepository = testHelper.EmployeesRepository;

            Employee person = new Employee { EmployeeID = guid_value1, EName = "Nic", EWork = "Строитель", Tasks = list };
            employeesRepository.AddAsync(person).Wait();

            Assert.Equal(expected, employeesRepository.GetByIdAsync(guid_value1).Result.EmployeeID);
        }*/
    }
}
