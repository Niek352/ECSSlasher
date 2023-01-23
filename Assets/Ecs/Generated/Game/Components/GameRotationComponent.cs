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
	public Ecs.Game.Core.Components.RotationComponent Rotation { get { return (Ecs.Game.Core.Components.RotationComponent)GetComponent(GameComponentsLookup.Rotation); } }
	public bool HasRotation { get { return HasComponent(GameComponentsLookup.Rotation); } }

	public void AddRotation(UnityEngine.Quaternion newValue)
	{
		var index = GameComponentsLookup.Rotation;
		var component = (Ecs.Game.Core.Components.RotationComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.RotationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceRotation(UnityEngine.Quaternion newValue)
	{
		var index = GameComponentsLookup.Rotation;
		var component = (Ecs.Game.Core.Components.RotationComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.RotationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyRotationTo(Ecs.Game.Core.Components.RotationComponent copyComponent)
	{
		var index = GameComponentsLookup.Rotation;
		var component = (Ecs.Game.Core.Components.RotationComponent)CreateComponent(index, typeof(Ecs.Game.Core.Components.RotationComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveRotation()
	{
		RemoveComponent(GameComponentsLookup.Rotation);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherRotation;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Rotation
	{
		get
		{
			if (_matcherRotation == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Rotation);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherRotation = matcher;
			}

			return _matcherRotation;
		}
	}
}
