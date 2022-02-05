using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterComponents
{
    
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
        AttackHandler();
        check();
    }
    
}
