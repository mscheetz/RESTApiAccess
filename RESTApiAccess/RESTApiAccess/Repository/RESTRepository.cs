// -----------------------------------------------------------------------------
// <copyright file="RESTRepository" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/20/2019 3:58:01 PM" />
// -----------------------------------------------------------------------------

namespace RESTApiAccess
{
    #region Usings

    using Newtonsoft.Json;
    using RESTApiAccess.Interface;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    #endregion Usings

    public class RESTRepository : IRESTRepository
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public RESTRepository()
        {
        }

        /// <summary>
        /// Get call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> GetApi<T>(string url, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Get call to api stream 
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> GetApiStream<T>(string url, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                var responseMessage = String.Empty;
                try
                {
                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    var sb = new StringBuilder();

                    using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        using (var sr = new StreamReader(stream, Encoding.UTF8))
                        {
                            sb.Append(sr.ReadToEnd());
                        }

                        responseMessage = sb.ToString();
                    }

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Post call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> PostApi<T, U>(string url, U data, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> PostApi<T>(string url, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                try
                {
                    var response = await client.PostAsync(url, null).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Put call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> PutApi<T, U>(string url, U data, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PutAsync(url, content).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Put call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> PutApi<T>(string url, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                try
                {
                    var response = await client.PutAsync(url, null).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Delete call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public async Task<T> DeleteApi<T>(string url, Dictionary<string, object> headers = null, string username = null, string password = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    var secureBytes = ASCIIEncoding.ASCII.GetBytes($"{username}:{password}");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secureBytes));
                }

                try
                {
                    var response = await client.DeleteAsync(url).ConfigureAwait(false);

                    string responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!StatusCodeSuccess(response.StatusCode))
                    {
                        throw new Exception(responseMessage);
                    }

                    try
                    {
                        return JsonConvert.DeserializeObject<T>(responseMessage, settings);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Check if response was successfully returned
        /// </summary>
        /// <param name="code">Status code of response</param>
        /// <returns>Boolean value of validity of response</returns>
        private bool StatusCodeSuccess(HttpStatusCode code)
        {
            if(code == HttpStatusCode.OK
                || code == HttpStatusCode.Accepted
                || code == HttpStatusCode.Created
                || code == HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
