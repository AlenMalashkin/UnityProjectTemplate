using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Bootstrap
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}