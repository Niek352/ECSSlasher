//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

/// <summary>
/// Represents a group of <see cref="JCMG.EntitasRedux.IComponent"/> instances that can be copied to one or more
/// <see cref="GameEntity"/>.
/// </summary>
public interface IGameBlueprint
{
	/// <summary>
	/// Applies all components in the blueprint to <paramref name="entity"/>.
	/// </summary>
	/// <param name="entity"></param>
	void ApplyToEntity(GameEntity entity);
}
