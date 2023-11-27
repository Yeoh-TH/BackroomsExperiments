using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pencil : MonoBehaviour,IInteractable
{
    [SerializeField] private string _prompt;

    



    public string InteractionPrompt => _prompt;


    public bool Interact(Interactor interactor)
    {

        SceneManager.LoadScene("Credits");
        return true;


    }
}
