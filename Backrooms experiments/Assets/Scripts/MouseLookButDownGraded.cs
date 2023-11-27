using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookButDownGraded : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    
}
