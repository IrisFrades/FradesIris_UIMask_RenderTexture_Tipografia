using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfo1 : MonoBehaviour
{
    [SerializeField]
    public Button QuitButton;

    private void Start()
    {
        QuitButton.onClick.AddListener(QuitApp);
    }
    void QuitApp()
    {
        Application.Quit();
    }
}
