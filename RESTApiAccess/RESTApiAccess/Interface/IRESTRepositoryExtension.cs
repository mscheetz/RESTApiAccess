// -----------------------------------------------------------------------------
// <copyright file="IRESTRepositoryExtension" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/20/2019 3:58:01 PM" />
// -----------------------------------------------------------------------------

namespace RESTApiAccess.Interface
{
    #region Usings

    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion Usings

    public static class IRESTRepositoryExtension
    {
        /// <summary>
        /// Get call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApi<T>(this IRESTRepository service, string url)
        {
            return await service.GetApi<T>(url: url).ConfigureAwait(false);
        }

        /// <summary>
        /// Get call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApi<T>(this IRESTRepository service, string url, Dictionary<string, object> headers)
        {
            return await service.GetApi<T>(url: url, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Get call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApi<T>(this IRESTRepository service, string url, string username, string password)
        {
            return await service.GetApi<T>(url: url, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Get call to api stream 
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApiStream<T>(this IRESTRepository service, string url)
        {
            return await service.GetApiStream<T>(url: url).ConfigureAwait(false);
        }

        /// <summary>
        /// Get call to api stream 
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApiStream<T>(this IRESTRepository service, string url, Dictionary<string, object> headers)
        {
            return await service.GetApiStream<T>(url: url, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Get call to api stream 
        /// For large json responses
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> GetApiStream<T>(this IRESTRepository service, string url, string username, string password)
        {
            return await service.GetApiStream<T>(url: url, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T, U>(this IRESTRepository service, string url, U data)
        {
            return await service.PostApi<T, U>(url: url, data: data).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T, U>(this IRESTRepository service, string url, U data, Dictionary<string, object> headers)
        {
            return await service.PostApi<T, U>(url: url, data: data, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T, U>(this IRESTRepository service, string url, U data, string username, string password)
        {
            return await service.PostApi<T, U>(url: url, data: data, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T>(this IRESTRepository service, string url)
        {
            return await service.PostApi<T>(url: url).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T>(this IRESTRepository service, string url, Dictionary<string, object> headers)
        {
            return await service.PostApi<T>(url: url, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Post call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PostApi<T>(this IRESTRepository service, string url, string username, string password)
        {
            return await service.PostApi<T>(url: url, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T, U>(this IRESTRepository service, string url, U data)
        {
            return await service.PutApi<T, U>(url: url, data: data).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T, U>(this IRESTRepository service, string url, U data, Dictionary<string, object> headers)
        {
            return await service.PutApi<T, U>(url: url, data: data, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api with data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <typeparam name="U">Type to post</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="data">Data object being sent</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T, U>(this IRESTRepository service, string url, U data, string username, string password)
        {
            return await service.PutApi<T, U>(url: url, data: data, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T>(this IRESTRepository service, string url)
        {
            return await service.PutApi<T>(url: url).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T>(this IRESTRepository service, string url, Dictionary<string, object> headers)
        {
            return await service.PutApi<T>(url: url, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Put call to api without data
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> PutApi<T>(this IRESTRepository service, string url, string username, string password)
        {
            return await service.PutApi<T>(url: url, username: username, password: password).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <returns>Type requested</returns>
        public static async Task<T> DeleteApi<T>(this IRESTRepository service, string url)
        {
            return await service.DeleteApi<T>(url: url).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="headers">Http Request headers</param>
        /// <returns>Type requested</returns>
        public static async Task<T> DeleteApi<T>(this IRESTRepository service, string url, Dictionary<string, object> headers)
        {
            return await service.DeleteApi<T>(url: url, headers: headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete call to api
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="url">Url to access</param>
        /// <param name="username">Username for basic auth</param>
        /// <param name="password">Password for basic auth</param>
        /// <returns>Type requested</returns>
        public static async Task<T> DeleteApi<T>(this IRESTRepository service, string url, string username, string password)
        {
            return await service.DeleteApi<T>(url: url, username: username, password: password).ConfigureAwait(false);
        }
    }
}