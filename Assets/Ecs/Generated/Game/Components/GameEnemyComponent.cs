//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	static readonly Ecs.Game.Components.EnemyComponent EnemyComponent = new Ecs.Game.Components.EnemyComponent();

	public bool IsEnemy
	{
		get { return HasComponent(GameComponentsLookup.Enemy); }
		set
		{
			if (value != IsEnemy)
			{
				var index = GameComponentsLookup.Enemy;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: EnemyComponent;

					AddComponent(index, component);
				}
				else
				{
					RemoveComponent(index);
				}
			}
		}
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherEnemy;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Enemy
	{
		get
		{
			if (_matcherEnemy == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Enemy);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherEnemy = matcher;
			}

			return _matcherEnemy;
		}
	}
}