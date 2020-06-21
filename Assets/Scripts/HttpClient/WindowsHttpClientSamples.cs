using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
#if WINDOWS_UWP
using Windows.Storage;
using Windows.Web.Http;
#endif

public class WindowsHttpClientSamples : MonoBehaviour
{
    const string url = "https://zipcloud.ibsnet.co.jp/api/search";
    const string key = "zipcode";
    const int zipcode = 1040061;
    string query = $"{key}={zipcode}";

#if WINDOWS_UWP
    private static readonly HttpClient httpClient = new HttpClient();
#endif

    public async UniTask GetRequestAsync()
    {
#if WINDOWS_UWP
        var builder = new UriBuilder(url);
        builder.Query = query;

        {
            // ヘッダを付ける場合
            //var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri);
            //request.Headers.Add("foo", "hoge");
            //var response = await httpClient.SendRequestAsync(request);

            // または
            //httpClient.DefaultRequestHeaders.Add("foo", "hoge");
        }

        var response = await httpClient.GetAsync(builder.Uri);

        if (!response.IsSuccessStatusCode)
        {
            Debug.Log("get failure.");
            Debug.Log(response.ReasonPhrase);
            Debug.Log(await response.Content.ReadAsStringAsync());
        }
        else
        {
            var text = await response.Content.ReadAsStringAsync();
            Debug.Log($"get success. {nameof(WindowsHttpClientSamples)}.{nameof(GetRequestAsync)}");
            Debug.Log(text);
        }
#endif
    }
    public async UniTask PostRequestAsync()
    {
#if WINDOWS_UWP
        var content = new HttpFormUrlEncodedContent(new Dictionary<string, string>
            {
                { key, zipcode.ToString() },
            });

        var uri = new Uri(url);

        {
            // ヘッダを付けて、画像(バイナリ)を送信する場合
            //var request = new HttpRequestMessage(HttpMethod.Post, uri);
            //request.Headers.Add("foo", "hoge");
            //var file = await KnownFolders.CameraRoll.GetFileAsync("test.jpg");
            //var buffer = await FileIO.ReadBufferAsync(file);
            //var byteContent = new HttpBufferContent(buffer);
            //byteContent.Headers.Add("Content-Type", "image/jpeg");

            //var data = new HttpMultipartFormDataContent();
            //data.Add(new HttpStringContent(zipcode.ToString()), key);
            //data.Add(byteContent, "file", "test.jpg");
            //request.Content = data;

            //var res = await httpClient.SendRequestAsync(request);
        }

        var response = await httpClient.PostAsync(uri, content);
        var text = await response.Content.ReadAsStringAsync();
        Debug.Log($"post success. {nameof(WindowsHttpClientSamples)}.{nameof(PostRequestAsync)}");
        Debug.Log(text);
#endif
    }
}
