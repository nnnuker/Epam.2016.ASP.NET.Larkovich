using HomeTask.Models;

namespace HomeTask.Data
{
    public interface IPersonRepo
	{
		Person[] GetAll();
        void Add(Person person);
    }
}
