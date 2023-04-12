using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Spike_Ball : MonoBehaviour
{
    private LineRenderer _linerenderer;
    [SerializeField] private Transform entrypoint;
    [SerializeField] private Transform exitpoint;
    // Start is called before the first frame update
    void Start()
    {
        _linerenderer=GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
       _linerenderer.SetPosition(0,entrypoint.position);
       _linerenderer.SetPosition(1,exitpoint.position);

    }
}
