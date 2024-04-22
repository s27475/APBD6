namespace WebApplication1;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal, int id);
    int DeleteAnimal(int id);
}