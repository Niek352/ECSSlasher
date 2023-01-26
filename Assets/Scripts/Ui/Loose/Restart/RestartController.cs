using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using VContainerUi.Abstraction;

namespace Ui.Loose.Restart
{
	public class RestartController : UiController<RestartView>, IStartable, IDisposable
	{
		private readonly CompositeDisposable _disposable = new CompositeDisposable();

		public void Start()
		{
			View.RestartButton.onClick.AsObservable().Subscribe(OnRestart).AddTo(_disposable);
		}
		
		private void OnRestart(Unit obj)
		{
			LoadSceneAsync().Forget();
			_disposable?.Dispose();
		}

		private async UniTask LoadSceneAsync()
		{
			await SceneManager.LoadSceneAsync(0).ToUniTask();
		}
		
		public void Dispose()
		{
			_disposable?.Dispose();
		}
	}
}