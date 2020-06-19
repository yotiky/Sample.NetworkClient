using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class NetworkClientSamples : MonoBehaviour
{
    public WWWSamples www;
    public WebRequestSamples webRequest;
    public HttpWebRequestSamples httpWebRequest;
    public SystemHttpClientSamples systemHttpClient;


    void Start()
    {
        //www.Get().Forget();
        //www.Post().Forget();

        //webRequest.Get().Forget();
        //webRequest.Post().Forget();

        //httpWebRequest.Get().Forget();
        //httpWebRequest.Post().Forget();

        systemHttpClient.Get().Forget();
        systemHttpClient.Post().Forget();
    }

}
