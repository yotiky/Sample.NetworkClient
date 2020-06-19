using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UniRx;
using UnityEngine;

public class HttpWebRequestSamples : MonoBehaviour
{
    const string url = "https://zipcloud.ibsnet.co.jp/api/search";
    const string key = "zipcode";
    const int zipcode = 1500042;
    string query = $"?{key}={zipcode}";

    #region GET

    public async UniTaskVoid Get()
    {
        // Callback
        GetRequestCallback();

        // Observable
        GetRequestObservable1();

        // Observable
        GetRequestObservable2();

        // Async
        await GetRequestAsync();
    }
    private void GetRequestCallback()
    {
        try
        {
            var request = WebRequest.Create(url + query);

            {
                // ヘッダを付ける場合
                //request.Headers.Add("foo", "hoge");
            }

            request.BeginGetResponse(x =>
                {
                    var response = (HttpWebResponse)request.EndGetResponse(x);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        Debug.Log("get failure.");
                    }
                    else
                    {
                        Debug.Log($"get success. {nameof(HttpWebRequestSamples)}.{nameof(GetRequestCallback)}");
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var text = reader.ReadToEnd();
                            Debug.Log(text);
                        }
                    }
                },
                null);
        }
        catch (WebException e)
        {
            Debug.Log(e.Message);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void GetRequestObservable1()
    {
        Observable.Start(() =>
            {
                var request = WebRequest.Create(url + query);
                var response = request.GetResponse();
                Debug.Log($"get success. {nameof(HttpWebRequestSamples)}.{nameof(GetRequestObservable1)}");

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            })
            .Subscribe(x => Debug.Log(x))
            .AddTo(this);
    }
    private void GetRequestObservable2()
    {
        WebRequest.Create(url + query)
            .GetResponseAsObservable()
            .Select(res =>
            {
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            })
            .Subscribe(
                x =>
                {
                    Debug.Log($"get success. {nameof(HttpWebRequestSamples)}.{nameof(GetRequestObservable2)}");
                    Debug.Log(x);
                },
                error => Debug.Log(error.Message),
                () => Debug.Log("completed."))
            .AddTo(this);
    }
    private async UniTask GetRequestAsync()
    {
        var request = WebRequest.Create(url + query);
        var response = await request.GetResponseAsync();
        Debug.Log($"get success. {nameof(HttpWebRequestSamples)}.{nameof(GetRequestAsync)}");

        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var text = reader.ReadToEnd();
            Debug.Log(text);
        }
    }

    #endregion

    #region POST

    public async UniTaskVoid Post()
    {
        // Callback
        PostRequestCallback();

        // Observable
        PostRequestObservable();

        // Async
        await PostRequestAsync();
    }
    private void PostRequestCallback()
    {
        try
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";

            var param = $"{key}={zipcode}";
            var data = Encoding.ASCII.GetBytes(param);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            {
                // 画像(バイナリ)を送信する場合
                //var postData = new byte[0];
                //request.ContentType = "image/png";
                //request.ContentLength = postData.Length;
                //using(var stream = request.GetRequestStream())
                //{
                //    stream.Write(postData, 0, postData.Length);
                //}
            }
            {
                // ヘッダを付けて、画像(バイナリ)を送信する場合
                //request.Headers.Add("foo", "hoge");
                //request.Headers.Add("Content-Type", "application/octet-stream");
                //var postData = new byte[0];
                //request.ContentType = "image/png";
                //request.ContentLength = postData.Length;
                //using (var stream = request.GetRequestStream())
                //{
                //    stream.Write(postData, 0, postData.Length);
                //}
            }

            request.BeginGetResponse(x =>
            {
                var response = (HttpWebResponse)request.EndGetResponse(x);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Debug.Log("post failure.");
                }
                else
                {
                    Debug.Log($"post success. {nameof(HttpWebRequestSamples)}.{nameof(PostRequestCallback)}");
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var text = reader.ReadToEnd();
                        Debug.Log(text);
                    }
                }
            },
                null);
        }
        catch (WebException e)
        {
            Debug.Log(e.Message);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    private void PostRequestObservable()
    {
        Observable.Start(() =>
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";

                var param = $"{key}={zipcode}";
                var data = Encoding.ASCII.GetBytes(param);

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                Debug.Log($"post success. {nameof(HttpWebRequestSamples)}.{nameof(PostRequestObservable)}");
                var response = request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            })
            .Subscribe(x => Debug.Log(x))
            .AddTo(this);
    }
    private async UniTask PostRequestAsync()
    {
        var request = WebRequest.Create(url);
        request.Method = "POST";

        var param = $"{key}={zipcode}";
        var data = Encoding.ASCII.GetBytes(param);

        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        using (var stream = request.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }

        Debug.Log($"post success. {nameof(HttpWebRequestSamples)}.{nameof(PostRequestAsync)}");
        var response = await request.GetResponseAsync();
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var text = reader.ReadToEnd();
            Debug.Log(text);
        }
    }

    #endregion
}
