using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public enum CharacterTypes { Human, Zombie, Dog };
    public List<GameObject> characters = new List<GameObject>();
    public GameObject currentCharacter;
    public CharacterTypes currentCharacterType;

    public PlayerController playerController;

    void Awake()
    {
        // Instantiate the initial character
        currentCharacterType = CharacterTypes.Human;
        InstantiateCharacter((int)currentCharacterType);
    }



    // Instantiate a character at the position of the current GameObject
    public void InstantiateCharacter(int index)
    {
        if (characters[index] == null) 
            return;
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        currentCharacter = Instantiate(characters[index], transform);
        playerController._animator = currentCharacter.GetComponentInChildren<Animator>();
        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.localRotation = Quaternion.identity;
        currentCharacter.name = characters[index].name;
        currentCharacterType = (CharacterTypes)index;
        CharacterType();
    }

    // Function to swap to the next character in the list
    public void SwapCharacter()
    {
        int nextCharacterType = (int)(currentCharacterType + 1) % characters.Count;
        InstantiateCharacter(nextCharacterType);
    }

    // Function to print the character type to the console
    public void CharacterType()
    {
        switch (currentCharacterType)
        {
            case CharacterTypes.Human:                
                HumanSpecs();
                print("Hooman");
                break;
            case CharacterTypes.Zombie:
                ZombieSpecs();
                print("Zombie");              
                break;
            case CharacterTypes.Dog:
                DogSpecs();
                print("Doggie");
                break;
        }
    }


    // Sets float values and activation of ability when character is changed.
    public void HumanSpecs()
    {
        
        playerController.moveSpeed = 3f;
        playerController.jumpForce = 3f;

    }

    public void ZombieSpecs()
    {

        playerController.moveSpeed = 2f;
        playerController.jumpForce = 4f;

    }

    public void DogSpecs()
    {
        playerController.moveSpeed = 5f;
        playerController.jumpForce = 5f;

    }
}

