using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [Tooltip("Image component dispplaying current health")]
        public Image HealthFillImage;
        public Image ArmorFillImage;

        Health m_PlayerHealth;
        Armor m_PlayerArmor;

        void Start()
        {
            PlayerCharacterController playerCharacterController =
                GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(
                playerCharacterController, this);

            m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            m_PlayerArmor = playerCharacterController.GetComponent<Armor>();
            DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this,
                playerCharacterController.gameObject);
            DebugUtility.HandleErrorIfNullGetComponent<Armor, PlayerHealthBar>(m_PlayerArmor, this,
                playerCharacterController.gameObject);
        }

        void Update()
        {
            // update health bar value
            HealthFillImage.fillAmount = m_PlayerHealth.CurrentHealth / m_PlayerHealth.MaxHealth;
            ArmorFillImage.fillAmount = m_PlayerArmor.CurrentArmor / m_PlayerArmor.MaxArmor;
        }
    }
}