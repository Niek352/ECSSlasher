using JCMG.EntitasRedux;
using Services.Camera;
using VContainer;

namespace Ecs.Views.Linkable.Impl
{
	public class PlayerView : CharacterView
	{
		[Inject] private readonly GameContext _game;
		[Inject] private readonly ICameraProvider _cameraProvider;
		
		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			var e = (GameEntity)entity;
			
			_cameraProvider.LookAt = _game.PlayerEntity.Transform.Value;
			_cameraProvider.Follow = _game.PlayerEntity.Transform.Value;
		}
	}
}