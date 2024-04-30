using System.Collections;
using Sablo.Core;
using UnityEngine;

namespace Sablo.UI.Transition
{
    public class Transition : BaseModule, ITransition
    {
        [SerializeField] private TransitionView _view;
        
        void ITransition.TransitionToGameplay()
        {
            var operation = GameFlow.OnPlay();
            StartCoroutine(PlayTransition(operation));
        }

        private IEnumerator PlayTransition(AsyncOperation operation)
        {
            _view.Show();
            while (!operation.isDone && !_view.IsTransitionComplete())
            {
                yield return null;
            }
            operation.allowSceneActivation = true;
        }
    }
}