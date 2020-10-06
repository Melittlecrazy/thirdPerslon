﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;
    }

    private void ShowMessage(string message, float deration)
    {
        messageText.text = message;

    }
}
