using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    public Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField]private TextMeshProUGUI _promptText;

    private void Start()
    {
        
        _uiPanel.SetActive(false);

    }

    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(worldPosition: transform.position + rotation * Vector3.forward,
            worldUp: rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void Setup(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {

        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }


}
