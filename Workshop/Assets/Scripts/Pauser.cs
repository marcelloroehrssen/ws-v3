using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [HideInInspector]
    public bool currentlyPaused = false;

    public Animator pauseAnimator;
    public GameObject menu;

    private void OnInspectorGUI()
    {
        if (GUILayout.Button("Pause / Resume"))
        {
            PauseToggle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseToggle();
        }
    }

    public void PauseToggle()
    {
        Debug.Log("Press");
        currentlyPaused = !currentlyPaused;
        Time.timeScale = 1.0f - Time.timeScale;
        pauseAnimator.SetBool("Paused", currentlyPaused);
        menu.SetActive(currentlyPaused);
    }
}
