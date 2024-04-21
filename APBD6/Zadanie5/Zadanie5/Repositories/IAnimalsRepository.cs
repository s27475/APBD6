namespace Zadanie5.Repositories;
    public interface IAnimalsRepository
    {
        IEnumerable<Animal> GetAnimals(String orderBy);
        int CreateAnimal(Animal animal);
        int UpdateAnimal(Animal animal, int id);
        int DeleteAnimal(int id);
}