using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ManeraiTest.ServerInteraction
{
    public class ServerInteractionService
    {
        public async UniTask SendRequest(string data)
        {
            using var request = UnityWebRequest.Post(ServerConstants.Url, data, ServerConstants.ContentType);
            request.SetRequestHeader("Authorization", ServerConstants.Authorization);

            using var response = await request.SendWebRequest();

            if (response.downloadHandler != null)
            {
                Debug.Log(response.downloadHandler.text);
            }
        }
    }
}