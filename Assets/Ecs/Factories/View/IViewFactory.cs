
namespace Ecs.Factories.View
{
	public interface IViewFactory<in TEntity, out TObject>
	{
		TObject Create(TEntity entity);
	}
}