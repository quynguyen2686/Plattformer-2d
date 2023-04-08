using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float starvalue;
    [SerializeField] private float endvalue;
    [SerializeField] private float speed;

    private void Update()
    {
        if (transform.localPosition.x <= endvalue)
        {
            transform.localPosition = new Vector3(starvalue, 0f, 0f);
        }

    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(-1f, 0f, 0f) * (Time.fixedDeltaTime * speed));
    }
}
