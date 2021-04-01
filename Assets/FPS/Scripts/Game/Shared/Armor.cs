using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    public class Armor: MonoBehaviour
    {
        [Tooltip("Maximum amount of Armor")] public float MaxArmor = 10f;

        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnGained;
        public UnityAction OnDepleate;

        public float CurrentArmor { get; set; }
        public bool Invincible { get; set; }
        public bool CanPickup() => CurrentArmor < MaxArmor;

        public float GetRatio() => CurrentArmor / MaxArmor;
       

        bool m_IsDepleate;

        void Start()
        {
            CurrentArmor = 0;
        }

        public void GainArmor(float armorAmount)
        {
            float armorBefore = CurrentArmor;
            CurrentArmor += armorAmount;
            CurrentArmor = Mathf.Clamp(CurrentArmor, 0f, MaxArmor);

            // call OnHeal action
            float trueArmorAmount = CurrentArmor - armorBefore;
            if (trueArmorAmount > 0f)
            {
                OnGained?.Invoke(trueArmorAmount);
            }
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (Invincible)
                return;

            float armorBefore = CurrentArmor;
            CurrentArmor -= damage;
            CurrentArmor = Mathf.Clamp(CurrentArmor, 0f, MaxArmor);

            // call OnDamage action
            float trueDamageAmount = armorBefore - CurrentArmor;
            if (trueDamageAmount > 0f)
            {
                OnDamaged?.Invoke(trueDamageAmount, damageSource);
            }

            HandleDepleate();
        }

        

        void HandleDepleate()
        {
            if (m_IsDepleate)
                return;

            // call OnDie action
            if (CurrentArmor <= 0f)
            {
                m_IsDepleate = true;
                
            }
        }
    }
}