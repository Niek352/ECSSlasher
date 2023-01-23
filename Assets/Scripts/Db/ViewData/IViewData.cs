using Ecs.Views.Linkable.Impl;

namespace Db.ViewData
{
	public interface IViewData
	{
		LinkableView Get(string prefabName);
	}
}