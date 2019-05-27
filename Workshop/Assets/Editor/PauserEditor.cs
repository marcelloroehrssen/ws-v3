using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(Pauser))]
public class PauserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Pauser pauser = (Pauser)target;

        string label = pauser.currentlyPaused ? "Resume" : "Pause";

        if (GUILayout.Button(label))
        {
            float alpha = pauser.currentlyPaused ? 0 : 0.5f;

            GameObject go = pauser.pauseAnimator.gameObject;
            Color color = go.GetComponent<Image>().color;
            go.GetComponent<Image>().color = new Color(
                color.r, color.g, color.b, alpha
            );
            pauser.PauseToggle();
        }
    }
}
