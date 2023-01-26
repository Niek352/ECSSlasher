namespace Ui.Hud.HealthDrawer
{
	public readonly struct HealthItem
	{
		public readonly HealthBar HealthBar;
		public readonly GameEntity OwnedEntity;
		
		public HealthItem(HealthBar healthBar, GameEntity ownedEntity)
		{
			HealthBar = healthBar;
			OwnedEntity = ownedEntity;
		}
	}
}