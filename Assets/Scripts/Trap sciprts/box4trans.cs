using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box4trans : MonoBehaviour
{

    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;
    [SerializeField] private Transform target4;
 

    private float d = 1f;
    private Ease e = Ease.OutQuad;
    private void Awake()
    {
      
        var sequence = DOTween.Sequence();
        var move1 = transform.DOMove(target1.position, d);
        var move2 = transform.DOMove(target2.position, d);
        var move3 = transform.DOMove(target3.position, d);
        var move4 = transform.DOMove(target4.position, d);

        sequence
            .Append(move1)
            .Append(move2)
            .Append(move3)
            .Append(move4)

            .SetAutoKill(false)
            .SetEase(e)
            .SetLoops(-1)
            .SetLoops(-1, LoopType.Yoyo)
            .Play();

    }
   
}
