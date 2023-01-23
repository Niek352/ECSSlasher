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
	public Ecs.Game.Core.Components.PositionComponent Position { get { return (Ecs.Game.Core.Components.PositionComponent)GetComponent(GameComponentsLookup.Position); } }
	public bool HasPosition { get { return HasComponent(GameComponentsLookup.Position); } }

	public void AddPosition(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.Position;
		var component = (Ecs.Game.Core.Components.PositionComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.PositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePosition(UnityEngine.Vector3 newValue)
	{
		var index = GameComponentsLookup.Position;
		var component = (Ecs.Game.Core.Components.PositionComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.PositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPositionTo(Ecs.Game.Core.Components.PositionComponent copyComponent)
	{
		var index = GameComponentsLookup.Position;
		var component = (Ecs.Game.Core.Components.PositionComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.PositionComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePosition()
	{
		RemoveComponent(GameComponentsLookup.Position);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPosition;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Position
	{
		get
		{
			if (_matcherPosition == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Position);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPosition = matcher;
			}

			return _matcherPosition;
		}
	}
}
