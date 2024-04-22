namespace WebApplication1;

public class AnimalsService : IAnimalService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(Animal animal, int id)
    {
        return _animalsRepository.UpdateAnimal(animal, id);
    }


    public int DeleteAnimal(int animalId)
    {
        return _animalsRepository.DeleteAnimal(animalId);
    }
}