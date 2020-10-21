using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageTrigger : MonoBehaviour
{
    [SerializeField]
    [TextArea(3,5)]
    private string message = "defult";

    [SerializeField]
    private float messageDuration = 1.0f;

    public static event Action<string, float> MessagedTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MessagedTriggered != null)
            {
                MessagedTriggered.Invoke(message, messageDuration);
            }
        }
    }
}
