using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimation : MonoBehaviour
{
   public Animator playerAnim;
   private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
   private static readonly int IsDead = Animator.StringToHash("IsDead");

   public void OnAttack()
   {
      playerAnim.SetTrigger(IsAttacking);
   }
   public void OnDead()
   {
      playerAnim.SetTrigger(IsDead);
   }
}
