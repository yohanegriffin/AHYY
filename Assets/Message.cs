using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public void ShowMessageBox(string message)
{
    // Create a new UI object for the message box
    GameObject messageBoxObject = new GameObject("MessageBox");

    // Add a canvas to the message box object
    Canvas canvas = messageBoxObject.AddComponent<Canvas>();
    canvas.renderMode = RenderMode.ScreenSpaceOverlay;

    // Add a panel to the canvas
    GameObject panelObject = new GameObject("Panel");
    panelObject.transform.parent = messageBoxObject.transform;

    Image panelImage = panelObject.AddComponent<Image>();
    panelImage.color = Color.gray;
    panelImage.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
    panelImage.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
    panelImage.rectTransform.pivot = new Vector2(0.5f, 0.5f);
    panelImage.rectTransform.sizeDelta = new Vector2(400, 200);

    // Add text to the panel
    GameObject textObject = new GameObject("Text");
    textObject.transform.parent = panelObject.transform;

    Text text = textObject.AddComponent<Text>();
    text.text = message;
    text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
    text.color = Color.white;
    text.alignment = TextAnchor.MiddleCenter;
    text.rectTransform.anchorMin = new Vector2(0, 0);
    text.rectTransform.anchorMax = new Vector2(1, 1);
    text.rectTransform.pivot = new Vector2(0.5f, 0.5f);
    text.rectTransform.sizeDelta = new Vector2(0, 0);
}

