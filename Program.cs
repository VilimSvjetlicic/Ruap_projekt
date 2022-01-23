// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RUAP;
using Newtonsoft.Json;

namespace CallRequestResponseService
{

    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }

        static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"school", "sex", "age", "address", "famsize", "Pstatus", "Medu", "Fedu", "Mjob", "Fjob", "reason", "guardian", "traveltime", "studytime", "failures", "schoolsup", "famsup", "paid", "activities", "nursery", "higher", "internet", "romantic", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "absences", "G1", "G2", "G3"},
                                Values = new string[,] {  { "value", "value", "0", "value", "value", "value", "0", "0", "value", "value", "value", "value", "0", "0", "0", "value", "value", "value", "value", "value", "value", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" } }//,  { "value", "value", "0", "value", "value", "value", "0", "0", "value", "value", "value", "value", "0", "0", "0", "value", "value", "value", "value", "value", "value", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "IJkijT3IcdlmHWLYdtolAk1lkqNSsm1TTYkIV1AKEoihnHqc+aUEpCzs+YNMDTpzaA+Y56ifSrXUC045wxHFwg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/ee7764b2357144ca906ce00a8a3041ee/services/2986a113c3e44896a19995595fe5d0f2/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);


                if (response.IsSuccessStatusCode)
                {
                    
                    string result = await response.Content.ReadAsStringAsync();
                    
                    var value = JsonConvert.DeserializeObject<Root>(result);

                    Console.WriteLine(value.Results.output1.value.getLastValue());

                    


                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }
    }
}
