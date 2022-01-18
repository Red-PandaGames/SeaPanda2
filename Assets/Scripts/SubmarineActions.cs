using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!SubmarineMovement.isOn) {
             GetComponentInChildren<Light>().intensity = 0;
        }
        else {
             GetComponentInChildren<Light>().intensity = 60;
        }
    }
}
