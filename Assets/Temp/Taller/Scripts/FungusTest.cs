using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusTest : MonoBehaviour
{
    public Flowchart FC;
    void OnTriggerEnter(Collider colo)
    {
        FC.ExecuteBlock("inicio");
    }
}
