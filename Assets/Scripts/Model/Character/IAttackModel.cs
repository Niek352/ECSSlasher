namespace Model.Character
{
	public interface IAttackModel
	{
		float Damage { get; }
		float AttackCooldown { get; }
	}
}