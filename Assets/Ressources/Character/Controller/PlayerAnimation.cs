using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimation : MonoBehaviour
{
   public Animator playerAnim;
   private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
   private static readonly int IsDead = Animator.StringToHash("IsDead");
    public GameObject vfx;
    bool goVFX;
    float time = 0;
    public void Update()
    {
        if (goVFX)
        {
            time += Time.deltaTime;
            vfx.SetActive(true);

            if (time >= 0.5f)
            {
                vfx.SetActive(false);
                goVFX= false;
            }
        }

    }
    public void OnAttack()
   {
        time = 0;
        goVFX= true;
      playerAnim.SetTrigger(IsAttacking);
   }
   public void OnDead()
   {
      playerAnim.SetTrigger(IsDead);
   }
}
