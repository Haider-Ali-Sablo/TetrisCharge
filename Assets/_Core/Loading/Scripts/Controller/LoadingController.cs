using System;
using System.Collections;
using Sablo.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sablo.Loading
{
    public class LoadingController : MonoBehaviour, ILoading
    {
        public ILoadingView ViewHandler { private get; set; }
        
        private AsyncOperation _sceneLoadingOperation;

        private void Start()
        {
            LoadScene();
        }
        
        private void LoadScene()
        {
            _sceneLoadingOperation = SceneManager.LoadSceneAsync(Constants.SceneName.MainScene);
            _sceneLoadingOperation.allowSceneActivation = false;
            SetProgressState();
        }   

        private void SetProgressState()
        {
            var delay = 0.1f;
            var wait = new WaitForSeconds(delay);
            
            StartCoroutine(Progression());
            IEnumerator Progression()
            {
                Initialize(() =>
                {
                    _sceneLoadingOperation.allowSceneActivation = true;
                    ViewHandler.SetProgressState(1);
                });
                
                while (!_sceneLoadingOperation.isDone)
                {
                    yield return wait;
                    ViewHandler.SetProgressState(_sceneLoadingOperation.progress);
                }
            }
        }
        
        private void Initialize(Action onComplete = null)
        {
            onComplete?.Invoke();
        }
    }
}