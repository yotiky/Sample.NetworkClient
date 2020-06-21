using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;

public class SystemHttpClientSamples : MonoBehaviour
{
    const string url = "https://zipcloud.ibsnet.co.jp/api/search";
    const string key = "zipcode";
    const int zipcode = 1070052;
    string query = $"?{key}={zipcode}";

    private static readonly HttpClient httpClient = new HttpClient();

    #region GET

    public async UniTaskVoid Get()
    {
        {
            // Async (Task)
            await GetRequestAsync();
        }
        {
            // Async (UniTask)
            await GetRequestAsyncUniTask();
        }
    }
    private async Task GetRequestAsync()
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { key, zipcode.ToString() },
        });
        var encodedQuery = await content.ReadAsStringAsync();

        {
            // ヘッダを付ける場合
            //var request = new HttpRequestMessage(HttpMethod.Get, url);
            //request.Headers.Add("foo", "hoge");
            //var response = await httpClient.SendAsync(request);

            // または
            //httpClient.DefaultRequestHeaders.Add("foo", "hoge");
        }

        var response = await httpClient.GetAsync($"{url}?{encodedQuery}");

        if (!response.IsSuccessStatusCode)
        {
            Debug.Log("get failure.");
            Debug.Log(response.ReasonPhrase);
            Debug.Log(await response.Content.ReadAsStringAsync());
        }
        else
        {
            var text = await response.Content.ReadAsStringAsync();
            Debug.Log($"get success. {nameof(SystemHttpClientSamples)}.{nameof(GetRequestAsync)}");
            Debug.Log(text);

            {
                // Json をデシリアライズする場合
                // JsonUtility : Unity純正、速いが制約が多い
                //   データ型はSerializable属性、パブリックフィールド
                //var data = UnityEngine.JsonUtility.FromJson<Rootobject>(html);
                // Json.NET : C#におけるメジャーどころ、遅いが汎用的で拡張性がある
                //   データ型はJsonObject属性、プロパティにJsonProperty属性
                //var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(html);
                // Utf8Json : neuecc作、JsonUtilityと同じくらいの速さで汎用的
                //var data = Utf8Json.JsonSerializer.Deserialize<ResponseData>(html);
            }
        }
    }
    private async UniTask GetRequestAsyncUniTask()
    {
        var html = await httpClient.GetStringAsync(url + query);
        Debug.Log($"get success. {nameof(SystemHttpClientSamples)}.{nameof(GetRequestAsyncUniTask)}");
        Debug.Log(html);
    }

    #endregion

    #region POST

    public async UniTaskVoid Post()
    {
        {
            // Async (Task)
            await PostRequestAsync();
        }
        {
            // Async (UniTask)
            await PostRequestAsyncUniTask();
        }
    }
    private async Task PostRequestAsync()
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { key, zipcode.ToString() },
        });

        {
            // 画像(バイナリ)を送信する場合
            //var postData = new byte[] { 1, 2 };
            //var byteContent = new ByteArrayContent(postData);
            //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //var res = await httpClient.PostAsync(url, byteContent);
            //var text = await res.Content.ReadAsStringAsync();
            //Debug.Log(text);

            // 画像(バイナリ)を送信する場合
            //var request = new HttpRequestMessage(HttpMethod.Post, url);
            //var postData = new byte[] { 1, 2 };
            //var byteContent = new ByteArrayContent(postData);
            //request.Content = byteContent;
            //request.Content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //var res = await httpClient.SendAsync(request);
            //var text = await res.Content.ReadAsStringAsync();
            //Debug.Log(text);
        }
        {
            // ヘッダを付けて、画像(バイナリ)を送信する場合
            //var request = new HttpRequestMessage(HttpMethod.Post, url);
            //request.Headers.Add("foo", "hoge");
            //var postData = new byte[] { 1, 2 };
            //var byteContent = new ByteArrayContent(postData);
            //byteContent.Headers.Add("Content-Type", "image/jpeg");

            //var data = new MultipartFormDataContent();
            //data.Add(new StringContent(zipcode.ToString()), key);
            //data.Add(byteContent, "file", "test.jpg");
            //request.Content = data;
            //var res = await httpClient.SendAsync(request);
            //var text = await res.Content.ReadAsStringAsync();
            //Debug.Log(text);
        }

        var response = await httpClient.PostAsync(url, content);
        var text = await response.Content.ReadAsStringAsync();
        Debug.Log($"post success. {nameof(SystemHttpClientSamples)}.{nameof(PostRequestAsync)}");
        Debug.Log(text);
    }
    private async UniTask PostRequestAsyncUniTask()
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { key, zipcode.ToString() },
        });

        var response = await httpClient.PostAsync(url, content);
        var text = await response.Content.ReadAsStringAsync();
        Debug.Log($"post success. {nameof(SystemHttpClientSamples)}.{nameof(PostRequestAsyncUniTask)}");
        Debug.Log(text);
    }

    #endregion
}
