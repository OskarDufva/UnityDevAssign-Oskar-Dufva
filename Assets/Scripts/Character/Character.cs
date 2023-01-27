using UnityEngine;
public class Character 
{
    public string name;
    public OnWave onwave;

    public Character(string name, OnWave onwave)
    {
        this.name = name;
        this.onwave = onwave;
    }
}

public class OnWave
{
    public string wave_name;
    public int wave_power;
    public OnWave(string wave_name, int wave_power)
    {
        this.wave_name = wave_name;
        this.wave_power = wave_power;
    }
}

public class Program 
{ 
    static void Main(string[] args)
    {
        OnWave human_onwave = new OnWave("KYAAAA", 100);
        OnWave zombie_onwave = new OnWave("Brrraaaains", 10);
        OnWave dog_onwave = new OnWave("Barkelybark", 50);

        Character human = new Character("Human", human_onwave);
        Character zombie = new Character("Zombie", zombie_onwave);
        Character dog = new Character("Dog", dog_onwave);

        Debug.Log(human.name + "'s OnWave is" + human.onwave.wave_name + " with a power of " + human.onwave.wave_power);
        Debug.Log(zombie.name + "'s OnWave is" + zombie.onwave.wave_name + " with a power of " + zombie.onwave.wave_power);
        Debug.Log(dog.name + "'s OnWave is" + dog.onwave.wave_name + " with a power of " + dog.onwave.wave_power);
    }

}