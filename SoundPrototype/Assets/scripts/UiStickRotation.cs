using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStickRotation : MonoBehaviour
{
    public Transform myTransform;
    [SerializeField] public Image stick;
    

    // Update is called once per frame
    void Update()
    {
        stick.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.right) * myTransform.rotation;
    }
}

