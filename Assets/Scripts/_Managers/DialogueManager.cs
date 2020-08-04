using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Read-Only")]
    [SerializeField] private float textSpeed = 0.025f;

    public float TextSpeed {
        get { return textSpeed; }
    }
}
