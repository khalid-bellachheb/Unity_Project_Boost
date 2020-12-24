using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 stepPosition=new Vector3(-15,-15,-15);

    [SerializeField] [Range(0, 1)] float RangeMovement;

    [SerializeField] float period = 5f; // 2 seconds

    float cycles;

    Vector3 Intialposition;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Intialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        cycles = Time.time / period;
        RangeMovement = Mathf.Sin(2 * Mathf.PI * cycles)/2+0.5f;
        offset = stepPosition * RangeMovement;
        transform.position = Intialposition + offset;
    }
}
