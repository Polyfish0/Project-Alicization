using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject box;
    public Material m1;
    public Material m2;

    public void OnDown()
    {
        box.GetComponent<MeshRenderer>().material = m1;
    }

    public void OnUp()
    {
        box.GetComponent<MeshRenderer>().material = m2;
    }
}
