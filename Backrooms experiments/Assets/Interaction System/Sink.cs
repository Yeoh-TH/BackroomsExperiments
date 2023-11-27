using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{

    public ParticleSystem waterEffect;
    protected bool tapRunning;
    [SerializeField] private string _prompt;

    void ToggleTap()
    {
        Instantiate(waterEffect);
        
    }



    public string InteractionPrompt => _prompt;
   
    
    public bool Interact(Interactor interactor)
    {
        if (!tapRunning)
        {ToggleTap();
            return tapRunning = true;
        }
        if (tapRunning)
        {
            Destroy(GameObject.FindGameObjectWithTag("Sink"));
            return tapRunning = false;
        }

        return true;
        

    }

   
    
        
    

   


}
