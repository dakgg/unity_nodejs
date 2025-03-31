using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    private const string GRAPHQL_URL = "http://localhost:4000/graphql";

    void Start()
    {
        StartCoroutine(CreatePlayer("Alice", 100));
        StartCoroutine(GetPlayer("1"));
    }

    IEnumerator CreatePlayer(string name, int score)
    {
        string mutation = $@"
        {{
            ""query"": ""mutation {{ createPlayer(name: \""{name}\"", score: {score}) {{ id name score }} }}""
        }}";

        yield return SendGraphQLRequest(mutation, "CreatePlayer");
    }

    IEnumerator GetPlayer(string id)
    {
        string query = $@"
        {{
            ""query"": ""query {{ player(id: \""{id}\"") {{ name score }} }}""
        }}";

        yield return SendGraphQLRequest(query, "GetPlayer");
    }

    IEnumerator SendGraphQLRequest(string bodyJson, string label)
    {
        var request = new UnityWebRequest(GRAPHQL_URL, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJson);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"[{label}] Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError($"[{label}] Error: " + request.error);
        }
    }
}
