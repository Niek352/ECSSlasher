//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext
{
	public GameEntity CameraEntity { get { return GetGroup(GameMatcher.Camera).GetSingleEntity(); } }

	public bool IsCamera
	{
		get { return CameraEntity != null; }
		set
		{
			var entity = CameraEntity;
			if (value != (entity != null))
			{
				if (value)
				{
					CreateEntity().IsCamera = true;
				}
				else
				{
					entity.Destroy();
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
public partial class GameEntity
{
	static readonly Ecs.Game.Core.Components.CameraComponent CameraComponent = new Ecs.Game.Core.Components.CameraComponent();

	public bool IsCamera
	{
		get { return HasComponent(GameComponentsLookup.Camera); }
		set
		{
			if (value != IsCamera)
			{
				var index = GameComponentsLookup.Camera;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CameraComponent;

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherCamera;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Camera
	{
		get
		{
			if (_matcherCamera == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Camera);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherCamera = matcher;
			}

			return _matcherCamera;
		}
	}
}
