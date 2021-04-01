using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ArmorPickup : Pickup
    {
        [Header("Parameters")] [Tooltip("Amount of armor to heal on pickup")]
        public float ArmorAmount;

        protected override void OnPicked(PlayerCharacterController player)
        {
            Armor playerArmor = player.GetComponent<Armor>();
            if (playerArmor && playerArmor.CanPickup())
            {
                playerArmor.GainArmor(ArmorAmount);
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }
    }
}