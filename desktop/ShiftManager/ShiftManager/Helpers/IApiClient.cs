using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DatabaseLayer.Database.Models;

namespace ShiftManager.Helpers;

public interface IAPIManager
{
    public static HttpClient GetHttpClient()
    {

        var client = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = ((message, certificate2, arg3, arg4) => true)
        });

        client.BaseAddress = new Uri("https://localhost:7298/api/v1/");
        return client;
    }
    
}