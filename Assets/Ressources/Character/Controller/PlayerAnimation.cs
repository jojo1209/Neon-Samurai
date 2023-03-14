using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   public Animator Player_Anim;

   public void OnAttack()
   {
      Player_Anim.SetTrigger("IsAttacking");
   }
   public void OnDead()
   {
      Player_Anim.SetTrigger("IsDead");
   }
}
