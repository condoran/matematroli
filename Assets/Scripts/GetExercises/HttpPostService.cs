using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MatematroliiCreateConfig.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MatematroliiCreateConfig.Service
{    
    public class HttpPostService
    {
        static readonly HttpClient client = new HttpClient ();

        public static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        // public async Task CreateConfiguration(string confName)
        // {
        //     client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYwNDFkNmJjZmE5N2RmMDAxNTEyYTBlNiIsImlhdCI6MTYxNjI0MTAzMCwiZXhwIjoxNjE4ODMzMDMwfQ.LjpIjOqMCgGXVD_jILexxcQO-YBKtfuZwB-PM9-XvNY");
        //     try
        //     {
        //         var configuration = new Configuration
        //         {
        //             Name=confName,
        //             Feedback=true,
        //             Sem=true,
        //             Time=true,
        //             Title = confName
        //         };
        //         var content = new StringContent(JsonConvert.SerializeObject(configuration, Formatting.None, serializerSettings), Encoding.UTF8, "application/json");
        //         var response = await client.PostAsync("https://admin.matematrolii.com/configurations", content);
        //         response.EnsureSuccessStatusCode();
        //         var configurationResponse = JsonConvert.DeserializeObject<Configuration>(await response.Content.ReadAsStringAsync());
        //         // Above three lines can be replaced with new helper method below
        //         // string responseBody = await client.GetStringAsync(uri);
        //         /*for(var i=0;i<7;i++)
        //         {*/
        //             await CreateMission($"adendus_{confName}", configurationResponse.Id,"ADENDUS");
        //             await CreateMission($"diminus_{confName}", configurationResponse.Id,"DIMINUS");
        //             await CreateMission($"divisia_{confName}", configurationResponse.Id,"DIVISIA");
        //             await CreateMission($"fracta_{confName}", configurationResponse.Id,"FRACTA");
        //             await CreateMission($"hybridia_{confName}", configurationResponse.Id,"HYBRIDIA");
        //             await CreateMission($"multiplis_{confName}", configurationResponse.Id,"MULTIPLIS");
        //             await CreateMission($"questia_{confName}", configurationResponse.Id,"QUESTIA");
        //             await CreateMission($"multiplis_{confName}", configurationResponse.Id,"MULTIPLIS");
        //         //}
        //     }
        //     catch (HttpRequestException e)
        //     {
        //         Console.WriteLine("\nException Caught!");
        //         Console.WriteLine("Message :{0} ", e.Message);
        //     }
        // }

        public async Task<List<ExerciseViewRasponse>> GetExercise()
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYwNTc5OGI4NzkzZWNjMDAxNTI0M2VlMCIsImlhdCI6MTYxOTkwMzQ4MCwiZXhwIjoxNjIyNDk1NDgwfQ.BZVQcDV7KNImef83WLzsoCUsjrJifsAgkoPU4KBlBEA");

            //var content = new StringContent(JsonConvert.SerializeObject(exercise, Formatting.None, serializerSettings), Encoding.UTF8, "application/json");
            var response = await client.GetAsync($"https://admin.matematrolii.com/exercises?name=exercise1_pack1_zone1_adendus_conf-1");
            response.EnsureSuccessStatusCode();
           
            
            // Console.WriteLine(await response.Content.ReadAsStringAsync());
            var configurationResponse = JsonConvert.DeserializeObject<List<ExerciseViewRasponse>>(await response.Content.ReadAsStringAsync());
            var exercise_id = configurationResponse[0].Id;

            //exercise_id = "605906246a5ac80015c1e09e";

            return configurationResponse;
        }
    }
}
