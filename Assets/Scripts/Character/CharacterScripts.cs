using UnityEngine;



public abstract class Race
{
    public bool enabled { get; set; }
    public PlayerController controller { get; set; }
}

public class Human : Race
{
    public void HumanAbilities()
    {
        controller.moveSpeed = 3f;
        controller.jumpForce = 3f;
    }
}

public class Elf : Race
{
    public void ElfAbilities()
    {
        controller.moveSpeed = 5f;
        controller.jumpForce = 4f;
    }
}

public class Dwarf : Race
{
    public void DwarfAbilities()
    {
        controller.moveSpeed = 4f;
        controller.jumpForce = 2f;
    }
}
public class CharacterScripts : MonoBehaviour
{
    public Race race;

    void Start()
    {
        switch (race)
        {
            case Human human:
                human.HumanAbilities(); 
                break;

            case Elf elf:
                elf.ElfAbilities();
                break;

            case Dwarf dwarf:
                dwarf.DwarfAbilities();
                break;
        }
    }
}
