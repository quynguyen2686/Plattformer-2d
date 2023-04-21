using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxHit : MonoBehaviour
{


    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
 

    private float d = 1f;
    private Ease e = Ease.OutQuad;
    private void Awake()
    {
   
        var sequence = DOTween.Sequence();
        var move1 = transform.DOMove(target1.position, d);
        var move2 = transform.DOMove(target2.position, d);
      
        sequence
            .Append(move1)
            .Append(move2)
        
            .SetAutoKill(false)
            .SetEase(e)
            .SetLoops(-1)
            .SetLoops(-1,LoopType.Yoyo)
            .Play();

    }
 

}

