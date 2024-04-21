namespace Zadanie5.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal, int id);
    int DeleteAnimal(int id);
}