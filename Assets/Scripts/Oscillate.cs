using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillate : MonoBehaviour
{
    [SerializeField] Vector3 MovementVector;
    [SerializeField] float Period = 2f;
    [Range(0, 1)][SerializeField] float MovementFactor;
    Vector3 StartingPos;

    void Start()
    {
        StartingPos = transform.localPosition;
    }
    void Update()
    {
        if (Period <= Mathf.Epsilon)
        {
            return;
        }

        float cycle = Time.time / Period;
        const float tau = Mathf.PI * 2f;
        float RawSinWave = Mathf.Sin(cycle * tau);
        MovementFactor = RawSinWave / 2f + 0.5f;
        Vector3 Offset = MovementFactor * MovementVector;
        transform.localPosition = StartingPos + Offset;
    }
}