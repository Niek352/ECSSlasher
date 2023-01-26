using UnityEngine;
using UnityEngine.UI;

namespace Ui.Hud.HealthDrawer
{
	public class HealthBar : MonoBehaviour, IHealthAddedListener
	{
		public Image HPBar;
		public void OnHealthAdded(GameEntity entity, float value)
		{
			HPBar.fillAmount = 1f / entity.MaxHealth.Value * entity.Health.Value;
		}
	}

}