using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge info;

    public void Trigger()
    {
        var system = FindObjectOfType<DialougeSystem>();
        system.Begin(info);
    }
}
