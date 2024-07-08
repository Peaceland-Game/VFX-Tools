using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZone : MonoBehaviour
{
    [SerializeField] public GameObject cam;
    [SerializeField] public List<String> dialogue;
    [SerializeField] public List<DialogueZone> choices;
}
