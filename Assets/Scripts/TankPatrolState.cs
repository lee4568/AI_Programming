using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolState : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo,int layerIndex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.SetNextPoint();
    }
   
}
