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
	public Ecs.Game.Components.CurrentAttackCooldownComponent CurrentAttackCooldown { get { return (Ecs.Game.Components.CurrentAttackCooldownComponent)GetComponent(GameComponentsLookup.CurrentAttackCooldown); } }
	public bool HasCurrentAttackCooldown { get { return HasComponent(GameComponentsLookup.CurrentAttackCooldown); } }

	public void AddCurrentAttackCooldown(float newValue)
	{
		var index = GameComponentsLookup.CurrentAttackCooldown;
		var component = (Ecs.Game.Components.CurrentAttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.CurrentAttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceCurrentAttackCooldown(float newValue)
	{
		var index = GameComponentsLookup.CurrentAttackCooldown;
		var component = (Ecs.Game.Components.CurrentAttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.CurrentAttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyCurrentAttackCooldownTo(Ecs.Game.Components.CurrentAttackCooldownComponent copyComponent)
	{
		var index = GameComponentsLookup.CurrentAttackCooldown;
		var component = (Ecs.Game.Components.CurrentAttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.CurrentAttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveCurrentAttackCooldown()
	{
		RemoveComponent(GameComponentsLookup.CurrentAttackCooldown);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherCurrentAttackCooldown;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> CurrentAttackCooldown
	{
		get
		{
			if (_matcherCurrentAttackCooldown == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentAttackCooldown);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherCurrentAttackCooldown = matcher;
			}

			return _matcherCurrentAttackCooldown;
		}
	}
}
