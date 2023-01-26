using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
	[Game]
	public class CharacterIdComponent : IComponent
	{
		[EntityIndex] public byte Id;
	}
}